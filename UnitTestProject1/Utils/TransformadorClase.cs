using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Negocio;

namespace UnitTestProject1.Utils
{
    public class TransformadorClase
    {
        LectorFichero LectorFichero { get; set; }

        public TransformadorClase(LectorFichero lectorFichero) {

            LectorFichero = lectorFichero;
        
        }

        public virtual Clase ObtenerClase()
        {
            //lo he construido a traves de lo que las pruebas unitarias me han orientado

            IList<string> lineas = LectorFichero.Lineas();

            // como se que tipo de fichero estoy manejando porque realemente
            // el lector lo que hace es leer un fichero de text ocon su contenido y punto
            //probablemente la primera liena del fichero me define de donde A o B

            string tipo = "";

            if (lineas.Count!=0 && lineas[0].Contains("*"))
            {
                tipo = "TipoA";
            }else if (lineas.Count != 0 &&  lineas[0].Contains("/"))
            {
                tipo = "TipoB";
            }else
            {
                tipo = "TipoC";
            }

            EliminarCabeceraPie(lineas);

            Clase clase = new Clase("mi clase");


            // que aqui tendremos que operar de una forma bastante diferente 

            foreach (string linea in lineas)
            {
                if (tipo.Equals("TipoA")) {

                    ProcesarLineaA(clase, linea);
                }else if (tipo.Equals("TipoB"))
                {

                    ProcesarLineaB(clase, linea);
                }else
                {
                    ProcesarLineaC(clase, linea);

                }
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
        private Clase ProcesarLineaA( Clase clase ,string linea)
        {
            
            return new ProcesadorLineaTipoA().Procesar(clase, linea);

        }

        private Clase ProcesarLineaB(Clase clase, string linea)
        {
          
              return new ProcesadorLineaTipoB().Procesar(clase, linea);


        }

        private Clase ProcesarLineaC(Clase clase, string linea)
        {
            return new ProcesadorLineaTipoC().Procesar(clase, linea);

        }
    }
    }
