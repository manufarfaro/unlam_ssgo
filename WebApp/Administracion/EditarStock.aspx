<%@ Page Title="" Language="C#" MasterPageFile="~/Usuario.master" AutoEventWireup="true"
    CodeFile="EditarStock.aspx.cs" Inherits="Administracion_EditarStock" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="divformulario">
        <div class="nombrecontrol">
            Seleccione categoria para filtrar:
        </div>
        <div class="control">
            <asp:DropDownList ID="ddlCategoria" runat="server" OnSelectedIndexChanged="ddlCategoria_SelectedIndexChanged">
            </asp:DropDownList>
        </div>
    </div>
    <div class="divformulario">
        <div class="nombrecontrol">
            Seleccione Producto:
            <!-- aca se van a concatenar de esta forma: nombre de producto - numero codigo -->
        </div>
        <div class="control">
            <asp:DropDownList ID="ddlProducto" runat="server">
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="ddlProducto" runat="server" ErrorMessage="Seleccione un producto"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="divformulario">
        <div class="nombrecontrol">
            Cantidad:
        </div>
        <div class="control">
            <asp:TextBox ID="txtQtyProducto" MaxLength = "6" runat="server"></asp:TextBox>
            <asp:RangeValidator ID="RangeValidator1" runat="server" Type="Integer" ControlToValidate="txtQtyProducto" MinimumValue="0" MaximumValue="10000" ErrorMessage="La cantidad debe estar entre 0 y 10000 unidades"></asp:RangeValidator>
        </div>
    </div>
    <div class="divformulario">
        <div class="nombrecontrol">
            <asp:Button ID="btnAceptar" runat="server" Text="Filtrar" OnClick="btnFiltrar_Click" />
        </div>
        <div class="control">
            <asp:Button ID="Button1" runat="server" Text="Actualizar stock" 
                onclick="Button1_Click" />
            <asp:Label ID="lblResultado" runat="server" Text=""></asp:Label>
        </div>
    </div>
</asp:Content>
