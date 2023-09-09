using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Practica5.MVC.Models
{
    public class OrderView
    {
        public int Id { get; set; }
        public string ShipName { get; set; }
        public string ShipCity { get; set; }
        public string ShipCountry { get; set; }
    }
}