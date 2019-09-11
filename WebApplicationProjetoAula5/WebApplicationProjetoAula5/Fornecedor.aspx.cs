using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplicationProjetoAula5
{
    public partial class Fornecedor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            string nome = txtnome.Text;
            string telefone = txttelefone.Text;
            string cidade = txtcidade.Text;
            string endereco = txtendereco.Text;
            int cnpj = Convert.ToInt32(txtCNPJ.Text);
            FORNECEDOR f = new FORNECEDOR() { nome = nome, telefone = telefone, cidade = cidade, endereco = endereco, cnpj = cnpj };
            Aula5Entities contextAula5 = new Aula5Entities();

            string valor = Request.QueryString["idItem"];

            if (String.IsNullOrEmpty(valor))
            {
                contextAula5.FORNECEDOR.Add(f);
                lblmsg.Text = "Registro Inserido!";
            }
            else
            {
                int id = Convert.ToInt32(valor);
                FORNECEDOR fornecedor = contextAula5.FORNECEDOR.First(c => c.id == id);
                fornecedor.id = f.id;
                fornecedor.nome = f.nome;
                fornecedor.telefone = f.telefone;
                fornecedor.endereco = f.endereco;
                fornecedor.cidade = f.cidade;
                fornecedor.cnpj = f.cnpj;
                lblmsg.Text = "Registro Alterado!";
            };
        }

        private void CarregarDadosPagina()
        {
            string valor = Request.QueryString["idItem"];
            int idItem = 0;
            FORNECEDOR fornecedor = new FORNECEDOR();
            Aula5Entities contextFor = new Aula5Entities();
            if (!String.IsNullOrEmpty(valor))
            {
                idItem = Convert.ToInt32(valor);
                fornecedor = contextFor.FORNECEDOR.First(c => c.id == idItem);
                txtnome.Text = fornecedor.nome;
                txttelefone.Text = fornecedor.telefone;
                txtcidade.Text = fornecedor.cidade;
                txtendereco.Text = fornecedor.endereco;
                txtCNPJ.Text = Convert.ToString(fornecedor.cnpj);
            }
        }
    }
}