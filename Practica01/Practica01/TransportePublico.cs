using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica01
{
    public abstract class TransportePublico
    {

        public TransportePublico(int cantPasajeros) //constructor de tipo entero, lo primero que se ejecuta en la instacia de la clase, ahora lo paso por parametro
        {
            pasajeros = cantPasajeros;//le damos el valor a traves del constructor, pasa por el constructor y se la da a la propiedad un valor
        }

        private int pasajeros; //defino variable privada pasajeros
        public int Pasajeros { get { return pasajeros; } set { pasajeros = value; } }//propiedad pública llamada Pasajeros, get y set para obtener valores de pasajeros y para asignar un valor

        public abstract string Avanzar();

        public abstract string Detenerse();

    }
}
