using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAppDemo.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required, DisplayName(displayName: "Full Name")]
        [MaxLength(length: 50, ErrorMessage = "Name too long.")]
        public string FullName { get; set; }

        public ICollection<StudentCourse> StudentCourses { get; set; } = new List<StudentCourse>();
    }

    public class Assignment
    {
        public int Id { get; set; }
        public string AssignmentName { get; set; }
    }
}
