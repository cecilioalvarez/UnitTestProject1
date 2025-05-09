using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestProject1.Negocio;
using Xunit;

namespace UnitTestProject1.Test.Ejercicio
{
    public  class FacturaTest
    {
        [Fact]
        public void ImporteConIVATest()
        {
            //arrange

            Factura f = new Factura(1, "ordenador", 200);
            //act 
            double importeTotalIVA=f.CalcularIVA();
            
            //assert 
            Assert.Equal(242, importeTotalIVA);


        }
    }
}
