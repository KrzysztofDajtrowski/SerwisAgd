using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SerwisAGD.Models;

namespace SerwisAGD.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(UserModel mod)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@Name", mod.Name);
            param.Add("@Surname", mod.Surname);
            param.Add("@PhoneNumber", mod.PhoneNumber);
            param.Add("@Email", mod.Email);
            param.Add("@City", mod.City);
            param.Add("@ZipCode", mod.ZipCode);
            param.Add("@Adress", mod.Adress);
            param.Add("@Password", mod.Password);
            DapperORM.ExecuteWithoutReturn("UserRegister", param);
            return RedirectToAction("Login", "Login");
        }
    }
}