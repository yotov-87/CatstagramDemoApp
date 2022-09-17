using System.ComponentModel.DataAnnotations;

namespace CatstagramDemoApp.Server.Features.Cats {
    public class CatListingResponseModel {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
    }
}
