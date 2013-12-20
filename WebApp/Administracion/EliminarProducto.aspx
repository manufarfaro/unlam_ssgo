<%@ Page Title="" Language="C#" MasterPageFile="~/Usuario.master" AutoEventWireup="true" CodeFile="EliminarProducto.aspx.cs" Inherits="EliminarProducto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <form action="#" method="post">
        <div class="divformulario">
            <div class="nombrecontrol">
                Selecccione Producto <!-- aca se van a concatenar de esta forma: nombre de producto - numero codigo -->
            </div>
            <div class="control">
                <asp:DropDownList ID="ddlProducto_eliminar" runat="server">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlProducto_eliminar" ErrorMessage="Seleccione un producto"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="divformulario">
            <asp:Button ID="btnElimiarProducto" runat="server" Text="Eliminar" 
                onclick="btnElimiarProducto_Click" />
            <asp:Label ID="lblResultado" runat="server" Text=""></asp:Label>
        </div>
    </form>
</asp:Content>

