<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TurnosAdministrador.aspx.cs" Inherits="TPI_GRUPO_25.TurnosAdministrador" %>
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

        .main-content {
            padding-top: 80px; 
        }

        .badge-personalizada {
            background-color: #9E5439;
            padding: 30px;
            font-weight: bold;
        }
        .label-fijo {
    width: 120px;
    text-align: right;
        }
.boton-personalizado {
    background-color: #BF7D56;
    color: black;            
    border: 1px solid black; 
}

.boton-personalizado:hover {
    background-color: #4d2606;
    color: white;           
    border: 1px solid black; 
}
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="bg-naranja-suave w-100">
                <nav class="navbar navbar-expand-xl" CssClass="navbar" style="background-color: #653208;">
  <div class="container-fluid" >
<a class="navbar-brand" href="SesionIniciadaAdministrador.aspx">Clínica TUP</a>
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
          <a class="nav-link" href="AltaPaciente.aspx">Alta Paciente</a>
        </li>
        <li class="nav-item">
          <a class="nav-link" href="BMLPaciente.aspx">BML Paciente</a>
        </li>
        <li class="nav-item">
          <a class="nav-link" href="InformesAdministrador.aspx">Informes</a>
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

 <div class="d-flex flex-column align-items-center mt-4">

    <asp:Label runat="server" ID="lblBienvenida" Text="Bienvenido Administrador: Estos son los turnos!" CssClass="h2 text-center d-block mb-4 text-dark"></asp:Label>
   

     <div class="d-flex align-items-center w-50 mb-4">
    <asp:Label runat="server" ID="lblTurno" Text="Id Turno:" CssClass="me-3 fw-bold label-fijo" />
    <asp:TextBox runat="server" ID="txtIdTurno" CssClass="form-control w-100" />
         <asp:Label ID="lblIDTurnoExistente" runat="server"></asp:Label>
</div>


    <div class="d-flex align-items-center w-50 my-4">
        <asp:Label runat="server" ID="lblPaciente" Text="Paciente:" CssClass="me-3 fw-bold label-fijo" />
        <asp:DropDownList runat="server" ID="ddlPaciente" CssClass="form-select w-100" />
    </div>

    
      <div class="d-flex align-items-center w-50 mb-4">
     <asp:Label runat="server" ID="lblEspecialidad" Text="Especialidad:" CssClass="me-3 fw-bold label-fijo" />
     <asp:DropDownList runat="server" ID="ddlEspecialidad" CssClass="form-select w-100" AutoPostBack="true" OnSelectedIndexChanged="ddlEspecialidad_SelectedIndexChanged" />
 </div>

 <div class="d-flex align-items-center w-50 mb-5">
     <asp:Label runat="server" ID="Label1" Text="Médico:" CssClass="me-3 fw-bold label-fijo" />
     <asp:DropDownList runat="server" ID="ddlMedico" CssClass="form-select w-100" />
 </div>


    <div class="d-flex align-items-center w-50 mb-4">
        <asp:Label runat="server" ID="lblDia" Text="Fecha:" CssClass="me-3 fw-bold label-fijo" />
        <asp:TextBox runat="server" ID="txtFecha" CssClass="form-control w-100" />
    </div>



    <div class="d-flex align-items-center w-50 mb-4">
        <asp:Label runat="server" ID="lblHora" Text="Hora:" CssClass="me-3 fw-bold label-fijo" />
        <asp:TextBox runat="server" ID="txtHora" CssClass="form-control w-100" />
    </div>

     <div><asp:Label ID="lblErrorTurno" CssClass="h4 fw-bold" runat="server"></asp:Label></div>
   


    <div class="d-flex justify-content-end">
        <asp:Button runat="server" ID="BtnGuardarTurno" Text="Guardar Turno" CssClass="btn boton-personalizado" OnClick="BtnGuardarTurno_Click" />
    </div>
</div>
</asp:Content>