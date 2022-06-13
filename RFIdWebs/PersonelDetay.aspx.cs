using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
public partial class PersonelDetay : System.Web.UI.Page
{
    public GenelAyarlar g = new GenelAyarlar();
    private static Logger _logger = LogManager.GetLogger("personelLogs");
    DataContext dc = new DataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            var kim = string.IsNullOrEmpty(Request.QueryString["kullanici"]) ? "" : Request.QueryString["kullanici"].ToString();
            if (kim == "")
            {
                HataMsj.Visible = true;
                msj.InnerText = "Bu sayfaya doğrudan erişmezsiniz";
                _logger.Error($"{g.IPogren()} adreinden kullancı deteyı hatası {msj.InnerText}");
                personelislem.Visible = false;
                return;
            }
            else
            {
                HataMsj.Visible = false;

                var Veri = dc.Personeller.Where(x => x.kartno == kim).Count();
                if (Veri == 0)
                {
                    HataMsj.Visible = true;
                    msj.InnerText = "Böyle bir kullanıcı bulunamadı";
                    return;
                }
                else
                {
                    personelislem.Visible = true;
                    var Veriler = dc.personel.Where(x => x.kartno == kim).FirstOrDefault();
                    KartNumber.Text = Veriler.kartno;
                    KartNumber.Enabled = false;
                    KartId.Text = Veriler.kartid;
                    Ad.Text = Veriler.ad;
                    Soyad.Text = Veriler.soyad;
                    SicilNo.Text = Veriler.sicilno;
                    KanGrup.SelectedValue = Veriler.kangrubu == "" ? "Seçiniz" : Veriler.kangrubu;
                    BaskanlikDrop.SelectedIndex = dc.Servis.Where(s => s.id == Veriler.servisid).Select(s => s.id).FirstOrDefault() - 1;
                    BasTarih.Text = string.Format(Veriler.isegiristarihi.ToString(),"{0:dd MMMM yyyy}");
                    KontroleTabi.Checked = Veriler.Kontroletabi == 1 ? true: false;
                    Engellilik.Checked = Veriler.Disability == 1 ? true : false;
                }
            }

        }

    }

    protected void PersEkleBtn_Click(object sender, EventArgs e)
    {
        try
        {
            var Pers = dc.personel.Where(x => x.kartno == KartNumber.Text).FirstOrDefault();
            Pers.kartid = KartId.Text;
            Pers.ad = Ad.Text;
            Pers.soyad = Soyad.Text;
            Pers.sicilno = SicilNo.Text;
            if (Engellilik.Checked) Pers.Disability = 1; else Pers.Disability=0;
            if (!KontroleTabi.Checked) Pers.Kontroletabi = 0; else Pers.Kontroletabi=1 ;
            //Pers.isegiristarihi = Convert.ToDateTime(BasTarih.Text);
            Pers.servisid = Convert.ToInt32(BaskanlikDrop.SelectedValue);
            Pers.kangrubu = KanGrup.SelectedItem.Text;
            dc.Entry(Pers).State = System.Data.Entity.EntityState.Modified;
            dc.SaveChanges();
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
                var sonuc = g.axCZKEM1.SSR_SetUserInfo(Mid, KartNumber.Text, isim, "", 0, true);
                if (sonuc)
                {
                    string Mesaj = $"{g.IPogren()} adresinden {isim} isimli Personel günceleme işelemi {terminal[i]}  ip adresli terminale yapıldı ";
                    _logger.Warn(Mesaj);
                }
                g.axCZKEM1.RefreshData(Mid);//Yenile
                g.axCZKEM1.EnableDevice(Mid, true);
                g.bIsConnected = false;
                g.sta_DisConnect();
            }
        }
        catch (Exception ex)
        {
            HataMsj.Visible = true;
            msj.InnerText = "Hata oluştu :" + ex.Message.ToString();
            _logger.Error($"{g.IPogren()} adreinden kullancı deteyı hatası {msj.InnerText}");
            return;
        }
        HataMsj.Visible = true;
        HataMsj.Attributes.Add("class", "alert alert-success");
        msj.InnerText = $"{Ad.Text} {Soyad.Text} personeli başarı ile güncellenmiştir.";
        _logger.Error($"{g.IPogren()} adresinden  {msj.InnerText}");


    }
}