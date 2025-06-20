using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ENTIDADES;

namespace TPI_GRUPO_25
{
    public partial class AltaMedico : System.Web.UI.Page
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
                    lblBienvenida.Text = $"Bienvenido, {Session["nombre"]}. Acá se hace la Alta de los médicos";
                    CargarEspecialidades();
                }
            }
        }
        protected void CargarEspecialidades()
        {
            NegocioUsuario negocio = new NegocioUsuario();
            ddlEspecialidad.DataSource = negocio.ObtenerEspecialidad();
            ddlEspecialidad.DataTextField = "nombre_E";
            ddlEspecialidad.DataValueField = "codEspecialidad_E";
            ddlEspecialidad.DataBind();

            ddlEspecialidad.Items.Insert(0, new ListItem("-- Seleccione --", "0"));
        }


        protected void btnAltaMedico_Click(object sender, EventArgs e)
        {
            MedicoCompleto MedicoCompleto = new MedicoCompleto();

            // Persona
            Persona persona = new Persona();
            persona.setDni(txtDNI.Text);
            persona.setNombre(txtNombre.Text);
            persona.setApellido(txtApellido.Text);
            persona.setSexo(Convert.ToInt32(ddlSexo.SelectedValue)); // "0" = Hombre, "1" = Mujer
            persona.setNacionalidad(txtNacionalidad.Text);
            persona.setFechaNacimiento(txtFechaNacimiento.Text); // o .Value.ToString("yyyy-MM-dd") si usás DateTimePicker
            persona.setDireccion(txtDireccion.Text);
            persona.setEmail(txtCorreo.Text);
            persona.setTelefono(txtTelefono.Text);
            persona.setIdLocalidad(Convert.ToInt32(txtLocalidad.Text));
            persona.setIdProvincia(Convert.ToInt32(txtProvincia.Text));
            MedicoCompleto.SetPersona(persona);

            // Usuario
            Usuario usuario = new Usuario();
            usuario.setNombreUsuario(txtUsuario.Text);
            usuario.setContraseniaUsuario(txtContraseña.Text);
            usuario.setTipoUsuario(true);
            MedicoCompleto.SetUsuario(usuario);

            // Médico
            Medico medico = new Medico();
            medico.SetLegajo_M(Convert.ToInt32(txtLegajo.Text));
            medico.SetUsuario_M(txtUsuario.Text);
            medico.SetContrasenia_M(txtContraseña.Text);
            medico.SetEspecialidad_M(Convert.ToInt32(ddlEspecialidad.SelectedValue));
            medico.SetDni_M(txtDNI.Text);
            medico.setHorario_M(ddlHorario.SelectedItem.ToString());
            MedicoCompleto.SetMedico(medico);

            NegocioUsuario negocio = new NegocioUsuario();
            negocio.AgregarMedico(MedicoCompleto);

            lblMedicoCreado.Text = "Medico creado!";

        }

    }
}