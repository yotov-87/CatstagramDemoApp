using CatstagramDemoApp.Server.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CatstagramDemoApp.Server.Features.Cats
{
    public class CatsController : ApiController
    {
        private readonly ICatService catService;

        public CatsController(ICatService catService)
        {
            this.catService = catService;
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> Create(CreateCatRequestModel model)
        {
            var userId = User.GetId();

            var id = await this.catService.Create(model.ImageUrl, model.Description, userId);

            return Created(nameof(this.Create), id);
        }
    }
}
