using Microsoft.AspNetCore.Identity;

namespace CatstagramDemoApp.Server.Data.Models {
    public class User : IdentityUser {

        public IEnumerable<Cat> Cats { get; } = new HashSet<Cat>();
    }
}
