using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Paginas_Logado_ItensPedido : System.Web.UI.Page
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
        DataSet ds = ItensBD.SelectJoinUsuario();
        rpt.DataSource = ds;
        rpt.DataBind();
    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        Button btn = (sender as Button);
        string[] arr = btn.CommandArgument.ToString().Split('|');

        txtCodigo.Text = arr[0];
        txtValor.Text = arr[1];
        txtQuantidade.Text = arr[2];
        ddlProdutoI.Text = arr[3];
        ddlPedidoI.Text = arr[4];


        Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "<script>$('#ModalEditar').modal('show');</script>", false);
    }

    protected void btnEditModal_Click(object sender, EventArgs e)
    {
        Itens i = new Itens();
        i.Pro_ped_codigo = Convert.ToInt32(txtCodigo.Text);
        i.Pro_ped_valor = Convert.ToDouble(txtValor.Text);
        i.Pro_ped_quantidade = Convert.ToInt32(txtQuantidade.Text);

        Produtos pro = new Produtos();
        pro.Codigo = Convert.ToInt32(ddlProdutoI.SelectedValue);
        i.Pro_codigo = pro;

        Pedidos ped = new Pedidos();
        ped.Ped_codigo= Convert.ToInt32(ddlPedidoI.SelectedValue);
        i.Ped_codigo = ped;

        switch (ItensBD.Update(i))
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
        ltlDeletar.Text += "Código: " + arr[0] +  "</p>";
        ltlCodigo.Text = arr[0];

        Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "<script>$('#ModalDeletar').modal('show');</script>", false);
    }

    protected void btnDeleteModal_Click(object sender, EventArgs e)
    {

        switch (ItensBD.Delete(Convert.ToInt32(ltlCodigo.Text)))
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

        DataSet ds = ProdutosBD.SelecionarTodos();
        ddlProdutoI.DataSource = ds;
        ddlProdutoI.DataTextField = "pro_nome";
        ddlProdutoI.DataValueField = "pro_codigo";
        ddlProdutoI.DataBind();

        ds = PedidosBD.SelecionarTodos();
        ddlPedidoI.DataSource = ds;
        ddlPedidoI.DataTextField = "ped_codigo";
        ddlPedidoI.DataValueField = "ped_codigo";
        ddlPedidoI.DataBind();
    }
}