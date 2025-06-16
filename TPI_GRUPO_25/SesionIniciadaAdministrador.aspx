<%@ Page Title="SesionIniciadaAdministrador" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SesionIniciadaAdministrador.aspx.cs" Inherits="TPI_GRUPO_25.SesionIniciadaAdministrador" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- Acá pueden ir Scripts-->
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
        .navbar .navbar-brand  {
            color: #fce7c6;
            font-weight: 400;
        }

         .badge-personalizada {
            background-color: #9E5439;
            padding:30px;
            font-weight: bold;
        }

         .btn-personalizado {
    background-color: #ebd2a9;
    color: black;
    border: 1px solid #653208; /* opcional: un borde marrón oscuro */
}

.btn-personalizado:hover {
    background-color: #e6d3b0; /* color más oscuro al pasar el mouse */
    color: black;
}

    </style>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="bg-naranja-suave w-100" >
        <nav class="navbar navbar-expand-xl" CssClass="navbar" style="background-color: #653208;">
  <div class="container-fluid" >
    <a class="navbar-brand" href="#">Navbar</a>
    <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarDark" aria-controls="navbarDark" aria-expanded="false" aria-label="Toggle navigation">
      <span class="navbar-toggler-icon"></span>
    </button>
    <div class="collapse navbar-collapse show" id="navbarDark">
      <ul class="navbar-nav me-auto mb-2 mb-xl-0 d-flex w-100">
        <li class="nav-item">
          <a class="nav-link" aria-current="page" href="#">Home</a>
        </li>
        <li class="nav-item">
          <a class="nav-link" href="#">Features</a>
        </li>
        <li class="nav-item">
          <a class="nav-link" href="#" >Disabled</a>
        </li>
            <li class="nav-item ms-auto">
              <asp:Label class="nav-link mb-15" ID="usuarioAd" runat="server" Text="Usuario: Admin"></asp:Label>
            </li>
        <li class="nav-item">
         <a class="nav-link" href="#">Cerrar sesion</a>
        </li>
      </ul>
    </div>
  </div>
</nav>

<asp:Label runat="server" ID="lblBienvenida" Text="Bienvenido Administrador" CssClass="h2 text-center d-block mt-5 mb-3 text-dark"></asp:Label>


              <div class="container mt-5 pt-5  d-flex justify-content-around ">
        <asp:Label runat="server" ID="lbl" Text="Cantidad de médicos registrados:" CssClass="h3 text-dark"></asp:Label>
         <asp:Label runat="server" ID="Label1" Text="Cantidad de pacientes registrados:" CssClass="h3 text-dark"></asp:Label>
    </div>
        <div class="container mt-5 pt-5 d-flex justify-content-around text-center">

    <div>
        <div class="badge text-wrap badge-personalizada p-3 mb-2" style="width: 12rem;">
            Médico
        </div>
        <div>
            <asp:HyperLink runat="server" NavigateUrl="AltaMedico.aspx" CssClass="btn btn-personalizado btn-sm mb-1">Alta</asp:HyperLink><br />
            <asp:HyperLink runat="server" NavigateUrl="ABMLMedico.aspx" CssClass="btn btn-personalizado btn-sm">Baja, Modificación, Leer</asp:HyperLink>
        </div>
    </div>

    <div>
        <div class="badge text-wrap badge-personalizada p-3 mb-2" style="width: 12rem;">
            Paciente
        </div>
        <div>
            <asp:HyperLink runat="server" NavigateUrl="AltaPaciente.aspx" CssClass="btn btn-personalizado btn-sm mb-1">Alta</asp:HyperLink><br />
            <asp:HyperLink runat="server" NavigateUrl="ABMLPaciente.aspx" CssClass="btn btn-personalizado btn-sm">Baja, Modificación, Leer</asp:HyperLink>
        </div>
    </div>

    <div>
        <div class="badge text-wrap badge-personalizada p-3 mb-2" style="width: 12rem;">
            Turno
        </div>
        <div>
            <asp:HyperLink runat="server" NavigateUrl="AltaTurno.aspx" CssClass="btn btn-personalizado btn-sm mb-1">Alta</asp:HyperLink><br />
        </div>
    </div>

    <div>
        <div class="badge text-wrap badge-personalizada p-3 mb-2" style="width: 12rem;">
            Informes
        </div>
        <div>
            <asp:HyperLink runat="server" NavigateUrl="AltaInforme.aspx" CssClass="btn btn-personalizado btn-sm mb-1">Ver</asp:HyperLink><br />
      
        </div>
    </div>

</div>

    </div>
</asp:Content>

