using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPI_GRUPO_25
{
    public partial class BMLMedico : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                NegocioUsuario negocioUsuario = new NegocioUsuario();
                DataTable dt = negocioUsuario.getMedicos();
                if (dt.Rows.Count > 0)
                {
                    gvMedicos.DataSource = dt;
                    gvMedicos.DataBind();
                }
            }
        }
    }
}