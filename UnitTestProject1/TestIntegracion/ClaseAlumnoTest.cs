using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Negocio;
using Xunit;

namespace TestIntegracion
{
    public class ClaseAlumnoTest
    {

        [Fact]
        public void NotaMediaTest()
        {
            Nota nota1 = new Nota(5, "Matematicas");
            Nota nota2 = new Nota(7, "Ingles");
            List<Nota> notasAlumno1= new List<Nota>();
            notasAlumno1.Add(nota1);
            notasAlumno1.Add(nota2);


            Nota nota3 = new Nota(2, "Matematicas");
            Nota nota4 = new Nota(1, "Ingles");
            List<Nota> notasAlumno2 = new List<Nota>();
            notasAlumno2.Add(nota3);
            notasAlumno2.Add(nota4);


            Alumno alumno1 = new Alumno("pedro", notasAlumno1);
            Alumno alumno2 = new Alumno("ana", notasAlumno2);

            List<Alumno> alumnos = new List<Alumno>();
            alumnos.Add(alumno1);
            alumnos.Add(alumno2);

            Clase clase = new Clase("clase A",alumnos);


            Assert.Equal(3.75, clase.NotaMedia().Valor);

        }
    }
}
