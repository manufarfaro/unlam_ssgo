<%@ Page Title="" Language="C#" MasterPageFile="~/Usuario.master" AutoEventWireup="true" CodeFile="EditarCategoria.aspx.cs" Inherits="Administracion_EditarCategoria" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

    <h1>
        Editar Categoria:
    </h1>

    <div class="divformulario">
        <div class="nombrecontrol">
            Nombre
        </div>
        <div class="control">
            <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNombre" ErrorMessage="El campo es requerido"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="divformulario">
        <div class="nombrecontrol">
            Codigo
        </div>
        <div class="control">
            <asp:TextBox ID="txtCodigo" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtCodigo" ErrorMessage="El campo es requerido"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="divformulario">
        <div class="nombrecontrol">
            Descrici&oacute;n
        </div>
        <div class="control">
            <asp:TextBox ID="txtDescripcion" TextMode="MultiLine" MaxLength="50" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtDescripcion" ErrorMessage="El campo es requerido"></asp:RequiredFieldValidator>
        </div>
    </div>

    <div class="divformulario">
        <div class="nombrecontrol">
            <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" 
                onclick="btnActualizar_Click" />
        </div>
        <div class="control">
            <a href="VerCategoria.aspx">Volver</a>
        </div>
    </div>

    <div class="divformulario">
        <asp:Label ID="lblCategorias" runat="server" Text=""></asp:Label>
    </div>

</asp:Content>
