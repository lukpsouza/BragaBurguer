<%@ Page Title="" Language="C#" MasterPageFile="~/Paginas/Logado/MasterPage.master" AutoEventWireup="true" CodeFile="CadastrarUsuario.aspx.cs" Inherits="Paginas_Logado_CadastrarUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
        <body style="background-image: url('http://localhost:61546/Imagens/mee4.png');"></body>
    <body></body>
    <div class="container mt-5">
        <div class="row">
            <div class="col-12 col-md-6">
                <h1>Cadastro de Usuário</h1>
                <hr />
                <label>Nome:</label>
                <asp:TextBox runat="server" ID="txtNome" CssClass="form-control"></asp:TextBox>
                <br />
                <label>E-mail:</label>
                <asp:TextBox runat="server" ID="txtEmail" type="email" CssClass="form-control"></asp:TextBox>
                <br />
                <label>Senha:</label>
                <asp:TextBox runat="server" ID="txtSenha" type="password" CssClass="form-control"></asp:TextBox>
                <br />
                <asp:Button ID="btnCadastrar" CssClass="btn btn-primary btn-dark" runat="server" Text="CADASTRAR" OnClick="btnCadastrar_Click" />&nbsp;
                <asp:Button ID="btnPesquisar" CssClass="btn btn-primary btn-dark" runat="server" Text="PESQUISAR" OnClick="btnPesquisar_Click" /><br />
                <br />
                <br />
                <asp:Label ID="lblMsg" runat="server"></asp:Label>
                <br />
                <hr />
                <br />
            </div>
        </div>
    </div>

</asp:Content>

