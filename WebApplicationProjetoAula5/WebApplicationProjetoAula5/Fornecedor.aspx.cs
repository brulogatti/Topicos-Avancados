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
            LoadGrid();
            if (!IsPostBack)
            {
                CarregarDadosPagina();
            }
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (txtcidade.Text == "" || txtnome.Text == "" || txttelefone.Text == "" || txtcidade.Text == "" || txtCNPJ.Text == "" || txtendereco.Text == "")
            {
                lblmsg.Text = "Preencha todos os campos!";
            }
            else
            {

                string nome = txtnome.Text;
                string telefone = txttelefone.Text;
                string cidade = txtcidade.Text;
                string endereco = txtendereco.Text;
                Int64 cnpj = Convert.ToInt64(txtCNPJ.Text.ToString().Substring(0, 8));
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
                    fornecedor.nome = f.nome;
                    fornecedor.telefone = f.telefone;
                    fornecedor.endereco = f.endereco;
                    fornecedor.cidade = f.cidade;
                    fornecedor.cnpj = f.cnpj;
                    lblmsg.Text = "Registro Alterado!";
                };

                contextAula5.SaveChanges();
                LoadGrid();
            }
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

        private void LoadGrid()
        {
            Aula5Entities context = new Aula5Entities();
            List<FORNECEDOR> lstfornecedor = context.FORNECEDOR.ToList<FORNECEDOR>();

            foreach (var item in lstfornecedor)
            {
                string cnpj = Convert.ToString(item.cnpj.Value);
                cnpj = cnpj + "0001";
                string digito = IsCnpj(cnpj);
                
                item.cnpj = Convert.ToInt64(cnpj + digito);
            }

            GVFornecedor.DataSource = lstfornecedor;
            GVFornecedor.DataBind();
        }

        public static string IsCnpj(String cnpj)
        {
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;
            string digito;
            string tempCnpj;
            cnpj = cnpj.Trim();
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");

            tempCnpj = cnpj.Substring(0, 12);
            soma = 0;
            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCnpj = tempCnpj + digito;
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return digito;
        }
    }
}