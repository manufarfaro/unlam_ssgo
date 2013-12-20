<%@ Page Title="" Language="C#" MasterPageFile="~/Superusuario.master" AutoEventWireup="true" CodeFile="HabilitacionEmpresa.aspx.cs" Inherits="Usuarios_HabilitacionEmpresa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

    
    <div class="divformulario">
        <div class="nombrecontrol">
            Empresa
        </div>
        <div class="control">
                <asp:DropDownList ID="ddlEmpresa" runat="server">
                </asp:DropDownList>
        </div>
    </div>
    <div class="divformulario">
        <div class="nombrecontrol">
            Habilitado
        </div>
        <div class="control">
            <asp:DropDownList ID="ddlHabilitado" runat="server">
                <asp:ListItem Selected="True" Text="" Value=""></asp:ListItem>
                <asp:ListItem Text="Si" Value="s"></asp:ListItem>
                <asp:ListItem Text="No" Value="n"></asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>
    <div class="divformulario">
        <div class="nombrecontrol">
    
        </div>
        <div class="control">
            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" />
        </div>
    </div>


</asp:Content>

