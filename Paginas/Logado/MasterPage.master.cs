using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Paginas_Logado_MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["USUARIO"] == null)
            Response.Redirect("../default.aspx");

        Usuarios u = (Usuarios) Session["USUARIO"];

        lblNome.Text = u.Nome;
    }

    protected void btnSair_Click(object sender, EventArgs e)
    {
        Session["USUARIO"] = null;
        Response.Redirect("../default.aspx");
    }
}
