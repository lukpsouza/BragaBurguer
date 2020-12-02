using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Paginas_Logado_CadastrarClientes : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnCadastrarC_Click(object sender, EventArgs e)
    {
        string ul = "<ul>";

        if (String.IsNullOrEmpty(txtNomeC.Text))
            ul += "<li> Preencha o nome do Cliente</li>";

        if (String.IsNullOrEmpty(txtEnderecoC.Text))
            ul += "<li> Preencha o Endereço do Cliente</li>";

        if (string.IsNullOrEmpty(txtTelefoneC.Text))
            ul += "<li> Preencha o Telefone do Cliente</li>";

        if (string.IsNullOrEmpty(txtQuantidadeC.Text))
            ul += "<li> Preencha a Quantidade de Compras do Cliente</li>";

        ul += "</ul>";

        if (ul == "<ul></ul>")
        {
            Clientes c = new Clientes();
            c.Nome = txtNomeC.Text;
            c.Codigo = 1;
            c.Telefone = txtTelefoneC.Text;
            c.Endereco = txtEnderecoC.Text;
            c.Quantidade = txtQuantidadeC.Text;

            if (ClientesBD.Inserir(c) == 0)
            {
                lblMsgC.Text = "Cadastrado com sucesso!";
                txtNomeC.Text = "";
                txtEnderecoC.Text = "";
                txtTelefoneC.Text = "";
                txtQuantidadeC.Text = "";
                txtNomeC.Focus();
            }
            else
            {
                lblMsgC.Text = "Houve um B.O para cadastrar o usuário";
            }
        }
        else
        {
            lblMsgC.Text = ul;
        }


    }

    protected void btnPesquisar_Click(object sender, EventArgs e)
    {
        Response.Redirect("Clientes.aspx");
    }

}