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

        if (!IsPostBack)
        {
            PersonelGetir();
        }
       
    }

    protected void PerList_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
       if( e.CommandName== "Degistir")
        {
            LinkButton l = e.Item.FindControl("IsActiveBtn") as LinkButton;
            try
            {
                var kartno = l.CommandArgument;
                var p = context.personel.Where(s => s.kartno == kartno).FirstOrDefault();
                p.durum = p.durum == "Aktif" ? "Pasif" : "Aktif";
                context.Entry(p).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();

            }
            catch (Exception ex)
            {
                HataMsj.Visible = true;
                msj.InnerText = $"Personel durum bilgisini değiştirirken hata oluştu :{ex.Message.ToString()} ";
                return;
            }
            PersonelGetir();
        }
    }

    private void PersonelGetir()
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
                Aktifmi = context.personel.Where(s => s.kartno == ps.kartno).Select(s => s.durum).FirstOrDefault(),
                Parola = "*******",
                PersonelAdi = ps.ad + ' ' + ps.soyad,
                Baskanlik = context.Servis.Where(s => s.id == se).Select(s => s.baskanlik).FirstOrDefault(),
                sicilno = context.personel.Where(s => s.kartno == ps.kartno).Select(s => s.sicilno).FirstOrDefault()
                
            };

            personels.Add(pes);
        }
      
        PerList.DataSource = personels;
        PerList.DataBind();
    }
}