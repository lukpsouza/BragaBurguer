using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Paginas_Logado_CadastrarUsuario : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnCadastrar_Click(object sender, EventArgs e)
    {
        string ul = "<ul>";

        if (String.IsNullOrEmpty(txtEmail.Text))
            ul += "<li> Preencha o e-mail</li>";

        if (String.IsNullOrEmpty(txtNome.Text))
            ul += "<li> Preencha o nome</li>";

        if (string.IsNullOrEmpty(txtSenha.Text))
            ul += "<li> Preencha o senha</li>";

        ul += "</ul>";

        if (ul == "<ul></ul>")
        {
            Usuarios u = new Usuarios();
            u.Nome = txtNome.Text;
            u.Ativo = 1;
            u.Email = txtEmail.Text;
            u.Senha = txtSenha.Text;

            if (UsuariosBD.Inserir(u) == 0)
            {
                lblMsg.Text = "Cadastrado com sucesso!";
                txtSenha.Text = "";
                txtEmail.Text = "";
                txtNome.Text = "";
                txtNome.Focus();
            }
            else
            {
                lblMsg.Text = "Houve um B.O para cadastrar o usuário";
            }
        }
        else
        {
            lblMsg.Text = ul;
        }


    }

    protected void btnPesquisar_Click(object sender, EventArgs e)
    {
        Response.Redirect("UsuariosEdit.aspx");
    }
}