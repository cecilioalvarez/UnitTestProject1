using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Negocio;

namespace UnitTestProject1.Utils
{
    internal class ProcesadorLineaTipoC : ProcesadorLinea
    {
        public override Clase Procesar(Clase clase, string linea)
        {


            if (!linea.Contains("*"))
            {

                //recogiendo el nombre del alumno
                string[] propiedadesAlumno = linea.Split(',');
                string nombre = propiedadesAlumno[0].Split(' ')[0].ToLower();
                Alumno alumno = new Alumno(nombre);
                Nota nota = new Nota(Double.Parse(propiedadesAlumno[1], CultureInfo.InvariantCulture), propiedadesAlumno[2]);

                if (clase.Alumnos.Contains(alumno))
                {

                    int posicionAlumno = clase.Alumnos.IndexOf(new Alumno(nombre, null));
                    clase.Alumnos[posicionAlumno].AddNota(nota);

                }
                else
                {
                    alumno.AddNota(nota);
                    clase.AddAlumno(alumno);
                }

            }
            return clase;

        }
    }
}
