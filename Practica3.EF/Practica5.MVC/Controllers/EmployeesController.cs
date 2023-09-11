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
            return View();
        }

        [HttpPost]
        public ActionResult Insert(EmployeesDto employeeDto) 
        {
            try
            {
                EmployeesDto employeesEntityDto = new EmployeesDto
                {
                    FirstName = employeeDto.FirstName,
                    LastName = employeeDto.LastName,
                    City = employeeDto.City,
                    Country = employeeDto.Country
                };

                employeesLogic.Insert(employeesEntityDto);

                return RedirectToAction("Index");
            }
            catch (ArgumentException ex) 
            {
                ViewBag.ErrorMessage = ex.Message;
                return View(employeeDto);
            }
            catch (Exception ex) 
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "Error");
            }
        }

        //Update
        [HttpGet]
        public ActionResult Update()
        {
            return View();
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