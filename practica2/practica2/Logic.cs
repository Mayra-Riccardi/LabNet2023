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
            throw new Exception("Mensaje de excepcion de prueba!");
        }

        public static void MetodoCustomException()
        {
            throw new CustomException("Nuestro CustomException capturado");
        }
    }
}
