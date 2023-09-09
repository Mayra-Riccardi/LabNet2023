using Practica3.EF.Logic;
using Practica5.MVC.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Practica5.MVC.Controllers
{
    public class EmployeesController : Controller
    {
        // GET: Employees
        public ActionResult Index()
        {
            {
                var logic = new EmployeesLogic();
                List<Practica3.EF.Entities.Employees> employees = logic.GetAll();

                List<EmployeesView> employeesViews = employees.Select(s => new EmployeesView
                {
                    Id = s.EmployeeID,
                    LastName = s.LastName,
                    FirstName = s.FirstName,
                    City = s.City,
                    Country = s.Country,
                }).ToList();

                return View(employeesViews);
            }
        }
    }
}