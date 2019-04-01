using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using polozi_ba.Data;
using polozi_ba.Data.Models;

namespace polozi_ba.Controllers
{
    public class GradController : Controller
    {
        private readonly IGrad _gradService;


        public GradController(IGrad gradService)
        {
            _gradService = gradService;
        }

        public IActionResult Index()
        {
            return View(_gradService.SviGradovi());
        }

        public IActionResult Dodaj()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Dodaj(Grad grad)
        {
            _gradService.Dodaj(grad);

            return RedirectToAction("index");
        }
    }
}