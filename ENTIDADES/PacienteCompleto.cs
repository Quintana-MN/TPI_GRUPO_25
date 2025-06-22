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
        public int IdTurno;

        // Constructor

        public PacienteCompleto()
        {
        
        }
        public PacienteCompleto(Persona persona, int idPaciente, int idTurno)
        {
            Persona = persona;
            IdPaciente = idPaciente;
            IdTurno = idTurno;
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

        public int GetIdTurno()
        {
            return IdTurno;
        }

        public void SetIdTurno(int idTurno)
        {
            IdTurno = idTurno;
        }
    }
}