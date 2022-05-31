using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TerminalLogSil : System.Web.UI.Page
{
    public GenelAyarlar g = new GenelAyarlar();
    ListBox l = new ListBox();
    private static Logger _logger = LogManager.GetLogger("personelLogs");
    public string sFirmver = "";
    public string sMac = "";
    public string sPlatform = "";
    public string sSN = "";
    public string sProductTime = "";
    public string sDeviceName = "";
    public int iFPAlg = 0;
    public int iFaceAlg = 0;
    public string sProducter = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        HataMsj.Visible = false;
        msj.InnerHtml = "";
    }

    protected void IsmLogSilBtn_Click(object sender, EventArgs e)
    {
        try
        {
            g.bIsConnected=g.axCZKEM1.Connect_Net("10.80.15.220", 4370);
          //  g.axCZKEM1.EnableDevice(1, false);
            int sonuc = g.sta_DeleteAttLog(l);
            if (sonuc != 1)
            {
                HataMsj.Visible = true;
                msj.InnerHtml = "Hata oluştu " + l.Items[0].ToString();
                return;
            }
            HataMsj.Visible = true;
            msj.InnerHtml = "Terminal Log bilgisi silindi";
        }
        catch (Exception ex)
        {

            HataMsj.Visible = true;
            msj.InnerHtml = "Hata oluştu " + ex.Message.ToString();
            string Mesaj = g.IPogren() + " adresinden Terminal log silme işleminde hata : "  +ex.Message.ToString();
            _logger.Error(Mesaj);
        }
        finally
        {
            g.axCZKEM1.RefreshData(1);//Yenile
            g.axCZKEM1.EnableDevice(1, true);
        }
        HataMsj.Visible = true;
        msj.InnerHtml = "Terminal Log bilgisi silindi";
        HataMsj.Attributes.Add("class", "alert alert-success");
        string Mesaj1 = g.IPogren() + " adresinden Terminal log silme işlemi yapıldı";
        _logger.Info(Mesaj1);
    }

    protected void LablogSil_Click(object sender, EventArgs e)
    {
        try
        {
            g.axCZKEM1.Connect_Net("10.80.15.221", 4370);
            g.axCZKEM1.EnableDevice(1, false);
            int sonuc = g.sta_DeleteAttLog(l);
            if (sonuc == 0)
            {
                HataMsj.Visible = true;
                msj.InnerHtml = "Hata oluştu " + l.Items[0].ToString();
                return;
            }
        }
        catch (Exception ex)
        {

            HataMsj.Visible = true;
            msj.InnerHtml = "Hata oluştu " + ex.Message.ToString();
            string Mesaj = g.IPogren() + " adresinden LAB  Terminal log silme işleminde hata : " + ex.Message.ToString();
            _logger.Error(Mesaj);

        }
        finally
        {
            g.axCZKEM1.RefreshData(1);//Yenile
            g.axCZKEM1.EnableDevice(1, true);
        }
        HataMsj.Visible = true;
        msj.InnerHtml = "Terminal Log bilgisi silindi";
        HataMsj.Attributes.Add("class", "alert alert-success");
        string Mesaj1 = g.IPogren() + " adresinden Terminal log silme işlemi yapıldı";
        _logger.Info(Mesaj1);
    }

    protected void DgrLogSil_Click(object sender, EventArgs e)
    {
        try
        {
            g.axCZKEM1.Connect_Net("10.80.15.222", 4370);
            g.axCZKEM1.EnableDevice(1, false);
            int sonuc = g.sta_DeleteAttLog(l);
            if (sonuc == 0)
            {
                HataMsj.Visible = true;
                msj.InnerHtml = "Hata oluştu " + l.Items[0].ToString();
                return;
            }

        }
        catch (Exception ex)
        {

            HataMsj.Visible = true;
            msj.InnerHtml = "Hata oluştu " + ex.Message.ToString();
            string Mesaj = g.IPogren() + " adresinden Diğer Terminal log silme işleminde hata : " + ex.Message.ToString();
            _logger.Error(Mesaj);
        }
        finally
        {
            g.axCZKEM1.RefreshData(1);//Yenile
            g.axCZKEM1.EnableDevice(1, true);
        }
        HataMsj.Visible = true;
        msj.InnerHtml = "Terminal Log bilgisi silindi";
        HataMsj.Attributes.Add("class", "alert alert-success");
        string Mesaj1 = g.IPogren() + " adresinden Terminal log silme işlemi yapıldı";
        _logger.Info(Mesaj1);
    }

    private int getDeviceInfo()
    {
        
     return   g.sta_GetDeviceInfo(l, out sFirmver, out sMac, out sPlatform, out sSN, out sProductTime, out sDeviceName, out iFPAlg, out iFaceAlg, out sProducter);
    }
    }