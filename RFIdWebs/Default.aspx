<%@ Page Title="Osmaniye İl Sağlık Personel" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
   <div class="row">
             <div class="alert alert-warning alert-dismissible fade show" role="alert" runat="server" id="HataMsj" visible="false">
                        <label runat="server" id="msj"></label>
                        <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>

						<div class="col-12">
							<div class="card">
								<div class="card-header">
							         <h2>Kullanıcılar</h2>
								</div>
								<div class="card-body">
                       <asp:Repeater runat="server" ID="PerList" OnItemCommand="PerList_ItemCommand">
                    <HeaderTemplate>
                        <table class="table table-bordered" id="PersonelTablo">
                            <thead>
                                <td>Sıra</td>
                                <td>Kart Numarası</td>
                                <td>Adı Soyadı</td>
                                <td>Sicil No</td>
                                 <td>Başkanlık</td>
                                <td>Aktif mi</td>
                               <td>Detay</td>
                            </thead>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td><%# Container.ItemIndex + 1 %></td>
                            <td><%# Eval("KullaniciNo") %></td>
                            <td><%# Eval("PersonelAdi") %></td>
                            <td><%# Eval("sicilno") %></td>
                            <td><%# Eval("Baskanlik") %></td>
                            <td>
                                <asp:LinkButton runat="server" ID="IsActiveBtn" CommandName="Degistir" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "KullaniciNo") %>'  CssClass='<%# Eval("Aktifmi").ToString() != "Aktif" ? "btn btn-danger" : "btn btn-success" %>'  OnClientClick="return confirm('Personel Aktiflik Bilgisini Değiştiriyorsunuz');"> <%# Eval("Aktifmi")%> </asp:LinkButton> 

                            </td>
                            <td><a href="PersonelDetay.aspx?kullanici=<%# Eval("KullaniciNo")%>" class="btn btn-info"">Detay</a>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
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
