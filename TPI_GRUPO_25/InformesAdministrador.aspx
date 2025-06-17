<%@ Page Title="InformesAdministrador" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InformesAdministrador.aspx.cs"  Inherits="TPI_GRUPO_25.InformesAdministrador"%>


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

    .filtros-fecha {
        display: flex;
        justify-content: center ;
        align-items: center;
        gap: 10px;
        margin-top: 120px;
        flex-wrap: wrap;
    }

    .filtros-fecha label {
        font-weight: bold;
        margin-right: 5px;
    }
    


    .btn-ver {
        padding: 6px 15px;
        background-color: #653208;
        color: white;
        border: none;
        border-radius: 5px;
        transition: 0.5s;
    }

    .btn-ver:hover {
        background-color: #8a4b20;
    }
        


    </style>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="bg-naranja-suave w-100">
<<<<<<< Updated upstream
     <nav class="navbar navbar-expand-xl" style="background-color: #653208;">
         <div class="container-fluid">
             <a class="navbar-brand" href="#">Navbar</a>
             <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarDark"
                 aria-controls="navbarDark" aria-expanded="false" aria-label="Toggle navigation">
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
                         <a class="nav-link" href="#">Disabled</a>
                     </li>
                     <li class="nav-item ms-auto">
                         <asp:Label CssClass="nav-link mb-15" ID="usuarioAd" runat="server" Text="Usuario: Admin"></asp:Label>
                     </li>
                     <li class="nav-item">
                         <a class="nav-link" href="InicioSesion.aspx">Cerrar sesión</a>
                     </li>
                 </ul>
             </div>
         </div>
     </nav>
=======
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
          <a class="nav-link" href="AltaPaciente.aspx">Alta Paciente</a>
        </li>
        <li class="nav-item">
          <a class="nav-link" href="BMLPaciente.aspx">BML Paciente</a>
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
>>>>>>> Stashed changes
 </div>


<asp:Label runat="server" ID="lblBienvenida" Text="!Bienvenido Administrador!.Estos son los informes!." CssClass="h2 text-center d-block mt-5 mb-3 text-dark"></asp:Label>

<div style="margin-top: 100px; text-align: center; padding: 20px; width: fit-content;  margin-right: auto;">
     <div class ="filtros-fecha">
         <label><strong>Desde</strong></label>
         <input type="date" name="fechaD" id="Desde" runat="server" class="form-control" style="width: 150px; background-color: #F2E0C9;"  />
          <br /><br />
 
          <label><strong>Hasta</strong></label>
          <input type="date" name="fechaH" id="Hasta" runat="server" class="form-control" style="width: 150px; background-color: #F2E0C9;"  />
        <asp:Button ID="btnVer" runat="server" Text="Ver" class="btn-ver" OnClick="btnVer_Click" />
         <br />
     </div>
      
   </div>
   <div style="display: flex; justify-content: center; gap: 80px; flex-wrap: wrap;">

    <!-- Panel Izquierdo - Asistencias -->
    <div style="background-color: #EDD3C0; width: 460px; min-height: 280px;">
        <div style="background-color:#A55F36; padding:12px; text-align: center;">
            <asp:Label ID="lblTituloAsistencias" runat="server" Text="Tasa Cantidad de Asistencias en Mayo 2025" ForeColor="White" Font-Bold="True"></asp:Label>
        </div>
        <div style="padding: 50px 30px; font-size: larger; font-weight: bold;">
            <div style="display: flex; justify-content: space-between; align-items: center; margin-bottom: 30px;">
                <asp:Label ID="lblPresentes3" runat="server" Text="Presentes:" ForeColor="Black"></asp:Label>
                <asp:Label ID="lblPorcentajePresentes" runat="server" Text="70%" ForeColor="Black"></asp:Label>
                <span style="font-size: 50px;">&#10004;</span>
            </div>
            <div style="display: flex; justify-content: space-between; align-items: center;">
                <asp:Label ID="lblAusentes3" runat="server" Text="Ausentes:" ForeColor="Black"></asp:Label>
                <asp:Label ID="lblPorcentajeAusentes" runat="server" Text="30%" ForeColor="Black"></asp:Label>
                <span style="color:red; font-size: 50px;">❌</span>
            </div>
        </div>
    </div>

    <!-- Panel Derecho - Turnos por Especialidad -->
    <div style="background-color: #EDD3C0; width: 460px; min-height: 280px;">
        <div style="background-color:#A55F36; padding:12px; text-align: center;">
            <asp:Label ID="lblTituloEspecialidades" runat="server" Text="Tasa Cantidad de Turnos por Especialidad Mayo 2025" ForeColor="White" Font-Bold="True"></asp:Label>
        </div>
        <div style="padding: 50px 30px; font-size: larger; font-weight: bold;">
            <div style="display: flex; justify-content: space-between; align-items: center; margin-bottom: 30px;">
                <asp:Label ID="lblPediatria" runat="server" Text="Pediatría:" ForeColor="Black"></asp:Label>
                <asp:Label ID="lblPorcentajePediatria" runat="server" Text="70%" ForeColor="Black"></asp:Label>
                <span style="font-size: 50px;">%</span>

            </div>
            <div style="display: flex; justify-content: space-between; align-items: center;">
                <asp:Label ID="lblCardiologia" runat="server" Text="Cardiología:" ForeColor="Black"></asp:Label>
                <asp:Label ID="lblPorcentajeCardiologia" runat="server" Text="30% " ForeColor="Black"></asp:Label>
                <span style="font-size: 50px;">%</span>
            </div>
        </div>
    </div>
</div>
  

    
  



    
     
    
</asp:Content>