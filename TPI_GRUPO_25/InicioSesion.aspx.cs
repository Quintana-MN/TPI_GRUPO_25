using ENTIDADES;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPI_GRUPO_25
{
    public partial class InicioSesion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string contrasena = txtClave.Text;

            NegocioUsuario negocio = new NegocioUsuario();
            Usuario user = negocio.login(usuario, contrasena);

            if (user != null)
            {
                Session["usuario_U"] = user;
                if (user.getTipoUsuario() == true)
                {
                    Response.Redirect("SesionIniciadaAdministrador.aspx");
                }
                else
                {
                    Response.Redirect("SesionIniciadaMedico.aspx");
                }
            }
            else
            {
                lblError.Text = "Usuario o contraseña incorrectos.";
            }
        }

    }
}