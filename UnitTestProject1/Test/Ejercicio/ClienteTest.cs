using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using UnitTestProject1.Negocio;
using Xunit;

namespace UnitTestProject1.Test.Ejercicio
{
    public  class ClienteTest
    {
        [Fact]
        public void AddFacturaIntegrationTest()
        {

            Cliente c = new Cliente();
            Factura f = new Factura(1, "ordenador", 100);
            c.AddFactura(f);

            int numeroFacturas = c.Facturas.Count;

            Assert.Equal(1, numeroFacturas);

        }


        [Fact]
        public void AddFacturaUnitTest()
        {

          
            Mock<IList<Factura>> mockListaFacturas= new Mock<IList<Factura>>();

            Factura f = new Factura(1, "ordenador", 100);

            Cliente c = new Cliente(mockListaFacturas.Object);

            //este metodo add factura lo que hace es invoca a la lista para añadir

            c.AddFactura(f);

            //oye estas llamando al metodo add de la lista
            mockListaFacturas.Verify(x => x.Add(f),Times.Once);

                

        }


        [Fact]
        public void CalcularImporteTotalUnitTest()
        {


            Mock<Factura> mockFactura1= new Mock<Factura>();
            Mock<Factura> mockFactura2 = new Mock<Factura>();
           
            //mini mocks con lo que tiene que ser operativo es suficiente
            mockFactura1.Setup(x => x.Importe).Returns(100);
            mockFactura2.Setup(x => x.Importe).Returns(100);



            IList<Factura> listaFacturas = new List<Factura>();
            listaFacturas.Add(mockFactura1.Object);
            listaFacturas.Add(mockFactura2.Object);

            Cliente c = new Cliente(listaFacturas);

            double calcularTotal = c.CalcularImporteTotal();


            Assert.Equal(200, calcularTotal);

        }

        [Fact]
        public void CalcularImporteTotalIvaUnitTest()
        {


            Mock<Factura> mockFactura1 = new Mock<Factura>();
            Mock<Factura> mockFactura2 = new Mock<Factura>();

            //mini mocks con lo que tiene que ser operativo es suficiente
            mockFactura1.Setup(x => x.CalcularIVA()).Returns(121);
            mockFactura2.Setup(x => x.CalcularIVA()).Returns(121);



            IList<Factura> listaFacturas = new List<Factura>();
            listaFacturas.Add(mockFactura1.Object);
            listaFacturas.Add(mockFactura2.Object);

            Cliente c = new Cliente(listaFacturas);

            double calcularTotal = c.CalcularImporteTotalIVA();


            Assert.Equal(242, calcularTotal);

        }


        [Fact]
        public void CalcularImporteTotalIntegrationTest()
        {

         
            Factura f = new Factura(1, "ordenador", 100);
            Factura f2 = new Factura(2, "ordenador", 150);
          
            
            IList<Factura> listaFacturas= new List<Factura>();
            listaFacturas.Add(f);
            listaFacturas.Add(f2);
            Cliente c = new Cliente(listaFacturas);

            double calcularTotal = c.CalcularImporteTotal();


            Assert.Equal(250, calcularTotal);

        }

    }
}
