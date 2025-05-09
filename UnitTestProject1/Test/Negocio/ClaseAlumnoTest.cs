using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Negocio;
using Xunit;
using Xunit.Sdk;

namespace UnitTestProject1.Test.Negocio
{
    public class ClaseAlumnoTest
    {

        // es una prueba de integracion

        //una prueba unitaria de otra prueba

        //conseguimos desacoplar las pruebas

        [Fact]
        public void AddAlumnoTest()
        {
          
          
            Alumno alumno = new Alumno("pedro", new List<Nota>());
            var  lista= new Mock<IList<Alumno>>();
            Clase clase = new Clase("clase A", lista.Object);
            
            clase.AddAlumno(alumno);
           
            lista.Verify(x=>x.Add(alumno), Times.Once);

        }


        [Fact]
        public void RemoveAlumnoTest()
        {


            Alumno alumno = new Alumno("pedro", new List<Nota>());
            var lista = new Mock<IList<Alumno>>();
            Clase clase = new Clase("clase A", lista.Object);
            
            clase.RemoveAlumno(alumno);

            lista.Verify(x => x.Remove(alumno), Times.Once);

        }

        [Fact]
        public void NotaMediaTest()
        {
         
            //arrange
            var alumno1 = new Mock<Alumno>();
            alumno1.Setup(x => x.NotaMedia()).Returns(new Nota(4, "nota media"));

            var alumno2 = new Mock<Alumno>();
            alumno2.Setup(x => x.NotaMedia()).Returns(new Nota(3, "nota media"));

            //diseño una lista con objetos simulados

            List<Alumno> alumnos = new List<Alumno>();
            alumnos.Add(alumno1.Object);
            alumnos.Add(alumno2.Object);

            Clase clase = new Clase("clase A", alumnos);
            Assert.Equal(3.5, clase.NotaMedia().Valor);

        }


        //es muchisimo codigo claro
        //porque esto no es una prueba unitaria
        //es una prueba de integracion


        [Fact]
        public void NotaMayorTest()
        {
            Nota nota1 = new Nota(5,"Matematicas");
            Nota nota2 = new Nota(6, "Matematicas");
            List<Nota> lista= new List<Nota>();

            lista.Add(nota1);
            lista.Add(nota2);


            Alumno a1 = new Alumno("pedro", lista);

            Nota nota3 = new Nota(8, "Matematicas");
            Nota nota4 = new Nota(9, "Matematicas");
            List<Nota> lista2 = new List<Nota>();

            lista2.Add(nota3);
            lista2.Add(nota4);

            Alumno a2 = new Alumno("pedro",lista2);


            List<Alumno> listaAlumnos= new List<Alumno>();
            listaAlumnos.Add(a1);
            listaAlumnos.Add(a2);

            Clase clase = new Clase("miclase",listaAlumnos);


            Nota notaMayor=clase.NotaMayor();

            Assert.Equal(nota4, notaMayor);


        }

        [Fact]
        public void NotaMayorUnitarioTest()
        {

            var a1 =new Mock<Alumno>();
            var a2 = new Mock<Alumno>();

            a1.Setup(x=>x.NotaMayor()).Returns(new Nota(0,"Matematicas"));
            a2.Setup(x => x.NotaMayor()).Returns(new Nota(0, "Matematicas"));


            List<Alumno> listaAlumnos = new List<Alumno>();
            listaAlumnos.Add(a1.Object);
            listaAlumnos.Add(a2.Object);



            Clase clase = new Clase("miclase", listaAlumnos);
            Nota notaMayor = clase.NotaMayor();


            a1.Verify(x => x.NotaMayor(), Times.Exactly(2));
            a2.Verify(x => x.NotaMayor(), Times.Once);


        }
    }
}
