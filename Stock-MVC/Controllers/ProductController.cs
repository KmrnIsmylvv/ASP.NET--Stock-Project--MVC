using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Stock_MVC.Models.Entity;
namespace Stock_MVC.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        StockProjectMVCEntities db = new StockProjectMVCEntities();
        public ActionResult Index()
        {
            var deyerler = db.TBL_MEHSULLAR.ToList();
            return View(deyerler);
        }

        [HttpGet]
        public ActionResult YeniMehsul()
        {
            List<SelectListItem> deyerler = (from i in db.TBL_KATEQORIYALAR.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KATEQORIYAAD,
                                                 Value = i.KATEQORIYAID.ToString()
                                             }).ToList();
            ViewBag.dgr = deyerler;

            return View();
        }

        [HttpPost]
        public ActionResult YeniMehsul(TBL_MEHSULLAR p1)
        {
            db.TBL_MEHSULLAR.Add(p1);
            db.SaveChanges();
            return View();
        }
    }
}