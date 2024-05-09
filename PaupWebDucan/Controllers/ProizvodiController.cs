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
        // GET: Proizvodi
        public ActionResult Index()
        {
            ViewBag.Title = "Početna stranica sa proizvodima";
            ViewBag.Trgovina = "Trgovina PAUP (Posebnih asortimana u prodaji)";
            return View();
        }

        public ActionResult PopisProizvoda()
        {
            ProizvodiDB proizvodidb = new ProizvodiDB();
            return View(proizvodidb);
        }

        public ActionResult Detalji(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("PopisProizvoda");
            }

            ProizvodiDB proizvodidb = new ProizvodiDB();

            Proizvod proizvod = proizvodidb.VratiListu().FirstOrDefault(x => x.SkladisniBroj == id);

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
            ProizvodiDB proizvodidb = new ProizvodiDB();

            Proizvod proizvod = proizvodidb.VratiListu().FirstOrDefault(x=>x.SkladisniBroj==id);

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
            if (!KontrolniBroj.ProvjeriKontrolniBroj(p.KontrolniBroj))
            {
                ModelState.AddModelError("Kontrolni broj", "Neispravan kontrolni broj.");
            }


            if(ModelState.IsValid)
            {
                ProizvodiDB proizvodidb = new ProizvodiDB();
                proizvodidb.AzurirajProizvod(p);
                return RedirectToAction("PopisProizvoda");
            }
            return View(p);
        }
    }
}