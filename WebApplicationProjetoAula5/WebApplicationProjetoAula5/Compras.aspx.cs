using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplicationProjetoAula5
{
    public partial class Compras : System.Web.UI.Page
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

            int fornecedor = int.Parse(ddlFornecedor.SelectedValue.ToString());
            int cliente = int.Parse(ddlCliente.SelectedValue.ToString());
            int material = int.Parse(ddlMaterial.SelectedValue.ToString());
            DateTime datavenda = Convert.ToDateTime(txtdatavenda.Text);
            COMPRA com = new COMPRA() { id_fornecedor = fornecedor, id_cliente = cliente, id_material = material, datavenda = datavenda };
            Aula5Entities contextAula5 = new Aula5Entities();

            string valor = Request.QueryString["idItem"];

            if (String.IsNullOrEmpty(valor))
            {
                contextAula5.COMPRA.Add(com);
                lblmsg.Text = "Registro Inserido!";
            }
            else
            {
                int id = Convert.ToInt32(valor);
                COMPRA compra = contextAula5.COMPRA.First(c => c.id == id);
                compra.id_cliente = com.id_cliente;
                compra.id_fornecedor = com.id_fornecedor;
                compra.id_material = com.id_material;
                compra.datavenda = com.datavenda;
                lblmsg.Text = "Registro Alterado!";
            };
        }

            private void CarregarDadosPagina()
            {
                string valor = Request.QueryString["idItem"];
                int idItem = 0;
                COMPRA compra = new COMPRA();
                Aula5Entities contextCompra = new Aula5Entities();
                if (!String.IsNullOrEmpty(valor))
                {
                idItem = Convert.ToInt32(valor);
                compra = contextCompra.COMPRA.First(c => c.id == idItem);
                ddlCliente.Equals(compra.id_cliente);
                ddlFornecedor.Equals(compra.id_fornecedor);
                ddlMaterial.Equals(compra.id_material);
                txtdatavenda.Text = compra.datavenda.ToString();
                }
            }

    }
}