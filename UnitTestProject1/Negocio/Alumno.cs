using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Alumno
    {

        public string Nombre { get; set; }

        public List<Nota> Notas { get; set; } = new List<Nota>();


        public Alumno()
        {

        }

        public Alumno(string nombre, List<Nota> notas)
        {

            Nombre = nombre;
            Notas = notas;
        }
        public void  AddNota(Nota nota)
        {

            Notas.Add(nota);
        }

        public void RemoveNota(Nota nota)
        {
            Notas.Remove(nota);
        }

        public virtual Nota NotaMayor()
        {
           
            // que comparar la nota que esta en la posicion inicial
         Nota notaMayor = Notas[0];

          for (int i=1;i<Notas.Count;i++)
            {
                if (notaMayor.EsMayor(Notas[i]) == -1)
                {

                    notaMayor = Notas[i];
                }

            }
            return notaMayor;

        }


        public virtual Nota NotaMedia()
        {
            double media = 0;
            Nota notaMedia = new Nota();
            foreach (Nota nota in Notas)
            {

                media = media += nota.Valor;
               
            }
            media = media / Notas.Count;


            notaMedia.Valor = media;
            notaMedia.Asignatura = "media del curso";
            return notaMedia;

        }

        public int  NotasAprobadas()
        {
            int aprobados = 0;

            foreach (Nota nota in Notas)
            {

                if (nota.Valor >=  5)
                {
                    aprobados++;
                }

            }
            return aprobados;

        }

        public int NotasSuspensas()
        {
            int suspensas = 0;

            foreach (Nota nota in Notas)
            {

                if (nota.Valor < 5)
                {
                    suspensas++;
                }

            }
            return suspensas;

        }

      
        public override bool Equals(object obj)
          {
                if (ReferenceEquals(this, obj)) return true;
                if (obj is null || this.GetType() != obj.GetType()) return false;

                Alumno otro = (Alumno)obj;
                return string.Equals(Nombre, otro.Nombre);
            }

            public override int GetHashCode()
            {
                return Nombre != null ? Nombre.GetHashCode() : 0;
            }
       

    }
}
