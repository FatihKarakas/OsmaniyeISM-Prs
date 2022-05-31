using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class KartBasmayanlar : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        Listele.DataSource = null;
        HataMsj.Visible = false;
        Listele.Dispose();
        msj.InnerText = "";

        if (!IsPostBack)
        {
            DropDownList1.DataSource = DB1;
            DropDownList1.DataBind();
            DropDownList1.Items.Insert(0, new ListItem("Seçiniz", "Seçiniz"));
        }

    }
    protected void RaporGetirBtn_Click(object sender, EventArgs e)
    {
        DB2.Dispose();
        Listele.Dispose();
        Listele.DataSource = null;
        Listele.DataBind();
        DB2.SelectCommand = null;
        DB2.SelectParameters.Clear();
        if (BasTarih.Text == "" || BitTarih.Text == "")
        {
            HataMsj.Visible = true;
            msj.InnerText = "Lüten iki tarih aralığı seçiniz.";
            return;
        }
        DateTime BasTarihi = Convert.ToDateTime(BasTarih.Text);
        DateTime BitTarihi = Convert.ToDateTime(BitTarih.Text);
        if (BasTarihi > BitTarihi)
        {
            HataMsj.Visible = true;
            msj.InnerText = "Başlangıç tarihi mutlaka Bitiş tarihinden küçük olmalıdır.";
            BasTarih.Focus();
            return;
        }
        else
        {
            if (DropDownList1.SelectedValue != "Seçiniz")
            {
                DB2.SelectCommandType = SqlDataSourceCommandType.StoredProcedure;
                DB2.SelectCommand = "KartBasmayanlarBirim";
                DB2.SelectParameters.Add("BasTarih", TypeCode.DateTime, BasTarih.Text);
                DB2.SelectParameters.Add("BitTarih", TypeCode.DateTime, BitTarih.Text);
                DB2.SelectParameters.Add("Baskanlik", TypeCode.Int32, DropDownList1.SelectedValue);
                Listele.DataSource = DB2;
                Listele.DataBind();
            }
            else
            {

                DB2.SelectCommandType = SqlDataSourceCommandType.StoredProcedure;
                DB2.SelectCommand = "KartBasmayanlar";
                DB2.SelectParameters.Add("BasTarih", TypeCode.DateTime, BasTarih.Text);
                DB2.SelectParameters.Add("BitTarih", TypeCode.DateTime, BitTarih.Text);
                Listele.DataSource = DB2;
                Listele.DataBind();
            }


        }



    }
}