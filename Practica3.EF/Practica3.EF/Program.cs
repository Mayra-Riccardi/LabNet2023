using Practica3.EF.Entities;
using Practica3.EF.Logic;
using Practica3.EF.Logic.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Practica3.EF
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ILogic<EmployeesDto> employeesILogic = new EmployeesLogic();

            while (true)
            {
                Console.WriteLine("Select the operation you want to perform:");
                Console.WriteLine("1. Query Employees entity");
                Console.WriteLine("2. Query Orders entity");
                Console.WriteLine("3. Insert new Employee");
                Console.WriteLine("4. Update Employee");
                Console.WriteLine("5. Delete Employee");
                Console.WriteLine("6. To exit");


                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            var employees = employeesILogic.GetAll();
                            Console.WriteLine("Employees List:");
                            foreach (var employee in employees)
                            {
                                Console.WriteLine($"Employee ID: {employee.Id} - Name: {employee.LastName} {employee.FirstName} - Country: {employee.Country}");
                            }
                            break;

                        case 2:
                            ILogic<Orders> ordersILogic = new OrdersLogic();
                            var orders = ordersILogic.GetAll();
                            Console.WriteLine("Orders List:");
                            foreach (var order in orders)
                            {
                                Console.WriteLine($"Order ID: {order.OrderID} - Date: {order.OrderDate} {order.ShipName}");
                            }
                            break;

                        case 3:
                            try
                            {
                                Console.Write("Enter Employee First Name: ");
                                string firstName = Console.ReadLine();

                                Console.Write("Enter Employee Last Name: ");
                                string lastName = Console.ReadLine();

                                Console.Write("Enter Employee Country: ");
                                string country = Console.ReadLine();


                                var newEmployeeDto = new EmployeesDto
                                {
                                    FirstName = firstName,
                                    LastName = lastName,
                                    Country = country,
                                };
                                EmployeesLogic employeesLogic = new EmployeesLogic();
                                employeesLogic.Validate(newEmployeeDto);

                                EmployeesDto insertedEmployee = employeesILogic.Insert(newEmployeeDto);
                                Console.WriteLine("Employee inserted successfully.");
                                Console.WriteLine($"ID: {insertedEmployee.Id} - Name and Surname: {insertedEmployee.LastName} {insertedEmployee.FirstName} - Country: {insertedEmployee.Country}");

                            }
                            catch (ArgumentException ex)
                            {
                                Console.WriteLine($"Error: ({ex.GetType().Name}): {ex.Message}");
                            }
                  
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Error: ({ex.GetType().Name}): {ex.Message}");
                            }
                            break;

                        case 4:
                            int employeeId = 0;//Creo variable int ID Para poder arrojar una excepcion si el id ingresado no existe, sigo pensando como mejorar esto

                            try
                            {
                                Console.Write("Enter Employee ID to update: ");
                                employeeId = int.Parse(Console.ReadLine());

                                var existingEmployee = employeesILogic.GetAll().FirstOrDefault(e => e.Id == employeeId);

                                if (existingEmployee == null)
                                {
                                    Console.WriteLine($"Employee with ID {employeeId} not found.");
                                    break;
                                }//no me convence esta validacion acá

                                Console.Write("Enter updated Employee First Name: ");
                                string firstName = Console.ReadLine();

                                Console.Write("Enter updated Employee Last Name: ");
                                string lastName = Console.ReadLine();

                                Console.Write("Enter updated Employee Country: ");
                                string country = Console.ReadLine();

                                existingEmployee.FirstName = firstName;
                                existingEmployee.LastName = lastName;
                                existingEmployee.Country = country;

                                EmployeesLogic employeesLogic = new EmployeesLogic();
                                employeesLogic.Validate(existingEmployee);

                                employeesILogic.Update(existingEmployee);

                                Console.WriteLine($"Employee with ID {employeeId} updated successfully");
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine($"Invalid input. Sorry but de Id you provide is not a valid Employee ID.");
                            }

                            catch (ArgumentException ex)
                            {
                                Console.WriteLine($"Error: ({ex.GetType().Name}): {ex.Message}");
                            }

                            catch (Exception ex)
                            {
                                Console.WriteLine($"An error occurred while deleting the employee: {ex.Message}");
                            }
                            break;

                        case 5:
                            try
                            {
                                Console.Write("Enter Employee ID to delete: ");
                                int employeeIdToDelete = int.Parse(Console.ReadLine());

                                employeesILogic.Delete(employeeIdToDelete);
                                Console.WriteLine($"Employee with ID {employeeIdToDelete} deleted successfully.");
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine($"Invalid input. Sorry but de Id you provide is not a valid Employee ID.");
                            }
                            catch (ArgumentException ex)
                            {
                                Console.WriteLine($"Error: ({ex.GetType().Name}): {ex.Message}");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"An error occurred while deleting the employee: {ex.Message}");
                            }
                            break;
                            
                        case 6:
                            Console.WriteLine("Exiting the program...");
                            return;

                        default:
                            Console.WriteLine("Invalid option. Select a valid option.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Enter a valid number.");
                }

                Console.WriteLine();
            }
        }
    }
} 