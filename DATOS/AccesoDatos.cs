using ENTIDADES;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
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
      
    public DataTable ObtenerTabla(string nombreTabla, string consulta)
        {
            DataSet dataSet = new DataSet();

            using (SqlConnection conexion = ObtenerConexion())
            {
                if (conexion == null)
                    throw new Exception("No se pudo establecer la conexión a la base de datos.");

                using (SqlDataAdapter adp = ObtenerAdaptador(consulta, conexion))
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
            SqlCommand comando = new SqlCommand();
            comando = Comando;
            comando.Connection = Conexion;
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = NombreSP;
            FilasCambiadas = comando.ExecuteNonQuery();
            Conexion.Close();
            return FilasCambiadas;
        }

        public Boolean existe(String consulta)
        {
            Boolean estado = false;
            SqlConnection Conexion = ObtenerConexion();
            SqlCommand comando = new SqlCommand(consulta, Conexion);
            SqlDataReader datos = comando.ExecuteReader();
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

            SqlCommand comando = new SqlCommand(consulta, Conexion);
            comando.Parameters.AddWithValue("@usuario_U", usuario);
            comando.Parameters.AddWithValue("@contrasenia_U", contrasenia);

            SqlDataAdapter adaptador = new SqlDataAdapter(comando);
            DataTable datatable = new DataTable();
            adaptador.Fill(datatable);
            Conexion.Close();
            return datatable;
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
        public DataTable ObtenerPacientesAcceso()
        {
            using (SqlConnection conexion = ObtenerConexion())
            {
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT id_Paciente FROM PACIENTE", conexion);
                DataTable tabla = new DataTable();
                sqlDataAdapter.Fill(tabla);
                return tabla;
            }
        }

        public DataTable ObtenerMedicosPorEspecialidadAcceso(int codEspecialidad)
        {
            using (SqlConnection conexion = ObtenerConexion())
            {

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT PERSONA.nombre_P , MEDICO.legajo_M FROM MEDICO INNER JOIN PERSONA ON MEDICO.dni_M = PERSONA.dni_P WHERE MEDICO.codEspecialidad_M = @codEspecialidad", conexion);
                sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@codEspecialidad", codEspecialidad);
                DataTable tabla = new DataTable();
                sqlDataAdapter.Fill(tabla);
                return tabla;
            }
        }
        public bool VerificarHorario(string fecha, int horario, int legajo)
        {
            using (SqlConnection conexion = ObtenerConexion())
            {
                string consulta = @"SELECT COUNT(*) 
                      FROM TURNOS 
                      WHERE fecha_T = @fecha 
                        AND horario_T = @horario 
                        AND legajo_T = @legajo";

                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@fecha", DateTime.Parse(fecha));
                comando.Parameters.AddWithValue("@horario", horario);
                comando.Parameters.AddWithValue("@legajo", legajo);


                int cantidad = (int)comando.ExecuteScalar();

                return cantidad > 0; // true = ya existe ese turno
            }
        }
        public bool VerificarDNIExistente(string dni)
        {
            using (SqlConnection conexion = ObtenerConexion())
            {
                string consulta = @"SELECT COUNT(*) 
                      FROM PERSONA 
                      WHERE dni_P = @dni";
                        

                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@dni", dni);

                int cantidad = (int)comando.ExecuteScalar();

                return cantidad > 0; // true = ya existe la persona
            }
        }
        public bool VerificarUsuarioExistente(string usuario)
        {
            using (SqlConnection conexion = ObtenerConexion())
            {
                string consulta = @"SELECT COUNT(*) 
                      FROM USUARIO 
                      WHERE usuario_U = @usuario";


                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@usuario", usuario);

                int cantidad = (int)comando.ExecuteScalar();

                return cantidad > 0; // true = ya existe la persona
            }
        }
        public bool VerificarLegajoExistente(int legajo)
        {
            using (SqlConnection conexion = ObtenerConexion())
            {
                string consulta = @"SELECT COUNT(*) 
                      FROM MEDICO 
                      WHERE legajo_M = @legajo";


                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@legajo", legajo);

                int cantidad = (int)comando.ExecuteScalar();

                return cantidad > 0; // true = ya existe la persona
            }
        }

        public bool VerificarIDPacienteExistente(int idPaciente)
        {
            using (SqlConnection conexion = ObtenerConexion())
            {
                string consulta = @"SELECT COUNT(*) 
                      FROM PACIENTE 
                      WHERE id_Paciente = @idPaciente";


                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@idPaciente", idPaciente);

                int cantidad = (int)comando.ExecuteScalar();

                return cantidad > 0; // true = ya existe la persona
            }
        }
        public bool VerificarIDTurnoExistente(int idTurno)
        {
            using (SqlConnection conexion = ObtenerConexion())
            {
                string consulta = @"SELECT COUNT(*) 
                      FROM TURNOS 
                      WHERE id_Turno_T = @idTurno";


                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@idTurno", idTurno);


                int cantidad = (int)comando.ExecuteScalar();

                return cantidad > 0; // true = ya existe la persona
            }
        }
        public int InformePresente(string fechaI, string fechaF)
        {
            using (SqlConnection conexion = ObtenerConexion())
            {
                string consulta = @"SELECT COUNT(*) 
                            FROM TURNOS 
                            WHERE fecha_T BETWEEN @fechaI AND @fechaF
                              AND asistencia_T = 1";

                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@fechaI", DateTime.Parse(fechaI));
                comando.Parameters.AddWithValue("@fechaF", DateTime.Parse(fechaF));

                int cantidad = (int)comando.ExecuteScalar();

                return cantidad; 
            }
        }
        public int InformeAusente(string fechaI, string fechaF)
        {
            using (SqlConnection conexion = ObtenerConexion())
            {
                string consulta = @"SELECT COUNT(*) 
                            FROM TURNOS 
                            WHERE fecha_T BETWEEN @fechaI AND @fechaF
                              AND asistencia_T = 0";

                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@fechaI", DateTime.Parse(fechaI));
                comando.Parameters.AddWithValue("@fechaF", DateTime.Parse(fechaF));

                int cantidad = (int)comando.ExecuteScalar();

                return cantidad;
            }
        }
        public int InformeCardiologia(string fechaI, string fechaF)
        {
            using (SqlConnection conexion = ObtenerConexion())
            {
                string consulta = @"SELECT COUNT(*) 
                            FROM TURNOS 
                            INNER JOIN MEDICO ON TURNOS.legajo_T = MEDICO.legajo_M
                            WHERE codEspecialidad_M = 3
                              AND fecha_T BETWEEN @fechaI AND @fechaF";

                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@fechaI", DateTime.Parse(fechaI));
                comando.Parameters.AddWithValue("@fechaF", DateTime.Parse(fechaF));

               

                int cantidad = (int)comando.ExecuteScalar();

                return cantidad;
            }
        }

        public int InformePediatría(string fechaI, string fechaF)
        {
            using (SqlConnection conexion = ObtenerConexion())
            {
                string consulta = @"SELECT COUNT(*) 
                            FROM TURNOS 
                            INNER JOIN MEDICO ON TURNOS.legajo_T = MEDICO.legajo_M
                            WHERE codEspecialidad_M = 2
                              AND fecha_T BETWEEN @fechaI AND @fechaF";

                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@fechaI", DateTime.Parse(fechaI));
                comando.Parameters.AddWithValue("@fechaF", DateTime.Parse(fechaF));       

                int cantidad = (int)comando.ExecuteScalar();

                return cantidad;
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
                comando.Parameters.AddWithValue("@fechaNac_P", DateTime.Parse(medico.GetPersona().getFechaNacimiento()));
                comando.Parameters.AddWithValue("@direccion_P", medico.GetPersona().getDireccion());
                comando.Parameters.AddWithValue("@email_P", medico.GetPersona().getEmail());
                comando.Parameters.AddWithValue("@telefono_P", medico.GetPersona().getTelefono());
                comando.Parameters.AddWithValue("@idLocalidad_P", medico.GetPersona().getIdLocalidad());
                comando.Parameters.AddWithValue("@idProvincia_P", medico.GetPersona().getIdProvincia());

                comando.Parameters.AddWithValue("@usuario_U", medico.GetUsuario().getNombreUsuario());
                comando.Parameters.AddWithValue("@contrasenia_U", medico.GetUsuario().getContraseniaUsuario());

                comando.Parameters.AddWithValue("@legajo_M", medico.GetMedico().GetLegajo_M());
                comando.Parameters.AddWithValue("@codEspecialidad_M", medico.GetMedico().GetEspecialidad_M());

                comando.ExecuteNonQuery();
            }
        }
        public void AltaPaciente(PacienteCompleto paciente)
        {
            using (SqlConnection conexion = ObtenerConexion())
            {
                SqlCommand comando = new SqlCommand("SP_AltaPaciente", conexion);
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@dni_Pac", paciente.GetPersona().getDni());
                comando.Parameters.AddWithValue("@nombre_Pac", paciente.GetPersona().getNombre());
                comando.Parameters.AddWithValue("@apellido_Pac", paciente.GetPersona().getApellido());
                comando.Parameters.AddWithValue("@sexo_Pac", paciente.GetPersona().getSexo());
                comando.Parameters.AddWithValue("@nacionalidad_Pac", paciente.GetPersona().getNacionalidad());
                comando.Parameters.AddWithValue("@fechaNac_Pac", DateTime.Parse(paciente.GetPersona().getFechaNacimiento()).Date);
                comando.Parameters.AddWithValue("@direccion_Pac", paciente.GetPersona().getDireccion());
                comando.Parameters.AddWithValue("@email_Pac", paciente.GetPersona().getEmail());
                comando.Parameters.AddWithValue("@telefono_Pac", paciente.GetPersona().getTelefono());
                comando.Parameters.AddWithValue("@idLocalidad_Pac", paciente.GetPersona().getIdLocalidad());
                comando.Parameters.AddWithValue("@idProvincia_Pac", paciente.GetPersona().getIdProvincia());

                comando.Parameters.AddWithValue("@idPaciente_Pac", paciente.GetIdPaciente());
                

                comando.ExecuteNonQuery();
            }
        }

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
        public void AltaTurno(Turno turno)
        {
            using (SqlConnection conexion = ObtenerConexion())
            {
                SqlCommand comando = new SqlCommand("SP_AltaTurno", conexion);
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@id_Turno_T", turno.GetIdTurno());
                comando.Parameters.AddWithValue("@id_Paciente_T", turno.GetIdPaciente());
                comando.Parameters.AddWithValue("@fecha_T", DateTime.Parse(turno.GetFecha()).Date);
                comando.Parameters.AddWithValue("@horario_T", turno.GetHorario());
                comando.Parameters.AddWithValue("@legajo_T", turno.GetLegajo());

                comando.ExecuteNonQuery();
            }
        }
        public void ActualizarTurno(int idTurno, int estado, string observacion)
        {
            using (SqlConnection conexion = ObtenerConexion())
            {
                SqlCommand comando = new SqlCommand("SP_ActualizarTurno", conexion);
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@idTurno", idTurno);
                comando.Parameters.AddWithValue("@estado", estado);
                comando.Parameters.AddWithValue("@observacion", observacion);


                comando.ExecuteNonQuery();
            }
        }
        public DataTable GetTurnosPorMedico(int legajo)
        {
            using (SqlConnection conexion = ObtenerConexion())
            {
                SqlCommand comando = new SqlCommand("SP_GetTurnosPorMedico", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@legajo_M", legajo);

                SqlDataAdapter adapter = new SqlDataAdapter(comando);
                DataTable tabla = new DataTable();
                adapter.Fill(tabla);
                return tabla;
            }
        }

        public int ObtenerLegajoPorUsuario(string usuario)
        {
            int legajo = 0;
            string consulta = "SELECT legajo_M FROM MEDICO WHERE usuario_M = @usuario";

            using (SqlConnection conexion = ObtenerConexion())
            {
                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@usuario", usuario);

                    if (comando.ExecuteScalar() != null)
                    {
                        legajo = Convert.ToInt32(comando.ExecuteScalar());
                    }
                }
            return legajo;
        }

        public DataTable ObtenerTablaConParametros(SqlCommand comando, string nombreTabla)
        {
            DataSet dataSet = new DataSet();

            using (SqlConnection conexion = ObtenerConexion())
            {
                comando.Connection = conexion;
                using (SqlDataAdapter adapter = new SqlDataAdapter(comando))
                {
                    adapter.Fill(dataSet, nombreTabla);
                }
            }

            return dataSet.Tables[nombreTabla];
        }
        
        public DataTable BuscarTurnosPorNombre(int legajo, string nombrePaciente)
        {
            using (SqlConnection conexion = ObtenerConexion())
            {
                using (SqlCommand comando = new SqlCommand("SP_BuscarTurnosPorNombre", conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@legajo_M", legajo);
                    comando.Parameters.AddWithValue("@nombrePaciente", nombrePaciente ?? "");

                    SqlDataAdapter adapter = new SqlDataAdapter(comando);
                    DataTable tabla = new DataTable();
                    adapter.Fill(tabla);
                    return tabla;
                }
            }
        }
        public DataTable BuscarTurnosConFiltro(int legajo, string nombrePaciente, bool filtroManana, bool filtroTarde)
        {
            DataTable table = new DataTable();

                using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                {
                    using (SqlCommand comando = new SqlCommand("SP_BuscarTurnosFiltrados", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.AddWithValue("@legajo", legajo);
                        comando.Parameters.AddWithValue("@nombrePaciente", nombrePaciente ?? "");
                        comando.Parameters.AddWithValue("@filtroMañana", filtroManana ? 1 : 0);
                        comando.Parameters.AddWithValue("@filtroTarde", filtroTarde ? 1 : 0);

                        SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                        adaptador.Fill(table);
                    }
                }

            return table;
        }

        public DataTable ValidarLogin(string usuario, string contrasenia)
        {
            string consulta = @"SELECT * FROM USUARIO 
                        WHERE usuario_U = @usuario AND contrasenia_U = @contrasenia";

            SqlCommand comando = new SqlCommand(consulta);
            comando.Parameters.AddWithValue("@usuario", usuario);
            comando.Parameters.AddWithValue("@contrasenia", contrasenia);

            return ObtenerUsuario(usuario, contrasenia);
        }
    }
}
