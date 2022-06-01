<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GirisYap.aspx.cs" Inherits="GirisYap" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <meta name="description" content="Osmaniye İl Sağlık Müdürlüğü">
    <meta name="author" content="Fatih KARAKAŞ">
    <meta name="keywords" content="Osmaniye, Fatih KARAKAŞ, Personel, admin, dashboard">
    <link rel="preconnect" href="https://fonts.gstatic.com">
    <link rel="shortcut icon" href="img/icons/icon-48x48.png" />
    <title>Personel Takip Sistemi</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous">
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.9.2/dist/umd/popper.min.js" integrity="sha384-IQsoLXl5PILFhosVNubq5LC7Qb9DXgDA9i+tQ8Zj3iwWAwPtgFTxbJ8NT4GN1R8p" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.min.js" integrity="sha384-cVKIPhGWiC2Al4u+LWgxfKTRIcfu0JTxR+EQDz/bgldoEyl4H0zUF0QKbrJ0EcQF" crossorigin="anonymous"></script>
</head>
<body class="align-items-center bg-light">
    <form runat="server">
        <div class="container-md">
            <div class="row">
                <div class="col-12">
                    <div class="alert alert-warning alert-dismissible fade show" role="alert" id="HataMsj" runat="server" visible="false">
                        <label runat="server" id="msj"></label>
                        <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
                    </div>
                </div>
            </div>
            <div class="row  p-5 d-flex justify-content-center ">
                <div class="col-6 p5">
                    <div class="card">
                        <div class="card-header text-center">
                            <h2>Osmaniye İl Sağlık Müdürlüğü</h2>
                            <h4>Kullanıcı Giriş Ekranı</h4>
                        </div>
                        <div class="card-body p5">
                            <div class="row">
                                <div class="col-12 text-center">
                                    <div class="mb-3">
                                        <label for="UserName" class="form-label">Kullanıcı Adınız :</label>
                                        <asp:TextBox runat="server" ID="UserName" CssClass="form-control form-control-lg" placeholder="Kullanıcı Adı" required></asp:TextBox>

                                    </div>
                                    <div class="mb-3">
                                        <label for="Parola" class="form-label">Parolanız</label>
                                        <asp:TextBox runat="server" TextMode="Password" ID="Parola" CssClass="form-control form-control-lg" placeholder="Parola" required></asp:TextBox>

                                    </div>
                                    <div class="mb-3 form-check">

                                        <asp:CheckBox runat="server" ID="Hatirla" CssClass="form-check-input" />
                                        <label class="form-check-label" for="exampleCheck1">Beni Hatırla</label>
                                    </div>
                                    <asp:Button runat="server" ID="giris" CssClass="btn btn-lg btn-primary" OnClick="giris_Click" Text="Kullanıcı Girişi" />
                                </div>

                            </div>
                        </div>
                    </div>
                </div>
            </div>
            </div>
    </form>
</body>
</html>
