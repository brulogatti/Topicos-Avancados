using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplicationTarefa
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CarregarListaTarefas();
            CarregarListaProjetos();
        }

        private void CarregarListaTarefas()
        {
            TarefaEntities context = new TarefaEntities();
            List<TB_TAREFA> lstTarefa = context.TB_TAREFA.ToList<TB_TAREFA>();

            GVTarefa.DataSource = lstTarefa;
            GVTarefa.DataBind();
        }

        private void CarregarListaProjetos()
        {
            TarefaEntities1 context = new TarefaEntities1();
            List<TB_PROJETO> lstProjeto = context.TB_PROJETO.ToList<TB_PROJETO>();

            GVProjeto.DataSource = lstProjeto;
            GVProjeto.DataBind();
        }

        protected void GVTarefa_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int idItem = Convert.ToInt32(e.CommandArgument.ToString());
            TarefaEntities contextTarefa = new TarefaEntities();
            TB_TAREFA tarefa = new TB_TAREFA();

            tarefa = contextTarefa.TB_TAREFA.First(c => c.id == idItem);

            if(e.CommandName == "ALTERAR")
            {
                Response.Redirect("Tarefa.aspx?idItem=" + idItem);
            }
            else if (e.CommandName == "EXCLUIR")
            {
                contextTarefa.TB_TAREFA.Remove(tarefa);
                contextTarefa.SaveChanges();
                string msg = "Tarefa excluída com sucesso!";
                string titulo = "Informação";
                CarregarListaTarefas();
                DisplayAlert(titulo, msg, this);
            }
        }

        protected void GVProjeto_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int idItem = Convert.ToInt32(e.CommandArgument.ToString());
            TarefaEntities1 contextProjeto = new TarefaEntities1();
            TB_PROJETO projeto = new TB_PROJETO();

            projeto = contextProjeto.TB_PROJETO.First(c => c.id == idItem);

            if (e.CommandName == "ALTERAR")
            {
                Response.Redirect("Projeto.aspx?idItem=" + idItem);
            }
            else if (e.CommandName == "EXCLUIR")
            {
                contextProjeto.TB_PROJETO.Remove(projeto);
                contextProjeto.SaveChanges();
                string msg = "Projeto excluído com sucesso!";
                string titulo = "Informação";
                CarregarListaProjetos();
                DisplayAlert(titulo, msg, this);
            }
        }

        public void DisplayAlert(string titulo, string mensagem, System.Web.UI.Page page)
        {
            h1.InnerText = titulo;
            lblMsgPopup.InnerText = mensagem;
            ClientScript.RegisterStartupScript(typeof(Page), Guid.NewGuid().ToString(), "MostrarPopupMensagem();", true);
        }

        
    }
}