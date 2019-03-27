﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using polozi_ba.Data;
using polozi_ba.Data.Models;

namespace polozi_ba.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class KorisnikAPIController : ControllerBase
    {
        private readonly UserManager<Korisnik> _userManager;
        private readonly IPredmet _predmet;

        public KorisnikAPIController(UserManager<Korisnik> userManager,IPredmet predmet)
        {
            _userManager = userManager;
            _predmet = predmet;
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

        [HttpPost]
        [Route("DodajPredmet")]
        public async Task<IActionResult> DodajPredmetKorisniku([FromForm] IEnumerable<string> predmeti)
        {
            if (predmeti==null)
            {
                return BadRequest("predmet je null");
            }
            var user=await _userManager.FindByNameAsync(User.Identity.Name);
            foreach (var item in predmeti)
            {
                _predmet.DodajPredmetKorisniku(Convert.ToInt32(item), user.Id);
            }
            return Ok();
        }

        [HttpPost("{id}")]
        [Route("IzbrisiPredmet")]
        public IActionResult IzbrisiPredmetKorisniku([FromQuery]int id)
        {
            var userId = _userManager.GetUserId(User);
            _predmet.IzbrisiPredmetKorisniku(id, userId);
            return Ok();
        }
    }
}