using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ENTIDADES;

namespace TPI_GRUPO_25
{
    public partial class TurnosAdministrador : System.Web.UI.Page
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
                    lblBienvenida.Text = $"Bienvenido, {Session["nombre"]}. Estos son los Turnos.";
                }

                CargarPacientes();
                CargarEspecialidades();
                ddlMedico.Items.Clear();
                ddlMedico.Items.Insert(0, new ListItem("--Seleccionar--", "0"));
            }
        }

        protected void CargarEspecialidades()
        {
            NegocioUsuario negocio = new NegocioUsuario();
            ddlEspecialidad.DataSource = negocio.ObtenerEspecialidad();
            ddlEspecialidad.DataTextField = "nombre_E";
            ddlEspecialidad.DataValueField = "codEspecialidad_E";
            ddlEspecialidad.DataBind();
            ddlEspecialidad.Items.Insert(0, new ListItem("--Seleccionar--", "0"));
        }
        protected void CargarPacientes()
        {
            NegocioUsuario negocio = new NegocioUsuario();
            ddlPaciente.DataSource = negocio.ObtenerPacientes();
            ddlPaciente.DataTextField = "id_Paciente";
            ddlPaciente.DataValueField = "id_Paciente";
            ddlPaciente.DataBind();
            ddlPaciente.Items.Insert(0, new ListItem("--Seleccionar--", "0"));
        }
        protected void CargarMedicos(int especialidad)
        {
            NegocioUsuario negocio = new NegocioUsuario();
            ddlMedico.DataSource = negocio.ObtenerMedicos(especialidad);
            ddlMedico.DataTextField = "nombre_P";
            ddlMedico.DataValueField = "legajo_M";
            ddlMedico.DataBind();
            ddlMedico.Items.Insert(0, new ListItem("--Seleccionar--", "0"));
        }

        protected void BtnGuardarTurno_Click(object sender, EventArgs e)
        {
            NegocioUsuario negocio = new NegocioUsuario();
            bool IDTurnoExistente = negocio.verificarIDTurno(Convert.ToInt32(txtIdTurno.Text));
            bool verificacion = negocio.VerificacionHorarios(txtFecha.Text, Convert.ToInt32(txtHora.Text), Convert.ToInt32(ddlMedico.SelectedValue));

            if (IDTurnoExistente)
            {
                lblIDTurnoExistente.Text = "Ese ID de Turno ya existe, ingrese otro";
            }
            else
            {
                lblIDTurnoExistente.Text = "";
                if (!verificacion)
                {
                    Turno turno = new Turno();

                    turno.SetIdTurno(Convert.ToInt32(txtIdTurno.Text));
                    turno.SetIdPaciente(Convert.ToInt32(ddlPaciente.SelectedValue));
                    turno.SetFecha(txtFecha.Text);
                    turno.SetHorario(Convert.ToInt32(txtHora.Text));
                    turno.SetLegajo(Convert.ToInt32(ddlMedico.SelectedValue));

                    negocio.AgregarTurno(turno);

                    lblErrorTurno.Text = "Agrego exitosamente";
                }
                else
                {


                    lblErrorTurno.Text = "Ya tiene asignado ese horario";
                }
            }
        }

        protected void ddlEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            int codEspecialidad = Convert.ToInt32(ddlEspecialidad.SelectedValue);

            CargarMedicos(codEspecialidad);
        }
    }
}