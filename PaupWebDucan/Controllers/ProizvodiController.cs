using PaupWebDucan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace PaupWebDucan.Controllers
{
    public class ProizvodiController : Controller
    {
        BazaDbContext bazaPodataka = new BazaDbContext();
        // GET: Proizvodi
        public ActionResult Index()
        {
            ViewBag.Title = "Početna stranica sa proizvodima";
            ViewBag.Trgovina = "Trgovina PAUP (Posebnih asortimana u prodaji)";
            return View();
        }

        public ActionResult PopisProizvoda()
        {
            var proizvodi = bazaPodataka.PopisProizvodaBaze.ToList();

            return View(proizvodi);
        }

        public ActionResult Detalji(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("PopisProizvoda");
            }

            Proizvod proizvod = bazaPodataka.PopisProizvodaBaze.FirstOrDefault(x => x.SkladisniBroj == id);

            if (proizvod == null)
            {
                return RedirectToAction("PopisProizvoda");
            }
            return View(proizvod);
        }

        public ActionResult Azuriraj(int? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Proizvod proizvod = bazaPodataka.PopisProizvodaBaze.FirstOrDefault(x => x.SkladisniBroj == id);

            if (proizvod == null)
            {
                return HttpNotFound();
            }
            return View(proizvod);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Azuriraj(Proizvod p)
        {
            if (!KontrolniBroj.JeValidanKontrolniBroj(p.KontrolniBroj))
            {
                ModelState.AddModelError("Kontrolni broj", "Neispravan kontrolni broj.");
            }


            if(ModelState.IsValid)
            {
                bazaPodataka.Entry(p).State = System.Data.Entity.EntityState.Modified;
                bazaPodataka.SaveChanges();
                return RedirectToAction("PopisProizvoda");
            }
            return View(p);
        }
    }
}