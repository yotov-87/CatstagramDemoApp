using Microsoft.AspNetCore.Mvc;

namespace CatstagramDemoApp.Server.Features {
    [ApiController]
    [Route("[controller]")]
    public abstract class ApiController : ControllerBase {
    }
}
