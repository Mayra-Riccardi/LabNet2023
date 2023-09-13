using Practica3.EF.Entities;
using Practica3.EF.Logic.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Practica3.EF.Logic
{
    public class EmployeesLogic : BaseLogic, ILogic<EmployeesDto>
    {
        public EmployeesLogic() : base() { }
        
        public List<EmployeesDto> GetAll()
        {
            IEnumerable<Employees> employees = _context.Employees.AsEnumerable();
            List<EmployeesDto> result = employees.Select(e => new EmployeesDto
            {
                Id = e.EmployeeID,
                LastName = e.LastName,
                FirstName = e.FirstName,
                City = e.City,
                Country = e.Country,
            }).ToList();

            return result;
        }

        public EmployeesDto GetById(int employeeId) 
        {
           try
            {
                var existingEmployee = _context.Employees.Find(employeeId);


                if (existingEmployee == null)
                {
                    return null;
                }

                EmployeesDto employeesDto = new EmployeesDto
                {
                    Id = existingEmployee.EmployeeID,
                    LastName = existingEmployee.LastName,
                    FirstName = existingEmployee.FirstName,
                    City = existingEmployee.City,
                    Country = existingEmployee.Country,
                };

                return employeesDto;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred", ex);
            }
        }

        public EmployeesDto Insert(EmployeesDto employeeDto)
        {
            try
            {
                Validate(employeeDto);

                var existingEmployee = _context.Employees.FirstOrDefault(e => e.FirstName == employeeDto.FirstName && e.LastName == employeeDto.LastName);

                if (existingEmployee != null)
                {
                    throw new ArgumentException("Employee with the first name and last name you provide already exists.");
                }

                var newEmployee = new Employees
                {
                    FirstName = employeeDto.FirstName,
                    LastName = employeeDto.LastName,
                    City = employeeDto.City,
                    Country = employeeDto.Country
                };

                _context.Employees.Add(newEmployee);

                _context.SaveChanges();

                //Hago esto para poder enviar como respuesta json en el controller el nuevo Id generado, sino me lo mostraba como cero, no mostraba el id creado por la db
                employeeDto.Id = newEmployee.EmployeeID;// le asigno el nuevo id generado en la db al employeeDto

                return employeeDto;
            }
            catch (ArgumentException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while inserting the employee.", ex);
            }
        }
        public EmployeesDto Update(EmployeesDto employeeDto)
        {
            try
            {
                Validate(employeeDto);

                var existingEmployee = _context.Employees.Find(employeeDto.Id);

                if (existingEmployee != null)
                {
                    existingEmployee.FirstName = employeeDto.FirstName;
                    existingEmployee.LastName = employeeDto.LastName;
                    existingEmployee.City = employeeDto.City;
                    existingEmployee.Country = employeeDto.Country;

                    _context.SaveChanges();
                    return employeeDto;
                }
                else
                {
                    throw new ArgumentException($"Employee with ID {employeeDto.Id} not found.");
                }
            }
            catch(ArgumentException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating the employee.", ex);
            }
        }

        public bool Delete(int employeeId)
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
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("The employee could not be deleted due to database conditions.", ex);
            }
        }

        public void Validate(EmployeesDto employeeDto)
        {
            if (string.IsNullOrEmpty(employeeDto.FirstName) || string.IsNullOrEmpty(employeeDto.LastName) || string.IsNullOrEmpty(employeeDto.City) || string.IsNullOrEmpty(employeeDto.Country))
            {
                throw new ArgumentException("First name, last name, City, and country are required.");
            }
            if (employeeDto.FirstName.Length < 3 || employeeDto.LastName.Length < 3 || employeeDto.City.Length < 3)
            {
                throw new ArgumentException("First name, last name and city requires at least 3 characters");
            }
            if (employeeDto.FirstName.Length > 10 || employeeDto.LastName.Length > 10 || employeeDto.City.Length > 10 || employeeDto.Country.Length > 10)
            {
                throw new ArgumentException("First name, last name, city and country can't exceed 10 characters");
            }
            if (FindNumbers(employeeDto.FirstName) || FindNumbers(employeeDto.LastName) || FindNumbers(employeeDto.City) || FindNumbers(employeeDto.Country))
            {
                throw new ArgumentException("First name, last name, city and country can´t contains numbers");
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

