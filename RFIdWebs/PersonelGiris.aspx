<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="PersonelGiris.aspx.cs" Inherits="PersonelGiris" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="row">
        <div class="col-12">
            <div class="card">
                <div class="card-header">
                    <h3>Personel Giriş Çıkış Listesi</h3>
                </div>
                <div class="card-body">
                    
                    <div class="alert alert-warning alert-dismissible fade show" role="alert" runat="server" id="HataMsj" visible="false">
      <label runat="server" id="msj"></label>
  <button type="button" class="close" data-dismiss="alert" aria-label="Close">
    <span aria-hidden="true">&times;</span>
  </button>
</div>
                    <asp:Repeater runat="server" ID="Listele">
                        <HeaderTemplate>
                            <table class="table table-bordered" id="PersonelTablo">
                                <thead>
                                    <td>Kart No:</td>
                                    <td>Kullanıcı ID</td>
                                    <td>Adı Soyadı</td>
                                    <td>Tarih</td>
                                    <td>Giriş Zaman</td>
                                    <td>Çıkış Zamanı</td>
                                     <td>İşlem</td>
                                </thead>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td><%# Eval("KartNo") %></td>
                                <td><%# Eval("personel") %></td>
                                <td><%# Eval("AdıSoyadi") %></td>
                                <td><%# Eval("giristarihi", "{0: dd/MM/yyyy}") %></td>
                                <td><%# Eval("girissaati") %></td>
                                <td><%# Eval("cikissaati") %></td>
                                <td><%# Eval("islemturu") %></td>
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
