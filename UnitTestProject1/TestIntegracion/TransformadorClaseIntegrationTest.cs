using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Negocio;
using UnitTestProject1.Test.Negocio;
using UnitTestProject1.Utils;
using Xunit;

namespace UnitTestProject1.TestIntegracion
{
    public class TransformadorClaseIntegrationTest
    {


        [Fact]
        public void CargarClaseConAlumnosYNotasTipoBTest()
        {
            //leo el fichero 

            LectorFichero lector = new LectorFichero("../../datos/clase2.txt");
            Documento documento = new Documento(lector.Lineas());
            ProcesadorLinea procesadorLinea= ProcesadorLinea.CrearProcesador(documento.Cabecera());
            TransformadorClase transformador = new TransformadorClase(documento, procesadorLinea);

            Clase clase = transformador.ObtenerClase();
          
            AssertClaseHelper(clase);

        }

        [Fact]
        public void CargarClaseConAlumnosYNotasTipoCTest()
        {

            LectorFichero lector = new LectorFichero("../../datos/clase3.txt");

            Documento documento = new Documento(lector.Lineas());
            ProcesadorLinea procesadorLinea = ProcesadorLinea.CrearProcesador(documento.Cabecera());
            TransformadorClase transformador = new TransformadorClase(documento, procesadorLinea);
          

            Clase clase = transformador.ObtenerClase();

            AssertClaseHelper(clase);

        }

        private void AssertClaseHelper(Clase clase)
        {


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
