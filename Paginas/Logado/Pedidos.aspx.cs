using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Paginas_Logado_Pedidos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CarregarRepeat();
            CarregarDDL();
        }


    }

    private void CarregarRepeat()
    {
        DataSet ds = PedidosBD.SelectJoinUsuario();
        
        rpt.DataSource = ds;
        rpt.DataBind();
    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        Button btn = (sender as Button);
        string[] arr = btn.CommandArgument.ToString().Split('|');

        txtCodigoPe.Text = arr[0];
        txtDataPe.Text = arr[1];
        txtFretePe.Text = arr[2];
        txtTempoPe.Text = arr[3];
        ddlUsuarioPe.SelectedValue = arr[4];
        ddlClientePe.SelectedValue = arr[5];


        Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "<script>$('#ModalEditar').modal('show');</script>", false);
    }

    protected void btnEditModal_Click(object sender, EventArgs e)
    {
        Pedidos pe = new Pedidos();
        pe.Ped_codigo = Convert.ToInt32(txtCodigoPe.Text);
        pe.Ped_data = txtDataPe.Text;
        pe.Ped_frete = txtFretePe.Text;
        pe.Ped_tempo = txtTempoPe.Text;

        Usuarios u = new Usuarios();
        u.Codigo = Convert.ToInt32(ddlUsuarioPe.SelectedValue);
        pe.Usu_codigo = u;
 
        Clientes c = new Clientes();
        c.Codigo = Convert.ToInt32(ddlClientePe.SelectedValue);
        pe.Cli_codigo = c;



        switch (PedidosBD.Update(pe))
        {
            case 0:
                ltlMSG.Text = "<p class='text-success'> Cadastro editado com sucesso! </p>";
                CarregarRepeat();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "<script>$('#modalMSG').modal('show');</script>", false);
                break;
            case -2:
                ltlMSG.Text = "<p class='text-danger'> Não foi possível editar o registro!</p>";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "<script>$('#modalMSG').modal('show');</script>", false);
                break;
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        Button btn = (sender as Button);
        string[] arr = btn.CommandArgument.ToString().Split('|');

        ltlDeletar.Text = "<p class='text-danger'>Deseja realmente deletar o registro:<br/>";
        ltlDeletar.Text += "Código: " + arr[0]  + "</p>";
        ltlCodigo.Text = arr[0];

        Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "<script>$('#ModalDeletar').modal('show');</script>", false);
    }

    protected void btnDeleteModal_Click(object sender, EventArgs e)
    {

        switch (PedidosBD.Delete(Convert.ToInt32(ltlCodigo.Text)))
        {
            case 0:
                ltlMSG.Text = "<p class='text-success'> Registro deletado com sucesso! </p>";
                CarregarRepeat();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "<script>$('#modalMSG').modal('show');</script>", false);
                break;
            case -2:
                ltlMSG.Text = "<p class='text-danger'> Não foi possível Deletar o registro!</p>";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "<script>$('#modalMSG').modal('show');</script>", false);
                break;
        }

    }
    protected void CarregarDDL()
    {

        DataSet ds = UsuariosBD.SelecionarTodos();
        ddlUsuarioPe.DataSource = ds;
        ddlUsuarioPe.DataTextField = "usu_nome";
        ddlUsuarioPe.DataValueField = "usu_codigo";
        ddlUsuarioPe.DataBind();

        ds = ClientesBD.SelecionarTodos();
        ddlClientePe.DataSource = ds;
        ddlClientePe.DataTextField = "cli_nome";
        ddlClientePe.DataValueField = "cli_codigo";
        ddlClientePe.DataBind();
    }
}