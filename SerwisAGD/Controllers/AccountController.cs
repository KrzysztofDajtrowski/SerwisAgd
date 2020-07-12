﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SerwisAGD.Models;
using System.Data.Entity;

namespace SerwisAGD.Controllers
   
{
    public class AccountController : Controller
    {
        majorkupricz_SerwisAGDEntities objmajorkupricz_SerwisAGDEntities = new majorkupricz_SerwisAGDEntities();
        // GET: Account
        public ActionResult Index()
        {
            return View();
            
        }
        public ActionResult Register()
        {
            UserModel objUserModel = new UserModel();
            return View(objUserModel);
        }
        [HttpPost]
        public ActionResult Register(UserModel objUserModel)
        {
            if(ModelState.IsValid)
            { 
            User objUser = new User();
            objUser.Name = objUserModel.Name;
            objUser.Surname = objUserModel.Surname;
            objUser.PhoneNumber = objUserModel.PhoneNumber;
            objUser.Email = objUserModel.Email;
            objUser.City = objUserModel.City;
            objUser.ZipCode = objUserModel.ZipCode;
            objUser.Adress= objUserModel.Adress;
            objUser.Password = objUserModel.Password;
            //objUser.UserRole = String("0");
            objmajorkupricz_SerwisAGDEntities.User.Add(objUser);
            objmajorkupricz_SerwisAGDEntities.SaveChanges();
            return RedirectToAction("Login", "Account");
            }
            else
            {
                return View();
            }
        }

        //Login
        public ActionResult Login()
        {
            LoginModel objLoginModel = new LoginModel();
            return View(objLoginModel);
        }
        [HttpPost]
        public ActionResult Login(LoginModel objLoginModel)
        {
            if (ModelState.IsValid)
            {
                if(objmajorkupricz_SerwisAGDEntities.User.Where(m=>m.Email == objLoginModel.Email && m.Password == objLoginModel.Password).FirstOrDefault() == null)
                {
                    ModelState.AddModelError("Error", "Błędny Email lub hasło");
                    return View();
                }
                else
                {
                    Session["Email"] = objLoginModel.Email;
                    Session["UserRole"] = objLoginModel.UserRole;
                    RedirectToAction("Index","Home");
                }
                
            }
            return View();
        }
        /*
        [HttpPost]
        public ActionResult Login(UserModel user)
        {
            using(OurDbContext db = new OurDbContext())
            {
                var usr = db.userAccount.Single(u => u.Email == user.Email && u.Password == user.Password);
                if(usr != null)
                {
                    Session["UserID"] = usr.UserID.ToString();
                    return RedirectToAction("LoggedIn");
                }
                else
                {
                    ModelState.AddModelError("", "Błędny Email lub hasło");
                }
            }
            return View();
        }
        */
        /*
        [HttpPost]
        public ActionResult Register(UserModel account)
        {
            if (ModelState.IsValid)
            {
                using(OurDbContext db = new OurDbContext())
                {
                    db.userAccount.Add(account);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = account.Name+ " "+account.Surname+ " pomyślnie zarejestrowany";
            }
            return View();
        }
        */
        /*
        public ActionResult LoggedIn()
        {
            if (Session["UserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        */
    }
}