using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
/// <summary>
/// GirisCikis için özet açıklama
/// </summary>
public class GirisCikis
{
        public int id { get; set; }
        public int personel { get; set; }
        public string KartNo { get; set; }
        public string AdıSoyadi { get; set; }
        public DateTime giristarihi { get; set; }
        public TimeSpan? girissaati { get; set; }
        public TimeSpan? cikissaati { get; set; }
        public string toplamsure { get; set; }
        public string islemturu { get; set; }
    public GirisCikis()
    {
    }
   
}