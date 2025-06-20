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
    public void BajaMedico(int legajo)
    {
        AccesoDatos datos = new AccesoDatos();
        datos.BajaLogicaMedico(legajo);
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
}

