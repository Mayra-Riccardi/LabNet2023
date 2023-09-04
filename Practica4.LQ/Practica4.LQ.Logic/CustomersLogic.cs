using Practica4.LQ.Data;
using Practica4.LQ.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace Practica4.LQ.Logic
{
    public class CustomersLogic : BaseLogic
    {

        public CustomersLogic() : base() { }

        public Customers CustomerObject()
        {
            var customer = _context.Customers.FirstOrDefault();

            if (customer == null)
            {
                throw new Exception("Customers not found");
            }

            return customer;
        }

        public List<Customers> CustomersInRegionWA()
        {
            var customersInRegionWA = _context.Customers.Where(customer => customer.Region == "WA").ToList();

            if (customersInRegionWA.Count == 0)
            {
                throw new Exception("No customers found in Region WA.");
            }

            return customersInRegionWA;
        }

        public List<string> CustomerNamesUpperAndLower()
        {
            return _context.Customers.Select(c => c.ContactName).ToList();
        }

        public List<Customers> JoinCustomersFromWaAndOrderDate()
        {
            var customersFromWAWithOrders = _context.Customers
                .Join(_context.Orders,
                    c => c.CustomerID,
                    o => o.CustomerID,
                    (customer, order) => new { Customer = customer, Order = order })
                .Where(co => co.Customer.Region == "WA" && co.Order.OrderDate > new DateTime(1997, 1, 1))
                .Select(co => co.Customer)
                .ToList();

            return customersFromWAWithOrders;
        }

        public List<Customers> First3CustomersFromWA()
        {
            var first3CustomersFromWA = _context.Customers.Where(c => c.Region == "WA").Take(3).ToList();

            return first3CustomersFromWA;
        }
        //public IEnumerable<CustomerWithOrdersInfo> CustomersWithOrders()
        //{
        //    var query = from customers in _context.Customers
        //                join orders in _context.Orders
        //                on customers.CustomerID equals orders.CustomerID into count
        //                select new CustomerWithOrdersInfo
        //                {
        //                    ID = customers.CustomerID,
        //                    ContactName = customers.ContactName,
        //                    OrdersQuantity = count.Count()
        //                };
        //    return query.ToList();
        //}
    }
}
