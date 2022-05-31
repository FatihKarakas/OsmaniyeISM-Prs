<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="OzelRapor.aspx.cs" Inherits="OzelRapor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">

    <div class="row">
        <div class="col-12">
            <div class="card">
                <div class="card-header">
                    <h3>Koşullu Rapor Listesi</h3>
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
                        <table class="table table-bordered">
                            <tr>
                                <td>Başkanlık Seçiniz</td>
                                <td>
                                    <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control form-select" DataTextField="baskanlik" DataValueField="id">
                                    </asp:DropDownList>
                                    <asp:SqlDataSource ID="DB1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionStringLocal %>" SelectCommand="SELECT [id], [baskanlik] FROM [Servis]"></asp:SqlDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td>Başlangıç Tarihi</td>
                                <td>
                                    <asp:TextBox runat="server" ID="BasTarih" name="dDate" class="form-control" autocomplete="off" />


                                </td>
                            </tr>
                            <tr>
                                <td>Bitiş Tarihi</td>
                                <td>
                                    <asp:TextBox runat="server" ID="BitTarih" name="dDate" class="form-control" autocomplete="off" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:Button runat="server" ID="RaporGetirBtn" CssClass="btn btn-block btn-lg btn-info" Text="Raporları Getir" OnClick="RaporGetirBtn_Click" /></td>
                            </tr>
                        </table>
                    </div>
                </div>
                <div class="row">
                    <div class="col-12">
                        <asp:Repeater runat="server" ID="Listele">
                            <HeaderTemplate>
                                <table class="table table-bordered" id="PersonelTablo">
                                    <thead>
                                        <td>Personel İd</td>
                                        <td>Adı Soyadı</td>
                                        <td>Başkanlık</td>
                                        <td>Tarih</td>
                                        <td>Giriş Zaman</td>
                                        <td>Çıkış Zamanı</td>
                                        <td>Giriş Durumu</td>
                                        <td>Çıkış Durumu</td>
                                    </thead>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td><%# Eval("perid") %></td>
                                    <td><%# Eval("isim") %></td>
                                    <td><%# Eval("baskanlik") %></td>
                                    <td><%# Eval("giristar", "{0: dd/MM/yyyy}") %></td>
                                    <td><%# Eval("girissaat") %></td>
                                    <td><%# Eval("cikissaat") %></td>
                                    <td class="alert <%# Eval("GirisDurum").ToString() == "Geliş Ok" ? "bg-success text-white" : "bg-danger text-white" %>"><%# Eval("GirisDurum") %></td>
                                    <td class="alert <%# Eval("CikisDurum").ToString() == "Çıkış Ok" ? "bg-success text-white" : "bg-danger text-white" %>"><%# Eval("CikisDurum") %></td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </table>
                            </FooterTemplate>
                        </asp:Repeater>
                        <asp:SqlDataSource ID="DB2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionStringLocal %>"></asp:SqlDataSource>
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
            $("#MainContent_BitTarih").datepicker(
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

