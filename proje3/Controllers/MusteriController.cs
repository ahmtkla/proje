using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using proje3.Models.Entity;

namespace proje3.Controllers
{
    public class MusteriController : Controller
    {
        // GET: Musteri
        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult Index()
        {
            var degerler = db.TBLMUSTERİLER.ToList();
            return View(degerler);
        }   
        [HttpGet]
        public ActionResult YeniMusteri()
        {
            return View();
        }
    [HttpPost]
    public ActionResult YeniMusteri(TBLMUSTERİLER p1)
        {
            db.TBLMUSTERİLER.Add(p1);
            db.SaveChanges();
            return View();
        }
        public ActionResult SIL(int id)
        {
            var musteri = db.TBLMUSTERİLER.Find(id);
            db.TBLMUSTERİLER.Remove(musteri);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MusteriGetir(int id)
        {
            var mus = db.TBLMUSTERİLER.Find(id);
            return View("MusteriGetir", mus);
        }
        public ActionResult Guncelle(TBLMUSTERİLER p1)
        {
            var musteri = db.TBLMUSTERİLER.Find(p1.MUSTERIIDA);
            musteri.MUSTERİAD = p1.MUSTERİAD;
            musteri.MUSTERİSOYAD = p1.MUSTERİSOYAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}