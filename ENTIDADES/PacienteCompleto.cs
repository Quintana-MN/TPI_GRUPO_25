using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDADES
{
    public class PacienteCompleto
    {
        // Atributos
        private Persona Persona;
        public int IdPaciente;

        // Constructor

        public PacienteCompleto()
        {

        }
        public PacienteCompleto(Persona persona, int idPaciente)
        {
            Persona = persona;
            IdPaciente = idPaciente;
        }

        // Getters y Setters
        public Persona GetPersona()
        {
            return Persona;
        }

        public void SetPersona(Persona persona)
        {
            Persona = persona;
        }

        public int GetIdPaciente()
        {
            return IdPaciente;
        }

        public void SetIdPaciente(int idPaciente)
        {
            IdPaciente = idPaciente;
        }
    }
}
