<%@ Page Title="" Language="C#" MasterPageFile="~/PagePrincipal.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplicationProjetoAula5.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
     <script type="text/javascript">
         function MostrarPopupMensagem() {
             $("#modalMsg").modal('show');
         }
         function EsconderPopupDados() {
             $("#modalDados").modal('hide');
         }
    </script>

    <!--/.modal-->
   <div class="modal fade" id="modalMsg"> 
       <div class="modal-dialog"> 
           <div class="modal-content"> 
               <div class="modal-header"> 
                   <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button> 
                   <h4 class="modal-title" id="h1" runat="server">Modal title</h4> 
               </div>
              <div class="modal-body"> 
                  <p> 
                      <label id="lblMsgPopup" runat="server"> 
                      </label> 
                  </p> 
              </div> 
              <div class="modal-footer"> 
                  <button type="button" class="btn btn-danger" data-dismiss="modal">Ok</button> 
              </div>
           </div> 
           <!-- /.modal-content --> 
       </div> 
       <!-- /.modal-dialog --> 
   </div>
    <form runat="server"> 

        <h1>Vendas</h1>
        <br />

        <asp:GridView runat="server" ID="GVCompras" CssClass="table table-hover" AutoGenerateColumns="False" CellPadding="3" OnRowCommand="GVCompras_RowCommand" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Id" />
            <asp:BoundField DataField="Id_fornecedor" HeaderText="Fornecedor" />
            <asp:BoundField DataField="Id_cliente" HeaderText="Cliente" />
            <asp:BoundField DataField="Id_material" HeaderText="Material" />
            <asp:BoundField DataField="Datavenda" HeaderText="Data Venda" />

             <asp:TemplateField HeaderText="AÇÕES"> 
                    <ItemTemplate> 
                        <asp:LinkButton runat="server" ID="btnAlterarMidia" CommandName="ALTERAR" CommandArgument='<%# Eval("Id") %>' CssClass="btn btn btn-info" Text="Alterar" /> 
                        <asp:LinkButton runat="server" ID="btnExcluirMidia" CommandName="EXCLUIR" CommandArgument='<%# Eval("Id") %>' CssClass="btn btn btn-primary" Text="Excluir" /> 
                    </ItemTemplate> 
                </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="White" ForeColor="#000066" />
        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
        <RowStyle ForeColor="#000066" />
        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#007DBB" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#00547E" />
        </asp:GridView>

         <h1>Materiais</h1>
        <br />
         <asp:GridView runat="server" ID="GVMaterial" CssClass="table table-hover" AutoGenerateColumns="False" CellPadding="3" OnRowCommand="GVMaterial_RowCommand" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="ID" />
            <asp:BoundField DataField="Descricao" HeaderText="Descrição" />
            <asp:BoundField DataField="Dataentrada" HeaderText="Data Entrada" />
            <asp:BoundField DataField="Id_tipo" HeaderText="Tipo" />
            <asp:BoundField DataField="Id_fornecedor" HeaderText="Fornecedor" />
            <asp:BoundField DataField="Valor" HeaderText="Valor" />

            <asp:TemplateField HeaderText="AÇÕES"> 
                    <ItemTemplate> 
                        <asp:LinkButton runat="server" ID="btnAlterarMidia" CommandName="ALTERAR" CommandArgument='<%# Eval("Id") %>' CssClass="btn btn btn-info" Text="Alterar" /> 
                        <asp:LinkButton runat="server" ID="btnExcluirMidia" CommandName="EXCLUIR" CommandArgument='<%# Eval("Id") %>' CssClass="btn btn btn-primary" Text="Excluir" /> 
                    </ItemTemplate> 
                </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="White" ForeColor="#000066" />
        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
        <RowStyle ForeColor="#000066" />
        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#007DBB" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#00547E" />
        </asp:GridView>

        <h1>Tipos de Materiais</h1>
        <br />
        <asp:GridView ID="GVTipo" runat="server" CssClass="table table-hover" CellPadding="3" AutoGenerateColumns="False" OnRowCommand="GVTipo_RowCommand" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="ID"></asp:BoundField>
                <asp:BoundField DataField="Descricao" HeaderText="Descrição"></asp:BoundField>

                <asp:TemplateField HeaderText="AÇÕES"> 
                    <ItemTemplate> 
                        <asp:LinkButton runat="server" ID="btnAlterarMidia" CommandName="ALTERAR" CommandArgument='<%# Eval("Id") %>' CssClass="btn btn btn-info" Text="Alterar" /> 
                        <asp:LinkButton runat="server" ID="btnExcluirMidia" CommandName="EXCLUIR" CommandArgument='<%# Eval("Id") %>' CssClass="btn btn btn-primary" Text="Excluir" /> 
                    </ItemTemplate> 
                </asp:TemplateField>
            </Columns>
        <FooterStyle BackColor="White" ForeColor="#000066" />
        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
        <RowStyle ForeColor="#000066" />
        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#007DBB" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#00547E" />
    </asp:GridView>

         <h1>Fornecedores</h1>
        <br />

         <asp:GridView runat="server" CssClass="table table-hover" ID="GVFornecedor" AutoGenerateColumns="False" CellPadding="3" OnRowCommand="GVFornecedor_RowCommand" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="ID" />
            <asp:BoundField DataField="Nome" HeaderText="Nome" />
            <asp:BoundField DataField="Telefone" HeaderText="Telefone" />
            <asp:BoundField DataField="Cidade" HeaderText="Cidade" />
            <asp:BoundField DataField="Endereco" HeaderText="Endereço" />
            <asp:BoundField DataField="CNPJ" HeaderText="CNPJ" />

            <asp:TemplateField HeaderText="AÇÕES"> 
                    <ItemTemplate> 
                        <asp:LinkButton runat="server" ID="btnAlterarMidia" CommandName="ALTERAR" CommandArgument='<%# Eval("Id") %>' CssClass="btn btn btn-info" Text="Alterar" /> 
                        <asp:LinkButton runat="server" ID="btnExcluirMidia" CommandName="EXCLUIR" CommandArgument='<%# Eval("Id") %>' CssClass="btn btn btn-primary" Text="Excluir" /> 
                    </ItemTemplate> 
                </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="White" ForeColor="#000066" />
        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
        <RowStyle ForeColor="#000066" />
        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#007DBB" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#00547E" />
        </asp:GridView>

        <h1>Clientes</h1>
        <br />

         <asp:GridView ID="GVCliente" CssClass="table table-hover" runat=server CellPadding="3" AutoGenerateColumns="False" OnRowCommand="GVCliente_RowCommand" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="ID"></asp:BoundField>
                    <asp:BoundField DataField="Nome" HeaderText="Nome"></asp:BoundField>
                    <asp:BoundField DataField="Telefone" HeaderText="Telefone"></asp:BoundField>
                    <asp:BoundField DataField="Cidade" HeaderText="Cidade"></asp:BoundField>
                    <asp:BoundField DataField="Endereco" HeaderText="Endereço"></asp:BoundField>
                    <asp:BoundField DataField="CPF" HeaderText="CPF"></asp:BoundField>

                    <asp:TemplateField HeaderText="AÇÕES"> 
                    <ItemTemplate> 
                        <asp:LinkButton runat="server" ID="btnAlterarMidia" CommandName="ALTERAR" CommandArgument='<%# Eval("Id") %>' CssClass="btn btn btn-info" Text="Alterar" /> 
                        <asp:LinkButton runat="server" ID="btnExcluirMidia" CommandName="EXCLUIR" CommandArgument='<%# Eval("Id") %>' CssClass="btn btn btn-primary" Text="Excluir" /> 
                    </ItemTemplate> 
                </asp:TemplateField>
                </Columns>
        <FooterStyle BackColor="White" ForeColor="#000066" />
        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
        <RowStyle ForeColor="#000066" />
        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#007DBB" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#00547E" />
    </asp:GridView>
    </form>
</asp:Content>
