using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStokDersVideosu.Models.Entity;
using PagedList;


namespace MvcStokDersVideosu.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        MvcDcStokEntities1 db = new MvcDcStokEntities1();

        public ActionResult Index(int sayfa=1)
        {
            //var degerler = db.URUNLER.ToList();
            var degerler = db.URUNLER.ToList().ToPagedList(sayfa, 10);
            return View(degerler);
        }

        [HttpGet]
        public ActionResult UrunEkle()
        {
            List<SelectListItem> degerler = (from i in db.TBLKATEGORILER.ToList()
                select new SelectListItem
                {
                    Text = i.KATEGORIAD,
                    Value = i.KATEGORIID.ToString()
                }).ToList();
            ViewBag.dgr = degerler;
            return View();
        }

        [HttpPost]
        public ActionResult UrunEkle(URUNLER p1)
        {
            var ktgr = db.TBLKATEGORILER.Where(m => m.KATEGORIID == p1.TBLKATEGORILER.KATEGORIID).FirstOrDefault();
            p1.TBLKATEGORILER = ktgr;
            db.URUNLER.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult SIL(int id)
        {
            var urun = db.URUNLER.Find(id);
            db.URUNLER.Remove(urun);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunGetir(int id)
        {
            var urun = db.URUNLER.Find(id);
            List<SelectListItem> degerler = (from i in db.TBLKATEGORILER.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KATEGORIAD,
                                                 Value = i.KATEGORIID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View("UrunGetir",urun);
        }
        public ActionResult Guncelle(URUNLER p1)
        {
            //Ürün günceleme çalışmıyor id hatası var kontrol et.Ders 38 Hata.
            var urun = db.URUNLER.Find(p1.URUNID);
            urun.URUNAD = p1.URUNAD;
            urun.MARKA = p1.MARKA;
            urun.STOK = p1.STOK;
            urun.FIYAT = p1.FIYAT;
            //urun.URUNKATEGORI = p1.URUNKATEGORI;
            var ktgr = db.TBLKATEGORILER.Where(m => m.KATEGORIID == p1.TBLKATEGORILER.KATEGORIID).FirstOrDefault();
            urun.URUNKATEGORI = ktgr.KATEGORIID;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}