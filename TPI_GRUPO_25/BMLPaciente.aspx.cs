using ENTIDADES;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
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
                    lblBienvenida.Text = $"Bienvenido, {Session["nombre"]}. Acá se hace la Baja, Modificación y Lectura de los Pacientes";
                }
                CargarGridPaciente();
            }
        }
        private void CargarGridPaciente()
        {
            NegocioUsuario negocio = new NegocioUsuario();
            DataTable dt = negocio.getPacientes();
            gvPacientes.DataSource = dt;
            gvPacientes.DataBind();
        }
        
        protected void gvPaciente_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < gvPacientes.DataKeys.Count)
            {
                int idPaciente = Convert.ToInt32(gvPacientes.DataKeys[e.RowIndex].Value);

                NegocioUsuario negocio = new NegocioUsuario();

                negocio.BajaPaciente(idPaciente);

                CargarGridPaciente();
            }
        }
        protected void gvPaciente_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string nombrePaciente = ((TextBox)gvPacientes.Rows[e.RowIndex].FindControl("txtEditTempNombre")).Text;
            string emailPaciente= ((TextBox)gvPacientes.Rows[e.RowIndex].FindControl("txtEditCorreo")).Text;

            string dniPaciente= ((Label)gvPacientes.Rows[e.RowIndex].FindControl("lblEditDniPaciente")).Text;

            PacienteUpdate pacienteUp = new PacienteUpdate(nombrePaciente, emailPaciente, dniPaciente);

            NegocioUsuario negocio = new NegocioUsuario();
            negocio.EditarPaciente(pacienteUp);

            gvPacientes.EditIndex = -1;
            CargarGridPaciente();
        }

        protected void gvPaciente_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvPacientes.EditIndex = e.NewEditIndex;
            CargarGridPaciente();
        }

        protected void gvPaciente_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvPacientes.EditIndex = -1;
            CargarGridPaciente();
        }

        protected void gvPacientes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvPacientes.PageIndex = e.NewPageIndex;
            CargarGridPaciente();
        }
    }
}