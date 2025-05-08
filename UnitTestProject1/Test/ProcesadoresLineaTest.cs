using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Negocio;
using UnitTestProject1.Utils;
using Xunit;

namespace UnitTestProject1.Test
{
    public  class ProcesadoresLineaTest
    {

        [Fact]
        public void ProcesarLineaTipoATest ()
        {

            //arrange 

            string linea = "antonio,matematicas,7.5";
            ProcesadorLinea procesadorLinea = new ProcesadorLineaTipoA();
            Clase clase = new Clase("mi clase");

            procesadorLinea.Procesar(clase, linea);

            IList<Alumno> listaAlumnos = clase.Alumnos;
            Alumno alumno1 = listaAlumnos[0];
          

            IList<Nota> notasAlumno1 = alumno1.Notas;
         

            Assert.NotNull(clase);
            Assert.NotNull(listaAlumnos);
            Assert.Equal("antonio", alumno1.Nombre);
            Assert.Equal("matematicas", notasAlumno1[0].Asignatura);
            Assert.Equal(7.5, notasAlumno1[0].Valor);





        }

        [Fact]
        public void ProcesarLineaTipoBTest()
        {

            //arrange 

            string linea = "gema,5,matematicas";
            ProcesadorLinea procesadorLinea = new ProcesadorLineaTipoB();
            Clase clase = new Clase("mi clase");

            procesadorLinea.Procesar(clase, linea);

            IList<Alumno> listaAlumnos = clase.Alumnos;
            Alumno alumno1 = listaAlumnos[0];


            IList<Nota> notasAlumno1 = alumno1.Notas;


            Assert.NotNull(clase);
            Assert.NotNull(listaAlumnos);
            Assert.Equal("gema", alumno1.Nombre);
            Assert.Equal("matematicas", notasAlumno1[0].Asignatura);
            Assert.Equal(5, notasAlumno1[0].Valor);





        }


        [Fact]
        public void ProcesarLineaTipoCTest()
        {

            //arrange 

            string linea = "ANTONIO GOMEZ,7.5,matematicas";
            ProcesadorLinea procesadorLinea = new ProcesadorLineaTipoC();
            Clase clase = new Clase("mi clase");

            procesadorLinea.Procesar(clase, linea);

            IList<Alumno> listaAlumnos = clase.Alumnos;
            Alumno alumno1 = listaAlumnos[0];


            IList<Nota> notasAlumno1 = alumno1.Notas;


            Assert.NotNull(clase);
            Assert.NotNull(listaAlumnos);
            Assert.Equal("antonio", alumno1.Nombre);
            Assert.Equal("matematicas", notasAlumno1[0].Asignatura);
            Assert.Equal(7.5, notasAlumno1[0].Valor);





        }


    }
}
