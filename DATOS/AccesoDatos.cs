using ENTIDADES;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DATOS
{
    public class AccesoDatos
    {
        private const string cadenaConexion = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=clinicaTUP;Integrated Security=True;TrustServerCertificate=True";

        public AccesoDatos() { }

        private SqlConnection ObtenerConexion()
        {
            SqlConnection conexion = new SqlConnection(cadenaConexion);
            try
            {
                conexion.Open();
                return conexion;
            }
            catch (Exception ex)
            {
                // Lanzar la excepción o loguearla
                throw new Exception("Error al abrir conexión: " + ex.Message);
            }
        }
       
    public SqlDataAdapter ObtenerAdaptador(string consultaSql, SqlConnection conexion)
        {
            try
            {
                return new SqlDataAdapter(consultaSql, conexion);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear adaptador: " + ex.Message);
            }
        }
      
    public DataTable ObtenerTabla(string nombreTabla, string sql)
        {
            DataSet dataSet = new DataSet();

            using (SqlConnection conexion = ObtenerConexion())
            {
                if (conexion == null)
                    throw new Exception("No se pudo establecer la conexión a la base de datos.");

                using (SqlDataAdapter adp = ObtenerAdaptador(sql, conexion))
                {
                    if (adp == null)
                        throw new Exception("No se pudo crear el adaptador de datos.");

                    adp.Fill(dataSet, nombreTabla);
                }
            }

            if (!dataSet.Tables.Contains(nombreTabla))
                throw new Exception($"No se encontró la tabla {nombreTabla} en el dataset.");

            return dataSet.Tables[nombreTabla];
        }

        public int EjecutarProcedimientoAlmacenado(SqlCommand Comando, String NombreSP)
        {
            int FilasCambiadas;
            SqlConnection Conexion = ObtenerConexion();
            SqlCommand cmd = new SqlCommand();
            cmd = Comando;
            cmd.Connection = Conexion;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = NombreSP;
            FilasCambiadas = cmd.ExecuteNonQuery();
            Conexion.Close();
            return FilasCambiadas;
        }

        public Boolean existe(String consulta)
        {
            Boolean estado = false;
            SqlConnection Conexion = ObtenerConexion();
            SqlCommand cmd = new SqlCommand(consulta, Conexion);
            SqlDataReader datos = cmd.ExecuteReader();
            if (datos.Read())
            {
                estado = true;
            }
            return estado;
        }
        public DataTable ObtenerUsuario(string usuario, string contrasenia)
        {
            string consulta = $"SELECT * FROM USUARIO WHERE usuario_U = @usuario_U AND contrasenia_U = @contrasenia_U";
            SqlConnection Conexion = ObtenerConexion();
            SqlCommand cmd = new SqlCommand(consulta, Conexion);
            cmd.Parameters.AddWithValue("@usuario_U", usuario);
            cmd.Parameters.AddWithValue("@contrasenia_U", contrasenia);

            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            Conexion.Close();
            return dt;
        }
        public void BajaLogicaMedico(int legajo)
        {
            using (SqlConnection conexion = ObtenerConexion())
            {
                SqlCommand comando = new SqlCommand("SP_BajaMedico", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@legajo_M", legajo);
                comando.ExecuteNonQuery();
            }
        }
        public void BajaLogicaPaciente(int idPaciente)
        {
            using (SqlConnection conexion = ObtenerConexion())
            {
                SqlCommand comando = new SqlCommand("SP_BajaPaciente", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@id_Paciente", idPaciente);
                comando.ExecuteNonQuery();
            }
        }


        private void ArmarParametrosMedico(ref SqlCommand Comando, Medico medico)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@legajo_M", SqlDbType.Int);
            SqlParametros.Value = medico.legajo_M;
            SqlParametros = Comando.Parameters.Add("@usuario_M", SqlDbType.Char, 30);
            SqlParametros.Value = medico.usuario_M;
            SqlParametros = Comando.Parameters.Add("@especialidad_M", SqlDbType.Int);
            SqlParametros.Value = medico.especialidad_M;
            SqlParametros = Comando.Parameters.Add("@dni_M", SqlDbType.NChar, 9);
            SqlParametros.Value = medico.dni_M;
            SqlParametros = Comando.Parameters.Add("@contrasenia", SqlDbType.Char,30);
            SqlParametros.Value = medico.contrasenia_M;
        }

        public bool ActualizarMedico(Medico medico)
        {
            SqlCommand sqlCommand = new SqlCommand();
            ArmarParametrosMedico(ref sqlCommand, medico);
            AccesoDatos accesoDatos = new AccesoDatos();
            int FilasInsertadas = accesoDatos.EjecutarProcedimientoAlmacenado(sqlCommand, "SP_EditarMedico");
            if (FilasInsertadas == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

<<<<<<< Updated upstream
        public DataTable ObtenerEspecialidades()
        {
            using (SqlConnection conexion = ObtenerConexion())
            {
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT codEspecialidad_E, nombre_E FROM ESPECIALIDADES", conexion);
                DataTable tabla = new DataTable();
                sqlDataAdapter.Fill(tabla);
                return tabla;
            }
        }

        public DataTable ObtenerProvincias()
        {
            using (SqlConnection conexion = ObtenerConexion())
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT idProvincia_Prov, nombre_Prov FROM PROVINCIAS", conexion);
                DataTable tabla = new DataTable();
                da.Fill(tabla);
                return tabla;
            }
        }
        public DataTable ObtenerLocalidadesPorProvincia(int idProvincia)
        {
            using (SqlConnection conexion = ObtenerConexion())
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT idLocalidad_L, nombre_L FROM LOCALIDADES WHERE idProvincia_L = @idProvincia_L", conexion);
                da.SelectCommand.Parameters.AddWithValue("@idProvincia_L", idProvincia);
                DataTable tabla = new DataTable();
                da.Fill(tabla);
                return tabla;
            }
        }



        public void AltaMedico(MedicoCompleto medico)
        {
            using (SqlConnection conexion = ObtenerConexion())
            {
                SqlCommand comando = new SqlCommand("SP_AltaMedico", conexion);
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@dni_P", medico.GetPersona().getDni());
                comando.Parameters.AddWithValue("@nombre_P", medico.GetPersona().getNombre());
                comando.Parameters.AddWithValue("@apellido_P", medico.GetPersona().getApellido());
                comando.Parameters.AddWithValue("@sexo_P", medico.GetPersona().getSexo());
                comando.Parameters.AddWithValue("@nacionalidad_P", medico.GetPersona().getNacionalidad());
                comando.Parameters.AddWithValue("@fechaNac_P", medico.GetPersona().getFechaNacimiento());
                comando.Parameters.AddWithValue("@direccion_P", medico.GetPersona().getDireccion());
                comando.Parameters.AddWithValue("@email_P", medico.GetPersona().getEmail());
                comando.Parameters.AddWithValue("@telefono_P", medico.GetPersona().getTelefono());
                comando.Parameters.AddWithValue("@idLocalidad_P", medico.GetPersona().getIdLocalidad());
                comando.Parameters.AddWithValue("@idProvincia_P", medico.GetPersona().getIdProvincia());

                comando.Parameters.AddWithValue("@usuario_U", medico.GetUsuario().getNombreUsuario());
                comando.Parameters.AddWithValue("@contrasenia_U", medico.GetUsuario().getContraseniaUsuario());

                comando.Parameters.AddWithValue("@legajo_M", medico.GetMedico().GetLegajo_M());
                comando.Parameters.AddWithValue("@codEspecialidad_M", medico.GetMedico().GetEspecialidad_M());
                comando.Parameters.AddWithValue("@horario_M", medico.GetMedico().getHorario_M());

                comando.ExecuteNonQuery();
            }
        }
=======
        private void ArmarParametrosPacienteUpdate(ref SqlCommand Comando, PacienteUpdate pacienteUpdate)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@nombre_paciente", SqlDbType.VarChar, 50);
            SqlParametros.Value = pacienteUpdate.nombre;
            SqlParametros = Comando.Parameters.Add("@email_paciente", SqlDbType.VarChar, 50);
            SqlParametros.Value = pacienteUpdate.email;
            SqlParametros = Comando.Parameters.Add("@dni_paciente", SqlDbType.NChar, 9);
            SqlParametros.Value = pacienteUpdate.dni;

        }

        public bool ActualizarPaciente(PacienteUpdate pacienteUpdate)
        {
            SqlCommand sqlCommand = new SqlCommand();
            ArmarParametrosPacienteUpdate(ref sqlCommand, pacienteUpdate);
            AccesoDatos accesoDatos = new AccesoDatos();
            int FilasInsertadas = accesoDatos.EjecutarProcedimientoAlmacenado(sqlCommand, "SP_EditarPaciente");
            if (FilasInsertadas == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

      
>>>>>>> Stashed changes



        public DataTable ValidarLogin(string usuario, string contrasenia)
        {
            string consulta = @"SELECT * FROM USUARIO 
                        WHERE usuario_U = @usuario AND contrasenia_U = @contrasenia";

            SqlCommand cmd = new SqlCommand(consulta);
            cmd.Parameters.AddWithValue("@usuario", usuario);
            cmd.Parameters.AddWithValue("@contrasenia", contrasenia);

            return ObtenerUsuario(usuario, contrasenia);
        }
    }
}
