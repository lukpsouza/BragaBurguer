using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Paginas_Logado_CadastrarItens : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CarregarDDL();
        }
        CarregarRepeat();
    }



    protected void btnCadastrarI_Click(object sender, EventArgs e)
    {



        Itens it = new Itens();
        it.Pro_ped_valor = Convert.ToDouble(txtValorI.Text);
        it.Pro_ped_quantidade = Convert.ToInt32(txtQuantidadeI.Text);



        // FK
        Produtos pro = new Produtos();
        pro.Codigo = Convert.ToInt32(ddlProduto.SelectedValue);
        it.Pro_codigo = pro;

        Pedidos ped = new Pedidos();
        ped.Ped_codigo = Convert.ToInt32(ddlPedido.SelectedValue);
        it.Ped_codigo = ped;



        switch (ItensBD.Inserir(it))
        {
            case 0:
                lblMsgI.Text = "<div class='alert alert-success'> OK </div>";
                CarregarRepeat();
                break;
            case -2:
                lblMsgI.Text = "<div class='alert alert-danger'> ERRO </div>";
                break;
        }




    }



    protected void CarregarDDL()
    {

        DataSet ds = ProdutosBD.SelecionarTodos();
        ddlProduto.DataSource = ds;
        ddlProduto.DataTextField = "pro_nome";
        ddlProduto.DataValueField = "pro_codigo";
        ddlProduto.DataBind();

        ds = PedidosBD.SelecionarTodos();
        ddlPedido.DataSource = ds;
        ddlPedido.DataTextField = "ped_codigo";
        ddlPedido.DataValueField = "ped_codigo";
        ddlPedido.DataBind();
    }



    private void CarregarRepeat()
    {
        DataSet ds = ItensBD.SelectJoinUsuario();
        repeat.DataSource = ds;
        repeat.DataBind();
    }

    protected void btnPesquisar_Click(object sender, EventArgs e)
    {
        Response.Redirect("ItensPedido.aspx");
    }


}
