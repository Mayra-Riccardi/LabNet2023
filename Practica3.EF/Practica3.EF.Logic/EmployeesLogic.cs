using Practica3.EF.Data;
using Practica3.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica3.EF.Logic
{
    public class EmployeesLogic : BaseLogic, ILogic<Employees>
    {

        public EmployeesLogic() : base() { }
        
        public List<Employees> GetAll()
        {
            return _context.Employees.ToList();
        }

        public Employees Insert(Employees employee)
        {
            try
            {
                _context.Employees.Add(employee);
                _context.SaveChanges();
                return employee;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while inserting the employee.", ex);
            }
        }

        public void Delete(int employeeId)
        {
            try
            {
                var employeeToDelete = _context.Employees.FirstOrDefault(e => e.EmployeeID == employeeId);

                if (employeeToDelete != null)
                {
                    _context.Employees.Remove(employeeToDelete);
                    _context.SaveChanges();
                }
                else
                {
                    throw new ArgumentException($"Employee with ID {employeeId} not found.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while deleting the employee.", ex);
            }
        }


    }
}
