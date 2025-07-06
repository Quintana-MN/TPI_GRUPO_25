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
    <a class="navbar-brand" href="SesionIniciadaAdministrador.aspx">Clínica TUP</a>
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
<a class="nav-link btn btn-primary"  href="InicioSesion.aspx">Cerrar Sesión</a>

        </li>
      </ul>
    </div>
  </div>
</nav>
    </div>

    <br />
<div class="container">
    <div class="row">
        <asp:Label CssClass="fw-bold h3 text-center" runat="server" ID="lblMedicoCreado"></asp:Label>
        <asp:Label runat="server" ID="lblBienvenida" Text="Bienvenido Administrador: Aquí se hace el Alta de Médicos" CssClass="h2 text-center d-block py-4 text-dark"></asp:Label>

        <!-- Fila 1: DNI y Nombre -->
        <div class="row mb-3">
            <div class="col-md-6">
                <asp:Label ID="lblDNI" runat="server" Text="DNI:" CssClass="form-label fw-bold"></asp:Label>
                <asp:TextBox ID="txtDNI" runat="server" CssClass="form-control" placeholder="Ingrese DNI..."></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Ingrese DNI" ForeColor="Red" ControlToValidate="txtDNI" Display="Dynamic" ValidationGroup="grupo1"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator 
ID="regexSoloNumeros2" 
runat="server" 
ControlToValidate="txtDNI"
ValidationGroup="grupo1"
ErrorMessage="Ingrese solo números"
ForeColor="Red"
Display="Dynamic"
SetFocusOnError="true"
ValidationExpression="^\d+$" />
                <asp:Label ID="lblDNIExistente" runat="server"></asp:Label>
            </div>
            <div class="col-md-6">
                <asp:Label ID="lblNombre" runat="server" Text="Nombre:" CssClass="form-label fw-bold"></asp:Label>
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" placeholder="Ingrese Nombre..."></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Ingrese Nombre" ForeColor="Red" ControlToValidate="txtNombre" Display="Dynamic" ValidationGroup="grupo1"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator 
    ID="regexNombre" 
    runat="server" 
    ControlToValidate="txtNombre"
    ValidationGroup="grupo1"
    ErrorMessage="Ingrese solo letras (sin números ni símbolos)"
    ForeColor="Red"
    Display="Dynamic"
    SetFocusOnError="true"
    ValidationExpression="^[a-zA-ZÁÉÍÓÚáéíóúÑñ\s]+$" />
            </div>
        </div>

        <!-- Fila 2: Apellido y Sexo -->
        <div class="row mb-3">
            <div class="col-md-6">
                <asp:Label ID="lblApellido" runat="server" Text="Apellido:" CssClass="form-label fw-bold"></asp:Label>
                <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control" placeholder="Ingrese Apellido..."></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Ingrese Apellido" ForeColor="Red" ControlToValidate="txtApellido" Display="Dynamic" ValidationGroup="grupo1"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator 
    ID="RegularExpressionValidator1" 
    runat="server" 
    ControlToValidate="txtApellido"
    ValidationGroup="grupo1"
    ErrorMessage="Ingrese solo letras (sin números ni símbolos)"
    ForeColor="Red"
    Display="Dynamic"
    SetFocusOnError="true"
    ValidationExpression="^[a-zA-ZÁÉÍÓÚáéíóúÑñ\s]+$" />
            </div>
            <div class="col-md-6">
                <asp:Label ID="lblSexo" runat="server" Text="Sexo:" CssClass="form-label fw-bold"></asp:Label>
                <asp:DropDownList ID="ddlSexo" runat="server" CssClass="form-control">
                    <asp:ListItem Value="0">Hombre</asp:ListItem>
                    <asp:ListItem Value="1">Mujer</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>

                   <!-- Fila 3: Nacionalidad y Fecha de Nacimiento -->
<div class="row mb-3">
    <div class="col-md-6">
        <asp:Label ID="lblNacionalidad" runat="server" Text="Nacionalidad:" CssClass="form-label fw-bold"></asp:Label>
        <asp:TextBox ID="txtNacionalidad" runat="server" CssClass="form-control" placeholder="Ingrese Nacionalidad..."></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Ingrese nacionalidad" ForeColor="Red" ControlToValidate="txtNacionalidad" Display="Dynamic" ValidationGroup="grupo1"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator 
    ID="RegularExpressionValidator2" 
    runat="server" 
    ControlToValidate="txtNacionalidad"
    ValidationGroup="grupo1"
    ErrorMessage="Ingrese solo letras (sin números ni símbolos)"
    ForeColor="Red"
    Display="Dynamic"
    SetFocusOnError="true"
    ValidationExpression="^[a-zA-ZÁÉÍÓÚáéíóúÑñ\s]+$" />
    </div>
    <div class="col-md-6">
        <asp:Label ID="lblFechaNacimiento" runat="server" Text="Fecha de Nacimiento:" CssClass="form-label fw-bold"></asp:Label>
        <asp:TextBox ID="txtFechaNacimiento" runat="server" CssClass="form-control" placeholder="Ingrese Fecha de Nacimiento..."></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Ingrese Fecha de Nacimiento" ForeColor="Red" ControlToValidate="txtFechaNacimiento" Display="Dynamic" ValidationGroup="grupo1"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator 
    ID="regexFechaNacimiento" 
    runat="server" 
    ControlToValidate="txtFechaNacimiento"
    ValidationGroup="grupo1"
    ErrorMessage="Ingrese una fecha válida en formato dd/mm/aaaa"
    ForeColor="Red"
    Display="Dynamic"
    SetFocusOnError="true"
    ValidationExpression="^(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[0-2])/\d{4}$" />
    </div>
</div>

<!-- Fila 4: Dirección y Provincia -->
<div class="row mb-3">
    <div class="col-md-6">
        <asp:Label ID="lblDireccion" runat="server" Text="Dirección:" CssClass="form-label fw-bold"></asp:Label>
        <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control" placeholder="Ingrese Dirección..."></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Ingrese Dirección" ForeColor="Red" ControlToValidate="txtDireccion" Display="Dynamic" ValidationGroup="grupo1"></asp:RequiredFieldValidator>
    </div>
    <div class="col-md-6">
        <asp:Label ID="lblProvincia" runat="server" Text="Provincia:" CssClass="form-label fw-bold"></asp:Label>
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
        <!-- Fila 5: Localidad y Correo Electrónico -->
<div class="row mb-3">
    <div class="col-md-6">
        <asp:Label ID="lblLocalidad" runat="server" Text="Localidad:" CssClass="form-label fw-bold"></asp:Label>
        <asp:DropDownList 
            ID="ddlLocalidad" 
            runat="server" 
            CssClass="form-control"
            AutoPostBack="false">
            <asp:ListItem Value="0">--Seleccionar--</asp:ListItem>
        </asp:DropDownList>
    </div>
    <div class="col-md-6">
        <asp:Label ID="lblCorreo" runat="server" Text="Correo Electrónico:" CssClass="form-label fw-bold"></asp:Label>
        <asp:TextBox ID="txtCorreo" runat="server" CssClass="form-control" placeholder="Ingrese Correo Electrónico..."></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="Ingrese Correo Electrónico" ForeColor="Red" ControlToValidate="txtCorreo" Display="Dynamic" ValidationGroup="grupo1"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator 
ID="regexCorreo" 
runat="server" 
ControlToValidate="txtCorreo"
ValidationGroup="grupo1"
ErrorMessage="Ingrese un correo electrónico válido"
ForeColor="Red"
Display="Dynamic"
SetFocusOnError="true"
ValidationExpression="^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$" />
    </div>
</div>

<!-- Fila 6: Teléfono y Legajo -->
<div class="row mb-3">
    <div class="col-md-6">
        <asp:Label ID="lblTelefono" runat="server" Text="Teléfono:" CssClass="form-label fw-bold"></asp:Label>
        <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control" placeholder="Ingrese Teléfono..."></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="Ingrese Teléfono" ForeColor="Red" ControlToValidate="txtTelefono" Display="Dynamic" ValidationGroup="grupo1"></asp:RequiredFieldValidator>
<asp:RegularExpressionValidator 
    ID="revNumero" 
    runat="server" 
    ValidationGroup="grupo1"
    ControlToValidate="txtTelefono" 
    Display="Dynamic"
    ErrorMessage="Debe ingresar exactamente 10 dígitos" 
    SetFocusOnError="true"
    ValidationExpression="^\d{10}$" 
    ForeColor="Red">
</asp:RegularExpressionValidator>


    </div>
    <div class="col-md-6">
        <asp:Label ID="lblLegajo" runat="server" Text="Legajo:" CssClass="form-label fw-bold"></asp:Label>
        <asp:TextBox ID="txtLegajo" runat="server" CssClass="form-control" placeholder="Ingrese Legajo..."></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="Ingrese Legajo" ForeColor="Red" ControlToValidate="txtLegajo" Display="Dynamic" ValidationGroup="grupo1"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator 
    ID="regexSoloNumeros" 
    runat="server" 
    ControlToValidate="txtLegajo"
    ValidationGroup="grupo1"
    ErrorMessage="Ingrese solo números"
    ForeColor="Red"
    Display="Dynamic"
    SetFocusOnError="true"
    ValidationExpression="^\d+$" />
        <asp:Label ID="lblLegajoExistente" runat="server"></asp:Label>
    </div>
</div>

                        <!-- Fila 7: Especialidad -->
<div class="row mb-3">
    <div class="col-md-6">
        <asp:Label ID="lblEspecialidad" runat="server" Text="Especialidad:" CssClass="form-label fw-bold"></asp:Label>
        <asp:DropDownList ID="ddlEspecialidad" runat="server" CssClass="form-control">
            <asp:ListItem Value="0">--Seleccionar--</asp:ListItem>

        </asp:DropDownList>
    </div>
        <div class="col-md-6">
        <asp:Label ID="lblUsuario" runat="server" Text="Usuario:" CssClass="form-label fw-bold"></asp:Label>
        <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control" placeholder="Ingrese Usuario..."></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="Ingrese Usuario" ForeColor="Red" ControlToValidate="txtUsuario" Display="Dynamic" ValidationGroup="grupo1"></asp:RequiredFieldValidator>
        <asp:Label ID="lblUsuarioExistente" runat="server"></asp:Label>
    </div>
</div>

<!-- Fila 8: Contraseña -->
<div class="row mb-3 justify-content-center">
    <div class="col-md-6">
        <asp:Label ID="lblContraseña" runat="server" Text="Contraseña:" CssClass="form-label fw-bold"></asp:Label>
        <asp:TextBox ID="txtContraseña" runat="server" CssClass="form-control" TextMode="Password" placeholder="Ingrese Contraseña..."></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ErrorMessage="Ingrese Contraseña" ForeColor="Red" ControlToValidate="txtContraseña" Display="Dynamic" ValidationGroup="grupo1"></asp:RequiredFieldValidator>
    </div>
</div>

<!-- Botón de Enviar -->
<div class="row mt-4">
    <div class="col-md-12 text-center">
        <asp:Button ID="btnAltaMedico" runat="server" Text="Enviar" CssClass="btn btn-primary boton-personalizado" ValidationGroup="grupo1" OnClick="btnAltaMedico_Click" />
        <br /><br />
    </div>
</div>

</asp:Content>
