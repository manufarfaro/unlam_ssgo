<%@ Page Title="" Language="C#" MasterPageFile="~/Usuario.master" AutoEventWireup="true" CodeFile="VerCategoria.aspx.cs" Inherits="Administracion_VerCategoria" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <h2>
        Lista de Categorias:
    </h2>
    <div id="ListaDeProductos" runat="server">
        <asp:GridView ID="gvCategorias" runat="server" AutoGenerateColumns="False"
            onselectedindexchanged="gvCategorias_SelectedIndexChanged" 
            OnRowCommand="gvCategorias_RowCommand" CellPadding="4" ForeColor="#333333" 
            GridLines="Horizontal" >
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="id_Categoria" HeaderText="Id" />
                <asp:BoundField DataField="nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="codigo" HeaderText="Codigo" />
                <asp:BoundField DataField="descripcion" HeaderText="Descripcion" />
                <asp:HyperLinkField DataNavigateUrlFields="id_Categoria" 
                    DataNavigateUrlFormatString="~/Administracion/EditarCategoria.aspx?id_Categoria={0}" 
                    Text="Editar" />
                <asp:ButtonField CommandName="cmdBorrar" Text="Borrar" />
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
    </div>
    <div class="divformulario">
        <asp:Button ID="btnActualizarDatos" runat="server" Text="Actualizar Datos" 
            onclick="btnActualizarDatos_Click"></asp:Button>
        <asp:Label ID="lblCategoria" runat="server" Text=""></asp:Label>
    </div>
</asp:Content>

