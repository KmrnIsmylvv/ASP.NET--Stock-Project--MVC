﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Stock_MVC.Models.Entity;

namespace Stock_MVC.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        StockProjectMVCEntities db = new StockProjectMVCEntities();
        public ActionResult Index()
        {
            var deyerler = db.TBL_MUSTERILER.ToList();
            return View(deyerler);
        }
    }
}