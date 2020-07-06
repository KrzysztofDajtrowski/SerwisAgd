﻿using Dapper;
using SerwisAGD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SerwisAGD.Controllers
{
    public class test_tableController : Controller
    {
        // GET: test_table
        public ActionResult Index()
        {
            return View(DapperORM.ReturnList<test_tableModels>("ViewAll", null));
        }
        [HttpGet]
        public ActionResult AddOrEdit(int id=0)
        {
            if (id == 0)
            {
                return View();
            }
            else
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@ID", id);
                return View(DapperORM.ReturnList<test_tableModels>("ViewById", param).FirstOrDefault<test_tableModels>());
            }
        }
        [HttpPost]
        public ActionResult AddOrEdit(test_tableModels tes)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@ID", tes.ID);
            param.Add("@Name", tes.Name);
            param.Add("@Surname", tes.Surname);
            DapperORM.ExecuteWithoutReturn("AddOrEdit", param);
            return RedirectToAction("index");
        }
        public ActionResult testDeleteById(int id)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@ID", id);
            DapperORM.ExecuteWithoutReturn("testDeleteById", param);
            return RedirectToAction("index");

        }
    }
}