<%@ Page Title="" Language="C#" MasterPageFile="~/PagePrincipal.Master" AutoEventWireup="true" CodeBehind="Compras.aspx.cs" Inherits="WebApplicationProjetoAula5.Compras" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
 <link rel="stylesheet" href="http://code.jquery.com/ui/1.9.0/themes/base/jquery-ui.css" /> 
    <script src="http://code.jquery.com/jquery-1.8.2.js"></script> 
    <script src="http://code.jquery.com/ui/1.9.0/jquery-ui.js"></script>
    <script>
    </script>
    <form id="form1" runat="server">
        <article class="kanban-entry grab" id="item1" draggable="true">
            <div class="kanban-entry-inner">
                <div class="kanban-label">
                    <h2><a href="#">Cadastro de Compras</a> <span></span></h2>
                    <p></p>
                </div>
            </div>
        </article>
        <div class="form-group">
            <label for="fornecedor">Fornecedor:</label>
            <asp:DropDownList ID="ddlFornecedor" runat="server"></asp:DropDownList>
        </div>
        <div class="form-group">
            <label for="cliente">Cliente:</label>
            <asp:DropDownList ID="ddlCliente" runat="server"></asp:DropDownList>
        </div>
        <div class="form-group">
            <label for="material">Material:</label>
            <asp:DropDownList ID="ddlMaterial" runat="server"></asp:DropDownList>
        </div>
        <div class="form-group">
            <label for="dtvenda">Data Venda:</label>
            <asp:TextBox class="form-control" name="txtdatavenda" ID="txtdatavenda" runat="server"></asp:TextBox>
        </div>
        <asp:Button class="btn btn-primary" ID="btnCadastrar" runat="server" Text="Salvar" OnClick="btnCadastrar_Click" />
    </form>
    <br />

    <% if (!String.IsNullOrEmpty(lblmsg.Text))
        {%>
    <div class="alert alert-success">
        <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
        <strong><asp:Label ID="lblmsg" runat="server" Text=""></asp:Label></strong>
    </div>
    <%} %>

    <% if (!String.IsNullOrEmpty(lblmsg.Text))
        {%>
    <div class="alert alert-success">
        <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
        <strong><asp:Label ID="lblmsgdiagnostico" runat="server" Text=""></asp:Label></strong>
    </div>
    <%} %>
</asp:Content>
