using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using SerwisAGD.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace SerwisAGD.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        /*
        public bool Login(UserModel mod, out string UserRole)
        {
            DapperORM.ConnectToDB();
            SqlCommand cmd = new SqlCommand("UserLogin");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Email", mod.Email);
            cmd.Parameters.AddWithValue("@Password", mod.Password);
            cmd.Connection = con;
            con.Open();
            
            UserRole = cmd.ExecuteNonQuery();
            con.Close();

            return !String.IsNullOrEmpty(userRole);





        }
        
    */

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("login", "login");
        }
    }
}