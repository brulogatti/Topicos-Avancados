using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplicationTarefa
{
    public partial class Projeto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregarDadosPg();
            }
        }

        protected void btnCadastrarproj_Click(object sender, EventArgs e)
        {
            if (txtdataimpl.Text == "" || txtdatainicio.Text == "" || txtdatateste.Text == "" || txtDescricaoProj.Text == "" || txtobs.Text == "" || txtqtd.Text == "" || txttel1.Text == "" || txttel2.Text == "")
            {
                lblmsg.Text = "Preencha os campos!";
            }
            else
            {
                string descricaoProjeto = txtDescricaoProj.Text;
                DateTime dtinicio = Convert.ToDateTime(txtdatainicio.Text);
                DateTime dtteste = Convert.ToDateTime(txtdatateste.Text);
                DateTime dtimplantacao = Convert.ToDateTime(txtdataimpl.Text);
                int qtd = Convert.ToInt32(txtqtd.Text);
                string contato1 = txttel1.Text;
                string contato2 = txttel2.Text;
                string obs = txtobs.Text;
                TB_PROJETO p = new TB_PROJETO() { descricao = descricaoProjeto, dtiniprojeto = dtinicio, dtimplantado = dtimplantacao, dtteste = dtteste, qtdpessoas = qtd, contatotel1 = contato1, contatotel2 = contato2, observacao = obs };
                TarefaEntities1 contextProjeto = new TarefaEntities1();

                string valor = Request.QueryString["idItem"];

                if (String.IsNullOrEmpty(valor))
                {
                    contextProjeto.TB_PROJETO.Add(p);
                    lblmsg.Text = "Registro Inserido!";
                    Clear();
                }
                else
                {
                    int id = Convert.ToInt32(valor);
                    TB_PROJETO projeto = contextProjeto.TB_PROJETO.First(c => c.id == id);
                    projeto.descricao = p.descricao;
                    projeto.dtiniprojeto = p.dtiniprojeto;
                    projeto.dtimplantado = p.dtimplantado;
                    projeto.dtteste = p.dtteste;
                    projeto.contatotel1 = p.contatotel1;
                    projeto.contatotel2 = p.contatotel2;
                    projeto.qtdpessoas = p.qtdpessoas;
                    projeto.observacao = p.observacao;
                    lblmsg.Text = "Registro Alterado!";
                }
                contextProjeto.SaveChanges();
            }
        }

        private void Clear()
        {
            txtdataimpl.Text = "";
            txtdatainicio.Text = "";
            txtdatateste.Text = "";
            txtDescricaoProj.Text = "";
            txtobs.Text = "";
            txtqtd.Text = "";
            txttel1.Text = "";
            txttel2.Text = "";
            txtDescricaoProj.Focus();
        }

        private void CarregarDadosPg()
        {
            string valor = Request.QueryString["idItem"];
            int idItem = 0;
            TB_PROJETO projeto = new TB_PROJETO();
            TarefaEntities1 contextProjeto = new TarefaEntities1();

            if (!String.IsNullOrEmpty(valor))
            {
                idItem = Convert.ToInt32(valor);
                projeto = contextProjeto.TB_PROJETO.First(c => c.id == idItem);

                txtDescricaoProj.Text = projeto.descricao;
                txtdatainicio.Text = projeto.dtiniprojeto.ToString();
                txtdataimpl.Text = projeto.dtimplantado.ToString();
                txtdatateste.Text = projeto.dtteste.ToString();
                txttel1.Text = projeto.contatotel1;
                txttel2.Text = projeto.contatotel2;
                txtqtd.Text = projeto.qtdpessoas.ToString();
                txtobs.Text = projeto.observacao;

            }
        }
    }
}