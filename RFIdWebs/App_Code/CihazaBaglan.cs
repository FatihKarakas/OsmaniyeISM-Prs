using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
/// <summary>
/// CihazaBaglan için özet açıklama
/// </summary>
public class CihazaBaglan
{
    public CihazaBaglan()
    {
        //
        //TODO: Buraya oluşturucu mantığı ekleyin
        //
    }
    public string IpAdres { get; set; }
    public int Port { get; set; }
    ICollection<PersonelBilgi> personels = new List<PersonelBilgi>();
    ZkSoftwareEU.CZKEUEMNetClass cZKEUEM = new ZkSoftwareEU.CZKEUEMNetClass();
    public bool CihazaBaglanti()
    {
        var Sonuc = cZKEUEM.Connect_Net(this.IpAdres, this.Port);
        if (Sonuc)
        {
            return true;
        }
        return false;
    }
    
}
