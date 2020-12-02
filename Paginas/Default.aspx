<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Paginas_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Login</title>
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../Content/LoginStyle.css" rel="stylesheet" />
    <script src="../Scripts/bootstrap.min.js"></script>
    <script src="//cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
</head>
<body>
    <br />
    <br />
    <br />
    <br />
    <br />
    <form id="form1" runat="server">
        <div class="container h-100">
            <div class="d-flex justify-content-center h-100">
                <div class="user_card">
                    <div class="d-flex justify-content-center">
                        <div class="brand_logo_container">
                            &nbsp;<img src="../Imagens/logobraga.png" class="brand_logo" alt="Logo" />
                        </div>
                    </div>
                    <div class="d-flex justify-content-center form_container">
                        <div class="col-md-12">


                            <label>E-mail:</label>
                            <asp:TextBox ID="txtEmail" type="email" required="required" runat="server" CssClass="form-control"></asp:TextBox>
                            <br />
                            <label>Senha:</label>
                            <asp:TextBox ID="txtSenha" type="password" required="required" runat="server" CssClass="form-control"></asp:TextBox>
                            <br />
                            <br />
                            <asp:Button ID="btnLogin" runat="server" CssClass="btn btn-primary btn-block btn-dark" Text="LOGAR" OnClick="btnLogin_Click" />
                            <br />

                        </div>
                    </div>
                    <div class="mt-4">
                        <div class="d-flex justify-content-center links">
                            <asp:Label ID="lblMsg" runat="server"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>

