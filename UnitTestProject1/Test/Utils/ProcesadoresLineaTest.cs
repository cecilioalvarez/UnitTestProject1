using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Negocio;
using UnitTestProject1.Utils;
using Xunit;

namespace UnitTestProject1.Test.Utils
{
    public  class ProcesadoresLineaTest
    {

        [Fact]
        public void ProcesarLineaTipoATest ()
        {

            string linea = "antonio,matematicas,7.5";
            ProcesadorLinea procesadorLinea = new ProcesadorLineaTipoA();
            Clase clase = new Clase("mi clase");

            procesadorLinea.Procesar(clase, linea);

            AssertClaseNotasHelper(clase, "antonio", "matematicas", 7.5);

        }

        [Fact]
        public void ProcesarLineaTipoBTest()
        {

            string linea = "gema,5,matematicas";
            ProcesadorLinea procesadorLinea = new ProcesadorLineaTipoB();
            Clase clase = new Clase("mi clase");

            procesadorLinea.Procesar(clase, linea);

            AssertClaseNotasHelper(clase, "gema", "matematicas", 5);

        }
        [Fact]
        public void ProcesarLineaTipoCTest()
        {

            string linea = "ANTONIO GOMEZ,7.5,matematicas";
            ProcesadorLinea procesadorLinea = new ProcesadorLineaTipoC();
            Clase clase = new Clase("mi clase");

            procesadorLinea.Procesar(clase, linea);

            AssertClaseNotasHelper(clase, "antonio", "matematicas", 7.5);
        }

        public void AssertClaseNotasHelper (Clase clase ,string nombre, string asignatura, double nota )
        {
            IList<Alumno> listaAlumnos = clase.Alumnos;
            Alumno alumno1 = listaAlumnos[0];
            IList<Nota> notasAlumno1 = alumno1.Notas;
            Assert.NotNull(clase);
            Assert.NotNull(listaAlumnos);
            Assert.Equal(nombre, alumno1.Nombre);
            Assert.Equal(asignatura, notasAlumno1[0].Asignatura);
            Assert.Equal(nota, notasAlumno1[0].Valor);

        }


    }
}
