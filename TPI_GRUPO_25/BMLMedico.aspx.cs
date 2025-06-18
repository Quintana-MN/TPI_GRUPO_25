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
            if (!IsPostBack)
            {
                string nombre = Session["usuario_M"]?.ToString() ?? "Invitado";
                lblBienvenida.Text = $"Bienvenido, {nombre}";
                CargarGrid();
            }
        }

        private void CargarGrid()
        {
            NegocioUsuario negocio = new NegocioUsuario();
            DataTable dt = negocio.getMedicos();
            gvMedicos.DataSource = dt;
            gvMedicos.DataBind();
        }
        protected void gvMedicos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < gvMedicos.DataKeys.Count)
            {
                int legajo = Convert.ToInt32(gvMedicos.DataKeys[e.RowIndex].Value);

                NegocioUsuario negocio = new NegocioUsuario();
                negocio.BajaMedico(legajo);

                CargarGrid();
            }
        }
    }
}