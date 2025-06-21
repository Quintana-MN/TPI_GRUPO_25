using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDADES
{
    public class PacienteUpdate
    {
        public string nombre;
        public string email;
        public string dni;

        public PacienteUpdate(string nombre_Pac, string email_Pac, string dni_Pac)
        {
            nombre = nombre_Pac;
            email = email_Pac;
            dni=dni_Pac;

        }

    }
}
