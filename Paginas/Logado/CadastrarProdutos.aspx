<%@ Page Title="" Language="C#" MasterPageFile="~/Paginas/Logado/MasterPage.master" AutoEventWireup="true" CodeFile="CadastrarProdutos.aspx.cs" Inherits="Paginas_Logado_CadastrarProdutos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
        <body style="background-image: url('http://localhost:61546/Imagens/mee4.png');"></body>
    <div class="container mt-5">

        <div class="row">
            <div class="col-12 col-md-6">
                <h1>Cadastro de Produtos</h1>
                <hr />
                <label>Nome:</label>
                <asp:TextBox ID="txtNomeP" runat="server" placeholder="Nome" CssClass="form-control"></asp:TextBox><br />
                <br />
                <label>Descricao:</label>
                <asp:TextBox ID="txtDescricaoP" runat="server" placeholder="Descrição" CssClass="form-control"></asp:TextBox><br />
                <br />
                <label>Valor:</label>
                <asp:TextBox ID="txtValorP" runat="server" placeholder="Valor" CssClass="form-control"></asp:TextBox><br />
                <br />


                <asp:Button ID="btnCadastrarP" CssClass="btn btn-primary btn-dark" runat="server" Text="CADASTRAR" OnClick="btnCadastrarP_Click" />&nbsp;<asp:Button ID="btnPesquisar" CssClass="btn btn-primary btn-dark" runat="server" Text="PESQUISAR" OnClick="btnPesquisar_Click" /><br />
                <br />
                <br />
                <asp:Label ID="lblMsgP" runat="server"></asp:Label>
                <br />
                <hr />
            </div>
        </div>
    </div>
</asp:Content>
