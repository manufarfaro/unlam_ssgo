<%@ Page Title="" Language="C#" MasterPageFile="~/Usuario.master" AutoEventWireup="true"
    CodeFile="Venta.aspx.cs" Inherits="Administracion_Venta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="sales_structure">
        <form id="frmProductSales" action="#" method="post">
        <h1>
            Venta de Productos</h1>
        <p>
            <h3>
                Agregar Producto</h3>
        </p>
        <div class="divformulario">
            <div class="nombrecontrol">
                <asp:Label ID="lblProducto" runat="server" Text="Producto:"></asp:Label>
            </div>
            <div class="control">
                <asp:DropDownList ID="ddlProducto" runat="server" AutoPostBack="true" 
                    onselectedindexchanged="ddlProducto_SelectedIndexChanged">
                </asp:DropDownList>
            </div>
        </div>
        <div class="divformulario">
            <div class="nombrecontrol">
                <asp:Label ID="lblStock" runat="server" Text="Stock:"></asp:Label>
            </div>
            <div class="control">
                <asp:Label ID="lblStockDesc" runat="server" Text="0"></asp:Label>
            </div>
        </div>
        <div class="divformulario">
            <div class="nombrecontrol">
                <asp:Label ID="lblProductoQty" runat="server" Text="Cantidad:"></asp:Label>
            </div>
            <div class="control">
                <asp:TextBox ID="txtProductoQty" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="divformulario">
            <asp:Button ID="btnAgregar" runat="server" Text="Agregar Producto" 
                onclick="btnAgregar_Click" />
        </div>
        <div id="sectionSeparator"></div>
        <p>
            <h3>
                Listado Productos</h3>
        </p>
        <div class="frmStructure">
            <asp:GridView ID="gvProductSales" class="formStandart" runat="server" OnRowDataBound = "gvProductSales_RowDataBound"
                OnRowCommand="gvProductSales_RowCommand" OnRowDeleting="gvProductSales_RowDeleting" 
                EmptyDataText="No tiene productos seleccionados." CellPadding="4" 
                ForeColor="#333333" GridLines="Horizontal" AutoGenerateColumns="False">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField HeaderText="Codigo" DataField="Id" />
                    <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                    <asp:BoundField HeaderText="Cantidad" DataField="Cantidad" />
                    <asp:BoundField DataField="Marca" HeaderText="Marca" />
                    <asp:BoundField DataField="Precio" HeaderText="Precio" />
                    <asp:ButtonField ButtonType="Button" Text="Editar" CommandName="btnEditar" />
                    <asp:ButtonField ButtonType="Button" Text="Eliminar" CommandName="btnEliminar" />
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
            <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" />
            <asp:Button ID="btnConfirmar" runat="server" Text="Confirmar Venta" 
                onclick="btnConfirmar_Click" />
        </div>
        <div class="divformulario">
            <asp:Label ID="lblProdStatus" runat="server" Text=""></asp:Label>
        </div>
        </form>
    </div>
</asp:Content>