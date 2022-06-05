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
        LogSilme("10.80.15.220", "İl Sağlık Merkez Terminal");

    }

    protected void LablogSil_Click(object sender, EventArgs e)
    {
        LogSilme("10.80.15.221", "Laboratuvar Terminal");
    }

    protected void DgrLogSil_Click(object sender, EventArgs e)
    {
        LogSilme("10.80.15.222", "Diğer Terminal");
    }

    private int getDeviceInfo()
    {

        return g.sta_GetDeviceInfo(l, out sFirmver, out sMac, out sPlatform, out sSN, out sProductTime, out sDeviceName, out iFPAlg, out iFaceAlg, out sProducter);
    }

    public void LogSilme(string Terminal, string Terminalad)
    {
        var t = Terminal;
        var port = 4370;

        try
        {
            var Baglan = g.axCZKEM1.Connect_Net(t, port);
            if (Baglan)
            {
                g.bIsConnected = true;
                var CihazAktif = g.axCZKEM1.EnableDevice(1, false);
                if (CihazAktif)
                {
                    int sonuc = g.sta_DeleteAttLog(l);
                    if (sonuc == 0 || sonuc < 0)
                    {
                        HataMsj.Visible = true;
                        msj.InnerHtml = $"Hata oluştu  {l.Items[0].ToString()}";
                        string Mesaj = $"{g.IPogren()} adresinden {Terminalad} log silme işleminde cihaz erişiminde hata :{l.Items[0].ToString()}";
                        _logger.Error(Mesaj);
                        return;
                    }
                }
                else
                {
                    HataMsj.Visible = true;
                    msj.InnerHtml = "Cihaz geçici kayıt durudurma yapılamadı";
                    string Mesaj = $"{g.IPogren()} adresinden {Terminalad} Cihaz geçici kayıt durudurma yapılamadı :{l.Items[0].ToString()}";
                    _logger.Error(Mesaj);
                    return; // Cihaz devre dışı bırak geçici
                }
            }
            else
            {
                HataMsj.Visible = true;
                msj.InnerHtml = $"{g.IPogren()} adresinden {Terminalad} Cihaza bağlantı yapılamadı ";
                string Mesaj = $"{g.IPogren()} adresinden {Terminalad} Cihaza bağlantı yapılamadı ";
                _logger.Error(Mesaj);
                return; // Bağlantı Hatası oldu;
            }

        }
        catch (Exception ex)
        {
            HataMsj.Visible = true;
            msj.InnerHtml = $"{Terminalad} cihazı log silmede hata oluştu, hata : {ex.Message.ToString()}";
            string Mesaj = $"{g.IPogren()} adresinden {Terminalad} log silme işleminde hata :{ ex.Message.ToString()}";
            _logger.Error(Mesaj);
        }
        finally
        {
            g.axCZKEM1.RefreshData(1);//Yenile
            g.axCZKEM1.EnableDevice(1, true);
            g.axCZKEM1.Disconnect();

        }

        HataMsj.Visible = true;
        msj.InnerHtml = $"{Terminalad} Terminal Log bilgisi silindi";
        HataMsj.Attributes.Add("class", "alert alert-success");
        string Mesaj1 = $"{g.IPogren()} adresinden {Terminalad} Terminal log silme işlemi yapıldı";
        _logger.Info(Mesaj1);
    }
}