<%@ Page Title="InicioSesion" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InicioSesion.aspx.cs" Inherits="TPI_GRUPO_25.InicioSesion" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- Acá pueden ir Scripts-->
    <style>
            body {
    background-color: #ffe5b4;
    min-height: 100vh;
}
            .bg-naranja-txtBox {
                background-color: #ffd1a4;
            }
            .border-naranja {
        border: 2px solid #ff9800;
    }
.btn-marron {
        background-color: #9E5439; /* marrón */
        color: #fff;
        border: 1px solid black;
        transition: background-color 0.3s ease, transform 0.2s ease;
    }

    .btn-marron:hover {
        background-color: #9C2900; /* marrón más oscuro */
        border: 1px solid black;
        color: #fff;
    }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="bg-naranja-suave">
        <div class="row justify-content-center">
            <div class="col-md-4">
                <h2 class="text-center mb-4">¡Bienvenido a la Clínica TUP!</h2>
                <img class="img-fluid d-block mx-auto w-50 mb-4" src="/imagenes/UTN-logo.svg" />
                <h3 class="text-center mb-4">Inicia Sesión:</h3>
                <div class="mb-3">
                    <label for="txtUsuario" class="form-label">Usuario:</label>
                    <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control bg-naranja-txtBox border-naranja" placeholder="Ingrese el nombre de Usuario..." />
                                            <asp:RegularExpressionValidator CssClass="fw-bold"
    ID="revUsuario" 
    ControlToValidate="txtUsuario" 
    ErrorMessage="El usuario no puede contener solo símbolos." 
    ValidationExpression="^(?=.*[a-zA-Z0-9])[^\s]+$"
    runat="server" />
                    <br />
                    <asp:RequiredFieldValidator CssClass="fw-bold" runat="server" ControlToValidate="txtUsuario" ErrorMessage="No ingresó un Usuario."></asp:RequiredFieldValidator>
                </div>

                <div class="mb-3">
                    <label for="txtClave" class="form-label">Contraseña:</label>
                    <asp:TextBox ID="txtClave" runat="server" TextMode="Password" CssClass="form-control bg-naranja-txtBox border-naranja" placeholder="Ingrese su Contraseña..." />
                    <br />
                    <asp:RequiredFieldValidator CssClass="fw-bold" runat="server" ControlToValidate="txtClave" ErrorMessage="No ingresó una Contraseña."></asp:RequiredFieldValidator>
                </div>

                <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" CssClass="btn btn-marron w-100" />
            </div>
        </div>
    </div>
</asp:Content>
