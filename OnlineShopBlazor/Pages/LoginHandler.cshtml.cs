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
            // دریافت اطلاعات از query string
            Username = Request.Query["Username"];
            Password = Request.Query["Password"];

            // اعتبارسنجی ورودی‌ها
            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
            {
                TempData["ErrorMessage"] = "نام کاربری و رمز عبور الزامی است.";
                return Page();
            }

            // جستجو برای کاربر در دیتابیس
            var user = await _context.Users
                .FirstOrDefaultAsync(x => x.Email == Username.ToLower().Trim() && x.Password == Password.Trim());

            if (user != null)
            {
                // ایجاد claims برای لاگین
                var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.FullName),
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Role, user.IsAdmin ? "admin" : "user")
        };

                var claimsIdentity = new ClaimsIdentity(
                    claims, "MyCookieAuth"); // تغییر به MyCookieAuth به جای Cookies

                // ورود به سیستم با استفاده از کوکی‌ها
                await HttpContext.SignInAsync(
                    "MyCookieAuth", // تغییر به MyCookieAuth
                    new ClaimsPrincipal(claimsIdentity)
                );

                // هدایت به صفحه اصلی بعد از ورود موفق
                return Redirect("/");
            }

            // اگر کاربر پیدا نشد، نمایش پیام خطا
            TempData["ErrorMessage"] = "نام کاربری یا رمز عبور اشتباه است.";
            return Page();
        }

    }
}
