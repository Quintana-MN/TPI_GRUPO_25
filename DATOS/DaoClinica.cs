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

        public DataTable getTablaMedicos()
        {
            DataTable tabla = dataset.ObtenerTabla("MEDICO", @"
            SELECT
            USUARIO.usuario_U AS [Usuario],
            USUARIO.contrasenia_U AS [Contraseña],
            ESPECIALIDADES.nombre_E AS [Especialidad], 
            MEDICO.legajo_M AS [Legajo],
            MEDICO.dni_M AS [DNI]
            FROM MEDICO
            INNER JOIN ESPECIALIDADES ON MEDICO.codEspecialidad_M = ESPECIALIDADES.codEspecialidad_E
            INNER JOIN USUARIO ON MEDICO.usuario_M = USUARIO.usuario_U WHERE MEDICO.estado_M = 1");

            return tabla;
        }


    }
}