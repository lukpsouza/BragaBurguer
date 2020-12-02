using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Paginas_Logado_CadastrarProdutos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnCadastrarP_Click(object sender, EventArgs e)
    {
        string ul = "<ul>";

        if (String.IsNullOrEmpty(txtNomeP.Text))
            ul += "<li> Preencha o nome do Produto</li>";

        if (String.IsNullOrEmpty(txtDescricaoP.Text))
            ul += "<li> Preencha a Validade do Produto</li>";

        if (string.IsNullOrEmpty(txtValorP.Text))
            ul += "<li> Insira o valor do Produto</li>";

        ul += "</ul>";

        if (ul == "<ul></ul>")
        {
            Produtos u = new Produtos();
            u.Nome = txtNomeP.Text;
            u.Descricao = txtDescricaoP.Text;
            u.Valor = Convert.ToDouble(txtValorP.Text);


            if (ProdutosBD.Inserir(u) == 0)
            {
                lblMsgP.Text = "Cadastrado com sucesso!";
                txtNomeP.Text = "";
                txtDescricaoP.Text = "";
                txtValorP.Text = "";
                txtNomeP.Focus();


            }
            else
            {
                lblMsgP.Text = "Houve um B.O para cadastrar o usuário";
            }
        }
        else
        {
            lblMsgP.Text = ul;
        }


    }
    protected void btnPesquisar_Click(object sender, EventArgs e)
    {
        Response.Redirect("Produtos.aspx");
    }
}