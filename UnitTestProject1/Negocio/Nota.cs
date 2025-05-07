using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Nota
    {
        private double _valor;


        public enum TipoNota
        {

            Suspenso,
            Aprobado,
            Notable,
            SobreSaliente
        }

        public double Valor
        {


            get { return _valor; }
            set { 
            
                if (value <0 || value>10)
                {

                    throw new Exception("nota no entra en rango valido");
                }else
                {

                    _valor = value;
                }
            
            }
        }
        public string Asignatura { get; set; }

        public Nota( double valor , string asignatura )
        {
            Valor = valor;
            Asignatura = asignatura;
        }

        public Nota()
        {


        }

        public bool EstaAprobada() {

           return  Valor >= 5? true:false;
               
        }

        // crear otro metodo para ver un poco
        // la igualdad de notas 
        public virtual bool EsMismaAsignatura(Nota nota)
        {

            if (Asignatura.Equals(nota.Asignatura)) 
            {

                return true;
            }
            else { return false; }

        }

        public virtual int EsMayor(Nota nota)
        {

            if (this.EsMismaAsignatura(nota))
            {

               if (this.Valor> nota.Valor)
                {
                    return 1;
                }
                else if (this.Valor<nota.Valor) 
                { return -1; 
                
                } else
                {
                    return 0;
                }
            }else
            {

                throw new Exception("error asignatura no coincide");
            }

    }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Nota otra = (Nota)obj;
            return Valor == otra.Valor && Asignatura == otra.Asignatura;
        }

        public override int GetHashCode()
        {
            unchecked // permite overflow sin lanzar excepción
            {
                int hash = 17;
                hash = hash * 23 + Valor.GetHashCode();
                hash = hash * 23 + (Asignatura != null ? Asignatura.GetHashCode() : 0);
                return hash;
            }
        }

        public TipoNota GetTipo()
        {

            if (Valor >= 0 && Valor < 5)
            {

                return TipoNota.Suspenso;
            }
            else if (Valor >= 5 && Valor < 7)
            {

                return TipoNota.Aprobado;
            }
            else if (Valor >= 7 && Valor < 9)
            {
                return TipoNota.Notable;
            }else
            {
                return TipoNota.SobreSaliente;
            }
        }
    }
}
