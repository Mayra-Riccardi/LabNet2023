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
                Console.WriteLine("1. Division por cero");
                Console.WriteLine("2. Division de dos numeros");
                Console.WriteLine("3. Ejercicio tres");
                Console.WriteLine("4. Ejercicio cuatro");

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
                    catch (DivideByZeroException ex)
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

                        string resultado = Calculadora.Division(dividendo, divisor);
                        Console.WriteLine(resultado);
                    }
                    catch (DivideByZeroException ex)
                    {
                        Console.WriteLine($"Hubo un error: {ex.Message}");
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine($"Seguro ingreso una letra o no ingreso nada!\nMensaje propio de la excepcion: {ex.Message}");
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
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Mensaje de excepción: {ex.Message}");
                        Console.WriteLine($"Tipo de excepción: {ex.GetType().Name}");

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
                    catch (Exception)
                    {
                        Console.WriteLine("Nuestro CustomException capturado");
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
