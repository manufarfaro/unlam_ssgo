<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CrearCategoria.aspx.cs" MasterPageFile="~/Usuario.master"
    Inherits="CrearCategoria" %>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Complete el formulario para crear una Nueva Categoria
    </h2>
    <form id="form1" method="post" action="#">
    <div>
        <div class="divformulario">
            <div class="nombrecontrol">
                Codigo de la Nueva Categoria:
            </div>
            <div class="control">
                <asp:TextBox ID="txtCodigoCategoria" MaxLength="20" runat="server"></asp:TextBox>
            </div>
            <div class="control">
                <asp:RequiredFieldValidator ID="valCodigoCategoria" runat="server" ErrorMessage="El Código es requerido"
                    ControlToValidate="txtCodigoCategoria"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtCodigoCategoria"
                    ValidationExpression="[a-zA-Z0-9-_ ]*" runat="server" ErrorMessage="Se permiten solo letras, numeros y guiones -_"></asp:RegularExpressionValidator>
            </div>
        </div>
        <div class="divformulario">
            <div class="nombrecontrol">
                Nombre:
            </div>
            <div class="control">
                <asp:TextBox ID="txtNombreCategoria" MaxLength="30" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="txtNombreCategoria"
                    ValidationExpression="[a-zA-Z0-9-_ ]*" runat="server" ErrorMessage="Se permiten solo letras, numeros y guiones -_"></asp:RegularExpressionValidator>
            </div>
            <div class="control">
                <asp:RequiredFieldValidator ID="valNombreCategoria" runat="server" ErrorMessage="El Nombre es requerido"
                    ControlToValidate="txtNombreCategoria"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="divformulario">
            <div class="nombrecontrol">
                Descripcion:
            </div>
            <div class="control">
                <asp:TextBox ID="txtDescripcion" TextMode="MultiLine" MaxLength="50" runat="server"></asp:TextBox>
            </div>
            <div class="control">
                <asp:RequiredFieldValidator ID="valDescripcion" runat="server" ErrorMessage="La Descripcion es requerida"
                    ControlToValidate="txtDescripcion"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ControlToValidate="txtDescripcion"
                ValidationExpression="[a-zA-Z0-9\-_ ]*" runat="server" ErrorMessage="Se permiten solo letras, numeros y guiones -_"></asp:RegularExpressionValidator>
            </div>
        </div>
        <div class="divformulario">
            <div class="control">
                <asp:Button ID="btnCrear" runat="server" Text="Crear" OnClick="btnCrear_Click" />
            </div>
        </div>
        <div class="divformulario">
            <asp:Label ID="lblResultado" runat="server" Text=""></asp:Label>
        </div>
    </div>
    </form>
</asp:Content>
