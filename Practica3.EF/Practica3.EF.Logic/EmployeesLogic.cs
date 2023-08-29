using Practica3.EF.Data;
using Practica3.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica3.EF.Logic
{
    public class EmployeesLogic
    {
        private NorthwindContext _context;

        public EmployeesLogic()
        {
            _context = new NorthwindContext();
        }


        public List<Employees> GetAll()
        {
            return _context.Employees.ToList();
        }

        public Employees GetById(int employeeId)
        {
            return _context.Employees.FirstOrDefault(e => e.EmployeeID == employeeId);
        }

    }
}
