using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
public partial class GirisYap : System.Web.UI.Page
{
    private static Logger _logger = LogManager.GetLogger("personelLogs");
    DataContext dc = new DataContext();
    GenelAyarlar ga = new GenelAyarlar();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["Yonetim"] != null)
            {
                if (Session["giris"].ToString() == "ok")
                { Response.Redirect("default.aspx"); }
            }
        }
    }
    protected void giris_Click(object sender, EventArgs e)
    {
        try
        {
            string UserNames = UserName.Text.Trim();
            string pass = Parola.Text;
            byte[] encodedPassword = new UTF8Encoding().GetBytes(pass);
            byte[] hash = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(encodedPassword);
            string encoded = BitConverter.ToString(hash)
                   .Replace("-", string.Empty)
                   .ToLower();
            var say = dc.Users.Where(y => y.Pass == encoded && y.UserName == UserNames).FirstOrDefault();
            if (say !=null)
            {
                if (say.IsActive!= 1)
                {
                    HataMsj.Visible = true;
                    msj.InnerText = "Kullanıcı Hesabı pasif edilmiş durumda";
                    _logger.Error($"{ga.IPogren()} adresin pasif kullanıcı girişi engellendi. {UserNames} ");
                    return;
                }
                Session["Yonetim"] = say.UserName;
                Session["giris"] = "ok";
                string mesaj = $"{ga.IPogren()} adresinden { UserNames } kullanıcısı başarı ile giriş yapılmıştır";
                _logger.Warn(mesaj);
                Response.Redirect("default");
            }
            else
            {
                HataMsj.Visible = true;
                msj.InnerText = "Kullanıcı adı veya parola hatalı";
                var mesaj = ga.IPogren() + " adresindne kullanıcı girişi yaparken hata oluştu, Kullanıcı adı veya parola hatalı \n ";
                mesaj += $"Kullanıcı adı { UserName.Text } ve parola { encoded}";
                _logger.Error(mesaj);
                return;
            }
        }
        catch (Exception ex)
        {
            HataMsj.Visible = true;
            msj.InnerText = "Hata oluştu, hata kodu :" + ex.Message.ToString();
            var mesaj = ga.IPogren() + " adresindne kullanıcı girişi yaparken hata oluştu, hata " + ex.Message.ToString();
            mesaj += $"Kullanıcı adı { UserName.Text } ve parola {Parola.Text}";
            _logger.Error(mesaj);
        }
        


    }
}