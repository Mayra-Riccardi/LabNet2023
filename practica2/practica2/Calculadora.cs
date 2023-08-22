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
                throw new DivideByZeroException("Caiste en la trampa, nadie te dijo nunca que no se puede dividir por cero? Volve a intentar otro dia!");
            }
        }

        public static string Division(int dividendo, int divisor)
        {
            try
            {
                int resultado = dividendo / divisor;
                return $"El resultado de la division es: {resultado}\n\n\nMuchas Gracias por usar nuestra calculadora!!!!";
            }
            catch (DivideByZeroException ex)
            {
                throw new DivideByZeroException ($"¡Solo Chuck Norris divide por cero!\nMensaje propio de la excepcion: {ex.Message}");
            }
            catch (FormatException ex)
            {
                throw ex;
            }
        }
    }
}
