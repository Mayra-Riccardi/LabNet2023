using Practica4.LQ.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica4.LQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomersLogic logic = new CustomersLogic();

            var customers = logic.GetAll();

            foreach ( var customer in customers ) 
            {
                Console.WriteLine(customer.ContactName);
            }
            Console.ReadLine();
        }
    }
}
