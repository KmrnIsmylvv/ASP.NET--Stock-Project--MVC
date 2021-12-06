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

        [HttpGet]
        public ActionResult YeniKateqoriya()
        {
            return View();
        }



        [HttpPost]
        public ActionResult YeniKateqoriya(TBL_KATEQORIYALAR p1)
        {
            db.TBL_KATEQORIYALAR.Add(p1);
            db.SaveChanges();
            return View();
        }

        public ActionResult SIL(int id)
        {
            var kateqoriya = db.TBL_KATEQORIYALAR.Find(id);
            db.TBL_KATEQORIYALAR.Remove(kateqoriya);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}