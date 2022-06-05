using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

/// <summary>
/// HashGoster için özet açıklama
/// </summary>
public class HashGoster
{
    public string Pass { get; set; }
    public  HashGoster()
    {
        Sonuc();
    }

    public string Sonuc()
    {
        byte[] encodedPassword = new UTF8Encoding().GetBytes(Pass);
        byte[] hash = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(encodedPassword);
        string encoded = BitConverter.ToString(hash)
               .Replace("-", string.Empty)
               .ToLower();
        return encoded;
    }

}