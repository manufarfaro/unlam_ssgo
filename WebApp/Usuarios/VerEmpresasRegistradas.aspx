<%@ Page Title="" Language="C#" MasterPageFile="~/Usuario.master" AutoEventWireup="true" CodeFile="VerEmpresasRegistradas.aspx.cs" Inherits="Administrador_Empresas_VerEmpresasRegistradas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <h1>Empresas Registradas</h1>
<div class="frmStructure">
    <asp:GridView ID="gvEmpresas" class="formStandart" runat="server"  OnRowCommand="gvEmpresas_RowCommand"
        AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="Id_Empresa" HeaderText="Id" />
            <asp:BoundField DataField="RazonSocial" HeaderText="RazonSocial" />
            <asp:BoundField DataField="Direccion" HeaderText="Direccion" />
            <asp:BoundField DataField="CUIT" HeaderText="CUIT" />
            <asp:BoundField DataField="Telefono" HeaderText="Telefono" />
            <asp:BoundField DataField="Activo" HeaderText="Activo" ReadOnly="True" />
            <asp:ButtonField Text="Habilitar" CommandName="btnHabilitar" 
                ButtonType="Button" DataTextFormatString="Habilitar" />
            <asp:ButtonField Text="Deshabilitar" CommandName="btnDeshabilitar" 
                ButtonType="Button" DataTextFormatString="Deshabilitar" />
        </Columns>
    </asp:GridView>
</div>
<div class="divformulario">
    <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" />
</div>
</asp:Content>