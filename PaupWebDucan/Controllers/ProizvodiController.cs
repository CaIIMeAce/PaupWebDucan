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
            ViewBag.Skladiste = "Skladiste PAUP (Posebnih asortimana u prodaji)";
            return View();
        }

        //Popis
        public ActionResult PopisProizvoda(string naziv, string ostecen)
        {
            var proizvodi = bazaPodataka.PopisProizvodaBaze.ToList();

            if (!string.IsNullOrWhiteSpace(naziv))
            {
                proizvodi = proizvodi.Where(x=> x.ImeKontrolniBroj.ToUpper().Contains(naziv.ToUpper())).ToList();
            }
            if (!string.IsNullOrWhiteSpace(ostecen))
            {
                proizvodi = proizvodi.Where(x => x.Ostecen == ostecen).ToList();
            }

            if (proizvodi.Count == 0)
            {
                ViewBag.Poruka = "Nema rezultata pretraživanja.";
            }
            else
            {
                ViewBag.Poruka = string.Empty;
            }
            return View(proizvodi);
        }


        //Detalji
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


        //Azuriraj
        public ActionResult Azuriraj(int? id)
        {
            Proizvod proizvod = null;

            if(!id.HasValue)
            {
                proizvod = new Proizvod();
                ViewBag.Title = "Unos novog proizvoda";
                ViewBag.NoviProizvod = true;
            }
            else
            {
                proizvod = bazaPodataka.PopisProizvodaBaze.FirstOrDefault(x => x.SkladisniBroj == id);
                //ako u listi nema proizvoda sa trazenim skladisnim brojem onda je varijabla Skladisni broj null
                if (proizvod == null)
                {
                    return HttpNotFound();
                }
                ViewBag.Title = "Ažuriranje podataka o proizvodu";
                ViewBag.NoviProizvod = false;
            }
            return View(proizvod);


        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Azuriraj(Proizvod p)
        {
            //Validacija kontrolnog broja
            if (!KontrolniBroj.JeValidanKontrolniBroj(p.KontrolniBroj))
            {
                ModelState.AddModelError("Kontrolni broj", "Neispravan kontrolni broj.");
            }
            //Kraj validacije



            if (ModelState.IsValid)
            {
                if(p.SkladisniBroj != 0)
                {
                    bazaPodataka.Entry(p).State = System.Data.Entity.EntityState.Modified;
                }
                else
                {
                    bazaPodataka.PopisProizvodaBaze.Add(p);
                }
                bazaPodataka.SaveChanges();

                return RedirectToAction("PopisProizvoda");
            }

            if(p.SkladisniBroj == 0)
            {
                ViewBag.Title = "Unos novog proizvoda";
                ViewBag.NoviProizvod = true;
            }
            else
            {
                ViewBag.Title = "Ažuriranje podataka o proizvodu";
                ViewBag.NoviProizvod = false;
            }
            return View(p);
        }




        //Brisi
        public ActionResult Brisi(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("PopisProizvoda");
            }
            Proizvod p = bazaPodataka.PopisProizvodaBaze.FirstOrDefault(x => x.SkladisniBroj == id);

            if(p == null)
            {
                return HttpNotFound();
            }
            ViewBag.Title = "Potvrda brisanja proizvoda";
            return View(p);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Brisi(int id)
        {
            Proizvod p = bazaPodataka.PopisProizvodaBaze.FirstOrDefault(x => x.SkladisniBroj == id);
            if (p == null)
            {
                return HttpNotFound();
            }

            bazaPodataka.PopisProizvodaBaze.Remove(p);
            bazaPodataka.SaveChanges();

            return View("BrisiStatus");
        }
    }
}