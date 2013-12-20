<%@ Page Title="" Language="C#" MasterPageFile="~/Usuario.master" AutoEventWireup="true"
    CodeFile="EditarCuenta.aspx.cs" Inherits="SuperUsuario_MiCuenta_EditarCuenta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="divformulario" runat="server" >
        <div class="nombrecontrol">
            Nombre de usuario:
        </div>
        <div class="control">
            <asp:TextBox ID="txtUserid" Enabled="false" runat="server"></asp:TextBox>
            
            <asp:RequiredFieldValidator ID="rfvUserid" runat="server" ControlToValidate="txtUserid" ErrorMessage="Complete nombre de usuario"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="txtNombre" ValidationExpression="[a-zA-Z0-9]*" runat="server" ErrorMessage="Se permiten solo letras y espacios"></asp:RegularExpressionValidator>
        </div>
    </div>
    <div class="divformulario" runat="server"  id="divNombre" visible="false">
        <div class="nombrecontrol">
            Nombre:
        </div>
        <div class="control">
            <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>

            <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="txtNombre" ErrorMessage="Complete Nombre"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="divformulario" runat="server" id="divApellido" visible="false">
        <div class="nombrecontrol">
            Apellido:
        </div>
        <div class="control">
            <asp:TextBox ID="txtApellido" runat="server"></asp:TextBox>

            <asp:RequiredFieldValidator ID="rfvApellido" runat="server" ControlToValidate="txtApellido" ErrorMessage="Complete Apellido"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="divformulario" runat="server"  id="divCUIT" visible="false">
        <div class="nombrecontrol">
            CUIT:
        </div>
        <div class="control">
            <asp:TextBox ID="txtCUIT" runat="server"></asp:TextBox>

            <asp:RequiredFieldValidator ID="rfvCUIT" runat="server" ControlToValidate="txtCUIT" ErrorMessage="Complete CUIT"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="divformulario" runat="server"  id="divDocumento" visible="false">
        <div class="nombrecontrol">
            Documento:
        </div>
        <div class="control">
            <asp:TextBox ID="txtDocumento" runat="server"></asp:TextBox>

            <asp:RequiredFieldValidator ID="rfvDocumento" runat="server" ControlToValidate="txtDocumento" ErrorMessage="Complete Documento"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="divformulario" runat="server" id="divRazonSocial" visible="false">
        <div class="nombrecontrol">
            Razon Social:
        </div>
        <div class="control">
            <asp:TextBox ID="txtRazonSocial" runat="server"></asp:TextBox>

            <asp:RequiredFieldValidator ID="rfvRazonSocial" runat="server" ControlToValidate="txtRazonSocial" ErrorMessage="Complete Razon Social"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="divformulario" runat="server"  id="divProvincia" visible="false">
        <div class="nombrecontrol">
            Provincia:
        </div>
        <div class="control">
            <asp:TextBox ID="txtProvincia" runat="server"></asp:TextBox>

            <asp:RequiredFieldValidator ID="rfvProvincia" runat="server" ControlToValidate="txtProvincia" ErrorMessage="Complete Provincia"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="divformulario" runat="server"  id="divLocalidad" visible="false">
        <div class="nombrecontrol">
            Localidad:
        </div>
        <div class="control">
            <asp:TextBox ID="txtLocalidad" runat="server"></asp:TextBox>

            <asp:RequiredFieldValidator ID="rfvLocalidad" runat="server" ControlToValidate="txtLocalidad" ErrorMessage="Complete Localidad"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="divformulario">
        <div class="nombrecontrol">
            Direccion:
        </div>
        <div class="control">
            <asp:TextBox ID="txtDireccion" runat="server"></asp:TextBox>

            <asp:RequiredFieldValidator ID="rfvDireccion" runat="server" ControlToValidate="txtDireccion" ErrorMessage="Complete Direccion"></asp:RequiredFieldValidator>
        </div>
    </div>
    <!-- <div class="divformulario">
        <div class="nombrecontrol">
            Codigo Postal:
        </div>
        <div class="control">
            <asp:TextBox ID="txtCodigoPostal" runat="server"></asp:TextBox>
        </div>
    </div>
    -->
    <div class="divformulario">
        <div class="nombrecontrol">
            Telefono:
        </div>
        <div class="control">
            <asp:TextBox ID="txtTelefono" runat="server"></asp:TextBox>

            <asp:RequiredFieldValidator ID="rfvTelefono" runat="server" ControlToValidate="txtTelefono" ErrorMessage="Complete Telefono"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="divformulario" runat="server"  id="divEmail" visible="false">
        <div class="nombrecontrol">
            Email:
        </div>
        <div class="control">
            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>

            <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Complete Email"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator id="revEmail" ControlToValidate="txtEmail" Text="Email no valido" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Runat="server" />    
        </div>
    </div>
    <div class="divformulario">
        <asp:Button ID="btnModificarDatos" runat="server" Text="Modificar Datos" 
            onclick="btnModificarDatos_Click"></asp:Button>
        <asp:Label ID="lblResultado" runat="server" Text=""></asp:Label>
    </div>
</asp:Content>
