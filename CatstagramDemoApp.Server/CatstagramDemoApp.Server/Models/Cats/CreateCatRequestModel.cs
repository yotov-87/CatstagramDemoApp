using CatstagramDemoApp.Server.Data.Models;
using System.ComponentModel.DataAnnotations;
using static CatstagramDemoApp.Server.Data.Validation.Cat;

namespace CatstagramDemoApp.Server.Models.Cats {
    public class CreateCatRequestModel {

        [Required]
        [MaxLength(MaxDescriotionLength)]
        public string Description { get; set; }

        [Required]
        public string ImageUrl { get; set; }
    }
}
