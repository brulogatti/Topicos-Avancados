using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjAula4
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEstados_Click(object sender, EventArgs e)
        {
            Response.Redirect("CadastroEstado.aspx");
        }

        protected void btnCidades_Click(object sender, EventArgs e)
        {
            Response.Redirect("CadastroCidade.aspx");
        }
    }
}