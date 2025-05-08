using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Negocio;

namespace UnitTestProject1.Utils
{
    public abstract class ProcesadorLinea
    {

        public abstract  Clase Procesar(Clase clase ,string linea);
        
    }
}
