using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Negocio;
using Xunit;

namespace UnitTestProject1.Test
{
    public class AlumnoEstadisticaTest
    {
        private Alumno _alumno;
        private List<Nota> _notas;


        [Fact]
        void NotaMediaTest()
        {

            _notas = new List<Nota>();
            _notas.Add(new Nota(5, "Matematicas"));
            _notas.Add(new Nota(7, "Ingles"));
            _notas.Add(new Nota(10, "Fisica"));
            _notas.Add(new Nota(10, "Filosofia"));
            _alumno = new Alumno("pepe", _notas);



            //act es muy significativo

            Nota notaMedia = _alumno.NotaMedia();

            Assert.Equal(8, notaMedia.Valor);
            Assert.Equal("media del curso", notaMedia.Asignatura);



        }

        [Fact]
        void NotasAprobadaTest()
        {


            _notas = new List<Nota>();
            _notas.Add(new Nota(5, "Matematicas"));
            _notas.Add(new Nota(7, "Ingles"));
            _notas.Add(new Nota(10, "Fisica"));
            _notas.Add(new Nota(10, "Filosofia"));
            _alumno = new Alumno("pepe", _notas);

            int aprobadas = _alumno.NotasAprobadas();

            Assert.Equal(4, aprobadas);

        }



        [Fact]
        void NotasSuspensasTest()
        {

            _notas = new List<Nota>();
            _notas.Add(new Nota(5, "Matematicas"));
            _notas.Add(new Nota(7, "Ingles"));
            _notas.Add(new Nota(3, "Fisica"));
            _notas.Add(new Nota(2, "Filosofia"));
            _alumno = new Alumno("pepe", _notas);

            int suspensas = _alumno.NotasSuspensas();

            Assert.Equal(2, suspensas);

        }


    }
}
