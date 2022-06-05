using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PersonelEkle : System.Web.UI.Page
{
    public DataContext dc = new DataContext();
    public GenelAyarlar g = new GenelAyarlar();
    private static Logger _logger = LogManager.GetLogger("personelLogs");
    protected void Page_Load(object sender, EventArgs e)
    {
        KartNo.Focus();

        if (!IsPostBack)
        {
            KartNo.Focus();
        }

    }

    protected void Kontrol_Et(object sender, EventArgs e)
    {
        Ad.Text = "";
        Soyad.Text = "";
        KartNumber.Text = "";
        KartId.Text = "";
        SicilNo.Text = "";
        KanGrup.SelectedIndex = 0;
        BasTarih.Text = "";

        if (KartNo.Text != null || KartNo.Text.Count() > 5)
        {
            try
            {
                var Pers = dc.personel.Where(x => x.kartid == KartNo.Text).FirstOrDefault();
                if (Pers == null)
                {

                    KartId.Text = KartNo.Text;
                    KartId.Enabled = false;
                    int cardno = Convert.ToInt32(dc.personel.Max(x => x.kartno));
                    cardno++;
                    var cardno1 = cardno.ToString();
                    if (cardno1.Length < 5)
                    {
                        switch (cardno1.Length)
                        {
                            case 4:
                                cardno1 = "0" + cardno1.ToString();
                                break;
                            case 3:
                                cardno1 = "00" + cardno1.ToString();
                                break;
                            case 2:
                                cardno1 = "000" + cardno1.ToString();
                                break;
                            default:
                                break;


                        }
                    }
                    KartNumber.Text = cardno1.ToString();
                    KartNumber.Enabled = false;
                }
                else
                {
                    Ad.Text = Pers.ad;
                    Soyad.Text = Pers.soyad;
                    KartNumber.Text = Pers.kartno;
                    KartId.Text = Pers.kartid;
                    SicilNo.Text = Pers.sicilno;
                    if (Pers.kangrubu != null)
                    {
                        KanGrup.SelectedItem.Text = Pers.kangrubu;
                    }
                    if (Pers.servisid != null)
                    {
                        BaskanlikDrop.SelectedValue = Pers.servisid.ToString();
                    }
                    BasTarih.Text = string.Format("{0:yyyy/MM/dd}", Pers.isegiristarihi);
                    KartNumber.Enabled = false;
                    KartId.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                HataMsj.Visible = true;
                msj.InnerText = "Hata oluştu, hata kodu: " + ex.Message.ToString();
                return;
            }
        }
        else
        {
            HataMsj.Visible = true;
            msj.InnerText = "Lütfen kart formatı doğru formatta giriniz";
            return;
        }
        FormGorunum.Visible = true;
        KartNo.Text = "";
        KartNo.Focus();
    }

    protected void PersEkleBtn_Click(object sender, EventArgs e)
    {
        var KartIDD = KartId.Text;
        if (Ad.Text == "" || Soyad.Text == "" || KartNumber.Text == "" || KartId.Text == "" || SicilNo.Text == "")
        {
            HataMsj.Visible = true;
            msj.InnerText = "Lütfen Personel bilgilerini doldurunuz";
            return;
        }
        var Pers = dc.personel.Where(x => x.kartid == KartIDD).FirstOrDefault();
        if (Pers != null)
        {
            try
            {
                Pers.ad = Ad.Text;
                Pers.soyad = Soyad.Text;
                Pers.sicilno = SicilNo.Text;
                Pers.isegiristarihi = Convert.ToDateTime(BasTarih.Text);
                Pers.servisid = Convert.ToInt32(BaskanlikDrop.SelectedValue);
                Pers.kangrubu = KanGrup.SelectedItem.Text;
                dc.Entry(Pers).State = System.Data.Entity.EntityState.Modified;
                dc.SaveChanges();
            }
            catch (Exception ex)
            {

                HataMsj.Visible = true;
                msj.InnerText = "Hata oluştu " + ex.Message.ToString();
                return;
            }
            try
            {
                ListBox hatalar = new ListBox();

                string[] terminal = { "10.80.15.220", "10.80.15.221", "10.80.15.222" };
                for (int i = 0; i < terminal.Length; i++)
                {
                    int Mid = i + 1;
                    var TerminalIp = terminal[i];
                    var baglan = g.sta_ConnectTCP(hatalar,TerminalIp, "4370", Mid.ToString());
                    g.axCZKEM1.EnableDevice(Mid, false);
                    g.axCZKEM1.SetStrCardNumber(KartId.Text);
                    var isim = Ad.Text.Trim() + " " + Soyad.Text.Trim();
                    var sonuc = g.axCZKEM1.SSR_SetUserInfo(1, KartNumber.Text, isim, "", 0, true);
                    if (sonuc)
                    {
                        string Mesaj = $"{g.IPogren()} adresinden {isim} isimli Personel Ekleme {terminal[i]}  ip adresli terminale işlemi yapıldı ";
                        _logger.Warn(Mesaj);
                    }
                     g.axCZKEM1.RefreshData(Mid);//Yenile
                    g.axCZKEM1.EnableDevice(Mid, true);
                    g.sta_DisConnect();
                }
                //int idwErrorCode = 0;
                //g.axCZKEM1.EnableDevice(1, false);
                //string Yenikart = Convert.ToInt32(KartId.Text).ToString();
                //g.axCZKEM1.SetStrCardNumber(Yenikart);//Kart Numrasını buluyoruz
                //string KartNoYeni = KartNumber.Text.ToString();
                //string isim = Ad.Text.Trim();
                //string Pass = null;
                //if (!g.axCZKEM1.SSR_SetUserInfo(1, KartNoYeni, isim, Pass, 0, true))
                //{

                //    g.axCZKEM1.GetLastError(ref idwErrorCode);
                //    HataMsj.Visible = true;
                //    msj.InnerText="Terminal cihaza gönderim hatası oldu =" + idwErrorCode.ToString();
                //    g.axCZKEM1.EnableDevice(1, true);
                //    return;
                //}
                //Verileri Günceller


            }
            catch (Exception ex)
            {
                HataMsj.Visible = true;
                msj.InnerText = "Hata oluştu " + ex.Message.ToString();
                string Mesaj = g.IPogren() + " Personel Ekleme  işlemini yaparken hata oluştu " + ex.Message.ToString();
                _logger.Error(Mesaj);

                return;
            }
           


        }
        else
        {
            try
            {
                personel ps = new personel();

                ps.ad = Ad.Text;
                ps.soyad = Soyad.Text;
                ps.birimid = Convert.ToInt32(BaskanlikDrop.SelectedValue);
                ps.sicilno = SicilNo.Text;
                ps.kartno = KartNumber.Text;
                ps.kartid = KartId.Text;
                ps.isegiristarihi = Convert.ToDateTime(BasTarih.Text);
                ps.durum = "Aktif";
                ps.ceptel = "";
                ps.personelturu = "Personel";
                ps.resim = null;
                ps.email = "";
                ps.cinsiyet = "";
                ps.kartfc = "0";
                ps.grupid = 14;


                dc.personel.Add(ps);
                _logger.Info<personel>(ps);
                dc.SaveChanges();
            }
            catch (Exception ex)
            {
                HataMsj.Visible = true;
                msj.InnerText = "Hata oluştu " + ex.Message.ToString();
                return;
            }
            try
            {
                ListBox hatalar = new ListBox();
                string[] terminal = { "10.80.15.220", "10.80.15.221", "10.80.15.222" };
                for (int i = 0; i < terminal.Length; i++)
                {
                    int Mid = i + 1;
                    var TerminalIp = terminal[i];
                    var baglan = g.sta_ConnectTCP(hatalar, TerminalIp, "4370", Mid.ToString());
                    g.axCZKEM1.EnableDevice(Mid, false);
                    g.axCZKEM1.SetStrCardNumber(KartId.Text);
                    var isim = Ad.Text.Trim() + " " + Soyad.Text.Trim();
                    var sonuc = g.axCZKEM1.SSR_SetUserInfo(1, KartNumber.Text, isim, "", 0, true);
                    if (sonuc)
                    {
                        string Mesaj = $"{g.IPogren()} adresinden {isim} isimli Personel için {terminal[i]}  ip adresli terminale güncelleme yapıldı ";
                        _logger.Warn(Mesaj);
                    }
                    g.axCZKEM1.RefreshData(Mid);//Yenile
                    g.axCZKEM1.EnableDevice(Mid, true);
                    g.sta_DisConnect();
                }


            }
            catch (Exception ex)
            {
                HataMsj.Visible = true;
                msj.InnerText = "Hata oluştu " + ex.Message.ToString();
                string Mesaj = g.IPogren() + " Personel Ekleme  işlemini yaparken hata oluştu " + ex.Message.ToString();
                _logger.Error(Mesaj);
                return;
            }
          

        }
        HataMsj.Visible = true;
        msj.InnerText = Ad.Text + " " + Soyad.Text + " için Personel bilgileri başarı ile güncellendi veya kayıt edildi";
        HataMsj.Attributes.Add("class", "alert alert-success");
        Ad.Text = "";
        Soyad.Text = "";
        KartNumber.Text = "";
        KartId.Text = "";
        SicilNo.Text = "";
        KanGrup.SelectedIndex = 0;
        BasTarih.Text = "";
        KartNo.Focus();
        string Mesaj1 = g.IPogren() + " Personel Eklme  işlemini başarı ile tamamladı ";
        _logger.Info(Mesaj1);
    }
}