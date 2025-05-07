using System;
using System.Collections.Generic;
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

            lineas.RemoveAt(0);
            lineas.RemoveAt(lineas.Count() - 1);

            Clase clase = new Clase("mi clase", new List<Alumno>());

            foreach (string linea in lineas)
            {

                if (!linea.Contains("-")){

                    //recogiendo el nombre del alumno
                    string[] textos = linea.Split(',');

                    Alumno alumno = new Alumno(textos[0], new List<Nota>());
                    if (!clase.Alumnos.Contains(alumno))
                    {
                        Nota nota = new Nota(Double.Parse(textos[2]), textos[1]);
                        alumno.AddNota(nota);
                        clase.AddAlumno(alumno);
                        Console.Write("valor" + textos[2]);
                        Console.Write("asignatura" + textos[1]);

                    }
                    else
                    {
                       int posicion= clase.Alumnos.IndexOf(new Alumno(textos[0],null));
                        Console.Write("valor" + textos[2]);
                        Console.Write("asignatura" + textos[1]);
                        Nota nota = new Nota(Double.Parse(textos[2]), textos[1]);
                       clase.Alumnos[posicion].AddNota(nota);
                    }
                  
                }
               
            }

            return clase;
        }
    }
}
