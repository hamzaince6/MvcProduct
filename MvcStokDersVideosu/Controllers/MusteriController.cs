using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStokDersVideosu.Models.Entity;

namespace MvcStokDersVideosu.Controllers
{
    public class MusteriController : Controller
    {
        // GET: Musteri
        MvcDcStokEntities1 db = new MvcDcStokEntities1();
        public ActionResult Index()
        {
            var degerler = db.TBLMUSTERILER.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniMusteri()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniMusteri(TBLMUSTERILER p1)
        {
            db.TBLMUSTERILER.Add(p1);
            db.SaveChanges();
            return View();
        }
    }
}