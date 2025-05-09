using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Negocio;
using UnitTestProject1.Test.Negocio;

namespace UnitTestProject1.Utils
{
    public class TransformadorClase
    {
        Documento Documento { get; set; }
        ProcesadorLinea ProcesadorLinea { get; set; }

        // ya he elegido q tipo de procesamiento voy a hacer
        public TransformadorClase(Documento documento, ProcesadorLinea procesadorLinea) {

            Documento = documento;
            ProcesadorLinea = procesadorLinea;
        }
        public virtual Clase ObtenerClase()
        {
           
            IList<string> lineas = Documento.Lineas;

            EliminarCabeceraPie(lineas);

            Clase clase = new Clase("mi clase");

            foreach (string linea in lineas)
            {
                //polimorfismo
               ProcesadorLinea.Procesar(clase, linea);
            }

            return clase;
        }

        private void EliminarCabeceraPie(IList<string> lineas)
        {
            if (lineas.Count != 0)
            {
                lineas.RemoveAt(0);
                lineas.RemoveAt(lineas.Count() - 1);
            }

        }
    }
    }
