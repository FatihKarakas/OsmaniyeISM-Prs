using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Islemler : System.Web.UI.Page
{
    public DataContext dc = new DataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            RaporGetirBtn.Visible = true;
            Revize.Visible = false;
            HataMsj.Visible = false;
            GirisSaat.Text = "";
            CikisSaat.Text = "";
        }
    }

    protected void BasTarih_TextChanged(object sender, EventArgs e)
    {
        GirisSaat.Text = "";
        CikisSaat.Text = "";
        int PerId = Convert.ToInt32(DropDownList1.SelectedValue.ToString());
        DateTime Tarih = Convert.ToDateTime(BasTarih.Text);
        try
        {
            var kisi = dc.pts_giriscikis
                .Where(x => x.personel == PerId && x.giristarihi == Tarih)
                .FirstOrDefault();
            if (kisi != null)
            {
                GirisSaat.Text = kisi.girissaati.ToString();
                CikisSaat.Text = kisi.cikissaati.ToString();
            }
            else
            {
                HataMsj.Visible = true;
                msj.InnerText = "Bu kişi için kayıt bulunamadı eklemek ister misiniz?";
            }
        }
        catch (Exception ex)
        {
            HataMsj.Visible = true;
            msj.InnerText = "İşlem sırasında hata oluştu" + ex.Message.ToString();
            return;
        }
        RaporGetirBtn.Visible = false;
        Revize.Visible = true;
    }

    protected void Revize_Click(object sender, EventArgs e)
    {
        var parca = GirisSaat.Text.ToString().Split(':');
        var parca1 = CikisSaat.Text.ToString().Split(':');
        var GirisSaati = new TimeSpan(Convert.ToInt32(parca[0].ToString()), Convert.ToInt32(parca[1].ToString()), Convert.ToInt32(parca[2].ToString()));
        var CikisSaati = new TimeSpan(Convert.ToInt32(parca1[0].ToString()), Convert.ToInt32(parca1[1].ToString()), Convert.ToInt32(parca1[2].ToString()));
        try
        {
            int PerId = Convert.ToInt32(DropDownList1.SelectedValue.ToString());
            DateTime Tarih = Convert.ToDateTime(BasTarih.Text);
            var kisi = dc.pts_giriscikis
           .Where(x => x.personel == PerId && x.giristarihi == Tarih)
           .FirstOrDefault();
            if (kisi != null)
            {
                kisi.girissaati = GirisSaati;
                kisi.cikissaati = CikisSaati;
                dc.Entry(kisi).State = System.Data.Entity.EntityState.Modified;
                dc.SaveChanges();
               
            }
            else
            {
                pts_giriscikis pt = new pts_giriscikis()
                {
                    personel = Convert.ToInt32(DropDownList1.SelectedValue.ToString()),
                    giristarihi = Tarih,
                    cikistarihi = Tarih,
                    girissaati = GirisSaati,
                    cikissaati = CikisSaati,
                    islemturu = "MesaiBitti"
                };
                dc.pts_giriscikis.Add(pt);
                dc.SaveChanges();
            }

        }
        catch (Exception ex)
        {
            HataMsj.Visible = true;
            msj.InnerText = "İşlem sırasında hata oluştu" + ex.Message.ToString();
            return;
        }
        HataMsj.Visible = true;
        HataMsj.Attributes.Add("class", "alert alert-success");
        msj.InnerText = "İşlem Tamamlandı" ;
        
    }
}