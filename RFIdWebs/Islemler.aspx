<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Islemler.aspx.cs" Inherits="Islemler" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
     <div class="row">
        <div class="col-12">
            <div class="card">
                <div class="card-header">
                    <h3>Kart Basmayanlar Listesi</h3>
                </div>
                <div class="card-body">

                    <div class="alert alert-warning alert-dismissible fade show" role="alert" runat="server" id="HataMsj" visible="false">
                        <label runat="server" id="msj"></label>
                        <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                </div>
                <div class="row">
                    <div class="col-12">
                        <table class="table table-bordered table-active">
                            <tr>
                                <td>Personel Seçiniz</td>
                                <td>
                                    <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control form-select" DataTextField="isim" DataValueField="id" DataSourceID="DB1" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:SqlDataSource ID="DB1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionStringLocal %>" SelectCommand="SELECT id,kartno, CONCAT(ad,' ',soyad) as isim FROM personel order by isim "></asp:SqlDataSource>
                                </td>
                           
                                <td>Kontrol Tarihi</td>
                                <td>
                                    <asp:TextBox runat="server" ID="BasTarih" name="dDate" class="form-control" autocomplete="off"  />


                                </td>
                            </tr>
                            <tr>
                                <td>Giriş Saati</td>
                                <td>
                                    <asp:TextBox runat="server" ID="GirisSaat" name="dDate" class="form-control" autocomplete="off" />
                                </td>
                           
                                <td>Çıkış Saati</td>
                                <td>
                                    <asp:TextBox runat="server" ID="CikisSaat" name="dDate" class="form-control" autocomplete="off" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <asp:Button runat="server" ID="RaporGetirBtn" CssClass="btn btn-block btn-lg btn-info" Text="İşlem Yap" OnClick="BasTarih_TextChanged"  />
                                    <asp:Button runat="server" ID="Revize" CssClass="btn btn-block btn-lg btn-info" Text="Veri Ekle Güncelle" Visible="false" OnClick="Revize_Click"  />
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
          
            </div>
        </div>
    </div>

    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.6.4/css/bootstrap-datepicker.css" type="text/css" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.6.4/js/bootstrap-datepicker.js" type="text/javascript"></script>
    <script src="https://unpkg.com/gijgo@1.9.13/js/messages/messages.tr-tr.js" type="text/javascript"></script>

    <script>
        $(function ($) {
            $.fn.datepicker.dates['tr'] =
                {
                    days: ["Pazar", "Pazartesi", "Salı", "Çarşamba", "Perşembe", "Cuma", "Cumartesi", "Pazar"],
                    daysShort: ["Pz", "Pzt", "Sal", "Çrş", "Prş", "Cu", "Cts", "Pz"],
                    daysMin: ["Pz", "Pzt", "Sa", "Çr", "Pr", "Cu", "Ct", "Pz"],
                    months: ["Ocak", "Şubat", "Mart", "Nisan", "Mayıs", "Haziran", "Temmuz", "Ağustos", "Eylül", "Ekim", "Kasım", "Aralık"],
                    monthsShort: ["Oca", "Şub", "Mar", "Nis", "May", "Haz", "Tem", "Ağu", "Eyl", "Eki", "Kas", "Ara"],
                    today: "Bugün",
                    suffix: [],
                    meridiem: []
                };
        });

        $(function ($) {
            $("#MainContent_BasTarih").datepicker(
                {
                    language: "tr",
                    changeMonth: true,
                    changeYear: false,
                    format: "yyyy/mm/dd",
                    firstDay: 1


                });
           
        });
    </script>
</asp:Content>

