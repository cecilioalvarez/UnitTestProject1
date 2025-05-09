using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestProject1.Utils;
using Xunit;

namespace UnitTestProject1.Test.Utils
{
    public class ProcesadorLineaFactoryTest
    {


        [Fact]
        public void factoriaCrearProcesadorTest()
        {

            ProcesadorLinea procesadorLineaA = ProcesadorLinea.CrearProcesador("*****");
            ProcesadorLinea procesadorLineaB = ProcesadorLinea.CrearProcesador("/////");
            ProcesadorLinea procesadorLineaC = ProcesadorLinea.CrearProcesador("||");

            bool esTipoA = procesadorLineaA is ProcesadorLineaTipoA;

            bool esTipoB = procesadorLineaB is ProcesadorLineaTipoB;

            bool esTipoC = procesadorLineaC is ProcesadorLineaTipoC;

            Assert.True(esTipoA);
            Assert.True(esTipoB);
            Assert.True(esTipoC);
        }
    }
}
