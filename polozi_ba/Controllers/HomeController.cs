using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.OData.Query.SemanticAst;
using polozi_ba.Data;
using polozi_ba.Data.Models;
using polozi_ba.Models;
using polozi_ba.Models.Naslovna;

namespace polozi_ba.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPredmet _predmetService;
        private readonly IGrad _gradService;
        private readonly IPoloziBa _poloziService;

        public HomeController(IPredmet predmetService,IGrad gradService,IPoloziBa poloziService)
        {
            _gradService = gradService;
            _predmetService = predmetService;
            _poloziService = poloziService;
        }


        public IActionResult Index()
        {

            var model = new IndexViewModel();

            model.PredmetiSelectLista = new SelectList(_predmetService.SviPredmeti(), "Id", "Naziv");
            model.GradoviSelectLista = new SelectList(_gradService.SviGradovi(), "Id", "Naziv");

            return View(model);
        }

        [HttpPost]
        public IActionResult Pretraga(string grad,string predmet)
        {
            var korisnici = _poloziService.NadjiKorisnikePrekoPredmetaIGrada(Convert.ToInt32(predmet),Convert.ToInt32(grad));

            return View(korisnici);
        }

        public async Task<IActionResult> Privacy()
        {
            
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
