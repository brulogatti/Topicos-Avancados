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
            LoadGrid();
            if (!IsPostBack)
            {
                CarregarDadosPagina();
            }
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (txtcidade.Text == "" || txtnome.Text == "" || txttelefone.Text == "" || txtcidade.Text == "" || txtCPF.Text == "" || txtendereco.Text == "")
            {
                lblmsg.Text = "Preencha todos os campos!";
            }
            else
            {

                string nome = txtnome.Text;
                string telefone = txttelefone.Text;
                string cidade = txtcidade.Text;
                string endereco = txtendereco.Text;
                Int64 cpf = Convert.ToInt64(txtCPF.Text.ToString().Substring(0, 9));
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
                    cliente.nome = cli.nome;
                    cliente.telefone = cli.telefone;
                    cliente.endereco = cli.endereco;
                    cliente.cidade = cli.cidade;
                    cliente.cpf = cli.cpf;
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
            CLIENTE cliente = new CLIENTE();
            Aula5Entities contextCli = new Aula5Entities();
            if (!String.IsNullOrEmpty(valor))
            {
                idItem = Convert.ToInt32(valor);
                cliente = contextCli.CLIENTE.First(c => c.id == idItem);
                txtnome.Text = cliente.nome;
                txttelefone.Text = cliente.telefone;
                txtcidade.Text = cliente.cidade;
                txtendereco.Text = cliente.endereco;
                txtCPF.Text = Convert.ToString(cliente.cpf);
            }
        }

        private void LoadGrid()
        {
            Aula5Entities context = new Aula5Entities();
            List<CLIENTE> lstcliente = context.CLIENTE.ToList<CLIENTE>();
            int cont = 0;
            do
            {
                foreach (var item in lstcliente)
                {
                    string cpf = Convert.ToString(item.cpf.Value);
                    string digito = IsCpf(cpf);

                    item.cpf = Convert.ToInt64((cpf + digito).Substring(0,11));
                }
                cont++;
            } while (cont <= (lstcliente.Count) + 1);


            GVCliente.DataSource = lstcliente;
            GVCliente.DataBind();
        }

        public static string IsCpf(String cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");

            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return digito;
        }
    }
}