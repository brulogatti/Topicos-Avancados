using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjAula4
{
    public partial class CadastroCidade : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadGrid();
                LoadDDL();
            }
            
        }

        protected void btnsalvar_Click(object sender, EventArgs e)
        {
            int idestado = int.Parse(ddlEstado.SelectedValue.ToString());

            Aula4Entities context = new Aula4Entities();

            CIDADE cidade = new CIDADE()
            {
                descricao = txtdescricao.Text, 
                ESTADO = context.ESTADO.First<ESTADO> (v=>v.id == idestado)
            };

            context.CIDADE.Add(cidade);
            context.SaveChanges();
            LoadGrid();
            SendMessage("Registro Inserido!");
        }

        private void LoadDDL()
        {
            ddlEstado.DataSource = new Aula4Entities().ESTADO.ToList<ESTADO>();
            ddlEstado.DataTextField = "Descricao";
            ddlEstado.DataValueField = "Id";
            ddlEstado.DataBind();
        }

        private void LoadGrid()
        {
            Aula4Entities context = new Aula4Entities();

            var dados = (from c in context.CIDADE
                         from e in context.ESTADO.Where(x => x.id == c.idestado)
                         select new
                         {
                             IdCidade = c.id,
                             NomeCidade = c.descricao,
                             Estado = e.descricao
                         }).ToList();
                  
            GVCidade.DataSource = dados;
            GVCidade.DataBind();
        }

        private void SendMessage (string txt)
        {
            lblmsg.Text = txt;
        }
    }
}