using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Negocio;
using UnitTestProject1.Utils;
using Xunit;

namespace UnitTestProject1.Test.Utils
{
    public class LectorFicheroTest
    {


        [Fact]
        void LineasTest()
        {

            LectorFichero lector = new LectorFichero("../../datos/clase.txt");

            IList<string> lineas=lector.Lineas(); 

            Assert.Equal(7, lineas.Count);



        }

    }
}
