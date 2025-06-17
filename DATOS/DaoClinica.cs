using ENTIDADES;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATOS
{
    public class DaoUsuario
    {
        AccesoDatos dataset = new AccesoDatos();

        public Usuario validarUsuario(string nombreUsuario, string contrasena)
        {
            DataTable tabla = dataset.ObtenerUsuario(nombreUsuario, contrasena);

            if (tabla.Rows.Count > 0)
            {
                Usuario usuario = new Usuario();
                usuario.setContraseniaUsuario(tabla.Rows[0]["contrasenia_U"].ToString());
                usuario.setNombreUsuario(tabla.Rows[0]["usuario_U"].ToString());
                usuario.setTipoUsuario(Convert.ToBoolean(tabla.Rows[0]["tipoUsuario_U"]));
                return usuario;
            }
            return null;
        }
    }
}