using ENTIDADES;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
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

        public DataTable getTablaPaciente()
        {
            DataTable tabla = dataset.ObtenerTabla("PACIENTE", @"
        SELECT 
        P.id_Paciente AS [ID_Paciente],
        P.dni_Pac AS [DNI],
        P.id_turno_Pac AS [ID_Turno],
        PR.nombre_P AS [Nombre],
        PR.email_P AS [Email]
        FROM PACIENTE P
        INNER JOIN PERSONA PR ON P.dni_Pac = PR.dni_P
        WHERE P.estado_Pac = 1");

            return tabla;
        }
        public DataTable getTurnos()
        {
            DataTable tabla = dataset.ObtenerTabla("TURNOS", @"
        SELECT
    TURNOS.id_turno_T AS [Turno],
    PERSONA.nombre_P AS [Paciente],
    CASE WHEN PACIENTE.estado_Pac = 1 THEN 'Presente' ELSE 'Ausente' END AS [Estado],
    TURNOS.observacion_T AS [Observacion]
    FROM TURNOS
    INNER JOIN PACIENTE ON TURNOS.id_Paciente = PACIENTE.id_Paciente
    INNER JOIN PERSONA ON PACIENTE.dni_Pac = PERSONA.dni_P");

        return tabla;
        }

    }
}