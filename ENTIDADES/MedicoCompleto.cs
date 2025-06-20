using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDADES
{
        public class MedicoCompleto
        {
            private Medico medico;
            private Persona persona;
            private Usuario usuario;

            public MedicoCompleto()
            {
                medico = new Medico(0, "", "", 0, "");
                persona = new Persona();
                usuario = new Usuario();
            }

            public Medico GetMedico()
            {
                return medico;
            }

            public void SetMedico(Medico m)
            {
                medico = m;
            }

            public Persona GetPersona()
            {
                return persona;
            }

            public void SetPersona(Persona p)
            {
                persona = p;
            }

            public Usuario GetUsuario()
            {
                return usuario;
            }

            public void SetUsuario(Usuario u)
            {
                usuario = u;
            }
        }
    }
