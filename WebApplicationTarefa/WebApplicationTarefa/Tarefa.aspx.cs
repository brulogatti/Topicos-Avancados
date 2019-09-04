using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplicationTarefa
{
    public partial class Tarefa : System.Web.UI.Page
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
            if (txtdata.Text == "" || txtdataentrega.Text == "" || txtdatalimentrega.Text == "" || txtDescricao.Text == "")
            {
                lblmsg.Text = "Preencha os campos!";
            }
            else
            {
                string descricaoTarefa = txtDescricao.Text;
                DateTime datatarefa = Convert.ToDateTime(txtdata.Text);
                DateTime dataentrega = Convert.ToDateTime(txtdataentrega.Text);
                DateTime datalimentrega = Convert.ToDateTime(txtdatalimentrega.Text);
                TB_TAREFA t = new TB_TAREFA() { descricao = descricaoTarefa, dtatividade = datatarefa, dtentrega = dataentrega, dtlimiteentrega = datalimentrega };
                TarefaEntities contextTarefa = new TarefaEntities();

                string valor = Request.QueryString["idItem"];

                if (String.IsNullOrEmpty(valor))
                {
                    contextTarefa.TB_TAREFA.Add(t);
                    lblmsg.Text = "Registro Inserido!";
                    Diagnostico();
                    Clear();
                }
                else
                {
                    int id = Convert.ToInt32(valor);
                    TB_TAREFA tarefa = contextTarefa.TB_TAREFA.First(c => c.id == id);
                    tarefa.descricao = t.descricao;
                    tarefa.dtatividade = t.dtatividade;
                    tarefa.dtentrega = t.dtentrega;
                    tarefa.dtlimiteentrega = t.dtlimiteentrega;
                    lblmsg.Text = "Registro Alterado!";
                }

                contextTarefa.SaveChanges();
            }
        }

        private void Clear()
        {
            txtdata.Text = "";
            txtdataentrega.Text = "";
            txtdatalimentrega.Text = "";
            txtDescricao.Text = "";
            txtDescricao.Focus();
        }

        private void CarregarDadosPagina()
        {
            string valor = Request.QueryString["idItem"];
            int idItem = 0;
            TB_TAREFA tarefa = new TB_TAREFA();
            TarefaEntities contextTarefa = new TarefaEntities();

            if (!String.IsNullOrEmpty(valor))
            {
                idItem = Convert.ToInt32(valor);
                tarefa = contextTarefa.TB_TAREFA.First(c => c.id == idItem);

                txtDescricao.Text = tarefa.descricao;
                txtdata.Text = tarefa.dtatividade.ToString();
                txtdataentrega.Text = tarefa.dtentrega.ToString();
                txtdatalimentrega.Text = tarefa.dtlimiteentrega.ToString();
            }
        }
     


        private void Diagnostico()
        {

            DateTime dataentrega = Convert.ToDateTime(txtdataentrega.Text);
            DateTime datalimentrega = Convert.ToDateTime(txtdatalimentrega.Text);

            if (dataentrega>datalimentrega)
            {
                lblmsgdiagnostico.Text = "Diagnóstico: Preciso focar algumas horas da semana para poder entregar minhas tarefas!";
            }
            else if(dataentrega == datalimentrega)
            {
                lblmsgdiagnostico.Text = "Diagnóstico: Estou dentro do prazo!";
            }
            else if (dataentrega < datalimentrega)
            {
                lblmsgdiagnostico.Text = "Diagnóstico: Bruto!";
            }
        }
    }
}