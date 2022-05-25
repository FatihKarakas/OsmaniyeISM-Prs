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
    <title>Personel Takip Sistemi Giriş Yap</title>
    <link href="css/app.css" rel="stylesheet">
    <link href="https://fonts.googleapis.com/css2?family=Inter:wght@300;400;600&display=swap" rel="stylesheet">
</head>
<body>
    <form runat="server">
        <main class="d-flex w-100">
            <div class="container d-flex flex-column">
                <div class="row vh-100">
                    <div class="col-sm-10 col-md-8 col-lg-6 mx-auto d-table h-100">
                        <div class="d-table-cell align-middle">
                            <div class="text-center mt-4">
                                <h1 class="h2">Osmaniye İl Sağlık Müdürlüğü</h1>
                                <p class="lead">
                                    Kullanıcı Giriş Ekranı
                                </p>
                            </div>
                            <div class="card">
                                <div class="card-body">
                                    <div class="m-sm-4">
                                        <div class="mb-3">
                                            <label class="form-label">Kullanıcı Adı</label>
                                            <asp:TextBox runat="server" ID="UserName" CssClass="form-control form-control-lg" placeholder="Kullanıcı Adı" required></asp:TextBox>
                                        </div>
                                        <div class="mb-3">
                                            <label class="form-label">Password</label>
                                            <asp:TextBox runat="server" TextMode="Password" ID="Parola" CssClass="form-control form-control-lg" placeholder="Parola" required></asp:TextBox>
                                            <small>
                                                <a href="#">Parolamı Unuttum</a>
                                            </small>
                                        </div>
                                        <div>
                                            <label class="form-check">
                                                <asp:CheckBox runat="server" ID="hatirla" Checked="true" CssClass="form-check-input"  />
                                                <span class="form-check-label">Beni Hatırla</span>
                                            </label>
                                        </div>
                                        <div class="text-center mt-3">
                                            <asp:Button runat="server" ID="giris"  CssClass="btn btn-lg btn-primary" OnClick="giris_Click" Text="Kullanıcı Girişi" />
                                            <!-- <button type="submit" class="btn btn-lg btn-primary">Sign in</button> -->
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </main>
        <script src="js/app.js"></script>
    </form>
</body>
</html>
