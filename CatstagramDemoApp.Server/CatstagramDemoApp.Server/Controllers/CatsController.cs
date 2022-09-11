using CatstagramDemoApp.Server.Data;
using CatstagramDemoApp.Server.Data.Models;
using CatstagramDemoApp.Server.Infrastructure;
using CatstagramDemoApp.Server.Models.Cats;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CatstagramDemoApp.Server.Controllers {
    public class CatsController : ApiController {
        private readonly CatstagramDemoAppDbContext data;

        public CatsController(CatstagramDemoAppDbContext data) {
            this.data = data;
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> Create(CreateCatRequestModel model) {
            var userId = this.User.GetId();

            var cat = new Cat {
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                UserId = userId,
            };

            this.data.Add(cat);

            await this.data.SaveChangesAsync();

            return Created(nameof(this.Create), cat.Id);
        }
    }
}
