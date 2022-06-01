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
    DataContext dc = new DataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void giris_Click(object sender, EventArgs e)
    {
        string pass = Parola.Text;
        byte[] encodedPassword = new UTF8Encoding().GetBytes(pass);

        // need MD5 to calculate the hash
        byte[] hash = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(encodedPassword);
        string encoded = BitConverter.ToString(hash)
   // without dashes
   .Replace("-", string.Empty)
   // make lowercase
   .ToLower();
        var count = dc.Users.Where(x => x.Pass == encoded).Count();



    }
}