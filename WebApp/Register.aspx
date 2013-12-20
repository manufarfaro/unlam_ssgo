<%@ Page Title="Registrarse" Language="C#" MasterPageFile="~/Usuario.master" AutoEventWireup="true"
    CodeFile="Register.aspx.cs" Inherits="Account_Register" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">



                    <h2>
                        Crear una nueva cuenta
                    </h2>
                    <p>
                        Use el formulario siguiente para crear una cuenta nueva.
                    </p>
                    <p>
                        Las contraseñas deben tener una longitud mínima de 6 caracteres.
                    </p>
                    <span class="failureNotification">
                        <asp:Literal ID="ErrorMessage" runat="server"></asp:Literal>
                    </span>
                    <asp:ValidationSummary ID="RegisterUserValidationSummary" runat="server" CssClass="failureNotification" 
                         ValidationGroup="RegisterUserValidationGroup"/>
                    <div class="accountInfo">
                        <fieldset class="register">
                            <legend>Información de cuenta</legend>
                            <p>
                                <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="txtUsuario">Nombre de usuario:</asp:Label>
                                <asp:TextBox ID="txtUsuario" runat="server" CssClass="textEntry" MaxLength="25"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="txtUsuario" 
                                     CssClass="failureNotification" ErrorMessage="El nombre de usuario es obligatorio." ToolTip="El nombre de usuario es obligatorio." 
                                     ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>

                                     <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="txtUsuario" ValidationExpression="[a-zA-Z0-9]*" runat="server" ErrorMessage="Se permiten solo letras y numeros"></asp:RegularExpressionValidator>
                            </p>
                            <p>
                                <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="txtPassword">Contraseña:</asp:Label>
                                <asp:TextBox ID="txtPassword" runat="server" CssClass="passwordEntry" TextMode="Password" MaxLength="25"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="txtPassword" 
                                     CssClass="failureNotification" ErrorMessage="La contraseña es obligatoria." ToolTip="La contraseña es obligatoria." 
                                     ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                            </p>
                            <p>
                                <asp:Label ID="ConfirmPasswordLabel" runat="server" AssociatedControlID="txtPassword2">Confirmar contraseña:</asp:Label>
                                <asp:TextBox ID="txtPassword2" runat="server" CssClass="passwordEntry" TextMode="Password" MaxLength="25"></asp:TextBox>
                                <asp:RequiredFieldValidator ControlToValidate="txtPassword2" CssClass="failureNotification" Display="Dynamic" 
                                     ErrorMessage="Confirmar contraseña es obligatorio." ID="ConfirmPasswordRequired" runat="server" 
                                     ToolTip="Confirmar contraseña es obligatorio." ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="PasswordCompare" runat="server" ControlToCompare="txtPassword" ControlToValidate="txtPassword2" 
                                     CssClass="failureNotification" Display="Dynamic" ErrorMessage="Contraseña y Confirmar contraseña deben coincidir."
                                     ValidationGroup="RegisterUserValidationGroup">*</asp:CompareValidator>
                            </p>
                            <p>
                                <asp:Label ID="Label1" runat="server" AssociatedControlID="txtRazonSocial">RazonSocial:</asp:Label>
                                <asp:TextBox ID="txtRazonSocial" runat="server" CssClass="textEntry" MaxLength="25"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtRazonSocial" 
                                     CssClass="failureNotification" ErrorMessage="El campo Razon Social es obligatorio." ToolTip="El campo Razon Social es obligatorio." 
                                     ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>

                                     <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtRazonSocial" ValidationExpression="[a-zA-Z0-9 ]*" runat="server" ErrorMessage="Se permiten solo letras y numeros"></asp:RegularExpressionValidator>
                            </p>
                            <p>
                                <asp:Label ID="Label2" runat="server" AssociatedControlID="txtDireccion">Direccion:</asp:Label>
                                <asp:TextBox ID="txtDireccion" runat="server" CssClass="textEntry" MaxLength="25"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDireccion" CssClass="failureNotification" ErrorMessage="La Direccion es obligatoria." ToolTip="La Direccion es obligatoria." ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                                     <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ControlToValidate="txtDireccion" ValidationExpression="[a-zA-Z0-9 ]*" runat="server" ErrorMessage="Se permiten solo letras y Numeros"></asp:RegularExpressionValidator>
                            </p>
                            <p>
                                <asp:Label ID="Label3" runat="server" AssociatedControlID="txtCUIT">CUIT:</asp:Label>
                                <asp:TextBox ID="txtCUIT" runat="server" CssClass="textEntry" MaxLength="25"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtCUIT" 
                                     CssClass="failureNotification" ErrorMessage="El CUIT es obligatorio." ToolTip="El CUIT es obligatorio." ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                                     <asp:RegularExpressionValidator ID="RegularExpressionValidator4" ControlToValidate="txtCUIT" ValidationExpression="[0-9\- ]*" runat="server" ErrorMessage="Se permiten solo numeros y guiones"></asp:RegularExpressionValidator>
                            </p>
                            <p>
                                <asp:Label ID="Label4" runat="server" AssociatedControlID="txtTelefono">Telefono:</asp:Label>
                                <asp:TextBox ID="txtTelefono" runat="server" CssClass="textEntry" MaxLength="25"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtTelefono" 
                                     CssClass="failureNotification" ErrorMessage="El Telefono es obligatorio." ToolTip="El Telefono es obligatorio." ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                                     <asp:RegularExpressionValidator ID="RegularExpressionValidator5" ControlToValidate="txtTelefono" ValidationExpression="[0-9]*" runat="server" ErrorMessage="Se permiten solo numeros"></asp:RegularExpressionValidator>
                            </p>
                        </fieldset>
                        <p class="submitButton">
                            <asp:Label ID="lblSeCreo" runat="server" Text=""></asp:Label>
                            <asp:Button ID="CreateUserButton" runat="server" CommandName="MoveNext" Text="Crear usuario" 
                                 ValidationGroup="RegisterUserValidationGroup" 
                                onclick="CreateUserButton_Click"/>
                        </p>
                    </div>

<a href="Default.aspx">Volver</a>
    
</asp:Content>