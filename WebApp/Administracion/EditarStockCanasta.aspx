<%@ Page Title="" Language="C#" MasterPageFile="~/Usuario.master" AutoEventWireup="true" CodeFile="EditarStockCanasta.aspx.cs" Inherits="Administracion_EditarStockCanasta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <h1>
        Editar Stock:
    </h1>

    <div class="divformulario">
        <div class="nombrecontrol">
            C&oacute;digo:
        </div>
        <div class="control">
            <asp:Label ID="lblId" runat="server" Text=""></asp:Label>
        </div>
    </div>

    <div class="divformulario">
        <div class="nombrecontrol">
            Nombre:
        </div>
        <div class="control">
            <asp:Label ID="lblName" runat="server" Text=""></asp:Label>
        </div>
    </div>

    <div class="divformulario">
        <div class="nombrecontrol">
            Marca:
        </div>
        <div class="control">
            <asp:Label ID="lblBrand" runat="server" Text=""></asp:Label>
        </div>
    </div>

    <div class="divformulario">
        <div class="nombrecontrol">
            Precio:
        </div>
        <div class="control">
            <asp:Label ID="lblPrice" runat="server" Text=""></asp:Label>
        </div>
    </div>

    <div class="divformulario">
        <div class="nombrecontrol">
            Cantidad:
        </div>
        <div class="control">
            <asp:TextBox ID="txtQty" runat="server" Text=""></asp:TextBox>
        </div>
    </div>

    <div class="divformulario">
        <div class="nombrecontrol">
            <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" 
                onclick="btnActualizar_Click" />
        </div>
        <div class="control">
            <a href="Venta.aspx">Volver</a>
            
        </div>
    </div>
    <div class="divformulario">
        <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label>
    </div>
</asp:Content>

