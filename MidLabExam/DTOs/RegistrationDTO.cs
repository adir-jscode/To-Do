using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MidLabExam.DTOs
{
    public class RegistrationDTO
    {
        [Required(ErrorMessage = "Please enter first name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please enter last name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter email address")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter password")]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters long")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please confirm password")]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "Please enter house no")]
        public string HouseNo { get; set; }
        [Required(ErrorMessage = "Please enter street")]
        public string Street { get; set; }
        [Required(ErrorMessage = "Please enter city")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please enter postal code")]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = "Please enter phone number")]
        [MinLength(11, ErrorMessage = "Invalid phone number")]
        public string Phone { get; set; }
    }
}