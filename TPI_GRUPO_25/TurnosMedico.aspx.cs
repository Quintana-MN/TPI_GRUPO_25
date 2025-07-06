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

        protected void gvTurnosMedico_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int idTurno = Convert.ToInt32(gvTurnosMedico.DataKeys[e.RowIndex].Value);
            GridViewRow row = gvTurnosMedico.Rows[e.RowIndex];

            DropDownList ddlEstado = (DropDownList)row.FindControl("ddlEditEstado");
            TextBox txtObservacion = (TextBox)row.FindControl("txtEditObservacion");

            int estado = Convert.ToInt32(ddlEstado.SelectedValue);
            string observacion = txtObservacion.Text;

            NegocioUsuario negocio = new NegocioUsuario();
            negocio.ActualizarTurno(idTurno, estado, observacion);

            //Cierra el modo de edición
            gvTurnosMedico.EditIndex = -1;
            cargarTurnos();
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
        private void AplicarFiltro()
        {
            string nombreBuscar = txtBuscar.Text.Trim();
            int legajo = Convert.ToInt32(Session["legajo"]);

            bool filtroMañana = chkMañana.Checked;
            bool filtroTarde = chkTarde.Checked;

            NegocioUsuario negocio = new NegocioUsuario();
            DataTable dt = negocio.ObtenerTurnosXFiltro(legajo, nombreBuscar, filtroMañana, filtroTarde);

            lblMensaje.Text = dt.Rows.Count == 0 ? "No se encontraron turnos con esos filtros." : "";

            gvTurnosMedico.DataSource = dt;
            gvTurnosMedico.DataBind();
        }

        protected void btnFiltrarTurnos_Click(object sender, EventArgs e)
        {
            AplicarFiltro();
        }
        protected void chkMañana_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMañana.Checked)
                chkTarde.Checked = false;
            else
                chkTarde.Checked = false; // Opcional, para que no queden ambos desmarcados (si querés)

            AplicarFiltro();
        }

        protected void chkTarde_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTarde.Checked)
                chkMañana.Checked = false;
            else
                chkMañana.Checked = false;

            AplicarFiltro();
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

        protected void gvTurnosMedico_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvTurnosMedico.PageIndex = e.NewPageIndex;
            cargarTurnos();
        }
    }
}