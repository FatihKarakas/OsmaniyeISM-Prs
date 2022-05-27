<%@ Page Title="Osmaniye İl Sağlık Personel" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
   <div class="row">
						<div class="col-12">
							<div class="card">
								<div class="card-header">
							         <h2>Kullanıcılar</h2>
								</div>
								<div class="card-body">
                       <asp:Repeater runat="server" ID="PerList">
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
                            <td><%# string.Format(Eval("Aktifmi").ToString() != "True" ? "Pasif" : "Aktif") %></td>
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
</asp:Content>
