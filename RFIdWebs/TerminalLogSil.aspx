<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="TerminalLogSil.aspx.cs" Inherits="TerminalLogSil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
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
                        <div class="col-12">

                          
                            <table>
                                <tr>

                                    <td>
                                        <asp:Button runat="server" ID="IsmLogSilBtn" Text="İSM Terminal Log Sil" CssClass="btn btn-danger" Enabled="True" Visible="True" OnClick="IsmLogSilBtn_Click" />

                                    </td>
                                </tr>
                                <tr>

                                    <td>
                                        <asp:Button runat="server" ID="LablogSil" Text="Lab Terminal Log Sil" CssClass="btn btn-danger" Enabled="True" Visible="True" OnClick="LablogSil_Click" />

                                    </td>
                                </tr>
                                <tr>

                                    <td>
                                        <asp:Button runat="server" ID="DgrLogSil" Text="İSM Terminal Log Sil" CssClass="btn btn-danger" Enabled="True" Visible="True" OnClick="DgrLogSil_Click" />

                                    </td>
                                </tr>
                            </table>


                        </div>
                    </div>

                </div>
            </div>
        </div>
    </div>
</asp:Content>

