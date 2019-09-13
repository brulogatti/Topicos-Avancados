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

        <asp:GridView runat="server" ID="GVCompras" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowCommand="GVCompras_RowCommand">
        <AlternatingRowStyle BackColor="White" />
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

         <h1>Materiais</h1>
        <br />
         <asp:GridView runat="server" ID="GVMaterial" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowCommand="GVMaterial_RowCommand">
        <AlternatingRowStyle BackColor="White" />
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

        <h1>Tipos de Materiais</h1>
        <br />
        <asp:GridView ID="GVTipo" runat="server" CellPadding="6" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" OnRowCommand="GVTipo_RowCommand">
        <AlternatingRowStyle BackColor="White" />
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

         <h1>Fornecedores</h1>
        <br />

         <asp:GridView runat="server" ID="GVFornecedor" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowCommand="GVFornecedor_RowCommand">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
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

        <h1>Clientes</h1>
        <br />

         <asp:GridView ID="GVCliente" runat=server CellPadding="6" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" OnRowCommand="GVCliente_RowCommand">
        <AlternatingRowStyle BackColor="White" />
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
</asp:Content>
