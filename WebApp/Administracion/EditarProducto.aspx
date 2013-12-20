<%@ Page Title="" Language="C#" MasterPageFile="~/Usuario.master" AutoEventWireup="true"
    CodeFile="EditarProducto.aspx.cs" Inherits="EditarProducto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="divformulario">
        <div class="nombrecontrol">
            Nombre:
        </div>
        <div class="control">
            <asp:TextBox ID="txtNombre_prod" MaxLength="30" runat="server"></asp:TextBox>
            
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNombre_prod"
                ErrorMessage="Complete nombre del producto"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtNombre_prod"
                ValidationExpression="[a-zA-Z ]*" runat="server" ErrorMessage="Se permiten solo letras y espacios"></asp:RegularExpressionValidator>
        </div>
    </div>
    <div class="divformulario">
        <div class="nombrecontrol">
            Marca:
        </div>
        <div class="control">
            <asp:TextBox ID="txtMarca_pro" MaxLength="20" runat="server"></asp:TextBox>
            
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtMarca_pro" ErrorMessage="Complete la marca del producto"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator5" ControlToValidate="txtMarca_pro"
                ValidationExpression="[a-zA-Z ]*" runat="server" ErrorMessage="Se permiten solo letras y espacios"></asp:RegularExpressionValidator>
        </div>
    </div>
    <div class="divformulario">
        <div class="nombrecontrol">
            Modelo:
        </div>
        <div class="control">
            <asp:TextBox ID="txtModelo" MaxLength="30" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtModelo" ErrorMessage="Complete una descripcion del producto"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="txtModelo"
                ValidationExpression="[a-zA-Z ]*" runat="server" ErrorMessage="Se permiten solo letras y espacios"></asp:RegularExpressionValidator>
        </div>
    </div>
    <div class="divformulario">
        <div class="nombrecontrol">
            Categoria:
        </div>
        <div class="control">
            <asp:DropDownList ID="ddlCategoria" runat="server">
            </asp:DropDownList>
        </div>
    </div>
    <div class="divformulario">
        <div class="nombrecontrol">
            Stock Minimo:
        </div>
        <div class="control">
            <asp:TextBox ID="txtStockMinimo_pro" MaxLength="4" runat="server"></asp:TextBox>

                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtStockMinimo_pro" ErrorMessage="Complete nombre del producto"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ControlToValidate="txtStockMinimo_pro" ValidationExpression="[0-9]*" runat="server" ErrorMessage="Se permiten solo numeros"></asp:RegularExpressionValidator>
        </div>
    </div>
    <div class="divformulario">
        <div class="nombrecontrol">
            Stock:
        </div>
        <div class="control">
            <asp:TextBox ID="txtStock" MaxLength="4" runat="server"></asp:TextBox>

                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtStock" ErrorMessage="Complete nombre del producto"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator6" ControlToValidate="txtStock" ValidationExpression="[0-9]*" runat="server" ErrorMessage="Se permiten solo numeros"></asp:RegularExpressionValidator>
        </div>
    </div>
    <div class="divformulario">
        <div class="nombrecontrol">
            Precio:
        </div>
        <div class="control">
            <asp:TextBox ID="txtPrecio_pro" MaxLength="6" runat="server"></asp:TextBox>
            
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtPrecio_pro" ErrorMessage="Complete el precio del producto"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" ControlToValidate="txtPrecio_pro" ValidationExpression="[0-9]*" runat="server" ErrorMessage="Se permiten solo numeros"></asp:RegularExpressionValidator>
        </div>
    </div>
    <div class="divformulario">
        <div class="nombrecontrol">
            <asp:Button ID="btnModificarDatos" runat="server" Text="Modificar Datos" 
                onclick="btnModificarDatos_Click"></asp:Button>
        </div>
        <div class="control">
            <a href="VerProducto.aspx">Volver</a>
        </div>
    </div>
    <div class="divformulario">
        <asp:Label runat="server" ID="lblProducto" text="" ></asp:Label>
    </div>
</asp:Content>
