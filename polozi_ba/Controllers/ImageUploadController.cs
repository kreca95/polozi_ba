using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using polozi_ba.Data.Models;

namespace polozi_ba.Controllers
{
    [Authorize]
    public class ImageUploadController : Controller
    {
        private readonly UserManager<Korisnik> _usermanager;

        public ImageUploadController(UserManager<Korisnik> userManager)
        {
            _usermanager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            var files = HttpContext.Request.Form.Files;
            var user = await _usermanager.GetUserAsync(User);

            foreach (var Image in files)
            {
                if (Image != null)
                {
                    var uploads = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "profilne");

                    using (var fileStream = new FileStream(Path.Combine(uploads, Image.FileName), FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                        user.SlikaUrl = file.FileName;
                        await _usermanager.UpdateAsync(user);
                    }
                }
            }
            return Redirect("/Identity/Account/Manage");
        }

    }
}