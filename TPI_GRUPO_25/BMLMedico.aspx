<%@ Page Title="BMLMedico" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BMLMedico.aspx.cs" Inherits="TPI_GRUPO_25.BMLMedico" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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

        .badge-personalizada {
            background-color: #9E5439;
            padding: 30px;
            font-weight: bold;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="bg-naranja-suave w-100">
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
                            <a class="nav-link" href="#">Cerrar sesión</a>
                        </li>
                    </ul>
                </div>
            </div>
        </nav>
    </div>
    <asp:Label runat="server" ID="lblBienvenida" Text="Bienvenido Administrador: Aquí se hace la baja, modificación y lectura de médicos" CssClass="h2 text-center d-block mt-5 mb-3 text-dark"></asp:Label>
  <div class="container mt-5 pt-5">
    <asp:ListView ID="lvMedicos" runat="server" >
    </asp:ListView>
</div>

</asp:Content>