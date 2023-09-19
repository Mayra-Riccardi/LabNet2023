using Practica3.EF.Logic.DTO;
using System.Collections.Generic;

namespace Practica3.EF.Logic.Validators
{
    public class EmployeeValidator
    {
        public List<string> Validate(EmployeesDto employeeDto)
        {
            List<string> validationErrors = new List<string>();

            if (string.IsNullOrEmpty(employeeDto.FirstName) || string.IsNullOrEmpty(employeeDto.LastName) || string.IsNullOrEmpty(employeeDto.City) || string.IsNullOrEmpty(employeeDto.Country))
            {
                validationErrors.Add("First name, last name, City, and country are required.");
            }
            if (employeeDto.FirstName.Length < 3 & employeeDto.FirstName.Length > 0 || employeeDto.LastName.Length < 3 & employeeDto.LastName.Length > 0 || employeeDto.City.Length < 3 & employeeDto.City.Length > 0)
            {
                validationErrors.Add("First name, last name and city require at least 3 characters.");
            }
            if (employeeDto.Country.Length < 2 & employeeDto.Country.Length > 0)
            {
                validationErrors.Add("Country require at least 2 characters.");
            }
            if (employeeDto.FirstName.Length > 10 || employeeDto.LastName.Length > 15 || employeeDto.City.Length > 15 || employeeDto.Country.Length > 15)
            {
                validationErrors.Add("First name, last name, city and country can't exceed 15 characters.");
            }
            if (FindNumbers(employeeDto.FirstName) || FindNumbers(employeeDto.LastName) || FindNumbers(employeeDto.City) || FindNumbers(employeeDto.Country))
            {
                validationErrors.Add("First name, last name, city and country can't contain numbers.");
            }

            return validationErrors;
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

