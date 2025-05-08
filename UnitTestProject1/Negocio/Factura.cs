using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1.Negocio
{
    public class Factura
    {

        public virtual int Numero { get; set; }
        public virtual string Concepto { get; set; }
        public virtual double Importe { get; set; }

        public Factura(int Numero, string Concepto, double Importe)
        {

            this.Numero = Numero;
            this.Concepto = Concepto;
            this.Importe = Importe; 
        }

        public Factura() { }

        public virtual double CalcularIVA()
        {

            return this.Importe *1.21;
        }
    }
}
