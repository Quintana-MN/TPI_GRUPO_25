using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDADES
{
    public class Medico
    {
        public int legajo_M;
        public String usuario_M;
        public int especialidad_M;
        public String dni_M;
        public String usuarioAntiguo;
        public String contrasenia_M;

        public Medico(int legajo_m, string usuario_m, string contrasenia_m, int especialidad_m, string dni_m, string usuarioantiguo)
        {
            legajo_M = legajo_m;
            usuario_M = usuario_m;
            especialidad_M = especialidad_m;
            dni_M = dni_m;
            usuarioAntiguo = usuarioantiguo;
            contrasenia_M = contrasenia_m;
        }

        public int GetLegajo_M()
        {
            return legajo_M;
        }

        public void SetLegajo_M(int legajo_m)
        {
            legajo_M = legajo_m;
        }

        public string GetUsuario_M()
        {
            return usuario_M;
        }

        public void SetUsuario_M(string usuario_m)
        {
            usuario_M = usuario_m;
        }

        public int GetEspecialidad_M()
        {
            return especialidad_M;
        }

        public void SetEspecialidad_M(int especialidad_m)
        {
            especialidad_M = especialidad_m;
        }

        public string GetDni_M()
        {
            return dni_M;
        }

        public void SetDni_M(string dni_m)
        {
            dni_M = dni_m;
        }
        public string GetContrasenia_M() { return contrasenia_M; }
        public void SetContrasenia_M(string contrasenia_m) { contrasenia_M = contrasenia_m; }
    }
}
