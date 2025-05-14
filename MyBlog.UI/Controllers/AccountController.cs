using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Application.Utilities.IEmailServices;
using MyBlog.Core.CoreEntities.Entities;
using MyBlog.Core.CoreEntities.Enums;
using MyBlog.UI.Models.VMs;
using System.Data;
using System.Security.Claims;

namespace MyBlog.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IEmailService _emailService;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager, IEmailService emailService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _emailService = emailService;
        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM model)
        {
            if (ModelState.IsValid)
            {
                var baseUserName = model.Email.Split('@')[0];
                var uniqueUserName = await GenerateUniqueUserNameAsync(baseUserName);

                var user = new AppUser
                {
                    Email = model.Email,
                    UserName = uniqueUserName,
                    ImageUrl = "/images/user/default-profile-photo.jpg"

                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "Writer");
                    
                    var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);

                    
                    var confirmationLink = Url.Action("ConfirmEmail", "Account", new
                    {
                        userId = user.Id,
                        token = token
                    }, protocol: HttpContext.Request.Scheme);

                    var subject = "Confirm your email address";
                    var body = $"<p>To confirm your account please <a href='{confirmationLink}'>click here</a>.</p>";

                    var emailSent = await _emailService.SendEmailAsync(user.Email, subject, body);


                    return Json(new { success = true, emailSent });
                }

                var errors = result.Errors.Select(e => e.Description).ToList();
                return Json(new { success = false, errors });
            }

            return Json(new { success = false, errors = new List<string> { "Form is not valid" } });
        }

        

        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if (userId == null || token == null)
                return BadRequest("Invalid request");

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                return NotFound("User is not found");

            var result = await _userManager.ConfirmEmailAsync(user, token);

            ViewData["Success"] = result.Succeeded;
            ViewData["Message"] = result.Succeeded
                ? "Email address confirmed successfully!"
                : "Failed to confirm mail address";

            return View("ConfirmEmailResult");
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user == null || user.Status == EntityStatus.Deleted)
                {
                    ModelState.AddModelError(string.Empty, "Invalid email or password.");
                }
                else if (!await _userManager.IsEmailConfirmedAsync(user)&&_emailService.UseEmailService)
                {
                    ModelState.AddModelError(string.Empty, "Please confirm your email");
                }
                else if(user != null && user.Status != EntityStatus.Deleted)
                {
                    var result = await _signInManager.PasswordSignInAsync(user.UserName, model.Password, model.RememberMe, lockoutOnFailure: false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Invalid email or password.");
                    }
                }
                else {
                    ModelState.AddModelError(string.Empty, "Invalid email or password.");
                }

            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        private async Task<string> GenerateUniqueUserNameAsync(string baseName)
        {
            string userName = baseName;
            int suffix = 1;

            while (await _userManager.FindByNameAsync(userName) != null)
            {
                userName = $"{baseName}{suffix}";
                suffix++;
            }

            return userName;
        }
        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null) return BadRequest();

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var resetLink = Url.Action("ResetPassword", "Account", new { email, token }, Request.Scheme);

            
            await _emailService.SendEmailAsync(email, "Password Reset", $"Click to reset your password: <a href='{resetLink}'>Reset</a>");

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordVM model)
        {
            if (model.Password != model.ConfirmPassword)
                return BadRequest();

            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null) return BadRequest("User not found.");

            var result = await _userManager.ResetPasswordAsync(user, model.Token, model.Password);
            if (!result.Succeeded)
                return BadRequest(result.Errors);

            return Ok();
        }

        [HttpGet]
        public IActionResult ResetPassword(string email, string token)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(token))
            {
                return BadRequest("Invalid reset link.");
            }

            var model = new ResetPasswordVM
            {
                Email = email,
                Token = token
            };

            return View(model);
        }

        
        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordVM model)
        {
            if (model.NewPassword != model.ConfirmPassword)
                return BadRequest(new { message = "New passwords do not match." });

            var user = await _userManager.FindByIdAsync(model.UserId);
            if (user == null)
                return BadRequest(new { message = "User not found." });

            
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (user.Id != currentUserId)
                return Forbid();

            var result = await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
            if (!result.Succeeded)
            {
                var error = result.Errors.FirstOrDefault()?.Description ?? "Password change failed.";
                return BadRequest(new { message = error });
            }

            return Ok();
        }

    }
}
