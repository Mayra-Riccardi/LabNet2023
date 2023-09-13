using Practica3.EF.Logic;
using Practica3.EF.Logic.DTO;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;

namespace Practica7.WebApi.Controllers
{
    public class EmployeesController : ApiController
    {

        //Get: Employees
        public IHttpActionResult Get()
        {
            try
            {
                var employeesLogic = new EmployeesLogic();

                List<EmployeesDto> employeesDto = employeesLogic.GetAll();

                return Content(HttpStatusCode.OK, new { status = 200, employeesDto });
            }

            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, new { status = 404, message = ex.Message });

            }

        }

        //GET api/values/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                EmployeesLogic customerLogic = new EmployeesLogic();
                var employee = customerLogic.GetById(id);

                if (employee == null)
                {
                    return Content(HttpStatusCode.NotFound, new { status = 404, message = $"Employee with ID {id} not found." });
                }

                return Content(HttpStatusCode.OK, new { status = 200, employee });
            }
     
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, new { status = 500, message = ex.Message });
            }
        }

        //Delete api/values/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                EmployeesLogic employeesLogic = new EmployeesLogic();
                employeesLogic.Delete(id);
                return Content(HttpStatusCode.OK, new { status = 200, message = $"Employee with ID {id}, successfully deleted" });
              
            
            }
            catch (ArgumentException ex)
            {
                return Content(HttpStatusCode.NotFound, new { status = 404, ex.Message });
            }
            catch(Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, new {  status= 500, message = ex.Message });
            }

        }
    }

}
