<%@ Page Title="BMLPaciente" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BMLPaciente.aspx.cs" Inherits="TPI_GRUPO_25.BMLPaciente" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- Acá pueden ir Scripts-->
    <style>
            body {
            background-color: #ffe5b4;
            min-height: 100vh;
            margin: 0;
            padding: 0;
            }

        .navbar {
            background-color: #653208 !important;
            position: fixed;
            top: 0;
            left: 0;
            width: 100%;
            z-index: 1000;
        }

        .navbar .nav-link,
        .navbar .navbar-brand {
            color: #fce7c6;
            font-weight: 400;
        }

        .bg-naranja-suave {
            margin-top: 0;
        }
         .grid-style {
        border-collapse: collapse;
        font-family: Arial;
    }

    .grid-style th {
        background-color: #7c3f1d;
        color: #f9e4c8;
        font-weight: bold;
        text-align: center;
    }

    .grid-style td {
        background-color: #fbe3cd;
        color: #000;
        text-align: center;
        height: 30px;
    }

    .grid-style tr:nth-child(even) td {
        background-color: #f5d6bb;
    }
    .pager-center {
        display:flex;
        justify-content:center;
      text-align: center;
      font-weight: bold;
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
        <br />
        <br />
        &nbsp;&nbsp;
        <br />
        <br />
   <div class="container mt-5 pt-5">
       
<asp:GridView ID="gvPacientes" runat="server" AutoGenerateColumns="False" PageSize="10" AllowPaging="True"
    CssClass="grid-style" Width="100%"
    PagerStyle-CssClass="gv-pager" PagerStyle-HorizontalAlign="Center" HorizontalAlign="Center">
    <Columns>
        <asp:BoundField HeaderText="DNI" DataField="DNI" />
        <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
        <asp:BoundField HeaderText="Apellido" DataField="Apellido" />
        <asp:BoundField HeaderText="Fecha de Nacimiento" DataField="FechaNacimiento" />
        <asp:BoundField HeaderText="Dirección" DataField="Direccion" />
        <asp:BoundField HeaderText="Localidad" DataField="Localidad" />
        <asp:BoundField HeaderText="Correo Electrónico" DataField="CorreoElectronico" />
    </Columns>
</asp:GridView>






     </div>
        </div>

    
     
    
</asp:Content>