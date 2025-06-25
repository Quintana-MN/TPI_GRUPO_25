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

            string estadoTexto = ddlEstado.SelectedItem.Text;
            string observacion = txtObservacion.Text;

            NegocioUsuario negocio = new NegocioUsuario();
            negocio.ActualizarTurno(idTurno, estadoTexto, observacion);

            // Salir del modo edición
            gvTurnosMedico.EditIndex = -1;
            cargarTurnos();
        }


        private void cargarTurnos()
        {
            NegocioUsuario negocioTurno = new NegocioUsuario();
            DataTable tabla = negocioTurno.ObtenerTurnosPorPaciente();
            gvTurnosMedico.DataSource = tabla;
            gvTurnosMedico.DataBind();
        }

    }
}