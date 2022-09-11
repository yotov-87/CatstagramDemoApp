using System.ComponentModel.DataAnnotations;
using static CatstagramDemoApp.Server.Data.Validation.Cat;

namespace CatstagramDemoApp.Server.Data.Models {
    public class Cat {
        public int Id { get; set; }

        [Required]
        [MaxLength(MaxDescriotionLength)]
        public string Description { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public string UserId { get; set; }

        public User User { get; set; }
    }
}
