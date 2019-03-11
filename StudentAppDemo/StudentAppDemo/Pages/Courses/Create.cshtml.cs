using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using StudentAppDemo.Data;
using StudentAppDemo.Models;

namespace StudentAppDemo.Pages.Courses
{
    public class CreateModel : PageModel
    {
        private readonly StudentAppDemo.Data.ApplicationDbContext _context;

        public CreateModel(StudentAppDemo.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            if(Course.ApplicationUser.Completed)
                return RedirectToPage("./Index");
            return Page();
        }

        [BindProperty]
        public Course Course { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }



            
       
            _context.Courses.Add(Course);
            await _context.SaveChangesAsync();

            Course.ApplicationUser.Completed = true;

            return RedirectToPage("./Index");
        }
    }
}