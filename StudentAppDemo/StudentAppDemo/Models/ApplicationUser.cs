using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace StudentAppDemo.Models
{

    //public enum UserType
    //{
    //    Rider, Driver, RiderDriver
    //}
    public class ApplicationUser : IdentityUser
    {
        //public DateTime Birthday { get; set; }
        //public UserType UserType { get; set; }

        public bool Completed { get; set; } = false;
       
        public Survey Survey { get; set; }
       
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 1)]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 1)]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "City")]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 1)]
        public string City { get; set; }

        [Required]
        [Display(Name = "State")]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 1)]
        public string State { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }


    }
}
