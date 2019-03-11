using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudentAppDemo.Data;
using StudentAppDemo.Models;

namespace StudentAppDemo.Pages.Courses
{
    public class IndexModel : PageModel
    {
        private readonly StudentAppDemo.Data.ApplicationDbContext _context;

        public IndexModel(StudentAppDemo.Data.ApplicationDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public IList<Course> Course { get;set; }

        public async Task OnGetAsync()
        {
            Course = await _context.Courses.ToListAsync();
        }
    }
}
