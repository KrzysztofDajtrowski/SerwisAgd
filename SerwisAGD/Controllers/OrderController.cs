using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SerwisAGD.Models;
namespace SerwisAGD.Controllers
{
    public class OrderController : Controller
    {
        majorkupricz_SerwisAGDEntities objmajorkupricz_SerwisAGDEntities = new majorkupricz_SerwisAGDEntities();
        // GET: Order
        public ActionResult Oder()
        {
            OrderModel objOrderModel = new OrderModel();
            return View(objOrderModel);
            
        }
        public ActionResult Order(OrderModel objOrderModel)
        {
            if (ModelState.IsValid)
            {
              
                Order objOrder = new Order();
                objOrder.OrderName = objOrderModel.OrderName;
                objOrder.OrderDescryption = objOrderModel.OrderDescryption;
                objOrder.UserID = Convert.ToInt32(Session["UserID"]);
                objOrder.OrderState = "Oczekuje";
                objOrder.OrderDate = DateTime.Now;
                objmajorkupricz_SerwisAGDEntities.Order.Add(objOrder);
                objmajorkupricz_SerwisAGDEntities.SaveChanges();
                return RedirectToAction("Order", "Order");
            }
            else
            {
                return View();
            }
        }
    }
}