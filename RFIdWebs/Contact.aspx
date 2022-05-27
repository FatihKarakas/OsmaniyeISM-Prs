<%@ Page Title="Osmaniye İl Sağlık" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Contact.aspx.cs" Inherits="Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-12">
            <div class="card">
                <div class="card-header">
                    <h2>Personel Listesi</h2>
                </div>
                <div class="card-body">
                    <div class="row">
                        <div class="alert alert-warning alert-dismissible fade show" role="alert" runat="server" id="HataMsj" visible="false">
                            <label runat="server" id="msj"></label>
                            <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="col-7">

                            <asp:ListBox runat="server" ID="hatalar" CssClass="form-control"></asp:ListBox>


                        </div>
                        <div class="col-5">
                            <table>
                                <tr>
                                    <td><a href="Contact.aspx?terminal=10.80.15.220" class="btn btn-success">Terminal İSM</a></td>
                                    <td><a href="Contact.aspx?terminal=10.80.15.221" class="btn btn-info">Terminal LAB</a></td>
                                    <td><a href="Contact.aspx?terminal=10.80.15.222" class="btn btn-danger">Terminal Diğer</a></td>
                                    <td>
                                        <asp:Button runat="server" ID="VeriAktar" Text="Verileri SQL e yaz" CssClass="btn btn-info" Enabled="True" Visible="True" OnClick="VeriAktar_Click" /></td>
                                </tr>
                            </table>
                            <asp:TextBox runat="server" ID="IpAdresiTerminal" CssClass="form-control" Visible="false"></asp:TextBox>


                            <asp:Button runat="server" ID="BaglantiKur" Text="Terminale Bağlan" CssClass="btn btn-success" Enabled="false" Visible="false" />

                        </div>
                    </div>


                    <asp:Repeater runat="server" ID="Listele">
                        <HeaderTemplate>
                            <table class="table table-bordered" id="PersonelTablo">
                                <thead>
                                    <td>Kullanıcı Kart Numarası</td>
                                    <td>Tarih</td>
                                    <td>Gün</td>
                                    <td>Giris Tipi</td>
                                    <td>Durum</td>
                                    <td>Çalışma</td>
                                </thead>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td><%# Eval("UserID") %></td>
                                <td><%# Eval("Tarih1") %></td>
                                <td><%# Eval("Gun") %></td>
                                <td><%# Eval("Type") %></td>
                                <td><%# Eval("state") %></td>
                                <td><%# Eval("WorkCode") %></td>
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
