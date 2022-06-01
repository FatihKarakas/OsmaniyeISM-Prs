using NLog;
using System;
using System.Collections.Generic;
using System.Net;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
public partial class SiteMaster : MasterPage
{
    public string sayfa;
    private const string AntiXsrfTokenKey = "__AntiXsrfToken";
    private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
    private string _antiXsrfTokenValue;
    private static Logger _logger = LogManager.GetLogger("personelLogs");
    GenelAyarlar ga = new GenelAyarlar();
    protected void Page_Init(object sender, EventArgs e)
    {
        // Aşağıdaki kod XSRF saldırılarına karşı korunmanıza yardımcı olur
        var requestCookie = Request.Cookies[AntiXsrfTokenKey];
        Guid requestCookieGuidValue;
        if (requestCookie != null && Guid.TryParse(requestCookie.Value, out requestCookieGuidValue))
        {
            // Tanımlama bilgisindeki Anti-XSRF belirtecini kullan
            _antiXsrfTokenValue = requestCookie.Value;
            Page.ViewStateUserKey = _antiXsrfTokenValue;
        }
        else
        {
            // Yeni bir Anti-XSRF belirteci oluştur ve tanımlama bilgisine kaydet
            _antiXsrfTokenValue = Guid.NewGuid().ToString("N");
            Page.ViewStateUserKey = _antiXsrfTokenValue;
            var responseCookie = new HttpCookie(AntiXsrfTokenKey)
            {
                HttpOnly = true,
                Value = _antiXsrfTokenValue
            };
            if (FormsAuthentication.RequireSSL && Request.IsSecureConnection)
            {
                responseCookie.Secure = true;
            }
            Response.Cookies.Set(responseCookie);
        }
        Page.PreLoad += master_Page_PreLoad;
    }
    protected void master_Page_PreLoad(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Anti-XSRF belirteci ayarla
            ViewState[AntiXsrfTokenKey] = Page.ViewStateUserKey;
            ViewState[AntiXsrfUserNameKey] = Context.User.Identity.Name ?? String.Empty;
        }
        else
        {
            // Anti-XSRF belirtecini doğrula
            if ((string)ViewState[AntiXsrfTokenKey] != _antiXsrfTokenValue
                || (string)ViewState[AntiXsrfUserNameKey] != (Context.User.Identity.Name ?? String.Empty))
            {
                throw new InvalidOperationException("Anti-XSRF belirteci doğrulanamadı.");
            }
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {

        string Mesaj = ga.IPogren() + " İp adresinden " + sayfa_oku() + " sayfası görüntülenmiştir.";
        _logger.Info(Mesaj);
        if (!IsPostBack)
        {
            if (Session["Yonetim"] != null)
            {
                string Mesaj1= ga.IPogren() + " İp adresinden kullanıcı girişi olmadan erişim engellendi.";
                _logger.Error(Mesaj1);
                if (Session["giris"].ToString() != "ok")
                {
                    Response.Redirect("GirisYap");

                    return;
                }
            }
            else
            {
                Response.Redirect("girisYap");
            }
            sayfa_oku();
        }

    }
    protected void Unnamed_LoggingOut(object sender, LoginCancelEventArgs e)
    {
        Context.GetOwinContext().Authentication.SignOut();
    }

    public string sayfa_oku()
    {
        sayfa = Page.ToString().Replace("_aspx", ".aspx").Remove(0, 4);
        string[] sayfa1 = sayfa.Split('.');
        sayfa = sayfa1[0].ToString();
        return sayfa;
    }

}