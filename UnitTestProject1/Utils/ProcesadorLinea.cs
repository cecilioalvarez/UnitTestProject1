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

        public static ProcesadorLinea CrearProcesador(string cabecera)
        {

            if (cabecera.Contains("*"))
            {
                return new ProcesadorLineaTipoA();
            }
            else if (cabecera.Contains("/"))
            {
                return new ProcesadorLineaTipoB();
            }
            else
            {
                return new ProcesadorLineaTipoC();
            }

        }
    }
}
