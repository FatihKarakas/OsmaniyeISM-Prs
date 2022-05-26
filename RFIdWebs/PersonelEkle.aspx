<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="PersonelEkle.aspx.cs" Inherits="PersonelEkle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
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
							         <h2>Yeni Personel Ekle</h2>
								</div>
								<div class="card-body">
                                <div class="row">
                                    <div class="col-2">
                                        Kartı Okutunuz :
                                    </div>
                                    <div class="col-5">
                                        <asp:TextBox runat="server" ID="KartNo" AutoCompleteType="Search" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <div class="col-5">
                                        <asp:Button runat="server" Text="Kontrol Et" CssClass="btn btn-primary" ID="KtBtn" OnClick="Kontrol_Et" />
                                    </div>
                                </div>
                                    <div class="row pt-5" runat="server" id="FormGorunum" visible="false">
                                        <div class="col-12">
                                            <table class="table table-light">
                                                <tr>
                                                    <td colspan="8">
                                                        <h3 class="text-center">Personel Bilgileri</h3>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>Kart No:</td>
                                                    <td><asp:TextBox runat="server" ID="KartNumber" CssClass="form-control"></asp:TextBox></td>
                                                    <td>Kart ID:</td>
                                                    <td><asp:TextBox runat="server" ID="KartId" CssClass="form-control"></asp:TextBox></td>
                                                    <td>Adı:</td>
                                                    <td><asp:TextBox runat="server" ID="Ad" CssClass="form-control"></asp:TextBox></td>
                                                    <td>Soyadı:</td>
                                                    <td><asp:TextBox runat="server" ID="Soyad" CssClass="form-control"></asp:TextBox></td>
                                                </tr>
                                                  <tr>
                                                    <td>Sicil No:</td>
                                                    <td><asp:TextBox runat="server" ID="SicilNo" CssClass="form-control"></asp:TextBox></td>
                                                    <td>Başkanlık:</td>
                                                    <td>
                                                        <asp:DropDownList runat="server" ID="BaskanlikDrop" CssClass="form-control from-select" DataSourceID="BaskanliKBilgileri" DataTextField="baskanlik" DataValueField="id"></asp:DropDownList>
                                                        <asp:SqlDataSource ID="BaskanliKBilgileri" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionStringLocal %>" SelectCommand="SELECT [id], [baskanlik] FROM [Servis]"></asp:SqlDataSource>
                                                    </td>
                                                    <td>Başlama Tarihi</td>
                                                    <td><asp:TextBox runat="server" ID="BasTarih" CssClass="form-control"></asp:TextBox></td>
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
                                                    <td colspan="8">
                                                        <asp:Button runat="server" ID="PersEkleBtn" Text=" Personel Ekle / Güncelle" CssClass="btn btn-block btn-success" OnClick="PersEkleBtn_Click" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </div>
								</div>
							</div>
						</div>
					</div>
    
<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.6.4/css/bootstrap-datepicker.css" type="text/css" />

<script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.6.4/js/bootstrap-datepicker.js" type="text/javascript"></script>
<script type="text/javascript">
    $(function () {
        $('#MainContent_BasTarih').datepicker({
            changeMonth: true,
            changeYear: true,
            format: "yyyy/mm/dd",
            language: "Tr"
        });
        
    });
</script>
</asp:Content>

