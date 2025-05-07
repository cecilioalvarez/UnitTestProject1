using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Negocio;

namespace UnitTestProject1.Utils
{
    public class TransformadorClase
    {
        LectorFichero LectorFichero { get; set; }

        public TransformadorClase(LectorFichero lectorFichero) {

            LectorFichero = lectorFichero;
        
        }

        public virtual Clase ObtenerClase()
        {
            //lo he construido a traves de lo que las pruebas unitarias me han orientado

            IList<string> lineas = LectorFichero.Lineas();

            EliminarCabeceraPie(lineas);

            Clase clase = new Clase("mi clase");

            foreach (string linea in lineas)
            {

                if (!linea.Contains("-")){

                    //recogiendo el nombre del alumno
                    string[] propiedadesAlumno = linea.Split(',');
                    Alumno alumno = new Alumno(propiedadesAlumno[0]);
                    Nota nota = new Nota(Double.Parse(propiedadesAlumno[2], CultureInfo.InvariantCulture), propiedadesAlumno[1]);

                    if (clase.Alumnos.Contains(alumno))
                    {

                        int posicionAlumno = clase.Alumnos.IndexOf(new Alumno(propiedadesAlumno[0], null));
                        clase.Alumnos[posicionAlumno].AddNota(nota);
                    
                    }
                    else
                    {
                        alumno.AddNota(nota);
                        clase.AddAlumno(alumno);
                    }
                  
                }
               
            }

            return clase;
        }

        private void EliminarCabeceraPie(IList<string> lineas)
        {
            if (lineas.Count != 0)
            {
                lineas.RemoveAt(0);
                lineas.RemoveAt(lineas.Count() - 1);
            }

        }
    }
}
