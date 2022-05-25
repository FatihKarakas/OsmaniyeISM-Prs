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
                  
                </div>
            </div>
        </div>
    </div>
   
</asp:Content>
