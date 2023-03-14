using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStokDersVideosu.Models.Entity;


namespace MvcStokDersVideosu.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        MvcDcStokEntities1 db = new MvcDcStokEntities1();
        public ActionResult Index()
        {
            var degerler = db.URUNLER.ToList();
            //ssasa
            return View(degerler);
        }
        [HttpGet]
        public ActionResult UrunEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UrunEkle(URUNLER p1)
        {
            db.URUNLER.Add(p1);
            db.SaveChanges();
            return View();
        }
            
    }
}