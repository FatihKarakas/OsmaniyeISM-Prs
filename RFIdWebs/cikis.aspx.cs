using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class cikis : System.Web.UI.Page
{
    GenelAyarlar ga = new GenelAyarlar();
    private static Logger _logger = LogManager.GetLogger("personelLogs");
    protected void Page_Load(object sender, EventArgs e)
    {

        string mesaj = ga.IPogren() + " adresinden çıkış yapılmıştır";
        _logger.Warn(mesaj);
        Session.Abandon();
        Response.Redirect("girisyap");
    }
}