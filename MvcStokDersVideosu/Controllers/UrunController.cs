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

            return View(degerler);
        }
    }
}