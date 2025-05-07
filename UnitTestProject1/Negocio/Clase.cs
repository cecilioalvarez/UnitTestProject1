using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Negocio;

namespace Negocio
{
    public class Clase
    {
        public string Nombre { get; set; }
        public IList<Alumno> Alumnos { get; set; } = new List<Alumno>();

        public void AddAlumno (Alumno alumno)
        {

            Alumnos.Add (alumno);
        }

        public void RemoveAlumno(Alumno alumno)
        {
            Alumnos.Remove (alumno);

        }
        public Clase(string nombre ,IList<Alumno> alumnos) {
        
            Nombre= nombre;
            Alumnos = alumnos;
        }


        public Clase(string nombre)
        {

            Nombre = nombre;
           
        }

        public Nota NotaMedia()
        {

            double notaMedia = 0;

            foreach (var alumno in Alumnos)
            {

                notaMedia+=alumno.NotaMedia().Valor;

            }
            notaMedia=notaMedia/Alumnos.Count();
            return new Nota(notaMedia, "media de la clase");

        }

        public Nota NotaMayor()
        {

            Nota notaMayor = Alumnos[0].NotaMayor();

            foreach (var alumno in Alumnos)
            {

                if (notaMayor.EsMayor(alumno.NotaMayor())==-1) {


                    notaMayor = alumno.NotaMayor();
                }
              

            }
            return notaMayor;
          

        }
    }
}
