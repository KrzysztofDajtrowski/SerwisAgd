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
        public ActionResult ViewOrderState()
        {
            return View(objmajorkupricz_SerwisAGDEntities.Order.ToList());
        }
        
        public ActionResult ChangeOrderState(string state)
        {
            var ord = objmajorkupricz_SerwisAGDEntities.Order.FirstOrDefault(c => c.OrderState == state);
            
            ord.OrderState = state;
            objmajorkupricz_SerwisAGDEntities.SaveChanges();
            return RedirectToAction("ViewOrderState", "Order");
        }
        public ActionResult DeleteOrder(int id)
        {

            var order = objmajorkupricz_SerwisAGDEntities.Order.FirstOrDefault(c => c.OrderID == id);


            objmajorkupricz_SerwisAGDEntities.Order.Remove(order);
            objmajorkupricz_SerwisAGDEntities.SaveChanges();
            return RedirectToAction("index", "Home");
        }
        
        public ActionResult MyOrder()
        {
            return View(objmajorkupricz_SerwisAGDEntities.Order.ToList().Where(c => c.UserID == Convert.ToInt32(Session["UserID"])));
        }
    }
}