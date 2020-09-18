using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using userservice.Interfaces;
using userservice.Models;

namespace userservice.Controllers {
    [Route("api/v1/[controller]")]
    public class UserController : Controller {
        private IUserRepository userRepo;

        public UserController(IUserRepository userRepo) {
            this.userRepo = userRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() {
            return Json(await userRepo.GetAll());
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] User data) {
            // dynamic data = form;
            var newUser = new User() {
                Name = data.Name,
                LastName = data.LastName,
                FechaNacimiento = DateTime.UtcNow
            };
            bool created = await userRepo.Create(newUser);
            if (created)
                return Json(new { message = "New record created!" });

            return BadRequest(new { message = "New record wasn't created!" });
        }
    }
}