using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1.Utils
{
    public class LectorFichero
    {
       
        public string Ruta { get; set; }

        public LectorFichero(string ruta)
        {

            Ruta = ruta;
        }

        public LectorFichero()
        {

        }

        public virtual IList<string> Lineas()
        {

            string[] lineas = File.ReadAllLines(Ruta);
            return lineas.ToList();
        }

    }
}
