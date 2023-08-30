﻿using Practica3.EF.Entities;
using Practica3.EF.Logic;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            EmployeesLogic employeesLogic = new EmployeesLogic();

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
                            ILogic<Employees> employeesILogic = new EmployeesLogic();
                            var employees = employeesILogic.GetAll();
                            Console.WriteLine("Employees List:");
                            foreach (var employee in employees)
                            {
                                Console.WriteLine($"Employee ID: {employee.EmployeeID} - Name: {employee.LastName} {employee.FirstName} - Country: {employee.Country}");
                            }
                            break;

                        case 2:
                            ILogic<Orders> ordersILogic = new OrdersLogic();
                            var orders = ordersILogic.GetAll();
                            Console.WriteLine("Orders List:");
                            foreach (var order in orders)
                            {
                                Console.WriteLine($"Order ID: {order.OrderID} - Date: {order.OrderDate}");
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

                                Console.Write("Enter Employee Title: ");
                                string title = Console.ReadLine();

                                Console.Write("Enter Employee Title of Courtesy: ");
                                string titleOfCourtesy = Console.ReadLine();

                                Console.Write("Enter Employee Address: ");
                                string address = Console.ReadLine();

                                Employees newEmployee = new Employees
                                {
                                    FirstName = firstName,
                                    LastName = lastName,
                                    Country = country,
                                    Title = title,
                                    TitleOfCourtesy = titleOfCourtesy,
                                    Address = address
                                };

                                Employees insertedEmployee = employeesLogic.Insert(newEmployee);
                                Console.WriteLine("Employee inserted successfully.");
                                Console.WriteLine($"ID: {insertedEmployee.EmployeeID} - Name and Surname: {insertedEmployee.LastName} {insertedEmployee.FirstName}");

                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"An error occurred: { ex.Message}");
                            }
                            break;


                        case 4:
                            Console.Write("Enter Employee ID to delete: ");
                            int employeeIdToDelete = int.Parse(Console.ReadLine());

                            try
                            {
                                employeesLogic.Delete(employeeIdToDelete);
                                Console.WriteLine($"Employee with ID {employeeIdToDelete} deleted successfully.");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"An error occurred while deleting the employee: {ex.Message}");
                            }
                            break;
                            
                        case 5:
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

                    