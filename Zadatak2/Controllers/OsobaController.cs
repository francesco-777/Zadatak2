using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zadatak2.Models;

namespace Zadatak2.Controllers
{
    public class OsobaController : Controller
    {
        public ActionResult UnosOsobe()
        {
            return View(new Osoba() { DatumRodjenja = DateTime.Today });
        }
        [HttpPost]
        public ActionResult ProvjeriOsobu(Osoba osoba)
        {
            if (string.IsNullOrEmpty(osoba.Ime))
            {
                ModelState.AddModelError("Ime", "Ime je obavezno!");
            }
            if (string.IsNullOrEmpty(osoba.Prezime))
            {
                ModelState.AddModelError("Prezime", "Prezime je obavezno!");
            }
            if (osoba.DatumRodjenja == DateTime.Today)
            {
                ModelState.AddModelError("DatumRodjenja", "Datum rođenja je obavezan!");
            }
            if (string.IsNullOrEmpty(osoba.Email))
            {
                ModelState.AddModelError("Email", "E-mail je obavezan!");
            }
            if (ModelState.IsValid)
            {
                return View("PregledOsobe", osoba);
            }
            else
            {
                return View("UnosOsobe", osoba);
            }
        }
    }
}