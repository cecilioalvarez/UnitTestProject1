using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Negocio;
using UnitTestProject1.Negocio;
using Xunit;

namespace UnitTestProject1.Test
{
    public class PersonaTest
    {
        [Fact]
        public void EsMayorEdadTest()
        {

            Persona p = new Persona("pedro",20);
            Persona p2 = new Persona("juan", 17);
            Persona p3 = new Persona("juan", 18);

            bool esMayor =p.EsMayorEdad();
            bool noEsMayor = p2.EsMayorEdad();
            bool esMayorJusto = p3.EsMayorEdad();

            Assert.True(esMayor);
            Assert.True(esMayorJusto);
            Assert.False(noEsMayor);
        }
    }
}
