using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica01
{
    internal class Omnibus : TransportePublico
    {
        public Omnibus(int cantPasajeros) : base(cantPasajeros)
        {

        }

        public override string Avanzar()
        {
            return string.Format($"avanza muy lento");
        }

        public override string Detenerse()
        {
            return string.Format($"Se detiene abruptamente");
        }
    }
}

