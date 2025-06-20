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
