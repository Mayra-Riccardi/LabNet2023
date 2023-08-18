using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica01
{
    public abstract class TransportePublico
    {

        internal TransportePublico(int cantPasajeros) //constructor de tipo entero, lo primero que se ejecuta en la instacia de la clase, ahora lo paso por parametro
        {
            Pasajeros = cantPasajeros;//le damos el valor a traves del constructor, pasa por el constructor y se la da a la propiedad un valor
        }

        internal int Pasajeros { get; set; }//propiedad de tipo entera, publica

        public abstract string Avanzar();

        public abstract string Detenerse();

    }
}
