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
            }
        }

        protected void btnAgregarPaciente_Click(object sender, EventArgs e)
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
            pacienteCompleto.SetIdPaciente(txtIdPaciente.Text); // Este campo lo tendrías que tener en tu form
            pacienteCompleto.SetIdTurno(txtIdTurno.Text);       // Este también (o puede ser nulo si se asigna después)

            // Lógica de negocio (ajustá al nombre real de tu clase)
            NegocioUsuario negocio = new NegocioUsuario();
            negocio.AgregarPaciente(pacienteCompleto);

            lblPacienteCreado.Text = "¡Paciente creado!";
        }
    }
}