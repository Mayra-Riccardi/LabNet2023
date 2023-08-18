using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica01
{
    public class Taxi : TransportePublico
    {
        public Taxi(int cantPasajeros) : base(cantPasajeros)
        {

        }

        public override string Avanzar()
        {
            return string.Format($"Avanza rápidamente");
        }

        public override string Detenerse()
        {
            return string.Format($"Se detiene en destino");
        }
    }
}

