using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceInterfaces.Service;
using Services;

namespace Demo.Pages;

public class IndexModel : PageModel
{
    private IUserProductFinderService _userProductFinderService;

    [BindProperty]
    [Required]
    public string Name { get; set; }

    [BindProperty]
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [BindProperty]
    [Required]
    public decimal Income { get; set; }

    [BindProperty]
    [Required]
    public decimal RequestedLoan { get; set; }


    public string? Message { get; set; }

    public IndexModel(IUserProductFinderService userProductFinderService)
    {
        _userProductFinderService = userProductFinderService;
    }

    public void OnGet()
    {

    }

    public ActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            Message = "Invalid input.";
            return Page();
        }

        var user = new LoanEnquiry { Email = Email!, Name = Name!, Income = Income, RequestedLoan = RequestedLoan  };
        var product = _userProductFinderService.GetBestProductForUser(user);

        if (product == null)
        {
            return RedirectToPage("NoLoanAvailable");
        }

        //We could also just pass the id and look it up on the other page
         return RedirectToPage("Result", new { name = product.Name, description = product.Description, interest = product.Interest });

    }
}
