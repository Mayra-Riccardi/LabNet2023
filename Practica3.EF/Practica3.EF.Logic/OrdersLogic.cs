﻿using Practica3.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Practica3.EF.Logic
{
    public class OrdersLogic : BaseLogic, ILogic<Orders>
    {

        public OrdersLogic() : base() { }

        public List<Orders> GetAll()
        {
            return _context.Orders.ToList();
        }

        public Orders Insert(Orders value)
        {
            throw new NotImplementedException();
        }

        public Orders Update(Orders t)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Orders GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
