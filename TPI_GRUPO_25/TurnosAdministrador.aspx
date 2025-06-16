<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TurnosAdministrador.aspx.cs" Inherits="TPI_GRUPO_25.TurnosAdministrador" %>
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
    border: 2px solid black; 
}

.boton-personalizado:hover {
    background-color: #4d2606;
    color: white;           
    border: 2px solid black; 
}
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="bg-naranja-suave w-100">
        <nav class="navbar navbar-expand-xl">
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

    <div class="main-content text-center">
        <asp:Label runat="server" ID="lblBienvenida" 
                   Text="Bienvenido Administrador: Estos son los turnos" 
                   CssClass="h2 text-center d-block mb-3 text-dark"></asp:Label>
 <div class="container mt-4 w-75">
   
    <div class="d-flex align-items-center mb-4">
        <asp:Label runat="server" ID="lblPaciente" Text="Paciente:" CssClass="me-3 fw-bold label-fijo" />
        <asp:DropDownList runat="server" ID="ddlPaciente" CssClass="form-select w-50" />
    </div>

 
    <div class="d-flex align-items-center mb-4">
        <asp:Label runat="server" ID="lblDia" Text="Día:" CssClass="me-3 fw-bold label-fijo" />
        <asp:TextBox runat="server" ID="txtDia" CssClass="form-control w-50" />
    </div>


    <div class="d-flex align-items-center mb-4">
        <asp:Label runat="server" ID="lblHora" Text="Hora:" CssClass="me-3 fw-bold label-fijo" />
        <asp:TextBox runat="server" ID="txtHora" CssClass="form-control w-50" />
    </div>


    <div class="d-flex align-items-center mb-4">
        <asp:Label runat="server" ID="lblEspecialidad" Text="Especialidad:" CssClass="me-3 fw-bold label-fijo" />
        <asp:DropDownList runat="server" ID="ddlEspecialidad" CssClass="form-select w-50" />
    </div>

    <div class="d-flex align-items-center mb-5">
        <asp:Label runat="server" ID="Label1" Text="Médico:" CssClass="me-3 fw-bold label-fijo" />
        <asp:DropDownList runat="server" ID="DropDownList1" CssClass="form-select w-50" />
    </div>


    <div class="d-flex justify-content-end">
        <asp:Button runat="server" ID="btnGuardarTurno" Text="Guardar Turno" CssClass="btn boton-personalizado" />
    </div>
</div>
</asp:Content>