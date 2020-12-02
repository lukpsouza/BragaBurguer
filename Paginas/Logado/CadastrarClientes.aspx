<%@ Page Title="" Language="C#" MasterPageFile="~/Paginas/Logado/MasterPage.master" AutoEventWireup="true" CodeFile="CadastrarClientes.aspx.cs" Inherits="Paginas_Logado_CadastrarClientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
        <body style="background-image: url('http://localhost:61546/Imagens/mee4.png');"></body>
    <div>

    </div>
    <div class="container mt-5">
        <div class="row">
            <div class="col-12 col-md-6">
                <h1>Cadastro de Clientes:</h1>
                <hr />
                <label>Nome:</label>
                <asp:TextBox ID="txtNomeC" runat="server" placeholder="Nome" CssClass="form-control"></asp:TextBox><br />
                <br />
                <label>Endereço:</label>
                <asp:TextBox ID="txtEnderecoC" runat="server" placeholder="Endereço" CssClass="form-control"></asp:TextBox><br />
                <br />
                <label>Telefone:</label>
                <asp:TextBox ID="txtTelefoneC" runat="server" placeholder="Telefone" CssClass="form-control"></asp:TextBox><br />
                <br />
                <label>Quantidade:</label>
                <asp:TextBox ID="txtQuantidadeC" runat="server" placeholder="Quantidade" CssClass="form-control"></asp:TextBox><br />
                <br />
                <asp:Button ID="btnCadastrarC" CssClass="btn btn-primary btn-dark" runat="server" Text="CADASTRAR" OnClick="btnCadastrarC_Click" />&nbsp;<asp:Button ID="btnPesquisar" CssClass="btn btn-primary btn-dark" runat="server" Text="PESQUISAR" OnClick="btnPesquisar_Click" /><br />&nbsp;<br />
                <br />
                <asp:Label ID="lblMsgC" runat="server"></asp:Label>
                <br />
                <hr />
                <br />
            </div>
        </div>
    </div>
</asp:Content>
