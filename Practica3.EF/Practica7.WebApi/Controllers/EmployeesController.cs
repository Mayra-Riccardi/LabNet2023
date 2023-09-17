using Practica3.EF.Logic;
using Practica3.EF.Logic.DTO;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Practica7.WebApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "GET,POST,PUT,DELETE,OPTIONS")]
    public class EmployeesController : ApiController
    {

        //GET api/Employees
        public IHttpActionResult Get()
        {
            try
            {
                var employeesLogic = new EmployeesLogic();

                List<EmployeesDto> employeesDto = employeesLogic.GetAll();

                return Content(HttpStatusCode.OK, employeesDto);
            }

            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, new { status = 404, message = ex.Message });

            }

        }


        //GET api/Employees/:id
        public IHttpActionResult Get(int id)
        {
            try
            {
                EmployeesLogic customerLogic = new EmployeesLogic();
                var employee = customerLogic.GetById(id);

                return Content(HttpStatusCode.OK, new { status = 200, employee });
            }

            catch (InvalidOperationException ex)
            {
                return Content(HttpStatusCode.NotFound, new { status = 404, message = ex.Message });
            }

            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, new { status = 500, message = ex.Message });
            }
        }


        // POST api/Employees ---- Post([FromBody] string value
        public IHttpActionResult Post([FromBody] EmployeesDto employeesDto)
        {
            try
            {
                EmployeesLogic employeesLogic = new EmployeesLogic();
                var insertedEmployee = employeesLogic.Insert(employeesDto);

                return Content(HttpStatusCode.Created, new { status = 201, message = "Employee created successfully", employee = insertedEmployee });
            }
            catch (ArgumentException ex)
            {
                return Content(HttpStatusCode.BadRequest, new { status = 400, message = ex.Message });
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, new { status = 500, message = ex.Message });
            }
        }


        // PUT api/Wmployees/:id ---- Put(int id[FromBody] string value
        //Le paso el id como parámetro en la Url, estoy mas acostumbrada asi, no se si es o no una buena practica, o es mejor pasarlo a través del body.
        public IHttpActionResult Put(int id, [FromBody] EmployeesDto employeesDto)
        {
            try
            {
                employeesDto.Id = id;//Me traigo el id que llega desde la url

                EmployeesLogic employeesLogic = new EmployeesLogic();
                var updatedEmployee = employeesLogic.Update(employeesDto);

                return Content(HttpStatusCode.OK, new { status = 200, message = "Employee updated successfully", employee = updatedEmployee });
            }
            catch (InvalidOperationException ex)
            {
                return Content(HttpStatusCode.NotFound, new { status = 404, message = ex.Message });
            }
            catch (ArgumentException ex)
            {
                return Content(HttpStatusCode.BadRequest, new { status = 400, message = ex.Message });
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, new { status = 500, message = ex.Message });
            }
        }


        //Delete api/Employees/:id
        public IHttpActionResult Delete(int id)
        {
            try
            {
                EmployeesLogic employeesLogic = new EmployeesLogic();
                employeesLogic.Delete(id);

                return Content(HttpStatusCode.OK, new { status = 200, message = $"Employee with ID {id}, successfully deleted" });

            }
            catch (InvalidOperationException ex)
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
