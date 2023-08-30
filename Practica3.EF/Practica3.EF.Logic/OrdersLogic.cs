﻿using Practica3.EF.Data;
using Practica3.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica3.EF.Logic
{
    public class OrdersLogic : BaseLogic, ILogic<Orders>
    {

        public OrdersLogic() : base() { }

        public List<Orders> GetAll()
        {
            return _context.Orders.ToList();
        }
    }
}
