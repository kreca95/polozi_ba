using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using polozi_ba.Data.Models;
using polozi_ba.Models.Panel;

namespace polozi_ba.Controllers
{
    public class PanelController : Controller
    {
        private readonly UserManager<Korisnik> _userManager;

        private readonly RoleManager<IdentityRole> _roleManager;

        public PanelController(UserManager<Korisnik> userManager, RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Korisnici()
        {

            var model = await _userManager.GetUsersInRoleAsync("korisnik");

            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> PromijeniUloguKorisniku(string idKorisnik, string uloga="admin")
        {
            var user = await _userManager.FindByIdAsync(idKorisnik);
            if (user != null)
            {
                var role = await _roleManager.FindByNameAsync(uloga);
                user.RoleId = role.Id;
                return Ok();
            }
            return BadRequest();
        }

    }
}