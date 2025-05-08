using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1.Negocio
{
    public  class Cliente
    {
        public string Nombre { get; set; }

        public IList<Factura> Facturas { get; set; }= new List<Factura>();

        public Cliente (IList<Factura> facturas)
        {
            Facturas = facturas;

        }

        public Cliente ()
        {

        }

        public void AddFactura(Factura factura)
        {

            Facturas.Add(factura);
        }

        public virtual double CalcularImporteTotal()
        {
            double total = 0;

            foreach (var factura in Facturas)
            {

                total += factura.Importe;

            }
            return total;
        }

        public virtual double CalcularImporteTotalIVA()
        {
            double total = 0;

            foreach (var factura in Facturas)
            {

                total += factura.CalcularIVA();

            }
            return total;
        }


    }
}
