using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using polozi_ba.Data;
using polozi_ba.Data.Models;

namespace polozi_ba.Controllers
{
    public class PredmetController : Controller
    {
        private readonly IPredmet _predmetService;

        public PredmetController(IPredmet predmetService)
        {
            _predmetService = predmetService;
        }


        public IActionResult Index()
        {
            var model = _predmetService.SviPredmeti();
            return View(model);
        }

        public ActionResult Dodaj()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Dodaj(Predmet predmet)
        {
            _predmetService.Dodaj(predmet);

            return RedirectToAction("index");
        }

        [HttpPost]
        public bool Izbrisi(int id)
        {
            try
            {
                _predmetService.Izbrisi(id);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            
        }


        public  IActionResult Detalji(int id)
        {
            var predmet = _predmetService.NadjiPredmet(id);
            return View(predmet);
        }

        public IActionResult Uredi(int id)
        {
            var predmet=_predmetService.NadjiPredmet(id);
            return View(predmet);
        }

        [HttpPost]
        public IActionResult Uredi(Predmet predmet,int id)
        {
            if (predmet.Id!=id)
            {
                return BadRequest();
            }
            _predmetService.Azuriraj(predmet);

            return RedirectToAction("index");
        }
    }
}