﻿using System.ComponentModel.DataAnnotations;

namespace StudentAppDemo.Models
{
    public class StudentCourse
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int StudentId { get; set; }
        public Student Student { get; set; }
        [Required]
        public int CourseId { get; set; }
        public Course Course { get; set; }

    }
}
