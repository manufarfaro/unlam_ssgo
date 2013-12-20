<%@ Page Title="" Language="C#" MasterPageFile="~/Usuario.master" AutoEventWireup="true" CodeFile="CambiarClave.aspx.cs" Inherits="SuperUsuario_MiCuenta_CambiarClave" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="divformulario">
        <div class="nombrecontrol">
            Clave actual:
        </div>
        <div class="control">
            <asp:TextBox ID="txtClaveActual" TextMode="Password" MaxLength="25" runat="server"></asp:TextBox>
        </div>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtClaveActual" runat="server" ErrorMessage="Debe ingresar su clave actual"></asp:RequiredFieldValidator>
    </div>
    <div class="divformulario">
        <div class="nombrecontrol">
            Nueva clave:
        </div>
        <div class="control">
            <asp:TextBox ID="txtClave1" TextMode="Password" MaxLength="25" runat="server"></asp:TextBox>
        </div>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtClave1" runat="server" ErrorMessage="Debe ingresar una nueva clave"></asp:RequiredFieldValidator>
        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtClave1" ControlToCompare="txtClave2" ErrorMessage="Las contraseñas deben coincidir"></asp:CompareValidator>
    </div>
    <div class="divformulario">
        <div class="nombrecontrol">
            Repita la clave para verificar:
        </div>
        <div class="control">
            <asp:TextBox ID="txtClave2" TextMode="Password" MaxLength="25" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="divformulario">
        <asp:Button ID="btnModificarClave" runat="server" Text="Modificar Clave" 
            onclick="btnModificarClave_Click"></asp:Button>
        <asp:Label ID="lblResultado" runat="server" Text=""></asp:Label>
    </div>


</asp:Content>

