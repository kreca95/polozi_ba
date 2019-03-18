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

        public HomeController(IPredmet predmetService)
        {
            _predmetService = predmetService;
        }


        public IActionResult Index()
        {

            var model = new IndexViewModel();

            model.PredmetiSelectLista = new SelectList(_predmetService.SviPredmeti(), "Id", "Naziv");

            return View(model);
        }

        public IActionResult Pretraga(string predmet, string grad)
        {

            return View();
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
