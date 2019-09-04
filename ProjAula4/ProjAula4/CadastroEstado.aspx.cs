using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjAula4
{
    public partial class CadastroEstado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadGrid();
        }

        protected void btnsalvar_Click(object sender, EventArgs e)
        {
            ESTADO estado = new ESTADO()
            {
                descricao = txtdescricao.Text
            };

            Aula4Entities context = new Aula4Entities();

            context.ESTADO.Add(estado);
            context.SaveChanges();
            LoadGrid();
            SendMessage("Registro Inserido!");
        }

        private void LoadGrid()
        {
            GVEstado.DataSource = new Aula4Entities().ESTADO.ToList<ESTADO>();
            GVEstado.DataBind();
        }

        private void SendMessage (String txt)
        {
            lblmsg.Text = txt;
        }
    }
}