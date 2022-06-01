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
             
             
                </div>
            </div>
        </div>
    </div>
</asp:Content>

