using Practica4.LQ.Logic;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Practica4.LQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Query Menu!");

            while (true)
            {
                Console.WriteLine("Select the operation you want to perform:");
                Console.WriteLine("1. Query to return a customer object");
                Console.WriteLine("2. Query to return all products with no stock");
                Console.WriteLine("3. Query to return all products with stock and unit price greater than 3");
                Console.WriteLine("4. Query to return all customers from region WA");
                Console.WriteLine("5. Query to return the first or null element from a product list where ProductID is 789");
                Console.WriteLine("6. Query to return customer names in uppercase and lowercase");
                Console.WriteLine("7. Query to return a join between Customers and Orders where customers are from region WA and order date is greater than 1/1/1997");
                Console.WriteLine("8. Query to return the first 3 Customers from region WA");
                Console.WriteLine("9. Query to return a list of products ordered by name");
                Console.WriteLine("10. Query to return a list of products ordered by units in stock in descending order");
                Console.WriteLine("11. Query to return the different categories associated with the products");
                Console.WriteLine("12. Query to return the first element of a list of products");
                Console.WriteLine("13. Query to return customers with the quantity of associated orders");
                Console.WriteLine("14. To exit");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            try
                            {
                                CustomersLogic customersLogic = new CustomersLogic();
                                var customer = customersLogic.CustomerObject();

                                Console.WriteLine("CUSTOMER:");
                                Console.WriteLine($"Id: {customer.CustomerID}");
                                Console.WriteLine($"Contact Name: {customer.ContactName}");
                                Console.WriteLine($"Company Name: {customer.CompanyName}");
                                Console.WriteLine($"Country: {customer.Country}");
                                Console.WriteLine($"Contact Title: {customer.ContactTitle}");
                                Console.WriteLine($"Address: {customer.Address}");
                                Console.WriteLine($"City: {customer.City}");
                                Console.WriteLine($"Region: {customer.Region}");
                                Console.WriteLine($"Postal Code: {customer.PostalCode}");
                                Console.WriteLine($"Country: {customer.Country}");
                                Console.WriteLine($"Phone: {customer.Phone}");
                                Console.WriteLine($"Fax: {customer.Fax}");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Error: ({ex.GetType().Name}): {ex.Message}");
                            }
                            break;

                        case 2:
                            try
                            {
                                ProductsLogic productsLogic = new ProductsLogic();
                                var products = productsLogic.ProductsWithNoStock();

                                Console.WriteLine("Products with no stock:");
                                foreach (var product in products)
                                {
                                    Console.WriteLine($"Product ID: {product.ProductID} - Product Name: {product.ProductName}");
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Error: ({ex.GetType().Name}): {ex.Message}");
                            }
                            break;

                        case 3:
                            try
                            {
                                ProductsLogic productsLogic = new ProductsLogic();
                                var products = productsLogic.ProductsWithStock();

                                Console.WriteLine("Products with stock and price over 3:");
                                foreach (var product in products)
                                {
                                    Console.WriteLine($"Product ID: {product.ProductID} - Product Name: {product.ProductName} - Unit Price: {product.UnitPrice} - Units In Stock: {product.UnitsInStock}");
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Error: ({ex.GetType().Name}): {ex.Message}");
                            }
                            break;

                        case 4:
                            try
                            {
                                CustomersLogic customersLogic = new CustomersLogic();
                                var customersInRegionWA = customersLogic.CustomersInRegionWA();

                                Console.WriteLine("Customers in Region WA:");
                                foreach (var customer in customersInRegionWA)
                                {
                                    Console.WriteLine($"ID: {customer.CustomerID} - Contact Name: {customer.ContactName} - Company Name: {customer.CompanyName} - Country: {customer.Country}");
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Error: ({ex.GetType().Name}): {ex.Message}");
                            }
                            break;

                        case 5:
                            try
                            {
                                ProductsLogic productsLogic = new ProductsLogic();
                                var productInfo = productsLogic.GetProductId(789);
                                Console.WriteLine(productInfo);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Error: ({ex.GetType().Name}): {ex.Message}");
                            }
                            break;

                        case 6:
                            try
                            {
                                CustomersLogic customersLogic = new CustomersLogic();
                                var customers = customersLogic.CustomerNamesUpperAndLower();

                                Console.WriteLine("Customer Names:");

                                foreach (var customer in customers)
                                {
                                    Console.WriteLine($"UpperCase: {customer.ToUpper()} - LowerCase: {customer.ToLower()} ");
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Error: ({ex.GetType().Name}): {ex.Message}");
                            }
                            break;

                        case 7:
                            try
                            {
                                CustomersLogic customersLogic = new CustomersLogic();
                                var customers = customersLogic.JoinCustomersFromWaAndOrderDate();

                                Console.WriteLine("Customers from Region WA with Orders after 1/1/1997:");

                                foreach (var customer in customers)
                                {
                                    Console.WriteLine($"Customer ID: {customer.CustomerID} - Contact Name: {customer.ContactName} - Company Name: {customer.CompanyName} - Country: {customer.Country}");
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Error: ({ex.GetType().Name}): {ex.Message}");
                            }
                            break;

                        case 8:
                            try
                            {
                                CustomersLogic customersLogic = new CustomersLogic();
                                var customers = customersLogic.First3CustomersFromWA();

                                Console.WriteLine("First three Customers from Region WA:");

                                foreach (var customer in customers)
                                {
                                    Console.WriteLine($"Customer ID: {customer.CustomerID} - Contact Name: {customer.ContactName} - Company Name: {customer.CompanyName} - Country: {customer.Country}");
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Error: ({ex.GetType().Name}): {ex.Message}");
                            }
                            break;

                        case 9:
                            try
                            {
                                ProductsLogic productsLogic = new ProductsLogic();
                                var products = productsLogic.GetProductsOrderedByName();

                                Console.WriteLine("Products Ordered by Name:");
                                foreach (var product in products)
                                {
                                    Console.WriteLine($"Product Name: {product.ProductName}");
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Error: ({ex.GetType().Name}): {ex.Message}");
                            }
                            break;

                        case 10:
                            try
                            {
                                ProductsLogic productsLogic = new ProductsLogic();
                                var products = productsLogic.GetProductsOrderedByUnitsInStockDesc();

                                Console.WriteLine("Products Ordered by Units in Stock descending:");
                                foreach (var product in products)
                                {
                                    Console.WriteLine($"Product Name: {product.ProductName} - Units In Stock: {product.UnitsInStock}");
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Error: ({ex.GetType().Name}): {ex.Message}");
                            }
                            break;

                        case 11:
                            try
                            {
                                CategoriesLogic categoriesLogic = new CategoriesLogic();
                                var differentsCategories = categoriesLogic.DifferentsCategories();

                                Console.WriteLine("Categories of Products:");
                                foreach (var category in differentsCategories)
                                {
                                    Console.WriteLine($"- {category}");
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Error: ({ex.GetType().Name}): {ex.Message}");
                            }
                            break;

                        case 12:
                            try
                            {
                                ProductsLogic productsLogic = new ProductsLogic();
                                var product = productsLogic.GetFirstProduct();

                                Console.WriteLine("First Product:");
                                Console.WriteLine($"Product Name: {product.ProductName} - Units In Stock: {product.UnitsInStock}");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Error: ({ex.GetType().Name}): {ex.Message}");
                            }
                            break;

                        //case 13:
                        //    try
                        //    {
                        //        OrdersLogic ordersLogic = new OrdersLogic();
                        //        var customersWithOrderCount = ordersLogic.GetCustomersWithOrderCount();

                        //        Console.WriteLine("Customers with Order Count:");
                        //        foreach (var customer in customersWithOrderCount)
                        //        {
                        //            Console.WriteLine($"Customer ID: {customer.CustomerID} - Contact Name: {customer.ContactName} - Order Count: {customer.OrderCount}");
                        //        }
                        //    }
                        //    catch (Exception ex)
                        //    {
                        //        Console.WriteLine($"Error: ({ex.GetType().Name}): {ex.Message}");
                        //    }
                        //    break;

                        case 14:
                            Console.WriteLine("Exiting the program...Good By, this was the last interactive menu in this lab :)");
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

                Console.WriteLine("Press any key to return to the menu");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
