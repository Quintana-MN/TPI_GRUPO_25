using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ENTIDADES;

namespace TPI_GRUPO_25
{
    public partial class AltaPaciente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            if (Session["nombre"] == null)
            {
                Response.Redirect("InicioSesion.aspx");
            }
            else
            {
                lblBienvenida.Text = $"Bienvenido, {Session["nombre"]}. Acá se hace el Alta de los Pacientes.";
                CargarProvincias();
            }
        }
        protected void CargarProvincias()
        {
            NegocioUsuario negocio = new NegocioUsuario();
            ddlProvincia.DataSource = negocio.ObtenerProvincias();
            ddlProvincia.DataTextField = "nombre_Prov";
            ddlProvincia.DataValueField = "idProvincia_Prov";
            ddlProvincia.DataBind();
            ddlProvincia.Items.Insert(0, new ListItem("--Seleccionar--", "0"));
        }
        protected void ddlProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idProvincia = Convert.ToInt32(ddlProvincia.SelectedValue);
            if (idProvincia > 0)
                CargarLocalidades(idProvincia);
            else
                ddlLocalidad.Items.Clear();
        }
        protected void CargarLocalidades(int idProvincia)
        {
            NegocioUsuario negocio = new NegocioUsuario();
            ddlLocalidad.DataSource = negocio.ObtenerLocalidadesPorProvincia(idProvincia);
            ddlLocalidad.DataTextField = "nombre_L";
            ddlLocalidad.DataValueField = "idLocalidad_L";
            ddlLocalidad.DataBind();
            ddlLocalidad.Items.Insert(0, new ListItem("--Seleccionar--", "0"));
        }
        protected void btnAgregarPaciente_Click(object sender, EventArgs e)
        {
            NegocioUsuario negocio = new NegocioUsuario();

            bool IDPacienteExistente=negocio.verificarIDPaciente(Convert.ToInt32(txtIdPaciente.Text));
            bool DNIExistente=negocio.verificarDNI(txtDNI.Text);

            if (DNIExistente)
            {
                lblDNIExistentee.Text = "Ya existe ese DNI,ingrese otro";
            }
            else
            {
                lblDNIExistentee.Text = "";
            }
            if (IDPacienteExistente)
            {
                lblIDPacienteExistente.Text = "Ya existe ese ID de Paciente, ingrese otro";
            }
            else
            {
                lblIDPacienteExistente.Text = "";
            }

            if (!IDPacienteExistente && !DNIExistente)
            {

                PacienteCompleto pacienteCompleto = new PacienteCompleto();

                // Persona
                Persona persona = new Persona();
                persona.setDni(txtDNI.Text);
                persona.setNombre(txtNombre.Text);
                persona.setApellido(txtApellido.Text);
                persona.setSexo(Convert.ToInt32(ddlSexo.SelectedValue)); // "0" = Hombre, "1" = Mujer
                persona.setNacionalidad(txtNacionalidad.Text);
                persona.setFechaNacimiento(txtFechaNacimiento.Text); // Asegurate que sea una fecha válida
                persona.setDireccion(txtDireccion.Text);
                persona.setEmail(txtCorreo.Text);
                persona.setTelefono(txtTelefono.Text);
                persona.setIdProvincia(Convert.ToInt32(ddlProvincia.SelectedValue));
                persona.setIdLocalidad(Convert.ToInt32(ddlLocalidad.SelectedValue));
                pacienteCompleto.SetPersona(persona);

                // IDs (puede que los generes o los tomes del form)
                pacienteCompleto.SetIdPaciente(Convert.ToInt32(txtIdPaciente.Text)); // Este campo lo tendrías que tener en tu form

                // Lógica de negocio (ajustá al nombre real de tu clase)

                negocio.AgregarPaciente(pacienteCompleto);

                lblPacienteAgregado.Text = "¡Paciente creado!";

            }
        }
    }
}