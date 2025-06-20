using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDADES
{
    public class Persona
    {
        private String dni;
        private int idLocalidad;
        private int idProvincia;
        private String nombre;
        private String apellido;
        private int sexo;
        private String nacionalidad;
        private String fechaNacimiento;
        private String direccion;
        private String email;
        private String telefono;

        public String getDni()
        {
            return dni;
        }

        public void setDni(String DNI)
        {
            dni = DNI;
        }

        public int getIdLocalidad()
        {
            return idLocalidad;
        }

        public void setIdLocalidad(int IdLocalidad)
        {
            idLocalidad = IdLocalidad;
        }

        public int getIdProvincia()
        {
            return idProvincia;
        }

        public void setIdProvincia(int IdProvincia)
        {
            idProvincia = IdProvincia;
        }

        public String getNombre()
        {
            return nombre;
        }

        public void setNombre(String Nombre)
        {
            nombre = Nombre;
        }

        public String getApellido()
        {
            return apellido;
        }

        public void setApellido(String Apellido)
        {
            apellido = Apellido;
        }

        public int getSexo()
        {
            return sexo;
        }

        public void setSexo(int Sexo)
        {
            sexo = Sexo;
        }

        public String getNacionalidad()
        {
            return nacionalidad;
        }

        public void setNacionalidad(String Nacionalidad)
        {
            nacionalidad = Nacionalidad;
        }

        public String getFechaNacimiento()
        {
            return fechaNacimiento;
        }

        public void setFechaNacimiento(String FechaNacimiento)
        {
            fechaNacimiento = FechaNacimiento;
        }

        public String getDireccion()
        {
            return direccion;
        }

        public void setDireccion(String Direccion)
        {
            direccion = Direccion;
        }

        public String getEmail()
        {
            return email;
        }

        public void setEmail(String Email)
        {
            email = Email;
        }

        public String getTelefono()
        {
            return telefono;
        }

        public void setTelefono(String Telefono)
        {
            telefono = Telefono;
        }
    }


}
