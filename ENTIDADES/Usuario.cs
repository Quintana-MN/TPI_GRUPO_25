using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDADES
{
    public class Usuario
    {
        private String contraseniaUsuario;
        private string nombreUsuario;
        private bool tipoUsuario;

        public void setContraseniaUsuario(string contrasenia) { contraseniaUsuario = contrasenia; }
        public string getContraseniaUsuario() { return contraseniaUsuario; }

        public void setNombreUsuario(string nombre) { nombreUsuario = nombre; }
        public void setTipoUsuario(bool tipo) { tipoUsuario = tipo; }

        public string getNombreUsuario() { return nombreUsuario; }
        public bool getTipoUsuario() { return tipoUsuario; }
    }
}
