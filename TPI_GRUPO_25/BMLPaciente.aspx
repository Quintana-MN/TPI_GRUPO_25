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
     <asp:Label runat="server" ID="lblBienvenida" Text="¡Bienvenido Administrador! Estos son los pacientes de la clínica TUP." CssClass="h2 text-center d-block mt-5 mb-3 text-dark"></asp:Label>
        <br />
        &nbsp;&nbsp;
        <br />
        <br />
   <div class="container mt-5 pt-5">
    <asp:GridView ID="gvPacientes" runat="server" AutoGenerateColumns="False" AllowPaging="True" CssClass="grid-style" Width="94%" HorizontalAlign="Center" CellPadding="3" AutoGenerateSelectButton="True" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellSpacing="2">
    <Columns>
        <asp:BoundField HeaderText="DNI" DataField="DNI" />
        <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
        <asp:BoundField HeaderText="Apellido" DataField="Apellido" />
        <asp:BoundField HeaderText="Fecha de Nacimiento" DataField="FechaNacimiento" />
        <asp:BoundField HeaderText="Dirección" DataField="Direccion" />
        <asp:BoundField HeaderText="Localidad" DataField="Localidad" />
        <asp:BoundField HeaderText="Correo Electrónico" DataField="CorreoElectronico" />
    </Columns>
    <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
    <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />

    <PagerStyle HorizontalAlign="Center" CssClass="gv-pager" ForeColor="#8C4510"></PagerStyle>
      <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
      <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
      <SortedAscendingCellStyle BackColor="#FFF1D4" />
      <SortedAscendingHeaderStyle BackColor="#B95C30" />
      <SortedDescendingCellStyle BackColor="#F1E5CE" />
      <SortedDescendingHeaderStyle BackColor="#93451F" />

    </asp:GridView>

   </div>

    
     
    
</asp:Content>