using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDADES
{
    public class Turno
    {
        public int id_Turno_T;
        public int id_Paciente_T;
        public string fecha_T;
        public int horario_T;
        public string dni_T;
        public int legajo_T;


        public Turno() { }


        public Turno(int idTurno, int idPaciente, string fecha, int horario, string dni, int legajo)
        {
            id_Turno_T = idTurno;
            id_Paciente_T = idPaciente;
            fecha_T = fecha;
            dni_T = dni;
            legajo_T = legajo;
            horario_T = horario;

        }
        public int GetHorario()
        {
            return horario_T;
        }
        public int GetIdTurno()
        {
            return id_Turno_T;
        }

        public void SetIdTurno(int turno)
        {
            id_Turno_T = turno;
        }

        public int GetIdPaciente()
        {
            return id_Paciente_T;
        }

        public void SetIdPaciente(int idPaciente)
        {
            id_Paciente_T = idPaciente;
        }

        public string GetFecha()
        {
            return fecha_T;
        }

        public void SetFecha(string fecha)
        {
            fecha_T = fecha;
        }
        public void SetHorario(int horario)
        {
            horario_T = horario;
        }


        public string GetDni()
        {
            return dni_T;
        }

        public void SetDni(string dni)
        {
            dni_T = dni;
        }

        public int GetLegajo()
        {
            return legajo_T;
        }

        public void SetLegajo(int legajo)
        {
            legajo_T = legajo;
        }
    }

}

