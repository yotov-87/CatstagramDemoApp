﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CatstagramDemoApp.Server.Controllers {
    public class HomeController : ApiController {
        [Authorize]        
        public ActionResult Get() {
            return Ok("Works!!!");
        }
    }
}