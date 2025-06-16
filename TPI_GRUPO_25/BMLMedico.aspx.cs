using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPI_GRUPO_25
{
    public partial class BMLMedico : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarTabla();
        }



        private void CargarTabla()
        {
            DataTable tabla = new DataTable();
            tabla.Columns.Add("Legajo");
            tabla.Columns.Add("Nombre");
            tabla.Columns.Add("Apellido");
            tabla.Columns.Add("FechaNacimiento");
            tabla.Columns.Add("Direccion");
            tabla.Columns.Add("Localidad");
            tabla.Columns.Add("CorreoElectronico");


            for (int i = 0; i < 10; i++)
            {
                tabla.Rows.Add("", "", "", "", "", "", "");
            }

            gvMedicos.DataSource = tabla;
            gvMedicos.DataBind();
        }
    }
}