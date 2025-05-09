using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Negocio;
using UnitTestProject1.Test.Negocio;
using UnitTestProject1.Utils;
using Xunit;
using Xunit.Sdk;

namespace UnitTestProject1.Test.Utils
{
    public class TransformadorClaseTest
    {
        [Fact]
        public void CargarClaseConAlumnosYNotasTest()
        {
            string[] lineasMock = new string[]
            {
                "/////////////////",
                "antonio,7.5,matematicas",
                "antonio,8,lengua",
                "-----------------",
                "gema,5,matematicas",
                "gema,9,lengua",
                "/////////////////"

            };

            var documento = new Mock<Documento>();
            documento.Setup(x => x.Lineas).Returns(lineasMock.ToList());
            Mock<ProcesadorLinea> procesadorLinea = new Mock<ProcesadorLinea>();
            TransformadorClase transformador = new TransformadorClase(documento.Object, procesadorLinea.Object);

            Clase clase = transformador.ObtenerClase();

            documento.Verify(x => x.Lineas, Times.Once);
            procesadorLinea.Verify(x => x.Procesar(clase, It.IsAny<string>()), Times.Exactly(5));
            Assert.NotNull(clase);

        }

      

    }

}
