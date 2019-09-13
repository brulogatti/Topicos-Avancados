using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplicationProjetoAula5
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CarregarListaCliente();
            CarregarListaCompra();
            CarregarListaFornecedor();
            CarregarListaMaterial();
            CarregarListaTipo();
        }

        protected void GVCompras_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int idItem = Convert.ToInt32(e.CommandArgument.ToString());
            Aula5Entities context = new Aula5Entities();
            COMPRA compra = new COMPRA();

            compra = context.COMPRA.First(c => c.id == idItem);

            if (e.CommandName == "ALTERAR")
            {
                Response.Redirect("Compras.aspx?idItem=" + idItem);
            }
            else if (e.CommandName == "EXCLUIR")
            {
                context.COMPRA.Remove(compra);
                context.SaveChanges();
                string msg = "Compra excluída com sucesso!";
                string titulo = "Informação";
                CarregarListaCompra();
                DisplayAlert(titulo, msg, this);
            }
        }

        protected void GVCliente_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int idItem = Convert.ToInt32(e.CommandArgument.ToString());
            Aula5Entities context = new Aula5Entities();
            CLIENTE cliente = new CLIENTE();

            cliente = context.CLIENTE.First(c => c.id == idItem);

            if (e.CommandName == "ALTERAR")
            {
                Response.Redirect("Cliente.aspx?idItem=" + idItem);
            }
            else if (e.CommandName == "EXCLUIR")
            {
                context.CLIENTE.Remove(cliente);
                context.SaveChanges();
                string msg = "Cliente excluído com sucesso!";
                string titulo = "Informação";
                CarregarListaCliente();
                DisplayAlert(titulo, msg, this);
            }
        }

        protected void GVFornecedor_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int idItem = Convert.ToInt32(e.CommandArgument.ToString());
            Aula5Entities context = new Aula5Entities();
            FORNECEDOR fornecedor = new FORNECEDOR();

            fornecedor = context.FORNECEDOR.First(c => c.id == idItem);

            if (e.CommandName == "ALTERAR")
            {
                Response.Redirect("Fornecedor.aspx?idItem=" + idItem);
            }
            else if (e.CommandName == "EXCLUIR")
            {
                context.FORNECEDOR.Remove(fornecedor);
                context.SaveChanges();
                string msg = "Fornecedor excluído com sucesso!";
                string titulo = "Informação";
                CarregarListaFornecedor();
                DisplayAlert(titulo, msg, this);
            }
        }

        protected void GVTipo_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int idItem = Convert.ToInt32(e.CommandArgument.ToString());
            Aula5Entities context = new Aula5Entities();
            TIPO tipo = new TIPO();

            tipo = context.TIPO.First(c => c.id == idItem);

            if (e.CommandName == "ALTERAR")
            {
                Response.Redirect("Tipo.aspx?idItem=" + idItem);
            }
            else if (e.CommandName == "EXCLUIR")
            {
                context.TIPO.Remove(tipo);
                context.SaveChanges();
                string msg = "Fornecedor excluído com sucesso!";
                string titulo = "Informação";
                CarregarListaTipo();
                DisplayAlert(titulo, msg, this);
            }
        }

        protected void GVMaterial_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int idItem = Convert.ToInt32(e.CommandArgument.ToString());
            Aula5Entities context = new Aula5Entities();
            MATERIAL material = new MATERIAL();

            material = context.MATERIAL.First(c => c.id == idItem);

            if (e.CommandName == "ALTERAR")
            {
                Response.Redirect("Material.aspx?idItem=" + idItem);
            }
            else if (e.CommandName == "EXCLUIR")
            {
                context.MATERIAL.Remove(material);
                context.SaveChanges();
                string msg = "Material excluído com sucesso!";
                string titulo = "Informação";
                CarregarListaMaterial();
                DisplayAlert(titulo, msg, this);
            }
        }

        private void CarregarListaCliente()
        {
            Aula5Entities context = new Aula5Entities();
            List<CLIENTE> lstcliente = context.CLIENTE.ToList<CLIENTE>();

            GVCliente.DataSource = lstcliente;
            GVCliente.DataBind();
        }

        private void CarregarListaFornecedor()
        {
            Aula5Entities context = new Aula5Entities();
            List<FORNECEDOR> lstfornecedor = context.FORNECEDOR.ToList<FORNECEDOR>();

            GVFornecedor.DataSource = lstfornecedor;
            GVFornecedor.DataBind();
        }

        private void CarregarListaTipo()
        {
            Aula5Entities context = new Aula5Entities();
            List<TIPO> lsttipo = context.TIPO.ToList<TIPO>();

            GVTipo.DataSource = lsttipo;
            GVTipo.DataBind();
        }

        private void CarregarListaCompra()
        {
            Aula5Entities context = new Aula5Entities();

            var dados = (
                         from compra in context.COMPRA
                         from m in context.MATERIAL.Where(x => x.id == compra.id_material)
                         from f in context.FORNECEDOR.Where(x => x.id == compra.id_fornecedor)
                         from cliente in context.CLIENTE.Where(x => x.id == compra.id_cliente)
                         select new
                         {
                             Id = compra.id,
                             Id_fornecedor = f.nome,
                             Id_cliente = cliente.nome,
                             Id_material = m.descricao,
                             Datavenda = compra.datavenda,
                         }).ToList();

            GVCompras.DataSource = dados;
            GVCompras.DataBind();
        }

        private void CarregarListaMaterial()
        {
            Aula5Entities context = new Aula5Entities();

            var dados = (
                         from m in context.MATERIAL
                         from f in context.FORNECEDOR.Where(x => x.id == m.id_fornecedor)
                         from t in context.TIPO.Where(x => x.id == m.id_tipo)
                         select new
                         {
                             Id = m.id,
                             Descricao = m.descricao,
                             Dataentrada = m.dataentrada,
                             Id_tipo = t.descricao,
                             Id_fornecedor = f.nome,
                             Valor = m.valor
                         }).ToList();

            GVMaterial.DataSource = dados;
            GVMaterial.DataBind();
        }

        public void DisplayAlert(string titulo, string mensagem, System.Web.UI.Page page)
        {
            h1.InnerText = titulo;
            lblMsgPopup.InnerText = mensagem;
            ClientScript.RegisterStartupScript(typeof(Page), Guid.NewGuid().ToString(), "MostrarPopupMensagem();", true);
        }
    }
}