using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Capstone.Web.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Required")]        
        public string Password { get; set; }

        [Required(ErrorMessage = "An email address is required")]
        public string Email { get; set; }
    }
}