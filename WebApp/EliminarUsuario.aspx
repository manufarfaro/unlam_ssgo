<%@ Page Title="" Language="C#" MasterPageFile="~/Usuario.master" AutoEventWireup="true" CodeFile="EliminarUsuario.aspx.cs" Inherits="Usuarios_EliminarUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="divformulario">
        <div class="nombrecontrol">
            Nombre de usuario
        </div>
        <div class="control">
            <asp:DropDownList ID="ddlUsuarios" runat="server" AutoPostBack="true"
                onselectedindexchanged="ddlUsuarios_SelectedIndexChanged">
            </asp:DropDownList>
        </div>
    </div>
    <div class="divformulario">
        <div class="nombrecontrol" >
            Nombre
        </div>
        <div class="control">
            <asp:TextBox ID="txtNombre" runat="server" Enabled="false"></asp:TextBox>
        </div>
    </div>
    <div class="divformulario">
        <div class="nombrecontrol">
            Apellido
        </div>
        <div class="control">
            <asp:TextBox ID="txtApellido" runat="server" Enabled="false" ></asp:TextBox>
        </div>
    </div>
    <div class="divformulario" visible="false">
        <div class="nombrecontrol">
            DNI
        </div>
        <div class="control">
            <asp:TextBox ID="txtDni" runat="server" Enabled="false" ></asp:TextBox>
        </div>
    </div>
        <div class="divformulario">
        <div class="nombrecontrol">
                    <asp:Button ID="btnEliminarUsuario" runat="server" Text="Eliminar Usuario" 
            onclick="btnEliminarUsuario_Click" />
        </div>
            <asp:Label ID="lblUsuarios" runat="server" Text=""></asp:Label>
            </div>
</asp:Content>

