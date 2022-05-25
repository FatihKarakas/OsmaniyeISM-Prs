using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
public partial class PersonelDetay : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var kim = string.IsNullOrEmpty(Request.QueryString["kullanici"]) ? "" : Request.QueryString["kullanici"].ToString();
        if (kim == "")
        {
            HataMsj.Visible = true;
            msj.InnerText = "Bu sayfaya doğrudan erişmezsiniz";
            return;
        }
        else
        {
            HataMsj.Visible = false;
            DataContext dc = new DataContext();
            var Veri = dc.Personeller.Where(x => x.kartno == kim).Count();
            if (Veri == 0)
            {
                HataMsj.Visible = true;
                msj.InnerText = "Böyle bir kullanıcı bulunamadı";
                return;
            }
            else
            {
                var Veriler = dc.Personeller.Where(x => x.kartno == kim).FirstOrDefault();
            }
        }
        return;
    }
}