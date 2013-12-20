<%@ Page Title="" Language="C#" MasterPageFile="~/Usuario.master" AutoEventWireup="true" CodeFile="VerProducto.aspx.cs" Inherits="VerStock" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <h1>
        Lista de Productos:
    </h1>
    <div id="ListaDeProductos" runat="server">
        <asp:GridView ID="gvProductos" runat="server" AutoGenerateColumns="False" 
            OnRowDataBound="gvProductos_RowDataBound" OnRowCommand="gvProductos_RowCommand" 
            CellPadding="4" ForeColor="#333333" GridLines="Horizontal">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="id_Producto" HeaderText="ID" />
                <asp:BoundField DataField="id_Categoria" HeaderText="Categoria" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre del Producto" />
                <asp:BoundField DataField="Cantidad_Stock" HeaderText="Stock" />
                <asp:BoundField DataField="Cantidad_Minima" HeaderText="Stock Minimo" />
                <asp:BoundField DataField="Precio" HeaderText="Precio" />
                <asp:HyperLinkField DataNavigateUrlFields="id_Producto" 
                    DataNavigateUrlFormatString="~/Administracion/EditarProducto.aspx?id_Producto={0}" 
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
        <asp:Label ID="lblProductos" runat="server" Text=""></asp:Label>
    </div>
</asp:Content>

