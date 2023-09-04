using Practica4.LQ.Data;
using Practica4.LQ.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica4.LQ.Logic
{
    public class CustomersLogic : BaseLogic
    {

        public CustomersLogic() : base() { }

        public List<Customers> GetAll()
        {
           return _context.Customers.ToList();
        }
    }
}
