<%@ Page Title="" Language="C#" MasterPageFile="~/PagePrincipal.Master" AutoEventWireup="true" CodeBehind="Fornecedor.aspx.cs" Inherits="WebApplicationProjetoAula5.Fornecedor" %>
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
                    <h2><a href="#">Cadastro de Fornecedor</a> <span></span></h2>
                    <p></p>
                </div>
            </div>
        </article>
        <div class="form-group">
            <label for="nome">Nome:</label>
            <asp:TextBox class="form-control" name="txtnome" ID="txtnome" runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="telefone">Telefone:</label>
            <asp:TextBox class="form-control" name="txttelefone" ID="txttelefone" runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="cidade">Cidade:</label>
            <asp:TextBox class="form-control" name="txtcidade" ID="txtcidade" runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="endereco">Endereço:</label>
            <asp:TextBox class="form-control" name="txtendereco" ID="txtendereco" runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="cnpj">CNPJ:</label>
  
  
            <asp:TextBox class="form-control" name="txtCNPJ" ID="txtCNPJ" runat="server"></asp:TextBox>
        </div>
        <asp:Button class="btn btn-primary" ID="btnCadastrar" runat="server" Text="Salvar" OnClick="btnCadastrar_Click" />
    
        <br />
        <br />
    
    <asp:GridView runat="server" ID="GVFornecedor" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="ID" />
            <asp:BoundField DataField="Nome" HeaderText="Nome" />
            <asp:BoundField DataField="Telefone" HeaderText="Telefone" />
            <asp:BoundField DataField="Cidade" HeaderText="Cidade" />
            <asp:BoundField DataField="Endereco" HeaderText="Endereço" />
            <asp:BoundField DataField="CNPJ" HeaderText="CNPJ" />
        </Columns>
        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
    </form>
    <br />

    <% if (!String.IsNullOrEmpty(lblmsg.Text))
        {%>
    <div class="alert alert-success">
        <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;
        <strong><asp:Label ID="lblmsg" runat="server" Text=""></asp:Label></strong>
    </div>
    <%} %>

   
</asp:Content>
