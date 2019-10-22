using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjEmpresaWCF
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ServicoWCF.ServicoClient wcf = new ServicoWCF.ServicoClient();
            GDdados.DataSource = wcf.Consultar("");
            GDdados.DataBind();
        }

        protected void BtnSalvar_Click(object sender, EventArgs e)
        {
            if (txtnome.Text==""||txtqtd.Text==""||txtendereco.Text=="")
            {
                lblmsg.Text = "Preencha os campos!";
            }
            else
            {
                string nome = txtnome.Text;
                string endereco = txtendereco.Text;
                int qtdfuncionarios = Convert.ToInt32(txtqtd.Text);

                TB_CADASTRO t = new TB_CADASTRO() { NOME = nome, QTDFUNCIONARIOS = qtdfuncionarios, ENDERECO = endereco };
                EmpresaEntities contextEmpresa = new EmpresaEntities();

                string valor = Request.QueryString["idItem"];

                if (String.IsNullOrEmpty(valor))
                {
                    contextEmpresa.TB_CADASTRO.Add(t);
                    lblmsg.Text = "Registro Inserido!";
                    contextEmpresa.SaveChanges();
                    ServicoWCF.ServicoClient wcf = new ServicoWCF.ServicoClient();
                    GDdados.DataSource = wcf.Consultar("");
                    GDdados.DataBind();
                }
            }
        }
        protected void BtnConsulta_Click(object sender, EventArgs e)
        {
            ServicoWCF.EntTesteCadastro objCliente = new ServicoWCF.EntTesteCadastro();
            objCliente.Nome = txtconsulta.Text;
            ServicoWCF.ServicoClient wcf = new ServicoWCF.ServicoClient();
            GDconsulta.DataSource = wcf.Consultar(txtconsulta.Text);
            GDconsulta.DataBind();
        }
    }
}