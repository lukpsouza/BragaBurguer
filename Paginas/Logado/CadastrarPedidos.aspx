<%@ Page Title="" Language="C#" MasterPageFile="~/Paginas/Logado/MasterPage.master" AutoEventWireup="true" CodeFile="CadastrarPedidos.aspx.cs" Inherits="Paginas_Logado_CadastrarPedidos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
        <body></body>
    <div class="container mt-5">
        <div class="row">
            <div class="col-12 col-md-6">
                <h1>Cadastro de Pedidos:</h1>
                <hr />
                <label>Data:</label>
                <asp:TextBox ID="txtDataPe" type="date" runat="server" CssClass="form-control"></asp:TextBox>
                <br />
                <label>Frete:</label>
                <asp:TextBox ID="txtFretePe" runat="server" placeholder="Frete" CssClass="form-control"></asp:TextBox><br />
                <br />
                <label>Tempo:</label>
                <asp:TextBox ID="txtTempoPe" runat="server" placeholder="Total" CssClass="form-control"></asp:TextBox><br />
                <br />
                <label>Cliente:</label>
                <asp:DropDownList ID="ddlCliente" runat="server" placeholder="Total" CssClass="form-control"></asp:DropDownList><br />
                <br />
                <label>Usuario:</label>
                <asp:DropDownList ID="ddlUsuario" runat="server" placeholder="Total" CssClass="form-control"></asp:DropDownList><br />
                <br />
                <asp:Button ID="btnCadastrarPe" runat="server" CssClass="btn btn-primary btn-dark" Text="CADASTRAR" OnClick="btnCadastrarPe_Click" />&nbsp;<asp:Button ID="btnPesquisar" CssClass="btn btn-primary btn-dark" runat="server" Text="PESQUISAR" OnClick="btnPesquisar_Click" />&nbsp;<br />
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

                <asp:Label ID="lblMsgPe" runat="server"></asp:Label>
                <br />
                <hr />
                <br />
            </div>
        </div>
    </div>
</asp:Content>
