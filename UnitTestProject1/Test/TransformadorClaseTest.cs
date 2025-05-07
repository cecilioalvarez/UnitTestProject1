using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Negocio;
using UnitTestProject1.Utils;
using Xunit;
using Xunit.Sdk;

namespace UnitTestProject1.Test
{
    public class TransformadorClaseTest
    {


     
        [Fact]
        public void UsaLectorFicheroTest()
        {

            //objeto mock es una simulacion del objeto real
            // pero esta simulacion debe cumplir al menos con lo que la prueba unitaria
            // solicita
            var lector = new Mock<LectorFichero>();
            lector.Setup(x => x.Lineas()).Returns(new List<string>());

            // si es un objeto real

            TransformadorClase transformador = new TransformadorClase(lector.Object);

            //llamamos al metodo obtener clase el va a ejecutarlo
            transformador.ObtenerClase();

            lector.Verify(x => x.Lineas(), Times.Once);

        }

        // es mas una prueba de integracion que una prueba unitaria

        // ya que usa dos clases diferentes usa por un lado el lector y
        //usa por otro lado el transformador
        // se sigue la idea
        
        [Fact]
        public void CargarClaseConAlumnosYNotasTest()
        {

            // sino otro tipo de prueba

            //LectorFichero lector = new LectorFichero("../../datos/clase.txt");
            string[] lineasMock = new string[]
            {
                "*****************",
                "antonio,matematicas,7.5",
                "antonio,lengua,8",
                "-----------------",
                "gema,matematicas,5",
                "gema,lengua,9",
                "*****************"

            };

            var lector = new Mock<LectorFichero>();
            lector.Setup(x => x.Lineas()).Returns(lineasMock.ToList());





            TransformadorClase transformador = new TransformadorClase(lector.Object);

            Clase clase=transformador.ObtenerClase();
            IList<Alumno> listaAlumnos = clase.Alumnos;
            Alumno alumno1 = listaAlumnos[0];
            Alumno alumno2 = listaAlumnos[1];

            IList<Nota> notasAlumno1 = alumno1.Notas;
            IList<Nota> notasAlumno2 = alumno2.Notas;

            Assert.NotNull(clase);
            Assert.NotNull(listaAlumnos);

            Assert.Equal("antonio", alumno1.Nombre);
            Assert.Equal("gema", alumno2.Nombre);

            Assert.Equal("matematicas", notasAlumno1[0].Asignatura);
            Assert.Equal("lengua", notasAlumno1[1].Asignatura);


            Assert.Equal("matematicas", notasAlumno2[0].Asignatura);
            Assert.Equal("lengua", notasAlumno2[1].Asignatura);

        }

    

       [Fact]
        public void CargarClaseConAlumnosYNotasTest2Integracion()
        {

            // sino otro tipo de prueba

            LectorFichero lector = new LectorFichero("../../datos/clase.txt");
          
            TransformadorClase transformador = new TransformadorClase(lector);

            Clase clase = transformador.ObtenerClase();
            IList<Alumno> listaAlumnos = clase.Alumnos;
            Alumno alumno1 = listaAlumnos[0];
            Alumno alumno2 = listaAlumnos[1];

            IList<Nota> notasAlumno1 = alumno1.Notas;
            IList<Nota> notasAlumno2 = alumno2.Notas;

            Assert.NotNull(clase);
            Assert.NotNull(listaAlumnos);

            Assert.Equal("antonio", alumno1.Nombre);
            Assert.Equal("gema", alumno2.Nombre);

            Assert.Equal("matematicas", notasAlumno1[0].Asignatura);
            Assert.Equal("lengua", notasAlumno1[1].Asignatura);


            Assert.Equal("matematicas", notasAlumno2[0].Asignatura);
            Assert.Equal("lengua", notasAlumno2[1].Asignatura);

        }

    }

}
