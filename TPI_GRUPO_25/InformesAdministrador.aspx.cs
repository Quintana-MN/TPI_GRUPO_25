using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPI_GRUPO_25
{
    public partial class InformesAdministrador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["nombre"] == null)
            {
                Response.Redirect("InicioSesion.aspx");
            }
            else
            {
                lblBienvenida.Text = $"Bienvenido, {Session["nombre"]}. Estos son los Informes.";
            }
        }

        protected void btnVer_Click(object sender, EventArgs e)
        {
            string fechaDesde = Desde.Value;
            string fechaHasta = Hasta.Value;





            NegocioUsuario negocio = new NegocioUsuario();

            //Informe presentes

            int presente = negocio.InformesPresenteNegocio(fechaDesde, fechaHasta);

            int ausente = negocio.InformesAusenteNegocio(fechaDesde, fechaHasta);

            int total = presente + ausente;

      
            if (total == 0)
            {
                lblPorcentajePresentes.Text = "0 %";
                lblPorcentajeAusentes.Text = "0 %";
            }
            else
            {
                float porcentajePresentes = (float)presente / (presente + ausente);
                float porcentajeAusentes = (float)ausente / (presente + ausente);

                lblPorcentajePresentes.Text = (porcentajePresentes * 100).ToString("0.00") + " %";
                lblPorcentajeAusentes.Text = (porcentajeAusentes * 100).ToString("0.00") + " %";
            }


            //Informe especialidades

            int cardiologia = negocio.InformeCardiologiaNegocio(fechaDesde, fechaHasta);

            int pediatria = negocio.InformePediatriaNegocio(fechaDesde, fechaHasta);

            int totalEspecialidades = cardiologia + pediatria;


            if (totalEspecialidades == 0)
            {
                lblPorcentajeCardiologia.Text = "0 %";
                lblPorcentajePediatria.Text = "0 %";
            }
            else
            {
                float porcentajeCardiologia = (float)cardiologia / totalEspecialidades;
                float porcentajePediatria = (float)pediatria / totalEspecialidades;

                lblPorcentajeCardiologia.Text = (porcentajeCardiologia * 100).ToString("0.00") + " %";
                lblPorcentajePediatria.Text = (porcentajePediatria * 100).ToString("0.00") + " %";
            }
        }

        
        
}
    }
