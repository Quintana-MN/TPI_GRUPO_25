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
                cargarTurnos();
                    if (Session["nombre"] == null)
                    {
                        Response.Redirect("InicioSesion.aspx");
                    }
                    else
                    {
                        lblBienvenida.Text = $"Bienvenido, {Session["nombre"]}";
                    }
                }
        }
        protected void gvTurnosMedico_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvTurnosMedico.EditIndex = e.NewEditIndex;
            cargarTurnos();
        }

        protected void gvTurnosMedico_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvTurnosMedico.EditIndex = -1;
            cargarTurnos();
        }

        protected void gvTurnosMedico_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int idTurno = Convert.ToInt32(gvTurnosMedico.DataKeys[e.RowIndex].Value);
            GridViewRow row = gvTurnosMedico.Rows[e.RowIndex];

            DropDownList ddlEstado = (DropDownList)row.FindControl("ddlEditEstado");
            TextBox txtObservacion = (TextBox)row.FindControl("txtEditObservacion");

            bool estado = ddlEstado.SelectedValue == "1";
            string observacion = txtObservacion.Text;

            NegocioUsuario negocio = new NegocioUsuario();
            negocio.ActualizarTurno(idTurno, estado, observacion);

            gvTurnosMedico.EditIndex = -1;
            cargarTurnos();
        }
        protected void btnFiltrarTurnos_Click(object sender, EventArgs e)
        {
            string nombreBuscar = txtBuscar.Text.Trim();
            int legajoMedico = Convert.ToInt32(Session["legajo"]); // o como tengas guardado el legajo

            NegocioUsuario negocio = new NegocioUsuario();
            DataTable dt = negocio.BuscarTurnosXNombre(legajoMedico, nombreBuscar);

            gvTurnosMedico.DataSource = dt;
            gvTurnosMedico.DataBind();

            lblMensaje.Text = dt.Rows.Count == 0 ? "No se encontraron turnos con ese nombre." : "";
        }




        private void cargarTurnos()
        {
            if (Session["legajo"] != null)
            {
                int legajo = Convert.ToInt32(Session["legajo"]);

                NegocioUsuario negocio = new NegocioUsuario();

                DataTable tabla = negocio.ObtenerTurnosPorMedico(legajo);
                gvTurnosMedico.DataSource = tabla;
                gvTurnosMedico.DataBind();

            }
        }

    }
}