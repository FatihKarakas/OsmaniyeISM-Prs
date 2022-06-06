<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="KullaniciEkle.aspx.cs" Inherits="KullaniciEkle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
        <div class="row">
        <div class="col-12">
            <div class="card">
                <div class="card-header">
                    <h2>Kullanıcı Ekle</h2>
                </div>
                <div class="card-body">
                    <div class="row">
                          <div class="alert alert-warning alert-dismissible fade show" role="alert" id="HataMsj" runat="server" visible="false">
                        <label runat="server" id="msj"></label>
                        <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
                    </div>
                        
                        
                    </div>
                    <div class="row">
                        <div class="col-12">
                            <table class="table">
                                <tr>
                                    <td>Kullanıcı Adı :</td>
                                    <td><asp:TextBox runat="server" ID="UserN" CssClass="form-control" required></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td>Parolanız :</td>
                                    <td><asp:TextBox runat="server" ID="Passi" CssClass="form-control" TextMode="Password" required></asp:TextBox></td>
                                </tr>
                                 <tr>
                                    <td>Parolanız :</td>
                                    <td><asp:TextBox runat="server" ID="Passit" CssClass="form-control" TextMode="Password" required></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td colspan="2" class="text-center"><asp:Button runat="server" ID="UserCreateBtn" CssClass="btn btn-danger" Text="Kullanıcı Oluştur" OnClick="UserCreateBtn_Click"/></td>
                                </tr>
                            </table>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-12">
                            <asp:Repeater runat="server" ID="Kullanicilar" DataSourceID="SqlDataSource1">
                               <HeaderTemplate>
                                    <table class="table table-bordered">
                                <thead>
                                    <tr>
                                        <th>ID</th>
                                        <th>Kullanıcı Adı</th>
                                        <th>Oluşturma Zamanı</th>
                                        <th>Aktif mi</th>
                                       
                                    </tr>
                                </thead>
                                <tbody>
                               </HeaderTemplate>
                                <ItemTemplate>
                                       <tr>
                                        <td><%#Eval("id") %></td>
                                        <td><%#Eval("UserName") %></td>
                                        <td><%# string.Format("{0:dd MMMM yyyy}", Eval("CreateDate"))%></td>
                                        <td><%# Eval("IsActive").ToString() != "1" ? "Pasif" : "Aktif" %></td>
                                    </tr>
                                </ItemTemplate>
                                <FooterTemplate>
                                       </tbody>
                            </table>
                                </FooterTemplate>
                            </asp:Repeater>
                           
                                 
                             
<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionStringLocal %>" SelectCommand="SELECT * FROM [Users]"></asp:SqlDataSource>
                        </div>
                    </div>
             
             
                </div>
            </div>
        </div>
    </div>
</asp:Content>

