using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Negocio;
using Xunit;
using Xunit.Sdk;

namespace UnitTestProject1.Test
{
    public class NotaTest
    {
        [Fact]
        void EstaAprobadaTest()
        {
            // AAA 
            //Arrange 
            //Act
            //Assert 
            //preparas los objetos que necesitas para las pruebas
            //arrange
            Nota notaEs6 = new Nota(6, "Matematicas");
            Nota notaEs5 = new Nota(5, "Matematicas");
            //act
            bool aprobado5 = notaEs6.EstaAprobada();
            bool aprobado6 = notaEs5.EstaAprobada();


            Assert.True(aprobado5);
            Assert.True(aprobado6);



        }


        [Fact]
        void FueraDeRangoValidoTest()
        {
          //hacer algo parecido pero en el mundo del manejo de excepcioens

            Nota notaNoValida = new Nota();

            var excepcionMayor10 = Assert.Throws<Exception>(() => notaNoValida.Valor = 10.1);
            var excepcionMenor0 = Assert.Throws<Exception>(() => notaNoValida.Valor = -1);

            Assert.Equal("nota no entra en rango valido",excepcionMayor10.Message);
            Assert.Equal("nota no entra en rango valido", excepcionMenor0.Message);





        }

        [Fact]
        void EstaSuspensaTest()
        {
         
            Nota nota = new Nota(4, "Matematicas");
            //act
            bool estaLaNotaAprobada = nota.EstaAprobada();

            Assert.False(estaLaNotaAprobada);



        }

        [Fact]
        void EsMismaAsignaturaTest()
        {
            
            Nota nota1 = new Nota(4, "Matematicas");
            Nota nota2 = new Nota(7, "Matematicas");

            //act
            bool sonLaMismaAsignatura = nota1.EsMismaAsignatura(nota2);

            Assert.True(sonLaMismaAsignatura);



        }

        [Fact]
        void EsMayorQueOtraTest()
        {

            Nota nota1 = new Nota(4, "Matematicas");
            Nota nota2 = new Nota(7, "Matematicas");

            //act
           int esMayor = nota2.EsMayor(nota1);

            Assert.Equal(1, esMayor);



        }

        [Fact]
        void EsMenorQueOtraTest()
        {

            Nota nota1 = new Nota(4, "Matematicas");
            Nota nota2 = new Nota(7, "Matematicas");

            //act
            int esMenor = nota1.EsMayor(nota2);

            Assert.Equal(-1,esMenor);



        }

        [Fact]
        void SonValoresIgualesTest()
        {

            Nota nota1 = new Nota(4, "Matematicas");
            Nota nota2 = new Nota(4, "Matematicas");

            //act
            int sonIguales = nota1.EsMayor(nota2);

            Assert.Equal(0,sonIguales);



        }

        [Fact]
        void SonObjetosIgualesTest()
        {

            Nota nota1 = new Nota(4, "Matematicas");
            Nota nota2 = new Nota(4, "Matematicas");

            //act
            bool sonIguales = nota1.Equals(nota2);

            Assert.True(sonIguales);



        }

        [Fact]
        void TipoSuspensoTest()
        {

            Nota nota0 = new Nota(0, "Matematicas");
            Nota nota3 = new Nota(3, "Matematicas");
            Nota nota5 = new Nota(5, "Matematicas");

            Nota.TipoNota tipoSuspenso0 = nota0.GetTipo();
            Nota.TipoNota tipoSuspenso3 = nota3.GetTipo();
            Nota.TipoNota tipoAprobado5 = nota5.GetTipo();

            Assert.Equal(Nota.TipoNota.Suspenso,tipoSuspenso0);
            Assert.Equal(Nota.TipoNota.Suspenso, tipoSuspenso3);
            Assert.Equal(Nota.TipoNota.Aprobado, tipoAprobado5);



        }

        [Fact]
        void TipoAprobadoTest()
        {

            Nota nota5 = new Nota(5, "Matematicas");
            Nota nota6 = new Nota(6, "Matematicas");
            Nota nota7 = new Nota(7, "Matematicas");

            Nota.TipoNota tipoAprobado5 = nota5.GetTipo();
            Nota.TipoNota tipoAprobado6 = nota6.GetTipo();
            Nota.TipoNota tipoAprobado7 = nota7.GetTipo();

            Assert.Equal(Nota.TipoNota.Aprobado, tipoAprobado5);
            Assert.Equal(Nota.TipoNota.Aprobado, tipoAprobado6);
            Assert.Equal(Nota.TipoNota.Notable, tipoAprobado7);



        }


    }
}
