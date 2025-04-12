using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using OnlineShopBlazor.Models.Db;

namespace OnlineShopBlazor.Models.Validations
{
    public class AuthService : AuthenticationStateProvider
    {
        private readonly IDbContextFactory<OnlineShopContext> _dbFactory;
        private ClaimsPrincipal _currentUser = new(new ClaimsIdentity());

        public AuthService(IDbContextFactory<OnlineShopContext> dbFactory)
        {
            _dbFactory = dbFactory;
        }

        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            return Task.FromResult(new AuthenticationState(_currentUser));
        }

        public async Task<bool> LoginAsync(string email, string password)
        {
            using var db = _dbFactory.CreateDbContext();

            var user = await db.Users.FirstOrDefaultAsync(u =>
                u.Email.ToLower() == email.Trim().ToLower() &&
                u.Password == password.Trim());

            if (user == null)
                return false;

            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Role, user.IsAdmin ? "admin" : "user")
        };

            var identity = new ClaimsIdentity(claims, "SimpleAuth");
            _currentUser = new ClaimsPrincipal(identity);

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(_currentUser)));
            return true;
        }

        public Task LogoutAsync()
        {
            _currentUser = new ClaimsPrincipal(new ClaimsIdentity());
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(_currentUser)));
            return Task.CompletedTask;
        }
    }

}
