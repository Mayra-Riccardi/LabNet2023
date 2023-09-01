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
                Validate(employee);

                _context.Employees.Add(employee);

                _context.SaveChanges();

                return employee;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while inserting the employee.", ex);
            }
        }

        public Employees Update(Employees employee)
        {
            try
            {
                Validate(employee);
                var existingEmployee = _context.Employees.Find(employee.EmployeeID);

                existingEmployee.FirstName = employee.FirstName;
                existingEmployee.LastName = employee.LastName;
                existingEmployee.Country = employee.Country;

                _context.SaveChanges();
                return existingEmployee;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating the employee.", ex);
            }

        }

        public void Delete(int employeeId)
        {
            var employeeToDelete = _context.Employees.FirstOrDefault(e => e.EmployeeID == employeeId);
            if (employeeToDelete == null)
            {
                throw new ArgumentException($"Employee with ID {employeeId} not found.");
            }
            try
            {
                _context.Employees.Remove(employeeToDelete);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while deleting the employee.", ex);
            }
        }

        public void Validate(Employees employee)
        {
            if (string.IsNullOrEmpty(employee.FirstName) || string.IsNullOrEmpty(employee.LastName) || string.IsNullOrEmpty(employee.Country))
            {
                throw new ArgumentException("First name, last name, and country are required.");
            }
            if (employee.FirstName.Length < 3 || employee.LastName.Length < 3 || employee.Country.Length < 3)
            {
                throw new ArgumentException("First name, last name and country requires at least 3 characters");
            }
            if (FindNumbers(employee.FirstName) || FindNumbers(employee.LastName) || FindNumbers(employee.Country))
            {
                throw new ArgumentException("First name, last name and country can´t contains numbers");
            }
        }

        private bool FindNumbers(string text)
        {
            foreach (char c in text)
            {
                if (char.IsDigit(c))
                {
                    return true;
                }
            }
            return false;
        }
    }
}

