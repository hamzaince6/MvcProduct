using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStokDersVideosu.Models.Entity;
using PagedList;
using PagedList.Mvc;



namespace MvcStokDersVideosu.Controllers
{
    public class MusteriController : Controller
    {
        // GET: Musteri
        MvcDcStokEntities1 db = new MvcDcStokEntities1();
        public ActionResult Index(int sayfa = 1)
        {

            //var degerler = db.TBLMUSTERILER.ToList();
            var degerler = db.TBLMUSTERILER.ToList().ToPagedList(sayfa, 10);
            return View(degerler);
        }
        
        public ActionResult YeniMusteri()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniMusteri(TBLMUSTERILER p1)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniMusteri");
            }
            db.TBLMUSTERILER.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Sil (int id)
        {
            var mstr = db.TBLMUSTERILER.Find(id);
            db.TBLMUSTERILER.Remove(mstr);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MusteriGetir(int id)
        {
            var mus = db.TBLMUSTERILER.Find(id);
            return View("MusteriGetir",mus);
        }
        public ActionResult Guncelle(TBLMUSTERILER p1)
        {
            var musteri = db.TBLMUSTERILER.Find(p1.MUSTERIID);
            musteri.MUSTERIAD = p1.MUSTERIAD;
            musteri.MUSTERISOYAD = p1.MUSTERISOYAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}