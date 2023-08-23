using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practica2
{
    public class Logic
    {
        public static void MetodoConExcepcion()
        {
            throw new InvalidOperationException();
        }

        public static void MetodoCustomException()
        {
            throw new CustomException("CustomException capturado");

        }
    }
}
