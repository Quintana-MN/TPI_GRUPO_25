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


        <!-- Fila 1: DNI y Nombre -->
<div class="px-4">
<div class="row mb-3">
        <asp:Label runat="server" ID="lblBienvenida" CssClass="text-center h3 fw-bold py-4"></asp:Label>
    <div class="col-md-6">
        <asp:Label ID="lblDNI" runat="server" Text="DNI:" CssClass="form-label fw-bold"></asp:Label>
        <asp:TextBox ID="txtDNI" runat="server" CssClass="form-control" placeholder="Ingrese DNI..."></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Ingrese DNI" ForeColor="Red" ControlToValidate="txtDNI" Display="Dynamic" ValidationGroup="grupo1"></asp:RequiredFieldValidator>
    </div>
    <div class="col-md-6">
        <asp:Label ID="lblNombre" runat="server" Text="Nombre:" CssClass="form-label fw-bold"></asp:Label>
        <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" placeholder="Ingrese Nombre..."></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Ingrese Nombre" ForeColor="Red" ControlToValidate="txtNombre" Display="Dynamic" ValidationGroup="grupo1"></asp:RequiredFieldValidator>
    </div>
</div>

<!-- Fila 2: Apellido y Sexo -->
<div class="row mb-3 ">
    <div class="col-md-6">
        <asp:Label ID="lblApellido" runat="server" Text="Apellido:" CssClass="form-label fw-bold"></asp:Label>
        <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control" placeholder="Ingrese Apellido..."></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Ingrese Apellido" ForeColor="Red" ControlToValidate="txtApellido" Display="Dynamic" ValidationGroup="grupo1"></asp:RequiredFieldValidator>
    </div>
    <div class="col-md-6">
        <asp:Label ID="lblSexo" runat="server" Text="Sexo:" CssClass="form-label fw-bold"></asp:Label>
        <asp:DropDownList ID="ddlSexo" runat="server" CssClass="form-control">
            <asp:ListItem Value="0">--Seleccionar--</asp:ListItem>
            <asp:ListItem Value="1">Hombre</asp:ListItem>
            <asp:ListItem Value="2">Mujer</asp:ListItem>
        </asp:DropDownList>
    </div>
</div>
    <!-- Fila 3: Nacionalidad y Fecha de Nacimiento -->
<div class="row mb-3 ">
    <div class="col-md-6">
        <asp:Label ID="lblNacionalidad" runat="server" Text="Nacionalidad:" CssClass="form-label fw-bold"></asp:Label>
        <asp:TextBox ID="txtNacionalidad" runat="server" CssClass="form-control" placeholder="Ingrese Nacionalidad..."></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Ingrese nacionalidad" ForeColor="Red" ControlToValidate="txtNacionalidad" Display="Dynamic" ValidationGroup="grupo1"></asp:RequiredFieldValidator>
    </div>
    <div class="col-md-6">
        <asp:Label ID="lblFechaNacimiento" runat="server" Text="Fecha de Nacimiento:" CssClass="form-label fw-bold"></asp:Label>
        <asp:TextBox ID="txtFechaNacimiento" runat="server" CssClass="form-control" placeholder="Ingrese Fecha de Nacimiento..."></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Ingrese Fecha de Nacimiento" ForeColor="Red" ControlToValidate="txtFechaNacimiento" Display="Dynamic" ValidationGroup="grupo1"></asp:RequiredFieldValidator>
    </div>
</div>

<!-- Fila 4: Dirección y Localidad -->
<div class="row mb-3 ">
    <div class="col-md-6">
        <asp:Label ID="lblDireccion" runat="server" Text="Dirección:" CssClass="form-label "></asp:Label>
        <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control" placeholder="Ingrese Dirección..."></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Ingrese Dirección" ForeColor="Red" ControlToValidate="txtDireccion" Display="Dynamic" ValidationGroup="grupo1"></asp:RequiredFieldValidator>
    </div>
        <div class="col-md-6">
        <asp:Label ID="Label1" runat="server" Text="Provincia:" CssClass="form-label fw-bold"></asp:Label>
        <asp:TextBox ID="txtProvincia" runat="server" CssClass="form-control" placeholder="Ingrese Provincia..."></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Ingrese Provincia" ForeColor="Red" ControlToValidate="txtProvincia" Display="Dynamic" ValidationGroup="grupo1"></asp:RequiredFieldValidator>
    </div>
</div>

                   <!-- Fila 5: Provincia y Correo Electrónico -->
<div class="row mb-3 ">
    <div class="col-md-6">
        <asp:Label ID="lblLocalidad" runat="server" Text="Localidad:" CssClass="form-label fw-bold"></asp:Label>
        <asp:TextBox ID="" runat="server" CssClass="form-control" placeholder="Ingrese Localidad..."></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Ingrese Localidad" ForeColor="Red" ControlToValidate="txtLocalidad" Display="Dynamic" ValidationGroup="grupo1"></asp:RequiredFieldValidator>
    </div>
    <div class="col-md-6">
        <asp:Label ID="lblCorreo" runat="server" Text="Correo Electrónico:" CssClass="form-label fw-bold"></asp:Label>
        <asp:TextBox ID="txtCorreo" runat="server" CssClass="form-control" placeholder="Ingrese Correo Electrónico..."></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="Ingrese Correo Electrónico" ForeColor="Red" ControlToValidate="txtCorreo" Display="Dynamic" ValidationGroup="grupo1"></asp:RequiredFieldValidator>
    </div>
</div>

<!-- Fila 6: Teléfono y Botón -->
<div class="row mb-4 ">
    <div class="col-md-6">
        <asp:Label ID="lblTelefono" runat="server" Text="Teléfono:" CssClass="form-label fw-bold"></asp:Label>
        <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control" placeholder="Ingrese Teléfono..."></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="Ingrese Teléfono" ForeColor="Red" ControlToValidate="txtTelefono" Display="Dynamic" ValidationGroup="grupo1"></asp:RequiredFieldValidator>
    </div>
    <div class="col-md-6 d-flex align-items-end">
        <asp:Button ID="btnAgregarPaciente" runat="server" Text="Guardar" CssClass="btn btn-primary w-100 boton-personalizado" ValidationGroup="grupo1" OnClick="btnAgregarPaciente_Click" />
    </div>
</div>
    </div>

</asp:Content>
