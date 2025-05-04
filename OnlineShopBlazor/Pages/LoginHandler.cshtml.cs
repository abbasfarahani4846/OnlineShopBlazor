using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

using OnlineShopBlazor.Models.Db;

using System.Security.Claims;

namespace OnlineShopBlazor.Pages
{
    public class LoginHandlerModel : PageModel
    {
        private OnlineShopOrginalContext _context;
        public LoginHandlerModel(OnlineShopOrginalContext context)
        {
            _context = context;
        }
        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
            // Retrieve information from query string
            Username = Request.Query["Username"];
            Password = Request.Query["Password"];

            // Search for the user in the database
            var user = await _context.Users
                .FirstOrDefaultAsync(x => x.Email == Username.ToLower().Trim() && x.Password == Password.Trim());

            if (user != null)
            {
                // Create claims for login
                var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.FullName),
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Role, user.IsAdmin ? "admin" : "user")
        };

                var claimsIdentity = new ClaimsIdentity(
                    claims, "MyCookieAuth"); // Use MyCookieAuth instead of default Cookies

                // Sign in using cookies
                await HttpContext.SignInAsync(
                    "MyCookieAuth", // Use MyCookieAuth
                    new ClaimsPrincipal(claimsIdentity)
                );

                // Redirect to homepage after successful login
                return Redirect("/");
            }

            // Redirect to login page if authentication fails
            return Redirect("/login");
        }

    }
}
