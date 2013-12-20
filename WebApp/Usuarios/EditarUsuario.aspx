<%@ Page Title="" Language="C#" MasterPageFile="~/Usuario.master" AutoEventWireup="true" CodeFile="EditarUsuario.aspx.cs" Inherits="Usuarios_EditarUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<h3>
    Editar Usuario:
</h3>
    <div class="divformulario">
        <div class="nombrecontrol">
            Nombre de usuario
        </div>
        <div class="control">
            <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="divformulario">
        <div class="nombrecontrol">
            Nombre
        </div>
        <div class="control">
            <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="divformulario">
        <div class="nombrecontrol">
            Apellido
        </div>
        <div class="control">
            <asp:TextBox ID="txtApellido" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="divformulario">
        <div class="nombrecontrol">
            DNI
        </div>
        <div class="control">
            <asp:TextBox ID="txtDni" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="divformulario">
        <div class="nombrecontrol">
            Direccion
        </div>
        <div class="control">
            <asp:TextBox ID="txtDireccion" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="divformulario">
        <div class="nombrecontrol">
            Email
        </div>
        <div class="control">
            <asp:TextBox ID="txtMail" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="divformulario">
        <div class="nombrecontrol">
            Telefono
        </div>
        <div class="control">
            <asp:TextBox ID="txtTelefono" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="divformulario">
        <asp:Button ID="btnEliminarUsuario" runat="server" Text="Actualizar Usuario" 
            onclick="btnActualizarUsuario_Click" />
        <a href="VerUsuariosRegistrados.aspx">Volver</a>
    </div>
    <div class="divformulario">
        <asp:Label ID="lblUsuario" runat="server" Text=""></asp:Label>
    </div>
</asp:Content>

