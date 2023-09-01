using Microsoft.VisualStudio.TestTools.UnitTesting;
using Practica3.EF.Entities;
using Practica3.EF.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica3.EF.Logic.Tests
{
    [TestClass()]
    public class EmployeesLogicTests
    {

        [TestMethod()]
        public void ValidateEmployeeName()
        {
            // Arrange
            EmployeesLogic employeesLogic = new EmployeesLogic();
            Employees validEmployee = new Employees
            {
                FirstName = "Mayra",
                LastName = "Ric",
                Country = "ARG"
            };
            // Act
            try
            {
                employeesLogic.Validate(validEmployee);
            }

            //Assert
            catch (Exception ex)
            {
                Assert.Fail($"Validation failed with exception: {ex.Message}");
            }
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void Validate_InvalidFirstName()
        {
            // Arrange
            EmployeesLogic employeesLogic = new EmployeesLogic();
            Employees invalidEmployee = new Employees
            {
                FirstName = "M",
                LastName = "Riccardi",
                Country = "ARG"
            };

            // Act
            employeesLogic.Validate(invalidEmployee);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void Validate_InvalidLastName()
        {
            // Arrange
            EmployeesLogic employeesLogic = new EmployeesLogic();
            Employees invalidEmployee = new Employees
            {
                FirstName = "Mayra",
                LastName = "R", 
                Country = "ARG"
            };

            // Act
            employeesLogic.Validate(invalidEmployee);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void Validate_InvalidCountry()
        {
            // Arrange
            EmployeesLogic employeesLogic = new EmployeesLogic();
            Employees invalidEmployee = new Employees
            {
                FirstName = "Mayra",
                LastName = "Riccardi",
                Country = "A" 
            };

            // Act
            employeesLogic.Validate(invalidEmployee);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void Validate_NameContainsNumbers()
        {
            // Arrange
            EmployeesLogic employeesLogic = new EmployeesLogic();
            Employees invalidEmployee = new Employees
            {
                FirstName = "Mayra",
                LastName = "Riccardi1",
                Country = "Argentina"
            };

            // Act
            employeesLogic.Validate(invalidEmployee);
        }
    }
}