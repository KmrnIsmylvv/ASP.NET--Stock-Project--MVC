using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Stock_MVC.Models.Entity;
namespace Stock_MVC.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category

        StockProjectMVCEntities db = new StockProjectMVCEntities();
        public ActionResult Index()
        {
            var deyerler = db.TBL_KATEQORIYALAR.ToList();
            return View(deyerler);
        }
    }
}