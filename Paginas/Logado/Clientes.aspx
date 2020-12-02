<%@ Page Title="" Language="C#" MasterPageFile="~/Paginas/Logado/MasterPage.master" AutoEventWireup="true" CodeFile="Clientes.aspx.cs" Inherits="Paginas_Logado_Clientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
   

  <div class="container mt-5">
        <div class="row">
            <div class="col-12 text-center">
                                <h1>Lista de Clientes:</h1>
                <h1></h1>
                <hr />
            </div>
            <div class="col-12">

                <table class="table table-hover">
                    <tr class="bg-dark text-white">
                        <td>Código</td>
                        <td>Nome</td>
                        <td>Telefone</td>
                        <td>Endereco</td>
                        <td>Quantidade</td>
                        <td>Editar</td>
                        <td>Deletar</td>

                    </tr>

                    <asp:Repeater ID="rpt" runat="server">
                        <ItemTemplate>

                            <tr>
                                <td> <%# Eval("cli_codigo") %> </td>
                                <td> <%# Eval("cli_nome") %> </td>
                                <td> <%# Eval("cli_telefone") %> </td>
                                <td> <%# Eval("cli_endereco") %> </td>
                                <td> <%# Eval("cli_quantidade") %> </td>
                                <td> <asp:Button runat="server" ID="btnEditar" Text="Editar" CssClass="btn btn-warning" OnClick="btnEdit_Click" CommandArgument='<%#Eval("cli_codigo") + "|" + Eval("cli_nome") + "|" + Eval("cli_telefone") + "|" + Eval("cli_endereco") + "|" + Eval("cli_quantidade") %>'  /> </td>
                                <td> <asp:Button runat="server" ID="btnDelete" Text="Deletar" CssClass="btn btn-danger" OnClick="btnDelete_Click" CommandArgument='<%#Eval("cli_codigo") + "|" + Eval("cli_nome") + "|" + Eval("cli_telefone") + "|" + Eval("cli_endereco") + "|" + Eval("cli_quantidade") %>'  /> </td>
                            </tr>

                        </ItemTemplate>
                    </asp:Repeater>
                    
                </table>

            </div>


        </div>
    </div>

    <!-- Modal - Editar -->
      <div class="modal fade" id="ModalEditar" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">Update</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                   
                    <div class="row">
                        <div class="col-12 col-md-4">
                            <label>Código</label>
                            <asp:TextBox runat="server" ID="txtCodigo" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                        </div>
                        <div class="col-12 col-md-8">
                            <label>Nome</label>
                            <asp:TextBox runat="server" ID="txtNome" CssClass="form-control"></asp:TextBox>
                        </div>
                           <div class="col-12 col-md-8">
                            <label>Telefone</label>
                            <asp:TextBox runat="server" ID="txtTelefone" CssClass="form-control"></asp:TextBox>
                        </div>
                           <div class="col-12 col-md-8">
                            <label>Endereço</label>
                            <asp:TextBox runat="server" ID="txtEndereco" CssClass="form-control"></asp:TextBox>
                        </div>
                            <div class="col-12 col-md-8">
                            <label>Quantidade</label>
                            <asp:TextBox runat="server" ID="txtQuantidade" CssClass="form-control"></asp:TextBox>
                        </div>
                        </div>

                </div>
                <div class="modal-footer">
                    <asp:Button runat="server" ID="btnEditModal" CssClass="btn btn-danger" Text="Editar" OnClick="btnEditModal_Click" />
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Fechar</button>
                  
                </div>
            </div>
            </div>
        </div>




    <!-- Modal - MSG  -->
         <div class="modal fade" id="modalMSG" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">MSG</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                   
                 <asp:Literal runat="server" ID="ltlMSG"></asp:Literal>

                </div>
                <div class="modal-footer">
                    
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Fechar</button>
                  
                </div>
            </div>
        </div>
    </div>

     <!-- Modal - Deletar -->
      <div class="modal fade" id="ModalDeletar" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">Deletar Registro</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                   
                   <asp:Literal runat="server" ID="ltlDeletar"></asp:Literal>
                   <asp:Label runat="server" ID="ltlCodigo" Visible="false"></asp:Label>

                </div>
                <div class="modal-footer">
                    <asp:Button runat="server" ID="btnDeleteModal" CssClass="btn btn-danger" Text="Deletar" OnClick="btnDeleteModal_Click" />
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Fechar</button>
                  
                </div>
            </div>
        </div>
    </div>




    <script src="../Scripts/jquery-3.5.1.min.js"></script>
    <script src="../Scripts/bootstrap.min.js"></script>
</asp:Content>