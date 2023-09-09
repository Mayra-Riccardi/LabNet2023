using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Practica5.MVC.Models
{
    public class EmployeesView
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}