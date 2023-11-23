using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceInterfaces.Model;
using ServiceInterfaces.Service;

namespace Demo.Pages
{
    public class UserModel : PageModel
    {
        private IUserService _userService;

        public UserModel(IUserService userService)
        {
            _userService = userService;

        }

        [BindProperty]
        [Required]
        public User User { get; set; }
        //Would be better not to include the same type as from the service and translate this into a view model etc

        public void OnGet()
        {

            User = _userService.GetUser().Result; 
            Console.Write(User.name);
        }
    }
}
