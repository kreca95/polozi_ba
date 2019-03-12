using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using polozi_ba.Data;
using polozi_ba.Data.Models;
using polozi_ba.Models;

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
            return View();
        }

        public IActionResult Pretraga(string predmet, string grad)
        {

            return View();
        }

        public async Task<IActionResult> Privacy()
        {
            var predmet = await _predmetService.NadjiPredmet(1);
            return View(predmet);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
