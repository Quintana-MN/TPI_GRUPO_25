using ENTIDADES;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace TPI_GRUPO_25
{
    public partial class BMLMedico : System.Web.UI.Page
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
                CargarGridMedico();
            }
        }

        private void CargarGridMedico()
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

                CargarGridMedico();
            }
        }

        protected void gvMedicos_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            int legajo = Convert.ToInt32(((Label)gvMedicos.Rows[e.RowIndex].FindControl("lblEditLegajo")).Text);

            string usuario = ((TextBox)gvMedicos.Rows[e.RowIndex].FindControl("txtEditUsuario")).Text;
            string contrasenia = ((TextBox)gvMedicos.Rows[e.RowIndex].FindControl("txtEditContraseña")).Text;


            DropDownList ddlEspecialidad = (DropDownList)gvMedicos.Rows[e.RowIndex].FindControl("ddlEditEspecialidad");
            int especialidad = Convert.ToInt32(ddlEspecialidad.SelectedValue);

            string dni = ((Label)gvMedicos.Rows[e.RowIndex].FindControl("lblEditDni")).Text;

            Medico medico = new Medico(legajo, usuario, contrasenia, especialidad, dni);

            NegocioUsuario negocio = new NegocioUsuario();
            negocio.EditarMedico(medico);

            gvMedicos.EditIndex = -1;
            CargarGridMedico();
        }

        protected void gvMedicos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvMedicos.EditIndex = e.NewEditIndex;
            CargarGridMedico();
        }

        protected void gvMedicos_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvMedicos.EditIndex = -1;
            CargarGridMedico();
        }

        protected void gvMedicos_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvMedicos.PageIndex = e.NewPageIndex;
            CargarGridMedico();
        }
    }
}