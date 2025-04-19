// Services/LoginService.cs
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

using OnlineShopBlazor.Models.Db;

using System.Security.Claims;

namespace OnlineShopBlazor.Models.Services // Adjust namespace if needed
{
    public class LoginService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly OnlineShopContext _context;

        // Inject IHttpContextAccessor
        public LoginService(IHttpContextAccessor httpContextAccessor, OnlineShopContext context)
        {
            _httpContextAccessor = httpContextAccessor;
            _context = context;
        }

        public async Task<bool> LoginAsync(string email, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == email.ToLower().Trim() && x.Password == password);

            if (user != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.FullName),
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Email, user.Email.ToString()),
                    new Claim(ClaimTypes.Role, user.IsAdmin?"admin":"user") 
                };

                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme); // Use the default scheme

                // Get the HttpContext via the accessor
                var httpContext = _httpContextAccessor.HttpContext;

                if (httpContext == null)
                {
                    // This shouldn't happen if dependency injection is set up correctly
                    // and the call originates from a valid request context.
                    return false;
                }
                
                // Sign in the user using the specified authentication scheme ("MyCookieAuth")
                // This is the call that creates and sets the authentication cookie.
                await httpContext.SignInAsync(
                    "MyCookieAuth", // <<<<< MUST MATCH the scheme name in Program.cs
                    new ClaimsPrincipal(claimsIdentity));

                return true; // Login successful
            }

            return false; // Login failed
        }

        public async Task<bool> LogoutAsync()
        {
            // Get the HttpContext via the accessor
            var httpContext = _httpContextAccessor.HttpContext;

            if (httpContext == null)
            {
                // This shouldn't happen if dependency injection is set up correctly
                // and the call originates from a valid request context.
                return false;
            }
            await httpContext.SignOutAsync("MyCookieAuth");

            return true;
        }
    }
}