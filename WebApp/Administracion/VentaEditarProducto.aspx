<%@ Page Title="" Language="C#" MasterPageFile="~/Usuario.master" AutoEventWireup="true"
    CodeFile="VentaEditarProducto.aspx.cs" Inherits="SuperUsuario_Administracion_VentaEditarProducto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="divformulario">
        <h1>
            Seleccione Producto para editar:
        </h1>
        <div class="divformulario">
            <div class="nombrecontrol">
                <asp:Label ID="lblProducto" runat="server" Text="Producto:"></asp:Label>
            </div>
            <div class="control">
                <asp:Label ID="lblProductoId" runat="server" Text="1"></asp:Label>
                -
                <asp:Label ID="lblRelatedName" runat="server" Text="Lapiz"></asp:Label>
            </div>
        </div>
        <div class="divformulario">
            <div class="nombrecontrol">
                <asp:Label ID="lblMark" runat="server" Text="Marca:"></asp:Label>
            </div>
            <div class="control">
                <asp:Label ID="lblMarkDesc" runat="server" Text="Faber Castell"></asp:Label>
            </div>
        </div>
        <div class="divformulario">
            <div class="nombrecontrol">
                <asp:Label ID="lblStock" runat="server" Text="Stock:"></asp:Label>
            </div>
            <div class="control">
                <asp:Label ID="lblStockDesc" runat="server" Text="12"></asp:Label>
            </div>
        </div>
        <div class="divformulario">
            <div class="nombrecontrol">
                <asp:Label ID="lblProductoQty" runat="server" Text="Cantidad:"></asp:Label>
            </div>
            <div class="control">
                <asp:TextBox ID="txtProductoQty" runat="server" Text="2"></asp:TextBox>
            </div>
        </div>
        <div class="divformulario">
            <asp:Button ID="btnEditar" runat="server" Text="Aceptar" />
        </div>
    </div>
</asp:Content>
