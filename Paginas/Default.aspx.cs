using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Paginas_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        if (!String.IsNullOrEmpty(txtEmail.Text) && !String.IsNullOrEmpty(txtSenha.Text))
        {

            Usuarios usu = UsuariosBD.Login(txtEmail.Text, txtSenha.Text);
            if(usu != null)
            {
                Session["USUARIO"] = usu;
                Response.Redirect("Logado/Default.aspx");
            }
            else
            {
                lblMsg.Text = "Usuário não encontrado. E-mail ou senha inválidos...";
            }
        }
    }
}