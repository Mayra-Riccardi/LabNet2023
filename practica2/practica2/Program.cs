using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practica2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool entradaValida = false;
            int eleccion = 0;

            while (!entradaValida)
            {
                Console.WriteLine("Elija una operacion a realizar:");
                Console.WriteLine("1. Division por cero - Ejercicio 1");
                Console.WriteLine("2. Division de dos numeros - Ejercicio 2");
                Console.WriteLine("3. Logic Exception - Ejercicio 3");
                Console.WriteLine("4. Logic CustomException - Ejercicio 4");

                string entrada = Console.ReadLine();

                if (int.TryParse(entrada, out eleccion) && (eleccion == 1 || eleccion == 2 || eleccion == 3) || eleccion == 4)
                {
                    entradaValida = true;
                }
                else
                {
                    Console.WriteLine("El valor que has ingresado no es valido, recorda que debes ingresar una opcion entre 1 y 4. Intente nuevamente.");
                }
            }

            switch (eleccion)
            {
                case 1:
                    try
                    {
                        Console.WriteLine("Ingresa un numero para realizar la division por 0: ");
                        int numero = int.Parse(Console.ReadLine());

                        Calculadora.DivisionPorCero(numero, 0);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Hubo una excepcion: {ex.Message}");
                    }

                    finally
                    {
                        Console.WriteLine("Operacion finalizada!");
                    }
                    break;
                case 2:
                    try
                    {
                        Console.WriteLine("Ingresa el dividendo: ");
                        int dividendo = int.Parse(Console.ReadLine());

                        Console.WriteLine("Ingresa el divisor: ");
                        int divisor = int.Parse(Console.ReadLine());

                        int resultado = Calculadora.Division(dividendo, divisor);
                        Console.WriteLine( $"El resultado de la division es: {resultado}");
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine($"Seguro ingreso una letra o no ingreso nada!\nMensaje propio de la excepcion: {ex.Message}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Hubo un error: {ex.Message} La causa fue: {ex.InnerException.Message}");
                    }
                    finally
                    {
                        Console.WriteLine("Operacion finalizada!");
                    }
                    break;
                case 3:
                    try
                    {
                        Logic.MetodoConExcepcion();
                    }
                    catch (InvalidOperationException ex)
                    {
                        Console.WriteLine($"Mensaje de excepcion: {ex.Message}");
                        Console.WriteLine($"Tipo de excepcion: {ex.GetType().Name}");

                    }
                    finally {
                        Console.WriteLine("Operacion completada");
                    };
                    break;
                case 4:
                    try 
                    {
                        Logic.MetodoCustomException();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Mensaje de excepcion: {ex.Message}");
                        Console.WriteLine($"Tipo de excepcion: {ex.GetType().Name}");
                    }
                    finally
                    {
                        Console.WriteLine("Operacion completada");
                    };
                    break;
            }

            Console.ReadLine();
        }
    }
}
