using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
/// <summary>
/// LogKayit için özet açıklama
/// </summary>
public class LogKayit
{
    public int CihazID { get; set; }
    public string KullaniciId { get; set; }
    public int MyProperty { get; set; }
    public int IslemTipi { get; set; }
    public string Tarih { get; set; }
    public string GirisSaat { get; set; }
    public string CikisSaat { get; set; }
    public LogKayit()
    {
        //
        //TODO: Buraya oluşturucu mantığı ekleyin
        //
    }
}