using CatstagramDemoApp.Server.Data;
using CatstagramDemoApp.Server.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CatstagramDemoApp.Server.Features.Cats {
    public class CatService : ICatService {

        private readonly CatstagramDemoAppDbContext data;

        public CatService(CatstagramDemoAppDbContext data) {
            this.data = data;
        }
        public async Task<int> Create(string imageUrl, string description, string userId) {
            var cat = new Cat {
                Description = description,
                ImageUrl = imageUrl,
                UserId = userId,
            };

            data.Add(cat);

            await data.SaveChangesAsync();

            return cat.Id;
        }

        public async Task<IEnumerable<CatListingResponseModel>> ByUser(string userId) {
            return await this.data
                .Cats
                .Where(x => x.UserId == userId)
                .Select(x => new CatListingResponseModel {
                    Id = x.Id,
                    ImageUrl = x.ImageUrl
                })
                .ToListAsync();
        }
    }
}
