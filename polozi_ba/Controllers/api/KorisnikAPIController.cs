using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using polozi_ba.Data.Models;

namespace polozi_ba.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class KorisnikAPIController : ControllerBase
    {
        private readonly UserManager<Korisnik> _userManager;

        public KorisnikAPIController(UserManager<Korisnik> userManager)
        {
            _userManager = userManager;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> KorisnikUAdmina([FromQuery] string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (await _userManager.IsInRoleAsync(user, "korisnik"))
            {
                await _userManager.RemoveFromRoleAsync(user, "korisnik");
                await _userManager.AddToRoleAsync(user, "admin");
                return Ok("User je sada admin");
            }
            if (await _userManager.IsInRoleAsync(user, "admin"))
            {
                await _userManager.RemoveFromRoleAsync(user, "admin");
                await _userManager.AddToRoleAsync(user, "korisnik");
                return Ok("User je sada korisnik");
            }
            return BadRequest("Nista nije odradjeno");
        }
    }
}