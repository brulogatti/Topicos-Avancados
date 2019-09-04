using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplicationInstrumentos
{
    public partial class formulario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            InstrumentosEntities context = new InstrumentosEntities();

            List<dados> lstDados = context.dados.ToList<dados>();

            GVDados.DataSource = lstDados;
            GVDados.DataBind();
        }

        protected void btnsalvar_Click(object sender, EventArgs e)
        {
            if(txtdatafab.Text.Length==0 || txtfamilia.Text.Length==0 || txtnome.Text.Length==0 || txttipo.Text.Length==0)
            {
                lblmsg.Text = "Campos em Branco!";
            } else
            {
                String datafab;
                datafab = txtdatafab.Text;
                DateTime parsedDatafab = DateTime.Parse(datafab);

                dados dados = new dados()
                {
                    nome = txtnome.Text,
                    tipo = txttipo.Text,
                    familia = txtfamilia.Text,
                    data_fab = parsedDatafab
                };

                InstrumentosEntities context = new InstrumentosEntities();

                //Inserindo as informações no banco de dados
                context.dados.Add(dados);

                //Efetiva a inclusão da informação na base de dados
                context.SaveChanges();

                List<dados> lstDados = context.dados.ToList<dados>();

                GVDados.DataSource = lstDados;
                GVDados.DataBind();

                lblmsg.Text = "Registro inserido com sucesso";
            }

            
        }

     
    }
}