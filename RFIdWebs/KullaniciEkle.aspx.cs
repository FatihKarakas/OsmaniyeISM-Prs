using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class KullaniciEkle : System.Web.UI.Page
{
    GenelAyarlar ga = new GenelAyarlar();
    private static Logger _logger = LogManager.GetLogger("personelLogs");
    DataContext dc = new DataContext();

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void UserCreateBtn_Click(object sender, EventArgs e)
    {
        HataMsj.Visible = false;
        var UserNames = UserN.Text;
        var Parola = Passi.Text;
        byte[] encodedPassword = new UTF8Encoding().GetBytes(Parola);
        byte[] hash = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(encodedPassword);
        string encoded = BitConverter.ToString(hash)
               .Replace("-", string.Empty)
               .ToLower();
        if (UserN.Text == "" || UserN.Text.Length < 5)
        {
            HataMsj.Visible = true;
            msj.InnerText = "Kullanıcı Adı boş veya 5 karakterden küçük olamaz";
            return;
        }
        if (Passi.Text == "" || Passi.Text.Length < 8)
        {
            HataMsj.Visible = true;
            msj.InnerText = "Parolanız en az 8 karakterden küçük olamaz";
            return;
        }
        if (Passi.Text != Passit.Text)
        {
            HataMsj.Visible = true;
            msj.InnerText = "Parola ile Parola Tekrar aynı olmalıdır";
            return;
        }
       if(dc.Users.Where(x=> x.UserName==UserNames).Count() > 0)
        {
            HataMsj.Visible = true;
            msj.InnerText = "Bu Kullanıcı adı daha önce kullanılmış";
            return;
        }
        try
            
        {
            int sayi = dc.Users.Select(x => x.id).Max() + 1;
                        
            Users u = new Users
            {
                id = sayi,
                UserName = UserNames,
                Pass = encoded,
                IsActive = 1
            };
            dc.Users.Add(u);
            dc.SaveChanges();
            string mesaj = ga.IPogren() + " adresinden " + UserNames + " için kullancı oluşturuldu";
            _logger.Warn(mesaj);
        }
        catch (Exception ex)
        {
            HataMsj.Visible = true;
            msj.InnerText = "Hata oluştu " + ex.Message.ToString();
            return;
        }
        
    }
}