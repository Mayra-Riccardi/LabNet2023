using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practica2
{
    public class Calculadora
    {
        public static void DivisionPorCero(int numero, int divisor)
        {
            if (divisor == 0)
            {
                throw new Exception();
            }
        }

        public static int  Division(int dividendo, int divisor)
        {
            try
            {
                int resultado = dividendo / divisor;
                return resultado;
            }
            catch (DivideByZeroException ex)
            {
                throw new Exception ($"¡Solo Chuck Norris divide por cero!\nMensaje propio de la excepcion: {ex.Message}", ex);
            }
        }
    }
}
