using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using StudentAppDemo.Data;
using StudentAppDemo.Models;
using static Microsoft.AspNetCore.Identity.UI.Pages.Account.Internal.ExternalLoginModel;

namespace StudentAppDemo.Pages.Survey
{
    public class SurveyModel : PageModel
    {
        private readonly StudentAppDemo.Data.ApplicationDbContext _context;

        public SurveyModel(StudentAppDemo.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        private string curentUserId { get; set; }

        public IActionResult OnGet()
        {
            curentUserId = User.Identity.Name;
            return Page();
        }
       

        public UserManager<ApplicationUser> userManager;
       
        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
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

        public SurveyModel Survey { get; set; }

        
        
       

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if(ModelState.IsValid)
            {
                curentUserId = User.Identity.Name;

                var survey = new Models.Survey
                {
                    ApplicationUserId = curentUserId,
                    Answer1 = Input.Answer1,
                    Answer2 = Input.Answer2,
                    Answer3 = Input.Answer3,
                    Answer4 = Input.Answer4,
                    Answer5 = Input.Answer5,
                    Answer6 = Input.Answer6,
                    Answer7 = Input.Answer7
                };

                _context.ApplicationUsers.Where(u => u.Email == survey.ApplicationUserId).FirstOrDefault().Survey = survey;

                _context.ApplicationUsers.Where(u => u.Email == survey.ApplicationUserId).FirstOrDefault().Completed = true;

                _context.Surveys.Add(survey);
            }
            
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}