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


        //esta prueba unitaria nos ayuda a ver que la relacion entre ambos conceptos es correcta
        /*
        [Fact]
        public void UsaLectorFicheroTest()
        {
            var lector = new Mock<LectorFichero>();
            lector.Setup(x => x.Lineas()).Returns(new List<string>());

            TransformadorClase transformador = new TransformadorClase(lector.Object);

            // que este metodo de la clase lector se ejecuta
            // se invoca
           

            transformador.ObtenerClase();

            lector.Verify(x => x.Lineas(), Times.Once);

        }
        ^*/
        [Fact]
        public void CargarClaseConAlumnosYNotasTest()
        {

            LectorFichero lector = new LectorFichero("../../datos/clase.txt");
            TransformadorClase transformador = new TransformadorClase(lector);

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




            /*
            Assert.Equal(2,listaAlumnos.Count);
            Assert.Equal(2,alumno1.Notas.Count);
            Assert.Equal(2, alumno2.Notas.Count);
            */
        }

    }

}
