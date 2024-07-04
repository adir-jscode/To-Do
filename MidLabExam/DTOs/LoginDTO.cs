using MidLabExam.EF;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MidLabExam.DTOs
{
    public class LoginDTO
    {
        [Required(ErrorMessage ="Please Enter Email")]
        [EmailAddress(ErrorMessage ="Provide Valid Email Address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please Enter Password")]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters")]
        public string Password { get; set; }
    }
}