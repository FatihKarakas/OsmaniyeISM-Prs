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
    protected void Page_Load(object sender, EventArgs e)
    {
        
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
        if (Ad.Text =="" ||Soyad.Text =="" || KartNumber.Text == "" ||  KartId.Text == "" || SicilNo.Text == "")
        {
            HataMsj.Visible = true;
            msj.InnerText = "Lütfen Personel bilgilerini doldurunuz";
            return;
        }
        try
        {
            personel ps = new personel()
            {
                ad = Ad.Text,
                soyad = Soyad.Text,
                birimid = Convert.ToInt32(BaskanlikDrop.SelectedValue),
                sicilno = SicilNo.Text,
                kartno = KartNumber.Text,
                kartid = KartId.Text,
                isegiristarihi = Convert.ToDateTime(BasTarih)
            };
            dc.personel.Add(ps);
            dc.SaveChanges();
        }
        catch (Exception ex)
        {
            HataMsj.Visible = true;
            msj.InnerText = "Hata oluştu " + ex.Message.ToString();
            return;
        }
        string sName = "";
        string sPassword = "";
        int iPrivilege = 0;
        string sFPTmpData = "";
        string sCardnumber = "";
        int idwFingerIndex = 0;
        string sdwFingerIndex = "";
        int iFlag = 0;
        string sFlag = "";
        int num = 0;
        ListBox hatalar = new ListBox();
         string terminal = "10.80.15.220";
         var baglan = g.sta_ConnectTCP(hatalar, terminal, "4370", "1");
        g.axCZKEM1.EnableDevice(1, false);
        g.axCZKEM1.SetStrCardNumber(KartNumber.Text);
        if (g.axCZKEM1.SSR_SetUserInfo(1, sEnrollNumber, sName, sPassword, iPrivilege, bEnabled))//upload user information to the device
        {
        
            
                idwFingerIndex = 0
                iFlag = 0;
                axCZKEM1.SetUserTmpExStr(iMachineNumber, sEnrollNumber, idwFingerIndex, iFlag, sFPTmpData);//upload templates information to the device
            }
            num++;
            prgSta.Value = num % 100;
        }

    }
}