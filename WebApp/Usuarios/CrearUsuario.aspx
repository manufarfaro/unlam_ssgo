<%@ Page Title="" Language="C#" MasterPageFile="~/Usuario.master" AutoEventWireup="true" CodeFile="CrearUsuario.aspx.cs" Inherits="Usuarios_CrearUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<form action="#">
    <div class="divformulario">
        <div class="nombrecontrol">
            Nombre
        </div>
        <div class="control">
            <asp:TextBox ID="txtNombre" MaxLength="50" runat="server"></asp:TextBox>

            
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNombre" ErrorMessage="Complete nombre del Usuario"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtNombre" ValidationExpression="[a-zA-Z ]*" runat="server" ErrorMessage="Se permiten solo letras y espacios"></asp:RegularExpressionValidator>
           
        </div>
    </div>
    <div class="divformulario">
        <div class="nombrecontrol">
            Apellido
        </div>
        <div class="control">
            <asp:TextBox ID="txtApellido" MaxLength="30" runat="server"></asp:TextBox>

           <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtApellido" ErrorMessage="Complete apellido del Usuario"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="txtNombre" ValidationExpression="[a-zA-Z ]*" runat="server" ErrorMessage="Se permiten solo letras y espacios"></asp:RegularExpressionValidator>
           
        </div>
    </div>
    <div class="divformulario">
        <div class="nombrecontrol">
            DNI
        </div>
        <div class="control">
            <asp:TextBox ID="txtDni" MaxLength="10" runat="server"></asp:TextBox>
            
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtDni" ErrorMessage="Complete DNI del usuario"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ControlToValidate="txtDni" ValidationExpression="[0-9]*" runat="server" ErrorMessage="Se permiten solo números"></asp:RegularExpressionValidator>
           
        </div>
    </div>
    <div class="divformulario">
        <div class="nombrecontrol">
            Direccion
        </div>
        <div class="control">
            <asp:TextBox ID="txtDireccion" MaxLength="30" runat="server"></asp:TextBox>
            
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtDireccion" ErrorMessage="Complete direccion del usuario"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" ControlToValidate="txtDireccion" ValidationExpression="[a-zA-Z0-9 ]*" runat="server" ErrorMessage="Se permiten solo letras, números y espacios"></asp:RegularExpressionValidator>
           
        </div>
    </div>
    <div class="divformulario">
        <div class="nombrecontrol">
            Email
        </div>
        <div class="control">
            <asp:TextBox ID="txtEmail" MaxLength="30" runat="server"></asp:TextBox>
            
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtEmail" ErrorMessage="Complete el email del cliente"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator id="revEmail" ControlToValidate="txtEmail" Text="Email no valido" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Runat="server"></asp:RegularExpressionValidator>
           
        </div>
    </div>
    <div class="divformulario">
        <div class="nombrecontrol">
            Telefono
        </div>
        <div class="control">
            <asp:TextBox ID="txtTelefono" MaxLength="12" runat="server"></asp:TextBox>

            
        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtTelefono" ErrorMessage="Complete el telefono del usuario"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator6" ControlToValidate="txtTelefono" ValidationExpression="[0-9]*" runat="server" ErrorMessage="Se permiten solo números"></asp:RegularExpressionValidator>
           
        </div>
    </div>
    <div class="divformulario">
        <div class="nombrecontrol">
            Nombre de usuario
        </div>
        <div class="control">
            <asp:TextBox ID="txtUserID" runat="server" MaxLength="20"></asp:TextBox>
            
        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtUserID" ErrorMessage="Complete nombre de usuario"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator7" ControlToValidate="txtUserID" ValidationExpression="[a-zA-Z0-9]*" runat="server" ErrorMessage="Se permiten solo letras y numeros"></asp:RegularExpressionValidator>
           
        </div>
    </div>
    <div class="divformulario">
        <div class="nombrecontrol">
            Clave
        </div>
        <div class="control">
            <asp:TextBox ID="txtClave" TextMode="Password" MaxLength="20" runat="server"></asp:TextBox>

            
        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtClave" ErrorMessage="Complete contraseña"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="divformulario">
        <asp:Button ID="btnCrearUsuario" runat="server" Text="Crear Usuario" 
            onclick="btnCrearUsuario_Click" />
    </div>
    <div class="divformulario">
        <asp:Label ID="lblSeCreo" runat="server" Text=""></asp:Label>
    </div>
</form>
</asp:Content>

