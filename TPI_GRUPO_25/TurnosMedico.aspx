<%@ Page Title="TurnosMedico" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TurnosMedico.aspx.cs" Inherits="TPI_GRUPO_25.TurnosMedico" %>

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
            <li class="nav-item ms-auto">
              <asp:Label class="nav-link mb-15" ID="usuarioAd" runat="server" Text="Usuario: Médico"></asp:Label>
            </li>
        <li class="nav-item">
<a class="nav-link btn btn-primary"  href="InicioSesion.aspx">Cerrar Sesión</a>
        </li>
      </ul>
    </div>
  </div>
</nav>
        </div>
        <div class="px-4 pt-4">
            <asp:Label runat="server" ID="lblBienvenida" CssClass="fw-bold h3 mt-4">¡Bienvenido a la Clínica TUP {Médico}, Estos son los Turnos!</asp:Label>
            <div class="d-flex justify-content-center">
            <asp:Label CssClass="d-flex align-items-center h5" runat="server" Text="Buscar:"></asp:Label>
            <asp:TextBox runat="server" ID="txtBuscar" CssClass="form-control w-25 mx-2" />
            <asp:Button runat="server" ID="btnFiltrarTurnos" Text="Filtrar" CssClass="btn boton-personalizado" OnClick="btnFiltrarTurnos_Click" />
            </div>
            
            <div class="text-center"><asp:Label CssClass="h3 ml-6" runat="server" ID="lblMensaje"></asp:Label></div>
            <div class="d-flex justify-content-center align-items-center py-4">
            <div class="divFiltrar px-2 col-sm-2 py-4">
                <asp:Label CssClass="h4" runat="server" Text="Filtrar por:"></asp:Label>
            <div>
                <asp:Label CssClass="h4" runat="server" Text="Turno:"></asp:Label>
                <div class="py-2">
                <asp:CheckBox ID="chkMañana" runat="server" Text="Turno Mañana" AutoPostBack="true" OnCheckedChanged="chkMañana_CheckedChanged" />
                </div>
                <div>
                <asp:CheckBox ID="chkTarde" runat="server" Text="Turno Tarde" AutoPostBack="true" OnCheckedChanged="chkTarde_CheckedChanged" />
                </div>
            </div>
            </div>
  <div class="w-100 px-4">
<asp:GridView ID="gvTurnosMedico" DataKeyNames="Turno" runat="server"
    AutoGenerateColumns="False"
    CssClass="grid-style"
    Width="100%"
    AllowPaging="True"
    AutoGenerateEditButton="True"
    BackColor="#DEBA84"
    BorderColor="#DEBA84"
    BorderStyle="None"
    BorderWidth="1px"
    CellPadding="3"
    CellSpacing="2"
    PageSize="5"
    PagerStyle-HorizontalAlign="Center"
    PagerStyle-Font-Size="Large"
    HorizontalAlign="Center"
    OnRowEditing="gvTurnosMedico_RowEditing"
    OnRowCancelingEdit="gvTurnosMedico_RowCancelingEdit"
    OnRowUpdating="gvTurnosMedico_RowUpdating" OnPageIndexChanging="gvTurnosMedico_PageIndexChanging">

    <Columns>
        <asp:TemplateField HeaderText="Turno">
            <ItemTemplate>
                <asp:Label ID="lblTurno" runat="server" Text='<%# Bind("Turno") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Paciente">
            <ItemTemplate>
                <asp:Label ID="lblPaciente" runat="server" Text='<%# Bind("Paciente") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Estado">
    <EditItemTemplate>
        <asp:DropDownList ID="ddlEditEstado" runat="server">
            <asp:ListItem Text="Presente" Value="0" />
            <asp:ListItem Text="Ausente" Value="1" />
        </asp:DropDownList>
    </EditItemTemplate>
    <ItemTemplate>
        <%# Eval("Estado") %>
    </ItemTemplate>
</asp:TemplateField>


        <asp:TemplateField HeaderText="Observación">
            <EditItemTemplate>
                <asp:TextBox ID="txtEditObservacion" runat="server" Text='<%# Bind("Observacion") %>'></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="lblObservacion" runat="server" Text='<%# Bind("Observacion") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>


 </div>
</div>
</div>
</asp:Content>