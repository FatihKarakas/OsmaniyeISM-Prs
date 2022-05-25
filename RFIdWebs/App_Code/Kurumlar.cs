using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;
/// <summary>
/// Kurumlar için özet açıklama
/// </summary>
///
[Table(name:"Kurumlar")]
public class Kurumlar 
 
{
    [Key, Display(Name = "Kurum ID")]
    public int ID { get; set; }
    public Kurumlar()
    {
        //
        //TODO: Buraya oluşturucu mantığı ekleyin
        //
    }
}