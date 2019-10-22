<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ProjEmpresaWCF.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 166px;
        }
        .auto-style3 {
            height: 23px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h1 class="auto-style1" dir="ltr" aria-atomic="False" aria-autocomplete="list" aria-live="off">Cadastro da Empresa</h1>
        <table class="auto-style1">
             <tr>
                 <td class="auto-style2">
                     <asp:Label ID="Label1" runat="server" Text="Nome:"></asp:Label>
                 </td>
                 <td>
                     <asp:TextBox ID="txtnome" runat="server" Width="225px"></asp:TextBox>
                 </td>
             </tr>
             <tr>
                 <td class="auto-style2">
                     <asp:Label ID="Label2" runat="server" Text="Quantidade Funcionários:"></asp:Label>
                 </td>
                 <td>
                     <asp:TextBox ID="txtqtd" runat="server" Width="224px"></asp:TextBox>
                 </td>
             </tr>
             <tr>
                 <td class="auto-style2">
                     <asp:Label ID="Label3" runat="server" Text="Endereço:"></asp:Label>
                 </td>
                 <td>
                     <asp:TextBox ID="txtendereco" runat="server" Width="224px"></asp:TextBox>
                 </td>
             </tr>
             <tr>
                 <td class="auto-style2">&nbsp;</td>
                 <td>
                     <asp:Button ID="BtnSalvar" runat="server" Text="Salvar" OnClick="BtnSalvar_Click" CssClass="auto-style3" EnableTheming="True" />
                 </td>
             </tr>
             <tr>
                 <td class="auto-style2">&nbsp;</td>
                 <td>
                     <asp:Label ID="lblmsg" runat="server"></asp:Label>
                     &nbsp;</td>
             </tr>
         </table>
        <hr />
        <h2>Consultar:</h2>
        <table class="auto-style1">
            <tr>
                 <td class="auto-style2">
                     <asp:Label ID="Label4" runat="server" Text="Nome:"></asp:Label>
                 </td>
                 <td>
                     <asp:TextBox ID="txtconsulta" runat="server" Width="179px"></asp:TextBox>
                 </td>
             </tr>
             <tr>
                 <td class="auto-style2">&nbsp;</td>
                 <td>
                     <asp:Button ID="BtnConsulta" runat="server" Text="Consultar" OnClick="BtnConsulta_Click" />
                 </td>
             </tr>
        </table>
        <div>
            <asp:GridView runat="server" ID="GDconsulta"  CssClass="table table-hover" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID" />
                    <asp:BoundField DataField="NOME" HeaderText="NOME" />
                    <asp:BoundField DataField="QTDFUNCIONARIOS" HeaderText="QUANTIDADE FUNCIONÁRIOS" />
                    <asp:BoundField DataField="ENDERECO" HeaderText="ENDEREÇO" />
                </Columns>
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            </asp:GridView>
        </div>
        <br />
        <hr />
        <h2 class="auto-style3">
         Todas as empresas cadastradas:
        </h2>
        <div>
            <asp:GridView runat="server" ID="GDdados" CssClass="table table-hover" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID" />
                    <asp:BoundField DataField="NOME" HeaderText="NOME" />
                    <asp:BoundField DataField="QTDFUNCIONARIOS" HeaderText="QUANTIDADE FUNCIONÁRIOS" />
                    <asp:BoundField DataField="ENDERECO" HeaderText="ENDEREÇO" />
                </Columns>
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            </asp:GridView>
        </div>
    </form>
</body>
</html>
