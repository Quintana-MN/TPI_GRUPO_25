using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPI_GRUPO_25
{
    public partial class TurnosMedico : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarTabla();
            }
        }

        private void CargarTabla()
        {
            DataTable tabla = new DataTable();
            tabla.Columns.Add("Turno");
            tabla.Columns.Add("Paciente");
            tabla.Columns.Add("Estado");
            tabla.Columns.Add("Observación");

            // Carga 30 filas vacías simuladas
            for (int i = 0; i < 30; i++)
            {
                tabla.Rows.Add("", "", "");
            }
            gvTurnos.DataSource = tabla;
            gvTurnos.DataBind();
        }
    }
}