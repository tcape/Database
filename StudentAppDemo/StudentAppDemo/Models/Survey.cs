using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace StudentAppDemo.Models
{
    public class Survey
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string ApplicationUserId { get; set; }

        public ICollection<ApplicationUser> ApplicationUsers { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Answer1 { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Answer2 { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Answer3 { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Answer4 { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Answer5 { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Answer6 { get; set; }

        [DataType(DataType.MultilineText)]
        public string Answer7 { get; set; }

    }
}
