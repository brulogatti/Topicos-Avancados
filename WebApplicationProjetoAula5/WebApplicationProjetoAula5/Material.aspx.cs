using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplicationProjetoAula5
{
    public partial class Material : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadGrid();
            if (!IsPostBack)
            {
                CarregarDadosPagina();
                LoadDDLFornecedor();
                LoadDDLTipo();
            }
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            int fornecedor = int.Parse(ddlFornecedor.SelectedValue.ToString());
            int tipo = int.Parse(ddlTipo.SelectedValue.ToString());
            DateTime dataentrada = Convert.ToDateTime(txtdataentrada.Text);
            string descricao = txtdescricao.Text;
            decimal valor = Convert.ToDecimal(txtvalor.Text);
            MATERIAL m = new MATERIAL() { id_fornecedor = fornecedor, id_tipo = tipo, dataentrada = dataentrada, descricao = descricao, valor = valor };
            Aula5Entities contextAula5 = new Aula5Entities();

            string value = Request.QueryString["idItem"];

            if (String.IsNullOrEmpty(value))
            {
                contextAula5.MATERIAL.Add(m);
                lblmsg.Text = "Registro Inserido!";
            }
            else
            {
                int id = Convert.ToInt32(value);
                MATERIAL material = contextAula5.MATERIAL.First(c => c.id == id);
                material.id_fornecedor = m.id_fornecedor;
                material.id_tipo = m.id_tipo;
                material.dataentrada = m.dataentrada;
                material.valor = m.valor;
                material.descricao = m.descricao;
                lblmsg.Text = "Registro Alterado!";
            };

            contextAula5.SaveChanges();
            LoadGrid();
        }

        private void LoadDDLFornecedor()
        {
            ddlFornecedor.DataSource = new Aula5Entities().FORNECEDOR.ToList<FORNECEDOR>();
            ddlFornecedor.DataTextField = "Nome";
            ddlFornecedor.DataValueField = "Id";
            ddlFornecedor.DataBind();
        }

        private void LoadDDLTipo()
        {
            ddlTipo.DataSource = new Aula5Entities().TIPO.ToList<TIPO>();
            ddlTipo.DataTextField = "Descricao";
            ddlTipo.DataValueField = "Id";
            ddlTipo.DataBind();
        }

        private void CarregarDadosPagina()
        {
            string valor = Request.QueryString["idItem"];
            int idItem = 0;
            MATERIAL material = new MATERIAL();
            Aula5Entities contextMaterial = new Aula5Entities();
            if (!String.IsNullOrEmpty(valor))
            {
                idItem = Convert.ToInt32(valor);
                material = contextMaterial.MATERIAL.First(c => c.id == idItem);;
                ddlFornecedor.Equals(material.id_fornecedor);
                ddlTipo.Equals(material.id_tipo);
                txtdataentrada.Text = material.dataentrada.ToString();
                txtdescricao.Text = material.descricao;
                txtvalor.Text = material.valor.ToString();
            }
        }

        private void LoadGrid()
        {
            Aula5Entities context = new Aula5Entities();

            var dados = (
                         from m in context.MATERIAL
                         from f in context.FORNECEDOR.Where(x=>x.id==m.id_fornecedor)
                         from t in context.TIPO.Where(x=>x.id==m.id_tipo)
                         select new
                         {
                             Id = m.id,
                             Descricao=m.descricao,
                             Dataentrada=m.dataentrada,
                             Id_tipo=t.descricao,
                             Id_fornecedor=f.nome,
                             Valor=m.valor
                         }).ToList();

            GVMaterial.DataSource = dados;
            GVMaterial.DataBind();
        }
    }
}