<%@ Page Title="" Language="C#" MasterPageFile="~/Usuario.master" AutoEventWireup="true" CodeFile="EliminarCategoria.aspx.cs" Inherits="EliminarCategoria" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<h1>Seleccione la categoria a eliminar:</h1>

    <div class="divformulario">
        <div class="nombrecontrol">
            Categoria <!-- aca se van a concatenar de esta forma: nombre de categoria - numero categoria -->
        </div>
        <div class="control">
            <asp:DropDownList ID="ddlCategoria" runat="server" >
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlCategoria" ErrorMessage="Seleccione una categoria"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="divformulario">
        <asp:Button ID="btnEliminarCategoria" runat="server" Text="Eliminar Categoria" 
            onclick="btnEliminarCategoria_Click" />
    </div>


</asp:Content>

