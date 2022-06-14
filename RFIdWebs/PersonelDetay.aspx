<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="PersonelDetay.aspx.cs" Inherits="PersonelDetay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">


    <div class="row">
        <div class="col-12">
            <div class="card">
                <div class="card-header">
                    <h2>Personel Detayları</h2>
                </div>
                <div class="card-body">

                    <div class="alert alert-warning alert-dismissible fade show" role="alert" runat="server" id="HataMsj" visible="false">
                        <label runat="server" id="msj"></label>
                        <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>

                    <div class="row pt-5" runat="server" id="personelislem">
                        <div class="col-12">
                            <table class="table table-light">
                                <tr>
                                    <td colspan="8">
                                        <h3 class="text-center">Personel Bilgileri</h3>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Kart No:</td>
                                    <td>
                                        <asp:TextBox runat="server" ID="KartNumber" CssClass="form-control"></asp:TextBox></td>
                                    <td>Kart ID:</td>
                                    <td>
                                        <asp:TextBox runat="server" ID="KartId" CssClass="form-control"></asp:TextBox></td>
                                    <td>Adı:</td>
                                    <td>
                                        <asp:TextBox runat="server" ID="Ad" CssClass="form-control"></asp:TextBox></td>
                                    <td>Soyadı:</td>
                                    <td>
                                        <asp:TextBox runat="server" ID="Soyad" CssClass="form-control"></asp:TextBox></td>


                                </tr>
                                <tr>
                                    <td>Sicil No:</td>
                                    <td>
                                        <asp:TextBox runat="server" ID="SicilNo" CssClass="form-control"></asp:TextBox></td>
                                    <td>Başkanlık:</td>
                                    <td>
                                        <asp:DropDownList runat="server" ID="BaskanlikDrop" CssClass="form-control from-select" DataSourceID="BaskanliKBilgileri" DataTextField="baskanlik" DataValueField="id"></asp:DropDownList>
                                        <asp:SqlDataSource ID="BaskanliKBilgileri" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionStringLocal %>" SelectCommand="SELECT [id], [baskanlik] FROM [Servis]"></asp:SqlDataSource>
                                    </td>
                                    <td>Başlama Tarihi</td>
                                    <td>
                                        <asp:TextBox runat="server" ID="BasTarih" CssClass="form-control"></asp:TextBox></td>
                                    <td>Kan Grubu:</td>
                                    <td>
                                        <asp:DropDownList runat="server" ID="KanGrup" CssClass="form-control form-select">
                                            <asp:ListItem Selected="True">Seçiniz</asp:ListItem>
                                            <asp:ListItem Value="1">A Rh(+)</asp:ListItem>
                                            <asp:ListItem Value="2">A Rh(-)</asp:ListItem>
                                            <asp:ListItem Value="3">B Rh(+)</asp:ListItem>
                                            <asp:ListItem Value="4">B Rh(-)</asp:ListItem>
                                            <asp:ListItem Value="5">AB Rh(+)</asp:ListItem>
                                            <asp:ListItem Value="6">AB Rh(-)</asp:ListItem>
                                            <asp:ListItem Value="7">0 Rh(+)</asp:ListItem>
                                            <asp:ListItem Value="8">0 Rh(-)</asp:ListItem>

                                        </asp:DropDownList>
                                    </td>
                                   
                                </tr>
                                <tr>
                                    <td>Engelli Durumu
                                    </td>
                                    <td>
                                        <div class="form-check">
                                            <input class="form-check-input" type="checkbox" value="" id="Engellilik" runat="server">
                                            <label class="form-check-label" for="Engellilik">
                                                Engelli mi?
                                            </label>
                                        </div>
                                    </td>
                                    <td>
                                        Kontrol Durumu:
                                    </td>
                                    <td>
                                        <div class="form-check">
                                            <input class="form-check-input" type="checkbox" value="" id="KontroleTabi" runat="server">
                                            <label class="form-check-label" for="KontroleTabi">
                                                Kontrole Tabi
                                            </label>
                                        </div>
                                    </td>
                                    <td colspan="2">
                                        Terminallere Aktarım:
                                    </td>
                                    <td colspan="2">
                                        <div class="form-check">
                                            <input class="form-check-input" type="checkbox" checked  id="AktarimYap" runat="server" name="AktarimYap">
                                            <label class="form-check-label" for="TerminalAktarim">
                                               Veriler Terminallere aktarılsın
                                            </label>
                                        </div>
                                    </td>
                                   
                                </tr>
                                <tr>
                                    <td colspan="8">
                                        <asp:Button runat="server" ID="PersEkleBtn" Text=" Personel Ekle / Güncelle" CssClass="btn btn-block btn-success" OnClick="PersEkleBtn_Click" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>

                    <asp:Repeater runat="server" ID="Listele" DataSourceID="DB3">
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
                                <td class="alert <%# Eval("GirisDurum").ToString() == "Zamanında" ? "bg-success text-white" : "bg-danger text-white" %>"><%# Eval("GirisDurum") %></td>
                                <td class="alert <%# Eval("CikisDurum").ToString() == "Zamanında" ? "bg-success text-white" : "bg-danger text-white" %>"><%# Eval("CikisDurum") %></td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>

                    <asp:SqlDataSource ID="DB3" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionStringLocal %>" SelectCommand="KisiselRapor" SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:QueryStringParameter DefaultValue="" Name="Personel" QueryStringField="Kullanici" Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>

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
