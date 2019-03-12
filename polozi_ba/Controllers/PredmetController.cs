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

        public ActionResult Dodaj(Predmet predmet)
        {
            _predmetService.Dodaj(predmet);

            return View();
        }
    }
}