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
                    CargarProvincias();
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
            ddlEspecialidad.Items.Insert(0, new ListItem("--Seleccionar--", "0"));
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
        protected void btnAltaMedico_Click(object sender, EventArgs e)
        {
            NegocioUsuario negocio = new NegocioUsuario();

            bool dniExistente = negocio.verificarDNI(txtDNI.Text);
            bool legajoExistente = negocio.verificarLegajo(Convert.ToInt32(txtLegajo.Text));
            bool usuarioExistente = negocio.verificarUsuario(txtUsuario.Text);

            if (dniExistente)
            {
                lblDNIExistente.Text = "Ya existe ese DNI,ingrese otro";
            }
            else
            {
                lblDNIExistente.Text = "";
            }
            if (legajoExistente)
            {
                lblLegajoExistente.Text = "Ya existe ese legajo, ingrese otro";
            }
            else
            {
                lblLegajoExistente.Text = "";
            }
            if (usuarioExistente)
            {
                lblUsuarioExistente.Text = "Ya existe ese usuario, ingrese otro";
            }
            else
            {
                lblUsuarioExistente.Text = "";
            }

            if (!dniExistente && !legajoExistente && !usuarioExistente)
            {
                MedicoCompleto MedicoCompleto = new MedicoCompleto();

                // Persona
                Persona persona = new Persona();
                persona.setDni(txtDNI.Text);
                persona.setNombre(txtNombre.Text);
                persona.setApellido(txtApellido.Text);
                persona.setSexo(Convert.ToInt32(ddlSexo.SelectedValue));
                persona.setNacionalidad(txtNacionalidad.Text);
                persona.setFechaNacimiento(txtFechaNacimiento.Text);
                persona.setDireccion(txtDireccion.Text);
                persona.setEmail(txtCorreo.Text);
                persona.setTelefono(txtTelefono.Text);
                persona.setIdProvincia(Convert.ToInt32(ddlProvincia.SelectedValue));
                persona.setIdLocalidad(Convert.ToInt32(ddlLocalidad.SelectedValue));
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
                MedicoCompleto.SetMedico(medico);


                negocio.AgregarMedico(MedicoCompleto);

                lblMedicoCreado.Text = "¡Medico creado!";
            }
            txtDNI.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtNacionalidad.Text = "";
            txtFechaNacimiento.Text = "";
            txtDireccion.Text = "";
            txtCorreo.Text = "";
            txtTelefono.Text = "";
            txtLegajo.Text = "";
            txtUsuario.Text = "";
            txtContraseña.Text = "";
            ddlSexo.SelectedIndex = 0;
            ddlEspecialidad.SelectedIndex = 0;
            ddlProvincia.SelectedIndex = 0;
        }
    }
}