using Newtonsoft.Json;
using Practica5.MVC.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Mvc;

namespace Practica5.MVC.Controllers
{
    public class ApiController : Controller
    {
        // GET: Api
        public ActionResult Index()
        {
            try
            {
                var httpClient = new HttpClient();
                var json = httpClient.GetStringAsync("https://jsonplaceholder.typicode.com/users").Result;
                var users = JsonConvert.DeserializeObject<List<ApiUserView>>(json);

                return View(users);
            }
            catch (Exception ex)
            {
                return View(new List<ApiUserView>());
            }
        }
    }
}