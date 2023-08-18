using Practica01;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<TransportePublico> transportes = new List<TransportePublico>();

            for (int i = 1; i <= 5; i++)
            {
                try
                {
                    int cantPasajerosOmnibus;
                    Console.WriteLine($"Ingrese la cantidad de pasajeros con la que viaja el Omnibus número {i}: ");
                    cantPasajerosOmnibus = int.Parse(Console.ReadLine());

                    if (cantPasajerosOmnibus < 1)
                    {
                        throw new ArgumentOutOfRangeException("cantPasajerosOmnibus", "La cantidad de pasajeros debe ser mayor que 1.");
                    }

                    Omnibus omnibus = new Omnibus(cantPasajerosOmnibus);
                    transportes.Add(omnibus);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error: Ingrese un valor numérico válido.");
                    i--;
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    i--;
                }
            }

            for (int i = 1; i <= 5; i++)
            {
                try
                {
                    int cantPasajerosTaxi;
                    Console.WriteLine($"Ingrese la cantidad de pasajeros con la que viaja el Taxi número {i + 5}: ");
                    cantPasajerosTaxi = int.Parse(Console.ReadLine());

                    if (cantPasajerosTaxi > 5 || cantPasajerosTaxi < 1)
                    {
                        throw new ArgumentOutOfRangeException("cantPasajerosTaxi", "Ingrese una cantidad de pasajeros válida, entre 1 y 5.");
                    }

                    Taxi taxi = new Taxi(cantPasajerosTaxi);
                    transportes.Add(taxi);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error: Ingrese un valor numérico válido.");
                    i--;
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    i--;
                }
            }

            Console.WriteLine("La cantidad de pasajeros que viaja en cada transporte es: ");
            foreach (var transporte in transportes)
            {
                if (transporte is Omnibus)
                {
                    var omnibus = transporte as Omnibus;
                    int pasajerosRestantes = omnibus.Pasajeros - 3;
                    if (pasajerosRestantes <= 3)
                    {
                        Console.WriteLine($"El Omnibus número {transportes.IndexOf(transporte) + 1} {omnibus.Avanzar()}, viaja con {omnibus.Pasajeros} pasajeros. {omnibus.Detenerse()}, se bajan todos y continúa vacío.");
                    }
                    else
                    {
                        Console.WriteLine($"El Omnibus número {transportes.IndexOf(transporte) + 1} {omnibus.Avanzar()}, viaja con {omnibus.Pasajeros} pasajeros. {omnibus.Detenerse()}, se bajan 3 pasajeros, quedan {pasajerosRestantes}.");
                    }
                }
                else if (transporte is Taxi)
                {
                    var taxi = transporte as Taxi;
                    Console.WriteLine($"El Taxi número {transportes.IndexOf(transporte) + 1} {taxi.Avanzar()}, viaja con {taxi.Pasajeros} pasajeros. {taxi.Detenerse()}, se bajan todos sus pasajeros.");
                }
            }

            Console.ReadLine();
        }
    }
}
