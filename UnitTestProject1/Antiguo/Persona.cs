using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1.Negocio
{
    public class Persona
    {

        public string Nombre { get; set; }
        public int Edad { get; set; }

        public bool EstaJubilado()
        {

            if (Edad >=67)
            {
                return true;
            }else return false;
        }

        public bool EsMayorEdad()
        {

            if (Edad >= 18)
            {
                return true;
            }
            else return false;
        }

        public Persona(string nombre, int edad)
        {
            Edad = edad;
            Nombre = nombre;
        }
    }
}
