using NLog;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using zkemkeeper;
public partial class _Default : Page
{
    public string sdwEnrollNumber;
    public int idwInOutMode;
    public int idwYear;
    public int idwMonth;
    public int idwHour;
    public int idwMinute;
    public int idwDay;
    public int idwVerifyMode;
    public DataTable Dt;
    public int idwSecond;
    public int iFlag;
    public string sTmpData;
    public int iTmpLength;
    public string sName;
    public string sPassword;
    public int iPrivilege;
    public bool bEnabled;
    public ZkemClient objZkeeper;
    DataContext context = new DataContext();
    private static Logger _logger = LogManager.GetLogger("personelLogs");
    protected void Page_Load(object sender, EventArgs e)
    {
 
         var p = context.Personeller.ToList();
        ICollection<PersonelBilgi> personels = new List<PersonelBilgi>();
        var pi = context.personel.Where(pe => pe.durum == "Aktif").FirstOrDefault();
        
        foreach (Personeller ps in p)
        {
            int se = Convert.ToInt32(ps.servisid);
            PersonelBilgi pes = new PersonelBilgi()
            {
                KullaniciNo = ps.kartno,
                Aktifmi = true,
                Parola = "*******",
                PersonelAdi = ps.ad + ' ' + ps.soyad,
                Baskanlik = context.Servis.Where(s => s.id == se).Select(s => s.baskanlik).FirstOrDefault(),
                sicilno = context.personel.Where(s => s.kartno == ps.kartno).Select(s => s.sicilno).FirstOrDefault()
            };
           
            personels.Add(pes);
        }
        //ZkSoftwareEU.CZKEUEMNetClass axCZKEM1 = new ZkSoftwareEU.CZKEUEMNetClass();
        //axCZKEM1.Connect_Net("10.80.15.220", 4370);
        //while (axCZKEM1.SSR_GetAllUserInfo(1, ref sdwEnrollNumber, ref sName, ref sPassword, ref iPrivilege, ref bEnabled))
        //{
        //    PersonelBilgi personelBilgi = new PersonelBilgi();
        //    personelBilgi.KullaniciNo = sdwEnrollNumber;
        //    personelBilgi.PersonelAdi = sName;
        //    personelBilgi.Parola = sPassword;
        //    personelBilgi.Aktifmi = bEnabled;
        //    personels.Add(personelBilgi);
        //}
        //axCZKEM1.Disconnect();
        PerList.DataSource = personels;
        PerList.DataBind();
        _logger.Info("Ana Sayfa Görüntülendi");
    }
}