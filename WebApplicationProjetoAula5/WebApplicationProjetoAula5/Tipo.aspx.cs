using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplicationProjetoAula5
{
    public partial class Tipo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregarDadosPagina();
            }
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            string descricao = txtdescricaotipo.Text;
            TIPO tip = new TIPO() { descricao = descricao };
            Aula5Entities contextAula5 = new Aula5Entities();

            string valor = Request.QueryString["idItem"];

            if (String.IsNullOrEmpty(valor))
            {
                contextAula5.TIPO.Add(tip);
                lblmsg.Text = "Registro Inserido!";
            }
            else
            {
                int id = Convert.ToInt32(valor);
                TIPO tipo = contextAula5.TIPO.First(c => c.id == id);
                tipo.id = tip.id;
                tipo.descricao = tip.descricao;
                lblmsg.Text = "Registro Alterado!";
            };
        }

        private void CarregarDadosPagina()
        {
            string valor = Request.QueryString["idItem"];
            int idItem = 0;
            TIPO tipo = new TIPO();
            Aula5Entities contextTipo = new Aula5Entities();
            if (!String.IsNullOrEmpty(valor))
            {
                idItem = Convert.ToInt32(valor);
                tipo = contextTipo.TIPO.First(c => c.id == idItem);
                txtdescricaotipo.Text = tipo.descricao;
            }
        }
    }
}