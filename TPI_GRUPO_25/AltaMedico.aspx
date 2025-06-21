<%@ Page Title="AltaMedico" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AltaMedico.aspx.cs" Inherits="TPI_GRUPO_25.AltaMedico" %>

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
          <a class="nav-link" href="BMLMedico.aspx">BML Médico</a>
        </li>
        <li class="nav-item">
          <a class="nav-link" href="AltaPaciente.aspx">Alta Paciente</a>
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


    <div class="container">
        <div class="row">
            <asp:Label runat="server" ID="lblBienvenida" Text="Bienvenido Administrador: Aquí se hace el Alta de Médicos" CssClass="h2 text-center d-block mt-5 mb-3 text-dark"></asp:Label>
            <div class="col-md-6">
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
                            <asp:DropDownList ID="ddlSexo" runat="server">
                                <asp:ListItem Value="0">Hombre</asp:ListItem>
                                <asp:ListItem Value="1">Mujer</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <br />
                    <div class="row mb-6">
                        <div class="col-md-4">
                            <asp:Label ID="lblNacionalidad" runat="server" Text="Nacionalidad:" CssClass="form-label"></asp:Label>
                        </div>
                        <div class="col-md-8">
                            <asp:TextBox ID="txtNacionalidad" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator
                                ID="RequiredFieldValidator4"
                                runat="server"
                                ErrorMessage="Ingrese nacionalidad"
                                ForeColor="Red"
                                ControlToValidate="txtNacionalidad"
                                Display="Dynamic"
                                ValidationGroup="grupo1"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <br />
                    <div class="row mb-6">
                        <div class="col-md-4">
                            <asp:Label ID="lblFechaNacimiento" runat="server" Text="Fecha de Nacimiento:" CssClass="form-label"></asp:Label>
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
                  <div class="row mb-4">
    <div class="col-md-6">
        <asp:Label ID="lblProvincia" runat="server" Text="Provincia:" CssClass="form-label"></asp:Label>
    </div>
    <div class="col-md-8">
        <asp:DropDownList 
            ID="ddlProvincia" 
            runat="server" 
            CssClass="form-control" 
            AutoPostBack="true" 
            OnSelectedIndexChanged="ddlProvincia_SelectedIndexChanged">
            <asp:ListItem Value="0">--Seleccionar--</asp:ListItem>
        </asp:DropDownList>
    </div>
</div>
                    <br />
                    <div class="row mb-3">
    <div class="col-md-4">
        <asp:Label ID="lblLocalidad" runat="server" Text="Localidad:" CssClass="form-label"></asp:Label>
    </div>
    <div class="col-md-8">
        <asp:DropDownList 
            ID="ddlLocalidad" 
            runat="server" 
            CssClass="form-control"
            AutoPostBack="false">
            <asp:ListItem Value="0">--Seleccionar--</asp:ListItem>
        </asp:DropDownList>
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
                            <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator
                                ID="RequiredFieldValidator10"
                                runat="server"
                                ErrorMessage="Ingrese Telefono"
                                ForeColor="Red"
                                ControlToValidate="txtTelefono"
                                Display="Dynamic"
                                ValidationGroup="grupo1"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-md-6">
                <div class="col-md-6">
                    <div class="row mb-6">
                        <div class="col-md-4">
                            <asp:Label ID="lblLegajo" runat="server" Text="Legajo:" CssClass="form-label"></asp:Label>
                        </div>
                        <div class="col-md-8">
                            <asp:TextBox ID="txtLegajo" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator
                                ID="RequiredFieldValidator11"
                                runat="server"
                                ErrorMessage="Ingrese Legajo"
                                ForeColor="Red"
                                ControlToValidate="txtLegajo"
                                Display="Dynamic"
                                ValidationGroup="grupo1"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <br />
                    </div>
                    <div class="row mb-6">
                        <div class="col-md-4">
                            <asp:Label ID="lblHorario" runat="server" Text="Horario Atencion:" CssClass="form-label"></asp:Label>
                        </div>
                        <div class="col-md-8">
                            <asp:DropDownList ID="ddlHorario" runat="server">
    <asp:ListItem Value="0">--Seleccionar--</asp:ListItem>
    <asp:ListItem Value="Lunes a Viernes 8-12">Lunes a Viernes 8-12</asp:ListItem>
    <asp:ListItem Value="Tarde 14-18">Tarde 14-18</asp:ListItem>
    <asp:ListItem Value="Sábados 9-13">Sábados 9-13</asp:ListItem>
</asp:DropDownList>
                        </div>
                    </div>
                    <br />
                    <div class="row mb-6">
                        <div class="col-md-4">
                            <asp:Label ID="lblEspecialidad" runat="server" Text="Especialidad:" CssClass="form-label"></asp:Label>
                        </div>
                        <div class="col-md-8">
                            <asp:DropDownList ID="ddlEspecialidad" runat="server">
                                <asp:ListItem Value="0">--Seleccionar--</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <br />
                    <div class="row mb-6">
                        <div class="col-md-4">
                            <asp:Label ID="lblUsuario" runat="server" Text="Usuario:" CssClass="form-label"></asp:Label>
                        </div>
                        <div class="col-md-8">
                            <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator
                                ID="RequiredFieldValidator12"
                                runat="server"
                                ErrorMessage="Ingrese Usuario"
                                ForeColor="Red"
                                ControlToValidate="txtUsuario"
                                Display="Dynamic"
                                ValidationGroup="grupo1"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <br />
                    <div class="row mb-6">
                        <div class="col-md-4">
                            <asp:Label ID="lblContraseña" runat="server" Text="Contraseña:" CssClass="form-label"></asp:Label>
                        </div>
                        <div class="col-md-8">
                            <asp:TextBox ID="txtContraseña" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator
                                ID="RequiredFieldValidator13"
                                runat="server"
                                ErrorMessage="Ingrese Contraseña"
                                ForeColor="Red"
                                ControlToValidate="txtContraseña"
                                Display="Dynamic"
                                ValidationGroup="grupo1"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <br />
                    <br />
                    <asp:Button ID="btnAltaMedico" runat="server" Text="Enviar" style="background-color: #653208; width:100px;" CssClass="form-control"  ValidationGroup="grupo1" OnClick="btnAltaMedico_Click"/>
                </div>
            <asp:Label runat="server" ID="lblMedicoCreado"></asp:Label>
        </div>
    </div>
</asp:Content>
