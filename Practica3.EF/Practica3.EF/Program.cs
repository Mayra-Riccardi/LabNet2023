using Practica3.EF.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica3.EF
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EmployeesLogic employeesLogic = new EmployeesLogic();

            var employees = employeesLogic.GetAll();

            Console.WriteLine("Employees List:");

            foreach (var employee in employees)
            {
                Console.WriteLine($"ID: {employee.EmployeeID} - NOMBRE Y APELLIDO: {employee.LastName} {employee.FirstName} - PAIS: {employee.Country}");
            }

            Console.WriteLine("Enter an employee ID to get details:");
            if (int.TryParse(Console.ReadLine(), out int employeeId))
            {
                var employee = employeesLogic.GetById(employeeId);
                if (employee != null)
                {
                    Console.WriteLine($"Detalles del empleado con ID {employee.EmployeeID}:");
                    Console.WriteLine($"Nombre completo: {employee.LastName} {employee.FirstName}");
                    Console.WriteLine($"País: {employee.Country}");
                }
                else
                {
                    Console.WriteLine("No se encontró ningún empleado con el ID proporcionado.");
                }
            }
            else
            {
                Console.WriteLine("Entrada inválida de ID de empleado.");
            }
            Console.ReadLine();
        }
        
    }
}
