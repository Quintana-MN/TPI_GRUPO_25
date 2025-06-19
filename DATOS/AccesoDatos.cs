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
    public class AccesoDatos
    {
        private const string cadenaConexion = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=clinicaTUP;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

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
                return null;
            }
        }

        private SqlDataAdapter ObtenerAdaptador(String consultaSql, SqlConnection conexion)
        {
            SqlDataAdapter adaptador;
            try
            {
                adaptador = new SqlDataAdapter(consultaSql, conexion);
                return adaptador;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataTable ObtenerTabla(String NombreTabla, String Sql)
        {
            DataSet dataSet = new DataSet();
            SqlConnection Conexion = ObtenerConexion();
            SqlDataAdapter adp = ObtenerAdaptador(Sql, Conexion);
            adp.Fill(dataSet, NombreTabla);
            Conexion.Close();
            return dataSet.Tables[NombreTabla];
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
        public bool EdicionMedico(Medico medico, string usuarioAntiguo)
        {
            using (SqlConnection conexion = ObtenerConexion())
            using (SqlCommand comando = new SqlCommand("SP_EditarMedicoUsuario", conexion))
            {
                comando.CommandType = CommandType.StoredProcedure;

                SqlParameter parametro;

                parametro = comando.Parameters.Add("@usuarioAntiguo", SqlDbType.Char, 30);
                parametro.Value = usuarioAntiguo;

                parametro = comando.Parameters.Add("@nuevoUsuario", SqlDbType.Char, 30);
                parametro.Value = medico.usuario_M;

                parametro = comando.Parameters.Add("@nuevaContrasenia", SqlDbType.VarChar, 100);
                parametro.Value = medico.contrasenia_M;

                parametro = comando.Parameters.Add("@dni_M", SqlDbType.NChar, 9);
                parametro.Value = medico.dni_M;

                parametro = comando.Parameters.Add("@codEspecialidad_M", SqlDbType.Int);
                parametro.Value = medico.especialidad_M;

                int filasAfectadas = comando.ExecuteNonQuery();

                return filasAfectadas > 0;
            }
        }


        private void ArmarParametrosLibros(ref SqlCommand Comando, Medico medico)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@legajo_M", SqlDbType.Int);
            SqlParametros.Value = medico.legajo_M;
            SqlParametros = Comando.Parameters.Add("@usuario_M", SqlDbType.Char, 30);
            SqlParametros.Value = medico.usuario_M;
            SqlParametros = Comando.Parameters.Add("@especialidad_M", SqlDbType.VarChar, 50);
            SqlParametros.Value = medico.especialidad_M;
            SqlParametros = Comando.Parameters.Add("@dni_M", SqlDbType.NChar, 9);
            SqlParametros.Value = medico.dni_M;
        }
        public bool ActualizarMedico(Medico medico)
        {
            SqlCommand sqlCommand = new SqlCommand();
            ArmarParametrosLibros(ref sqlCommand, medico);
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
