using Practica3.EF.Logic;
using Practica5.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practica5.MVC.Controllers
{
    public class OrdersController : Controller
    {
        // GET: Orders
        public ActionResult Index()
        {
            var logic = new OrdersLogic();
            List<Practica3.EF.Entities.Orders> orders = logic.GetAll();

            List<OrderView> orderView = orders.Select(s => new OrderView
            {
                Id = s.OrderID,
                ShipName = s.ShipName,
                ShipCity = s.ShipCity,
                ShipCountry = s.ShipCountry,
            }).ToList();
            return View(orderView);
        }
    }
}