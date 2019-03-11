using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentAppDemo.Models;

namespace StudentAppDemo.Pages
{
    public class IndexModel : PageModel
    {

        private readonly StudentAppDemo.Data.ApplicationDbContext _context;

        public IndexModel(StudentAppDemo.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public ApplicationUser user;

        public IActionResult OnGet()
        {
            user = _context.ApplicationUsers.Where(u => u.Email == User.Identity.Name).FirstOrDefault();
            if (user == null)
            {
                return Page();
            }
            if (!user.Completed)
            {
                return Page();
            }
            else
                return RedirectToPage("./Contact");
                
        }
    }
}
