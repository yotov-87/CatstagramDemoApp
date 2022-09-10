﻿using System.ComponentModel.DataAnnotations;

namespace CatstagramDemoApp.Server.Models.Identity {
    public class RegisterRequestModel {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }
    }
}
