using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
public partial class PersonelGiris : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataContext dc = new DataContext();
        GenelAyarlar g = new GenelAyarlar();
        HataMsj.Visible = false;
        msj.InnerText = "";
        //var baglan = g.sta_ConnectTCP(hatalar, "10.80.15.220", "4370", "1");
        try
        {
            ICollection<GirisCikis> tts = new List<GirisCikis>();
            DateTime kt = new DateTime(2022, 01, 01);
            var p = dc.pts_giriscikis.Where(y => y.giristarihi > kt).ToList();
            foreach (pts_giriscikis c in p)
            {
                GirisCikis gr = new GirisCikis()
                {
                    AdıSoyadi = dc.personel.Where(pi => pi.id == c.personel).Select(pi => pi.ad).FirstOrDefault() + " " + dc.personel.Where(pi => pi.id == c.personel).Select(pi => pi.soyad).FirstOrDefault(),
                    giristarihi = c.giristarihi,
                    girissaati = c.girissaati,
                    cikissaati = c.cikissaati,
                    islemturu=c.islemturu,
                    KartNo = dc.personel.Where(pi => pi.id == c.personel).Select(pi => pi.kartno).FirstOrDefault(),
                    personel = c.personel
                };
                tts.Add(gr);

            }
            // dc.TestGirisCikis.AddRange(tts);
            Listele.DataSource = tts;
            Listele.DataBind();
        }
        catch (Exception ht)
        {
            HataMsj.Visible = true;
            msj.InnerText = "Hata oluştu, hata kodu: " + ht.Message.ToString();
        }
       
    }
}