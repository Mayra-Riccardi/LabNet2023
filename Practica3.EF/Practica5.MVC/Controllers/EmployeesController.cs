using Practica3.EF.Logic;
using Practica3.EF.Logic.DTO;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Practica5.MVC.Controllers
{
    public class EmployeesController : Controller
    {
        //Instancia de logic para poder trabajarlo a nivel general, sino tenia que estar instanciando una y otra vez
        EmployeesLogic employeesLogic = new EmployeesLogic();

        // GET: Employees
        public ActionResult Index()
        {
            List<EmployeesDto> result = employeesLogic.GetAll();

            return View(result);
        }

        //Insert
        public ActionResult Insert()
        {
            ViewData["Action"] = "Insert";
            ViewData["IsInsert"] = true; // Indico que es una inserción
            return View("InsertOrUpdate");
        }

        [HttpPost]
        public ActionResult Insert(EmployeesDto employeeDto)
        {
            try
            {
                EmployeesDto employeeEntityDto = new EmployeesDto
                {
                    FirstName = employeeDto.FirstName,
                    LastName = employeeDto.LastName,
                    City = employeeDto.City,
                    Country = employeeDto.Country
                };

                employeesLogic.Insert(employeeEntityDto);

                return RedirectToAction("Index"); ;
            }
            catch (ArgumentException ex)
            {
                return Json(new { success = false, errorMessage = ex.Message });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, errorMessage = ex.Message });
            }
        }

            //Update
            [HttpGet]
        public ActionResult Update()
        {
            ViewData["Action"] = "Update";
            ViewData["IsInsert"] = false; // Indico que es una actualización
            return View("InsertOrUpdate");
        }

        //Update probando Fetch
        [HttpPost]
        public ActionResult Update(EmployeesDto employeeDto)
        {
            try
            {
                employeesLogic.Update(employeeDto);

                return Json(new { success = true });
            }
            catch (ArgumentException ex)
            {
                return Json(new { success = false, errorMessage = ex.Message });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, errorMessage = ex.Message });
            }
        }

        //Delete probando Fetch
        public ActionResult Delete(int employeeId)
        {
            try 
            {
                bool result = employeesLogic.Delete(employeeId);
                return Json(new { success = result });
            }
            catch (ArgumentException ex) 
            {
                return Json(new { success = false, errorMessage = ex.Message });
            }
            catch (Exception ex) 
            {
                return Json(new { success = false, errorMessage = ex.Message });
            }
        }

    }
}