using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceInterfaces.Model;

namespace Demo.Pages
{
	public class ResultModel : PageModel
    {

        public int Id { get; set; }
        public decimal MaxRiskLevel { get; set; }

        [BindProperty]
        [Required]
        public string Name { get; set; } = "";

        public string Description { get; set; } = "";
        public decimal Interest { get; set; }
        public string InterestText { get { return $"{Interest * 100}% APR "; } }

        public void OnGet(string name, string description, decimal interest)
        {
            this.Name = name;
            this.Description = description;
            this.Interest = interest;
        }
    }
}
