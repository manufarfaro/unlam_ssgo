<%@ Page Title="" Language="C#" MasterPageFile="~/Usuario.master" AutoEventWireup="true" CodeFile="VerUsuariosRegistrados.aspx.cs" Inherits="Usuario_Administracion_VerUsuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <h1>Usuarios Registrados</h1>
    <div class="frmStructure">
        <asp:GridView ID="gvUsuarios" class="formStandart" runat="server" 
            AutoGenerateColumns="False" 
            onselectedindexchanged="gvUsuarios_SelectedIndexChanged" 
            OnRowCommand="gvUsuarios_RowCommand" CellPadding="4" ForeColor="#333333" 
            GridLines="Horizontal" >
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="id_Usuario" HeaderText="Id" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                <asp:BoundField DataField="email" HeaderText="Mail" />
                <asp:BoundField DataField="UserName" HeaderText="Usuario" />
                <asp:HyperLinkField DataNavigateUrlFields="id_Usuario" 
                    DataNavigateUrlFormatString="~/Usuarios/EditarUsuario.aspx?id_Usuario={0}" 
                    NavigateUrl="~/Usuarios/EditarUsuario.aspx" Text="Editar" />
                <asp:ButtonField CommandName="cmdBorrar" Text="Borrar" />
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
    </div>
    <div class="divformulario">
    <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" />
    <asp:Label ID="lblUsuario" runat="server" Text=""></asp:Label>
</div>
</asp:Content>

