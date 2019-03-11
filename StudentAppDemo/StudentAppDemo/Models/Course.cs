using Microsoft.AspNetCore.DataProtection.KeyManagement;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StudentAppDemo.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        
        public ApplicationUser ApplicationUser { get; set; }

        [Required, DisplayName(displayName: "Course Name")]
        [MaxLength(length: 50, ErrorMessage = "Name too long.")]
        public string CourseName { get; set; }

        public ICollection<StudentCourse> StudentCourses { get; set; } = new List<StudentCourse>();

    }
}
