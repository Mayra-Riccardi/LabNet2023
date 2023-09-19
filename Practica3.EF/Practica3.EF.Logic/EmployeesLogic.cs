using Practica3.EF.Entities;
using Practica3.EF.Logic.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using Practica3.EF.Logic.Validators;
using Practica3.EF.Logic.Utilities;

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


                if (existingEmployee != null)
                {
                    EmployeesDto employeesDto = new EmployeesDto
                    {
                        Id = existingEmployee.EmployeeID,
                        LastName = existingEmployee.LastName,
                        FirstName = existingEmployee.FirstName,
                        City = existingEmployee.City,
                        Country = existingEmployee.Country
                    };
                     return employeesDto;
                }
                else
                {
                    throw new InvalidOperationException($"Employee with ID: {employeeId} not found.");
                }
            }
            catch(InvalidOperationException ex)
            {
                throw ex;
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
                EmployeeValidator employeeValidator = new EmployeeValidator();
                List<string> validationErrors = employeeValidator.Validate(employeeDto);

                if (validationErrors.Count > 0)
                {
                    ValidationUtilities.ThrowValidationErrors(validationErrors);
                }

                var existingEmployee = _context.Employees.FirstOrDefault(e => e.FirstName == employeeDto.FirstName && e.LastName == employeeDto.LastName);

                if (existingEmployee != null)
                {
                    throw new ArgumentException("Ups, sorry! An employee with the provided first name and last name already exists in our records.");
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
                EmployeeValidator employeeValidator = new EmployeeValidator();
                List<string> validationErrors = employeeValidator.Validate(employeeDto);

                if (validationErrors.Count > 0)
                {
                    ValidationUtilities.ThrowValidationErrors(validationErrors);
                }

                var existingEmployee = _context.Employees.Find(employeeDto.Id);

                if (existingEmployee != null)
                {

                    var duplicateEmployee = _context.Employees .FirstOrDefault(
                        e => e.EmployeeID != employeeDto.Id && e.FirstName == employeeDto.FirstName && e.LastName == employeeDto.LastName);

                    if (duplicateEmployee != null)
                    {
                        throw new ArgumentException("Ups, sorry! You can't update the employee because the provided first name and last name already exist in our records.");
                    }

                    existingEmployee.FirstName = employeeDto.FirstName;
                    existingEmployee.LastName = employeeDto.LastName;
                    existingEmployee.City = employeeDto.City;
                    existingEmployee.Country = employeeDto.Country;

                    _context.SaveChanges();
                    return employeeDto;
                }
                else
                {
                    throw new InvalidOperationException($"Employee with ID {employeeDto.Id} not found.");
                }
            }
            catch (InvalidOperationException)
            {
                throw;
            }
            catch (ArgumentException)
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
                throw new InvalidOperationException($"Employee with ID {employeeId} not found.");
            }
            try
            {
                _context.Employees.Remove(employeeToDelete);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ups, sorry. You can´t delete this Employee.", ex);
            }
        }
    }
}

