using ENTIDADES;
using System;
using System.Collections.Generic;
using System.Data;
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

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string contrasenia = txtClave.Text;

            NegocioUsuario negocio = new NegocioUsuario();
            DataTable dt = negocio.ValidarLogin(usuario, contrasenia);

            if (dt.Rows.Count > 0)
            {
                Session["usuario"] = usuario;
                Session["nombre"] = dt.Rows[0]["usuario_U"].ToString();

                Response.Redirect("SesionIniciadaAdministrador.aspx");
            }
            else
            {
                lblError.Text = "Usuario o contraseña incorrectos";
            }
        }


    }
}