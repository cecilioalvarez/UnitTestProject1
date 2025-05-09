using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Negocio;
using Xunit;

namespace UnitTestProject1.Test.Negocio
{
    public class AlumnoTest :IDisposable
    {
        private Alumno _alumno;
        private List<Nota> _notas;



        public AlumnoTest() {

          
            _notas = new List<Nota>();
            _notas.Add(new Nota(5,"Matematicas"));
            _notas.Add(new Nota(3, "Matematicas"));
            _notas.Add(new Nota(7, "Ingles"));
            _notas.Add(new Nota(10, "Fisica"));
            _notas.Add(new Nota(10, "Filosofia"));
            _alumno = new Alumno("pepe",_notas);
        }

        [Fact]
        void AddNotaTest()
        {

            //no es muy timely porque he tenido que modificar bastante
          
            Nota nota = new Nota(3,"Matematicas");

            _alumno.AddNota(nota);

            Assert.Contains(nota,_alumno.Notas);



        }

        [Fact]
        void RemoveNotaTest()
        {


            Nota nota = new Nota(5, "Matematicas");

            _alumno.RemoveNota(nota);

            Assert.DoesNotContain(nota, _alumno.Notas);

        }


        [Fact]
        void NotaMayorTest()
        {
            //porque este metodo ejecuta otro metodo
            // EsNotaMayor la tenemos

            var nota1 = new Mock<Nota>();
            var nota2 = new Mock<Nota>();
            var nota3 = new Mock<Nota>();

            nota1.Setup(x=>x.EsMismaAsignatura(It.IsAny<Nota>())).Returns(true);
            nota2.Setup(x => x.EsMismaAsignatura(It.IsAny<Nota>())).Returns(true);
            nota3.Setup(x => x.EsMismaAsignatura(It.IsAny<Nota>())).Returns(true);

            var  alumno = new Alumno("pedro", new List<Nota> { nota1.Object,nota2.Object,nota3.Object });

            //act es muy significativo

            Nota notaMayor=alumno.NotaMayor();

            //assert lo que verifico es que cada mock su metodo EsMayor fue invocado

            nota1.Verify(x=>x.EsMayor(It.IsAny<Nota>()));
        





        }


       

        public void Dispose()
        {


            _notas = null;

            _alumno = null;
        }
    }
}
