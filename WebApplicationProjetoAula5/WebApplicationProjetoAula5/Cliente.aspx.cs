using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplicationProjetoAula5
{
    public partial class Cliente : System.Web.UI.Page
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
            string nome = txtnome.Text;
            string telefone = txttelefone.Text;
            string cidade = txtcidade.Text;
            string endereco = txtendereco.Text;
            int cpf = Convert.ToInt32(txtCPF.Text);
            CLIENTE cli = new CLIENTE() { nome = nome, telefone = telefone, cidade = cidade, endereco = endereco, cpf = cpf };
            Aula5Entities contextAula5 = new Aula5Entities();

            string valor = Request.QueryString["idItem"];

            if (String.IsNullOrEmpty(valor))
            {
                contextAula5.CLIENTE.Add(cli);
                lblmsg.Text = "Registro Inserido!";
            }
            else
            {
                int id = Convert.ToInt32(valor);
                CLIENTE cliente = contextAula5.CLIENTE.First(c => c.id == id);
                cliente.id = cli.id;
                cliente.nome = cli.nome;
                cliente.telefone = cli.telefone;
                cliente.endereco = cli.endereco;
                cliente.cidade = cli.cidade;
                lblmsg.Text = "Registro Alterado!";
            };
        }

        private void CarregarDadosPagina()
        {
            string valor = Request.QueryString["idItem"];
            int idItem = 0;
            CLIENTE cliente = new CLIENTE();
            Aula5Entities contextTipo = new Aula5Entities();
            if (!String.IsNullOrEmpty(valor))
            {
                idItem = Convert.ToInt32(valor);
                cliente = contextTipo.CLIENTE.First(c => c.id == idItem);
                txtnome.Text = cliente.nome;
                txttelefone.Text = cliente.telefone;
                txtcidade.Text = cliente.cidade;
                txtendereco.Text = cliente.endereco;
                txtCPF.Text = Convert.ToString(cliente.cpf);
            }
        }
    }
}