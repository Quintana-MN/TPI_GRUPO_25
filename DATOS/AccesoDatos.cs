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
    }
}
