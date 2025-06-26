using DATOS;
using ENTIDADES;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class NegocioUsuario
{
    public Usuario login(string nombreUsuario, string contrasena)
    {
        DaoUsuario dao = new DaoUsuario();
        return dao.validarUsuario(nombreUsuario, contrasena);
    }

    public DataTable getMedicos()
    {
        DATOS.DaoUsuario dao = new DATOS.DaoUsuario();
        return dao.getTablaMedicos();
    }
    public DataTable getPacientes()
    {
        DATOS.DaoUsuario dao = new DATOS.DaoUsuario();
        return dao.getTablaPaciente();
    }
    public void BajaMedico(int legajo)
    {
        AccesoDatos datos = new AccesoDatos();
        datos.BajaLogicaMedico(legajo);
    }
    public void BajaPaciente(int idPaciente)
    {
        AccesoDatos datos = new AccesoDatos();
        datos.BajaLogicaPaciente(idPaciente);
    }
    public void EditarMedico(Medico medico)
    {
        AccesoDatos datos = new AccesoDatos();
        datos.ActualizarMedico(medico);
    }

    public void AgregarMedico(MedicoCompleto medico)
    {
        AccesoDatos datos = new AccesoDatos();
        datos.AltaMedico(medico);
    }

    public void AgregarPaciente(PacienteCompleto paciente)
    {
        AccesoDatos datos = new AccesoDatos();
        datos.AltaPaciente(paciente);
    }

    public void EditarPaciente(PacienteUpdate pacienteUpdate)
    {
        AccesoDatos datos = new AccesoDatos();
        datos.ActualizarPaciente(pacienteUpdate);

    }
    public DataTable ValidarLogin(string usuario, string contrasenia)
    {
        AccesoDatos datos = new AccesoDatos();
        return datos.ObtenerUsuario(usuario, contrasenia);
    }

    public DataTable ObtenerEspecialidad()
    {
        AccesoDatos datos = new AccesoDatos();
        return datos.ObtenerEspecialidades();
    }
    public DataTable ObtenerProvincias()
    {
        AccesoDatos datos = new AccesoDatos();
        return datos.ObtenerProvincias();
    }
    public DataTable ObtenerLocalidadesPorProvincia(int idProvincia)
    {
        AccesoDatos datos = new AccesoDatos();
        return datos.ObtenerLocalidadesPorProvincia(idProvincia);
    }
    public DataTable ObtenerTurnosPorPaciente()
    {
        DaoUsuario dao = new DaoUsuario();
        return dao.getTurnos();
    }
    public DataTable ObtenerTurnosPorMedico(int legajo)
    {
        AccesoDatos datos = new AccesoDatos();
        return datos.GetTurnosPorMedico(legajo);
    }
    public int ObtenerLegajoPorUsuario(string usuario)
    {
        DATOS.AccesoDatos datos = new DATOS.AccesoDatos();
        return datos.ObtenerLegajoPorUsuario(usuario);
    }

    public void ActualizarTurno(int idTurno, bool estado, string observacion)
    {
        AccesoDatos datos = new AccesoDatos();
        datos.ActualizarTurno(idTurno, estado, observacion);
    }
    public DataTable BuscarTurnosXNombre(int legajo, string nombrePaciente)
    {
        AccesoDatos accesoDatos = new AccesoDatos();
        return accesoDatos.BuscarTurnosPorNombre(legajo, nombrePaciente);
    }
    public DataTable ObtenerPacientes()
    {
        AccesoDatos datos = new AccesoDatos();
        return datos.ObtenerPacientesAcceso();
    }
    public DataTable ObtenerMedicos(int especialidad)
    {
        AccesoDatos datos = new AccesoDatos();
        return datos.ObtenerMedicosPorEspecialidadAcceso(especialidad);
    }

    public bool VerificacionHorarios(string fecha, int horario, int legajo)
    {
        AccesoDatos datos = new AccesoDatos();
        if (datos.VerificarHorario(fecha, horario, legajo))
        {
            return true;
        }
        else { return false; }
    }
    public void AgregarTurno(Turno turno)
    {
        AccesoDatos datos = new AccesoDatos();
        datos.AltaTurno(turno);
    }
}

