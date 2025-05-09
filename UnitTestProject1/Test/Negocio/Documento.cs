using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1.Test.Negocio
{
    public  class Documento
    {
        public virtual IList<string> Lineas { get; set; }= new List<string>();

        public Documento(IList<string> lineas)
        {
            Lineas = lineas;
        }

        public Documento()
        {


        }

        public string Cabecera()
        {

            return Lineas[0];
        }
    }
}
