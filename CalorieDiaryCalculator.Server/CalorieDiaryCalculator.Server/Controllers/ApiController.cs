using Microsoft.AspNetCore.Mvc;

namespace CatstagramDemoApp.Server.Controllers {
    [ApiController]
    [Route("[controller]")]
    public abstract class ApiController : ControllerBase {
    }
}
