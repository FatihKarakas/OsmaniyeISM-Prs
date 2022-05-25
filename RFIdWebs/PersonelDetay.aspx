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
                                <td><%# Eval("GirisDurum") %></td>
                                <td><%# Eval("CikisDurum") %></td>
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
   
</asp:Content>
