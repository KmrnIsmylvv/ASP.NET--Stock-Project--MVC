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
            var ktg = db.TBL_KATEQORIYALAR.Where(m => m.KATEQORIYAID == p1.TBL_KATEQORIYALAR.KATEQORIYAID).FirstOrDefault();
            p1.TBL_KATEQORIYALAR = ktg;
            db.TBL_MEHSULLAR.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult SIL(int id)
        {
            var mehsul = db.TBL_MEHSULLAR.Find(id);
            db.TBL_MEHSULLAR.Remove(mehsul);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult MehsulGetir(int id)
        {
            var mehsul = db.TBL_MEHSULLAR.Find(id);

            List<SelectListItem> deyerler = (from i in db.TBL_KATEQORIYALAR.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KATEQORIYAAD,
                                                 Value = i.KATEQORIYAID.ToString()
                                             }).ToList();
            ViewBag.dgr = deyerler;

            return View("MehsulGetir", mehsul);
        }

        public ActionResult Guncelle(TBL_MEHSULLAR p)
        {
            var mehsul = db.TBL_MEHSULLAR.Find(p.MEHSULID);
            mehsul.MEHSULAD = p.MEHSULAD;
            mehsul.MARKA = p.MARKA;
            mehsul.STOK = p.STOK;
            mehsul.QIYMET = p.QIYMET;
           // mehsul.MEHSULKATEQORIYA = p.MEHSULKATEQORIYA;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}