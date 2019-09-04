<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Projeto.aspx.cs" Inherits="WebApplicationTarefa.Projeto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
     <link rel="stylesheet" href="http://code.jquery.com/ui/1.9.0/themes/base/jquery-ui.css" /> 
    <script src="http://code.jquery.com/jquery-1.8.2.js"></script> 
    <script src="http://code.jquery.com/ui/1.9.0/jquery-ui.js"></script>
    <script>
        $(function () {
            $("#<%= txtdataimpl.ClientID %>").datepicker({
                dateFormat: 'dd/mm/yy',
                dayNames: ['Domingo', 'Segunda', 'Terça', 'Quarta', 'Quinta', 'Sexta', 'Sábado', 'Domingo'],
                dayNamesMin: ['D', 'S', 'T', 'Q', 'Q', 'S', 'S', 'D'],
                dayNamesShort: ['Dom', 'Seg', 'Ter', 'Qua', 'Qui', 'Sex', 'Sáb', 'Dom'],
                monthNames: ['Janeiro', 'Fevereiro', 'Março', 'Abril', 'Maio', 'Junho', 'Julho', 'Agosto', 'Setembro', 'Outubro', 'Novembro', 'Dezembro'],
                monthNamesShort: ['Jan', 'Fev', 'Mar', 'Abr', 'Mai', 'Jun', 'Jul', 'Ago', 'Set', 'Out', 'Nov', 'Dez']
            });
        });
        $(function () {
            $("#<%= txtdatainicio.ClientID %>").datepicker({
                dateFormat: 'dd/mm/yy',
                dayNames: ['Domingo', 'Segunda', 'Terça', 'Quarta', 'Quinta', 'Sexta', 'Sábado', 'Domingo'],
                dayNamesMin: ['D', 'S', 'T', 'Q', 'Q', 'S', 'S', 'D'],
                dayNamesShort: ['Dom', 'Seg', 'Ter', 'Qua', 'Qui', 'Sex', 'Sáb', 'Dom'],
                monthNames: ['Janeiro', 'Fevereiro', 'Março', 'Abril', 'Maio', 'Junho', 'Julho', 'Agosto', 'Setembro', 'Outubro', 'Novembro', 'Dezembro'],
                monthNamesShort: ['Jan', 'Fev', 'Mar', 'Abr', 'Mai', 'Jun', 'Jul', 'Ago', 'Set', 'Out', 'Nov', 'Dez']
            });
        });
        $(function () {
            $("#<%= txtdatateste.ClientID %>").datepicker({
                dateFormat: 'dd/mm/yy',
                dayNames: ['Domingo', 'Segunda', 'Terça', 'Quarta', 'Quinta', 'Sexta', 'Sábado', 'Domingo'],
                dayNamesMin: ['D', 'S', 'T', 'Q', 'Q', 'S', 'S', 'D'],
                dayNamesShort: ['Dom', 'Seg', 'Ter', 'Qua', 'Qui', 'Sex', 'Sáb', 'Dom'],
                monthNames: ['Janeiro', 'Fevereiro', 'Março', 'Abril', 'Maio', 'Junho', 'Julho', 'Agosto', 'Setembro', 'Outubro', 'Novembro', 'Dezembro'],
                monthNamesShort: ['Jan', 'Fev', 'Mar', 'Abr', 'Mai', 'Jun', 'Jul', 'Ago', 'Set', 'Out', 'Nov', 'Dez']
            });
        });
    </script>
    <form id="form1" runat="server">
        <article class="kanban-entry grab" id="item1" draggable="true">
            <div class="kanban-entry-inner">
                <div class="kanban-label">
                    <h2><a href="#">Controle de Projetos</a> <span></span></h2>
                    <p></p>
                </div>
            </div>
        </article>
        <div class="form-group">
            <label for="descricao">Descrição:</label>
            <asp:TextBox class="form-control" name="txtDescricaoProj" ID="txtDescricaoProj" runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="datainicio">Data Início Projeto:</label>
            <asp:TextBox class="form-control" name="txtdatainicio" ID="txtdatainicio" runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="qtd">Quantidade de Pessoas:</label>
            <asp:TextBox class="form-control" name="txtqtd" ID="txtqtd" runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="dtimplantacao">Data Implantação:</label>
            <asp:TextBox class="form-control" name="txtdataimpl" ID="txtdataimpl" runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="dtteste">Data Teste:</label>
            <asp:TextBox class="form-control" name="txtdatateste" ID="txtdatateste" runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="contato1">Telefone de contato 1:</label>
            <asp:TextBox class="form-control" name="txttel1" ID="txttel1" runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="contato2">Telefone de contato 2:</label>
            <asp:TextBox class="form-control" name="txttel2" ID="txttel2" runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="observacao">Observação:</label>
            <asp:TextBox class="form-control" name="txtobs" ID="txtobs" runat="server"></asp:TextBox>
        </div>
        <asp:Button class="btn btn-primary" ID="btnCadastrarproj" runat="server" Text="Salvar" OnClick="btnCadastrarproj_Click" />
    </form>
    <br />

    <% if (!String.IsNullOrEmpty(lblmsg.Text))
        {%>
    <div class="alert alert-success">
        <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
        <strong><asp:Label ID="lblmsg" runat="server" Text=""></asp:Label></strong>
    </div>
    <%} %>
</asp:Content>
