using System;
using Negocio;
using Xunit;


namespace UnitTestProject1.Test
{
    
    public class CalculadoraTest
    {
        [Fact]
        public void SumaCalculadora()
        {

            var calculadora = new Calculadora();

            // Act
            var resultado = calculadora.Sumar(2, 3);

            // Assert
            Assert.Equal(5, resultado);

        }

        [Fact]
        public void RestaCalculadora()
        {

            var calculadora = new Calculadora();

            // Act
            var resultado = calculadora.Restar(2, 3);

            // Assert
            Assert.Equal(-1, resultado);

        }
    }
}
