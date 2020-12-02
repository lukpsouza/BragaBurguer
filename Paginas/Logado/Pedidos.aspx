<%@ Page Title="" Language="C#" MasterPageFile="~/Paginas/Logado/MasterPage.master" AutoEventWireup="true" CodeFile="Pedidos.aspx.cs" Inherits="Paginas_Logado_Pedidos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
   

  <div class="container mt-5">
        <div class="row">
            <div class="col-12 text-center">
                <h1>Lista de Pedidos:</h1>
                <h1></h1>
                <hr />
            </div>
            <div class="col-12">

                <table class="table table-hover">
                    <tr class="bg-dark text-white">
                        <td>Codigo</td>
                        <td>Data</td>
                        <td>Frete</td>
                        <td>Tempo</td>
                        <td>Usuario</td>
                        <td>Cliente</td>
                        <td>Editar</td>
                        <td>Deletar</td>
                    </tr>

                    <asp:Repeater ID="rpt" runat="server">
                        <ItemTemplate>

                            <tr>
                                <td> <%# Eval("ped_codigo") %> </td>
                                <td> <%# Eval("ped_data") %> </td>
                                <td> <%# Eval("ped_frete") %> </td>
                                <td> <%# Eval("ped_tempo") %> </td>
                                <td> <%# Eval("usu_nome") %> </td>
                                <td> <%# Eval("cli_nome") %> </td>
                                <td> <asp:Button runat="server" ID="btnEditar" Text="Editar" CssClass="btn btn-warning" OnClick="btnEdit_Click" CommandArgument='<%#Eval("ped_codigo") + "|" +Eval("ped_data") + "|" + Eval("ped_frete")  + "|"  + Eval("ped_tempo") + "|" + Eval("usu_codigo") + "|"  + Eval("cli_codigo")  %>'  /> </td>
                                <td> <asp:Button runat="server" ID="btnDelete" Text="Deletar" CssClass="btn btn-danger" OnClick="btnDelete_Click" CommandArgument='<%#Eval("ped_codigo") + "|" +Eval("ped_data") + "|" + Eval("ped_frete") +  "|"  + Eval("ped_tempo") + "|" + Eval("usu_codigo") + "|"  + Eval("cli_codigo")  %>'  /> </td>
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
                            <label>Codigo</label>
                            <asp:TextBox runat="server" ID="txtCodigoPe" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                        </div>
                        <div class="col-12 col-md-4">
                            <label>Data</label>
                            <asp:TextBox runat="server" ID="txtDataPe" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                        </div>
                        <div class="col-12 col-md-8">
                            <label>Frete</label>
                            <asp:TextBox runat="server" ID="txtFretePe" CssClass="form-control"></asp:TextBox>
                        </div>
                            <div class="col-12 col-md-8">
                            <label>Tempo</label>
                            <asp:TextBox runat="server" ID="txtTempoPe" CssClass="form-control"></asp:TextBox>
                        </div>
                             <div class="col-12 col-md-8">
                            <label>Usuario</label>
                            <asp:DropDownList runat="server" ID="ddlUsuarioPe" CssClass="form-control"></asp:DropDownList>
                        </div>
                           <div class="col-12 col-md-8">
                            <label>Cliente</label>
                            <asp:DropDownList runat="server" ID="ddlClientePe" CssClass="form-control"></asp:DropDownList>
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
