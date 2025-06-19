<%@ Page Title="AltaPaciente" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AltaPaciente.aspx.cs" Inherits="TPI_GRUPO_25.AltaPaciente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        body {
            background-color: #ffe5b4;
            margin: 0;
            padding: 0;
        }

        .navbar {
            background-color: #653208 !important;
        }

            .navbar .nav-link,
            .navbar .navbar-brand {
                color: #fce7c6;
                font-weight: 400;
            }

        .boton-personalizado {
            background-color: #BF7D56;
            color: black;
            border: 1px solid black;
            font-weight: bold;
        }

            .boton-personalizado:hover {
                background-color: #4d2606;
                color: white;
                border: 1px solid black;
            }

        .divFiltrar {
            border: 1px solid black;
            background-color: #FFC27D;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
                <nav class="navbar navbar-expand-xl" CssClass="navbar" style="background-color: #653208;">
  <div class="container-fluid" >
    <a class="navbar-brand">Clínica TUP</a>
    <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarDark" aria-controls="navbarDark" aria-expanded="false" aria-label="Toggle navigation">
      <span class="navbar-toggler-icon"></span>
    </button>
    <div class="collapse navbar-collapse show" id="navbarDark">
      <ul class="navbar-nav me-auto mb-2 mb-xl-0 d-flex w-100">
        <li class="nav-item">
          <a class="nav-link" aria-current="page" href="AltaMedico.aspx">Alta Médico</a>
        </li>
        <li class="nav-item">
          <a class="nav-link" href="BMLMedico.aspx">BML Médico</a>
        </li>
        <li class="nav-item">
          <a class="nav-link" href="BMLPaciente.aspx">BML Paciente</a>
        </li>
        <li class="nav-item">
          <a class="nav-link" href="InformesAdministrador.aspx">Informes</a>
        </li>
        <li class="nav-item">
          <a class="nav-link" href="TurnosAdministrador.aspx">Turnos</a>
        </li>
            <li class="nav-item ms-auto">
              <asp:Label class="nav-link mb-15" ID="usuarioAd" runat="server" Text="Usuario: Admin"></asp:Label>
            </li>
        <li class="nav-item">
<a class="nav-link" href="InicioSesion.aspx">Cerrar Sesión</a>

        </li>
      </ul>
    </div>
  </div>
</nav>
    </div>


        <div class="row justify-content-center">
    <asp:Label runat="server" ID="lblBienvenida" Text="Bienvenido Administrador: Aquí se hace la baja, modificación y lectura de médicos" CssClass="h2 text-center d-block mt-5 mb-3 text-dark"></asp:Label>

            <div class="col-md-6">
                <h4 class="text-center">Nuevo Paciente<asp:Label ID="Administrador" runat="server" ClientIDMode="Predictable"></asp:Label></h4>
                <div class="col-md-6">
                    <div class="row mb-6">
                        <div class="col-md-4">
                            <asp:Label ID="lblDNI" runat="server" Text="DNI:" CssClass="form-label"></asp:Label>
                        </div>
                        <div class="col-md-8">
                            <asp:TextBox ID="txtDNI" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator
                                ID="RequiredFieldValidator1"
                                runat="server"
                                ErrorMessage="Ingrese DNI"
                                ForeColor="Red"
                                ControlToValidate="txtDNI"
                                Display="Dynamic" ValidationGroup="grupo1"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <br />
                    <div class="row mb-6">
                        <div class="col-md-4">
                            <asp:Label ID="lblNombre" runat="server" Text="Nombre:" CssClass="form-label"></asp:Label>
                        </div>
                        <div class="col-md-8">
                            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator
                                ID="RequiredFieldValidator2"
                                runat="server"
                                ErrorMessage="Ingrese Nombre"
                                ForeColor="Red"
                                ControlToValidate="txtNombre"
                                Display="Dynamic"
                                ValidationGroup="grupo1"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <br />
                    <div class="row mb-6">
                        <div class="col-md-4">
                            <asp:Label ID="lblApellido" runat="server" Text="Apellido:" CssClass="form-label"></asp:Label>
                        </div>
                        <div class="col-md-8">
                            <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator
                                ID="RequiredFieldValidator3"
                                runat="server"
                                ErrorMessage="Ingrese Apellido"
                                ForeColor="Red"
                                ControlToValidate="txtApellido"
                                Display="Dynamic"
                                ValidationGroup="grupo1"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <br />
                    <div class="row mb-6">
                        <div class="col-md-4">
                            <asp:Label ID="lblSexo" runat="server" Text="Sexo:" CssClass="form-label"></asp:Label>
                        </div>
                        <div class="col-md-8">
                            <asp:DropDownList ID="DropDownList3" runat="server">
                                <asp:ListItem Value="0">--Seleccionar--</asp:ListItem>
                                <asp:ListItem Value="1">Hombre</asp:ListItem>
                                <asp:ListItem Value="2">Mujer</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <br />
                    <div class="row mb-6">
                        <div class="col-md-4">
                            <asp:Label ID="lblNacionalidad" runat="server" Text="Nacionalidad:" CssClass="form-label"></asp:Label>
                        </div>
                        <div class="col-md-8">
                            <asp:TextBox ID="txtNaciolidad" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator
                                ID="RequiredFieldValidator4"
                                runat="server"
                                ErrorMessage="Ingrese nacionalidad"
                                ForeColor="Red"
                                ControlToValidate="txtNaciolidad"
                                Display="Dynamic"
                                ValidationGroup="grupo1"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <br />
                    <div class="row mb-6">
                        <div class="col-md-4">
                            <asp:Label ID="lblFechaNacimietno" runat="server" Text="Fecha de Nacimiento:" CssClass="form-label"></asp:Label>
                        </div>
                        <div class="col-md-8">
                            <asp:TextBox ID="txtFechaNacimiento" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator
                                ID="RequiredFieldValidator5"
                                runat="server"
                                ErrorMessage="Ingrese Fecha de Nacimiento"
                                ForeColor="Red"
                                ControlToValidate="txtFechaNacimiento"
                                Display="Dynamic"
                                ValidationGroup="grupo1"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <br />
                    <div class="row mb-6">
                        <div class="col-md-4">
                            <asp:Label ID="lblDirecion" runat="server" Text="Dirección:" CssClass="form-label"></asp:Label>
                        </div>
                        <div class="col-md-8">
                            <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator
                                ID="RequiredFieldValidator6"
                                runat="server"
                                ErrorMessage="Ingrese Dirección"
                                ForeColor="Red"
                                ControlToValidate="txtDireccion"
                                Display="Dynamic"
                                ValidationGroup="grupo1"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <br />
                    <div class="row mb-6">
                        <div class="col-md-4">
                            <asp:Label ID="lblLocalidad" runat="server" Text="Localidad:" CssClass="form-label"></asp:Label>
                        </div>
                        <div class="col-md-8">
                            <asp:TextBox ID="txtLocalidad" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator
                                ID="RequiredFieldValidator7"
                                runat="server"
                                ErrorMessage="Ingrese Localidad"
                                ForeColor="Red"
                                ControlToValidate="txtLocalidad"
                                Display="Dynamic"
                                ValidationGroup="grupo1"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <br />
                    <div class="row mb-6">
                        <div class="col-md-4">
                            <asp:Label ID="lblProvincia" runat="server" Text="Provincia:" CssClass="form-label"></asp:Label>
                        </div>
                        <div class="col-md-8">
                            <asp:TextBox ID="txtProvincia" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator
                                ID="RequiredFieldValidator8"
                                runat="server"
                                ErrorMessage="Ingrese Provincia"
                                ForeColor="Red"
                                ControlToValidate="txtProvincia"
                                Display="Dynamic"
                                ValidationGroup="grupo1"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <br />
                    <div class="row mb-6">
                        <div class="col-md-4">
                            <asp:Label ID="lblCorreo" runat="server" Text="Correo Electronico:" CssClass="form-label"></asp:Label>
                        </div>
                        <div class="col-md-8">
                            <asp:TextBox ID="txtCorreo" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator
                                ID="RequiredFieldValidator9"
                                runat="server"
                                ErrorMessage="Ingrese Correo Electronico"
                                ForeColor="Red"
                                ControlToValidate="txtCorreo"
                                Display="Dynamic"
                                ValidationGroup="grupo1"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <br />
                    <div class="row mb-6">
                        <div class="col-md-4">
                            <asp:Label ID="lblTelefono" runat="server" Text="Telefono:" CssClass="form-label"></asp:Label>
                        </div>
                        <div class="col-md-8">
                            <asp:TextBox ID="txtTelefo" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator
                                ID="RequiredFieldValidator10"
                                runat="server"
                                ErrorMessage="Ingrese Telefono"
                                ForeColor="Red"
                                ControlToValidate="txtTelefo"
                                Display="Dynamic"
                                ValidationGroup="grupo1"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    <div class="row justify-content-center">
        <div class="col-md-1">
            <asp:Button ID="Button1" runat="server" Text="Button" CssClass="form-control" ValidationGroup="grupo1" />
        </div>
    </div>
</asp:Content>
