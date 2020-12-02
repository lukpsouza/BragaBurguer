using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Paginas_Logado_CadastrarPedidos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CarregarDDL();
        }
        CarregarRepeat();


    }



    protected void btnCadastrarPe_Click(object sender, EventArgs e)
    {

       


        Pedidos ped = new Pedidos();
        ped.Ped_data = txtDataPe.Text;
        ped.Ped_frete = txtFretePe.Text;
        ped.Ped_tempo = txtTempoPe.Text;



        // FK
        Usuarios u = new Usuarios();
        u.Codigo = Convert.ToInt32(ddlUsuario.SelectedValue);
        ped.Usu_codigo = u;

        Clientes c = new Clientes();
        c.Codigo = Convert.ToInt32(ddlCliente.SelectedValue);
        ped.Cli_codigo = c;



        switch (PedidosBD.Inserir(ped))
        {
            case 0:
                lblMsgPe.Text = "<div class='alert alert-success'> OK </div>";
                CarregarRepeat();
                Response.Redirect("CadastrarItens.aspx");
                break;
            case -2:
                lblMsgPe.Text = "<div class='alert alert-danger'> ERRO </div>";
                break;
        }




    }



    protected void CarregarDDL()
    {

        DataSet ds = UsuariosBD.SelecionarTodos();
        ddlUsuario.DataSource = ds;
        ddlUsuario.DataTextField = "usu_nome";
        ddlUsuario.DataValueField = "usu_codigo";
        ddlUsuario.DataBind();

        ds = ClientesBD.SelecionarTodos();
        ddlCliente.DataSource = ds;
        ddlCliente.DataTextField = "cli_nome";
        ddlCliente.DataValueField = "cli_codigo";
        ddlCliente.DataBind();
    }



    private void CarregarRepeat()
    {
        DataSet ds = PedidosBD.SelectJoinUsuario();
        repeat.DataSource = ds;
        repeat.DataBind();
    }

    protected void btnPesquisar_Click(object sender, EventArgs e)
    {
        Response.Redirect("Pedidos.aspx");
    }

}
