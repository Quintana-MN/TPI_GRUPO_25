using DATOS;
using ENTIDADES;
using System;
using System.Collections.Generic;
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
}
