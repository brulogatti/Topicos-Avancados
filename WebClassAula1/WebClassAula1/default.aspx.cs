using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebClassAula1
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Aula2Entities context = new Aula2Entities();

            List<dados> lstDados = context.dados.ToList<dados>();

            GVDados.DataSource = lstDados;
            GVDados.DataBind();

        }

        protected void btnsalvar_Click(object sender, EventArgs e)
        {
            dados dados = new dados()
            {
                nome=txtnome.Text,
                telefone=txttelefone.Text
            };

            Aula2Entities context = new Aula2Entities();

            //Inserindo as informações no banco de dados
            context.dados.Add(dados);

            //Efetiva a inclusão da informação na base de dados
            context.SaveChanges();

            lblmsg.Text = "Registro inserido com sucesso!";

            List<dados> lstDados = context.dados.ToList<dados>();

            GVDados.DataSource = lstDados;
            GVDados.DataBind();

        }
    }
}