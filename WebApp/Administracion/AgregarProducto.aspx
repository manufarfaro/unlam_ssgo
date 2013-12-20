<%@ Page Title="" Language="C#" MasterPageFile="~/Usuario.master" AutoEventWireup="true" CodeFile="AgregarProducto.aspx.cs" Inherits="AgregarProducto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<form action="#" method="post">
<div class="divformulario">
    <div class="nombrecontrol">
        Nombre:
    </div>
    <div class="control">
        <asp:TextBox ID="txtNombre" MaxLength="50" runat="server"></asp:TextBox>
        
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNombre" ErrorMessage="Complete nombre del producto"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtNombre" ValidationExpression="[a-zA-Z ]*" runat="server" ErrorMessage="Se permiten solo letras y espacios"></asp:RegularExpressionValidator>
           
    </div>
</div>
<div class="divformulario">
    <div class="nombrecontrol">
        Categoria:
    </div>
    <div class="control">
        <asp:DropDownList ID="ddlCategoria" runat="server">
        </asp:DropDownList>

        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlCategoria" ErrorMessage="Seleccione una categoria"></asp:RequiredFieldValidator>

    </div>
</div>
<div class="divformulario">
    <div class="nombrecontrol">
        Stock Minimo:
    </div>
    <div class="control">
        <asp:TextBox ID="txtStockMinimo" MaxLength="3" runat="server"></asp:TextBox>

        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtStockMinimo" ErrorMessage="Complete el stock minimo"></asp:RequiredFieldValidator>
        <asp:RangeValidator ID="RangeValidator2" ControlToValidate="txtStockMinimo" MinimumValue="0" MaximumValue="100" Type="Integer" runat="server" ErrorMessage="El stock minimo debe estar en el rango de 0 a 100"></asp:RangeValidator>

    </div>
</div>
<div class="divformulario">
    <div class="nombrecontrol">
    Stock Inicial:
    </div>
    <div class="control">
    <asp:TextBox ID="txtStockInicial" MaxLength="5" runat="server"></asp:TextBox>

    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtStockInicial" ErrorMessage="Complete el stock inicial"></asp:RequiredFieldValidator>
            <asp:RangeValidator ID="RangeValidator3" ControlToValidate="txtStockInicial" MinimumValue="0" MaximumValue="10000" Type="Integer" runat="server" ErrorMessage="El stock inicial debe estar en el rango de 0 a 10000"></asp:RangeValidator>


    </div>
</div>
<div class="divformulario">
    <div class="nombrecontrol">
        Marca:
    </div>
    <div class="control">
        <asp:TextBox ID="txtMarca" MaxLength="50" runat="server"></asp:TextBox>

        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtMarca" ErrorMessage="Complete marca del producto"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="txtNombre" ValidationExpression="[a-zA-Z0-9 ]*" runat="server" ErrorMessage="Se permiten solo letras y espacios"></asp:RegularExpressionValidator>
        
    </div>
</div>
<div class="divformulario">
    <div class="nombrecontrol">
        Modelo:
    </div>
    <div class="control">
        <asp:TextBox ID="txtModelo" MaxLength="50" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtModelo" ErrorMessage="Complete modelo del producto"></asp:RequiredFieldValidator>
    </div>
</div>
<div class="divformulario">
    <div class="nombrecontrol">
    Precio($):
    </div>
    <div class="control">
    <asp:TextBox ID="txtPrecio" MaxLength="7" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtPrecio" ErrorMessage="Complete precio del producto"></asp:RequiredFieldValidator>
    </div>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ControlToValidate="txtPrecio" ValidationExpression="[0-9 ]*" runat="server" ErrorMessage="El precio debe ser numerico"></asp:RegularExpressionValidator>
    <asp:RangeValidator ID="RangeValidator1" MinimumValue="1" MaximumValue="100000" Type="integer" ControlToValidate="txtPrecio" runat="server" ErrorMessage="El precio no puede ser menor a 1 ni mayor a 100000"></asp:RangeValidator>
</div>
<div class="divformulario">
    <asp:Button ID="btnAgregar" runat="server" Text="Agregar" 
        onclick="btnAgregar_Click"></asp:Button>
</div>
<div class="divformulario">
    <asp:Label ID="lblResultado" runat="server" Text=""></asp:Label>
</div>
</form>
</asp:Content>
