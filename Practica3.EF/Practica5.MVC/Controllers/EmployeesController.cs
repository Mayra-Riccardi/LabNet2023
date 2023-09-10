using Practica3.EF.Logic;
using Practica3.EF.Logic.DTO;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Practica5.MVC.Controllers
{
    public class EmployeesController : Controller
    {
        //Instancia de logic para poder trabajarlo a nivel general
        EmployeesLogic employeesLogic = new EmployeesLogic();

        // GET: Employees
        public ActionResult Index()
        {
            List<EmployeesDto> result = employeesLogic.GetAll();

            return View(result);
        }

        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(EmployeesDto employeesDto) 
        {
            try
            {
                EmployeesDto employeesEntityDto = new EmployeesDto
                {
                    FirstName = employeesDto.FirstName,
                    LastName = employeesDto.LastName,
                    City = employeesDto.City,
                    Country = employeesDto.Country
                };

                employeesLogic.Insert(employeesEntityDto);

                return RedirectToAction("Index");
            }
            catch (ArgumentException ex) 
            {
                ViewBag.ErrorMessage = ex.Message;
                return View(employeesDto);
            }
            catch (Exception ex) 
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "Error");
            }
        }

        //[HttpPut]
        //public ActionResult Update(EmployeesDto employeesDto)
        //{
        //    try
        //    {
        //        employeesLogic.Update(employeesDto); // Llamar a tu método de lógica para actualizar

        //        return RedirectToAction("Index");
        //    }
        //    catch (ArgumentException ex)
        //    {
        //        ViewBag.ErrorMessage = ex.Message;
        //        return View(employeesDto); // Vuelve a la vista de actualización con mensaje de error si es necesario
        //    }
        //    catch (Exception ex)
        //    {
        //        ViewBag.ErrorMessage = ex.Message;
        //        return RedirectToAction("Index", "Error"); // Redirige a la página de error en caso de error general
        //    }
        //}

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