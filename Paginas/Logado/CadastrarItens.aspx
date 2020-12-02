<%@ Page Title="" Language="C#" MasterPageFile="~/Paginas/Logado/MasterPage.master" AutoEventWireup="true" CodeFile="CadastrarItens.aspx.cs" Inherits="Paginas_Logado_CadastrarItens" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
        <body style="background-image: url('http://localhost:61546/Imagens/mee4.png');"></body>
    <div class="container mt-5">
        <div class="row">
            <div class="col-12 col-md-6">
                <h1>Cadastro de Itens do Pedido:</h1>
                <hr />
                <label>Valor:</label>
                <asp:TextBox ID="txtValorI" runat="server" placeholder="Valor" CssClass="form-control"></asp:TextBox><br />
                <br />
                <label>Quantidade:</label>
                <asp:TextBox ID="txtQuantidadeI"  runat="server" placeholder="Quantidade" CssClass="form-control"></asp:TextBox>
                <br />
                <label>Produto:</label>
                <asp:DropDownList ID="ddlProduto" runat="server" placeholder="Produto" CssClass="form-control"></asp:DropDownList><br />
                <br />
                <label>Pedido:</label>
                <asp:DropDownList ID="ddlPedido" runat="server" placeholder="Pedido" CssClass="form-control"></asp:DropDownList><br />
                <br />
                <asp:Button ID="btnCadastrarI" runat="server" CssClass="btn btn-primary btn-dark" Text="CADASTRAR" OnClick="btnCadastrarI_Click" />&nbsp;<asp:Button ID="btnPesquisar" CssClass="btn btn-primary btn-dark" runat="server" Text="PESQUISAR" OnClick="btnPesquisar_Click" /><br />
                <br />
                   <section class="container">

 

        <div class="row">

 

            <asp:Repeater runat="server" ID="repeat">
                <ItemTemplate>



                </ItemTemplate>
            </asp:Repeater>
            <!---- -->

 

 

 

        </div>

 

    </section>

                <asp:Label ID="lblMsgI" runat="server"></asp:Label>
                <br />
                <hr />
                <br />
            </div>
        </div>
    </div>
</asp:Content>