using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
public partial class Contact : Page
{
    public DataTable dt = new DataTable();
    public DataContext dc = new DataContext();
    public GenelAyarlar g = new GenelAyarlar();
    protected void Page_Load(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), Guid.NewGuid().ToString(),
                    "toastr.warning('Uyarı Uyarısı', 'Uyarı')", true);
        HataMsj.Visible = false;
        msj.InnerText = "";
        try
        {
            var terminal = string.IsNullOrEmpty(Request.QueryString["terminal"]) ? "10.80.15.220" : Request.QueryString["terminal"].ToString();

            
            if (g.bIsConnected)
            {
                IpAdresiTerminal.Enabled = true;
                IpAdresiTerminal.Visible = true;
                BaglantiKur.Visible = true;
                BaglantiKur.Enabled = Visible;
            }
            var baglan = g.sta_ConnectTCP(hatalar, terminal, "4370", "1");
            hatalar.CssClass = "table table-bordered";
            dt.Columns.Add("UserID");
            dt.Columns.Add("Type");
            dt.Columns.Add("Tarih");
            dt.Columns.Add("Tarih1");
            dt.Columns.Add("Gun");
            dt.Columns.Add("state");
            dt.Columns.Add("WorkCode");
            dt.Columns.Add("GirisSaat");
            hatalar.Dispose();
            g.sta_readAttLog(hatalar, dt,terminal);
            ICollection<TestGirisCikis> tts = new List<TestGirisCikis>();
            foreach (DataRow ds in dt.Rows)
            {
                var KontrolTarih = Convert.ToDateTime(ds["Tarih"].ToString());
                var parca = ds["GirisSaat"].ToString().Split(':');
                var kl = ds["UserID"].ToString();
                var Modify = dc.TestGirisCikis.Where(u => u.Kullanici == kl && u.Tarih == KontrolTarih).FirstOrDefault();

                // int say = dc.TestGirisCikis.Where(u => u.Kullanici == tt.Kullanici && Convert.ToDateTime(u.Tarih).ToShortDateString() == KontrolTarih).Count();



                if (Modify != null)
                {
                    Modify.State = 2;
                    Modify.CikisSaat = new TimeSpan(Convert.ToInt32(parca[0].ToString()), Convert.ToInt32(parca[1].ToString()), Convert.ToInt32(parca[2].ToString()));
                    dc.Entry(Modify).State = System.Data.Entity.EntityState.Modified;

                }
                else
                {
                    TestGirisCikis tt = new TestGirisCikis()
                    {
                        Kullanici = ds["UserID"].ToString(),
                        Type = Convert.ToInt32(ds["type"].ToString()),
                        Tarih = Convert.ToDateTime(ds["Tarih"].ToString()),
                        State = 1,
                        GirisSaat = new TimeSpan(Convert.ToInt32(parca[0].ToString()), Convert.ToInt32(parca[1].ToString()), Convert.ToInt32(parca[2].ToString()))
                    };
                    //tts.Add(tt);
                    dc.TestGirisCikis.Add(tt);
                    dc.SaveChanges();
                }


            }

            // dc.TestGirisCikis.AddRange(tts);
            dc.SaveChanges();
            Listele.DataSource = dt;
            Listele.DataBind();
        }
        catch (Exception ht)
        {
            HataMsj.Visible = true;
            msj.InnerText = "Hata oluştu, hata kodu: " + ht.Message.ToString();

        }
       


    }


    protected void VeriAktar_Click(object sender, EventArgs e)
    {
        try
        {
            ICollection<pts_giriscikis> tts = new List<pts_giriscikis>();
            foreach (DataRow data in dt.Rows)
            {
               
                var UserIdsi = data["UserID"].ToString();
                var parca = data["GirisSaat"].ToString().Split(':');
                var GirisSaat = new TimeSpan(Convert.ToInt32(parca[0].ToString()), Convert.ToInt32(parca[1].ToString()), Convert.ToInt32(parca[2].ToString()));
                var GirisSaatk = new TimeSpan(09,00,10);
                var tarihi = Convert.ToDateTime(data["Tarih"].ToString());
                var ktarihi = new DateTime(2022,05,24);
                if (tarihi > ktarihi)
                {
                    var Kisi = dc.personel.Where(x => x.kartno == UserIdsi).FirstOrDefault();
                    if (Kisi == null)
                    {
                        new Exception("Bu kart sahibi personel tablosunda kayıtlı değil Kart no: " + UserIdsi);
                        return;
                    }
                    var girisk = dc.pts_giriscikis.Where(x => x.giristarihi == tarihi && x.personel == Kisi.id).FirstOrDefault();
                    if (girisk != null)
                    {
                        var son = (girisk.girissaati == GirisSaat) ? true : false;
                        if (!son)
                        {
                            girisk.cikistarihi = tarihi;
                            girisk.cikissaati = GirisSaat;
                            girisk.islemturu = "mesaibitti";
                            dc.Entry(girisk).State = System.Data.Entity.EntityState.Modified;
                            dc.SaveChanges();
                        }
                    }
                    else
                    {
                        pts_giriscikis pt = new pts_giriscikis()
                        {
                            personel = Kisi.id,
                            giristarihi = tarihi,
                            girissaati = GirisSaat,
                            islemturu = "MesaiBaşladı",
                            toplamsure = ""

                        };
                        dc.pts_giriscikis.Add(pt);
                        dc.SaveChanges();
                    }
                }
                

            }
        }
        catch (Exception ht)
        {
            HataMsj.Visible = true;
            msj.InnerText = "Hata oluştu, hata kodu: " + ht.Message.ToString();
        }
      


    }
}