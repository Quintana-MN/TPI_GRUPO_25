using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPI_GRUPO_25
{
    public partial class BMLPaciente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["nombre"] == null)
                {
                    Response.Redirect("InicioSesion.aspx");
                }
                else
                {
                    lblBienvenida.Text = $"Bienvenido, {Session["nombre"]}. Acá se hace la Baja, Modificación y Lectura de los médicos";
                }
                CargarTabla();
            }
        }

        private void CargarTabla()
        {
            DataTable tabla = new DataTable();
            tabla.Columns.Add("DNI");
            tabla.Columns.Add("Nombre");
            tabla.Columns.Add("Apellido");
            tabla.Columns.Add("FechaNacimiento");
            tabla.Columns.Add("Direccion");
            tabla.Columns.Add("Localidad");
            tabla.Columns.Add("CorreoElectronico");

            // Carga 30 filas vacías simuladas
            for (int i = 0; i < 30; i++)
            {
                tabla.Rows.Add("", "", "", "", "", "", "");
            }

            gvPacientes.DataSource = tabla;
            gvPacientes.DataBind();
        }
    }
}