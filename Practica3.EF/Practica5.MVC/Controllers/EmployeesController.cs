using Practica3.EF.Logic;
using Practica3.EF.Logic.DTO;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Practica5.MVC.Controllers
{
    public class EmployeesController : Controller
    {
        // GET: Employees
        public ActionResult Index()
        {
            var logic = new EmployeesLogic();
            List<EmployeesDto> employeesDto = logic.GetAll();

            return View(employeesDto);
        }

//        public ActionResult Insert() 
//        {
//            return View();
//        }

//        [HttpPost]
//        public ActionResult Insert(EmployeesView employeesView) 
//        {
//            try 
//            {
            
//            }
//            catch(Exception ex) 
//            {
//                throw;
//            }
//        }
   }
}