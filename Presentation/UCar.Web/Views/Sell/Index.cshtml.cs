using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UCar.Web.Views.Sell
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public InputModel Input { get; set; }


        public string ReturnUrl { get; set; }


        public class InputModel
        {
            [Required]
            public string Model { get; set; }

            [Required]
            public string Description { get; set; }
        }
        public void OnPost()
        {
            var Model = Input.Model;
            var Description = Input.Description;
        }
    }
}
