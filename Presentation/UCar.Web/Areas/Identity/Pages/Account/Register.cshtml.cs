using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using UCar.Web.Areas.Identity.Data;

namespace UCar.Web.Areas.Identity.Pages.Account
{
    /// <summary>
    /// модель регистрации
    /// </summary>
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<AuthUser> _signInManager;
        private readonly UserManager<AuthUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;

        /// <summary>
        /// конструктор модели регистрации
        /// </summary>
        /// <param name="userManager">Для работы с БД ролей</param>
        /// <param name="signInManager">Для поиска в БД</param>
        /// <param name="logger"></param>
        /// <param name="emailSender"></param>
        /// <param name="roleManager"></param>
        public RegisterModel(
            UserManager<AuthUser> userManager,
            SignInManager<AuthUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _roleManager = roleManager;
        }

        /// <summary>
        /// Модель ввода
        /// </summary>
        [BindProperty]
        public InputModel Input { get; set; }

        /// <summary>
        /// Возвращаемая ссылка
        /// </summary>
        public string ReturnUrl { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        /// <summary>
        /// Модель ввода
        /// </summary>
        public class InputModel
        {
            /// <summary>
            /// Имя
            /// </summary>
            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "First Name")]
            public string FirstName { get; set; }

            /// <summary>
            /// Фамилия
            /// </summary>
            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Last Name")]
            public string LastName { get; set; }

            /// <summary>
            /// Электронная почта
            /// </summary>
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            /// <summary>
            /// Пароль
            /// </summary>
            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            /// <summary>
            /// подтверждение пароля
            /// </summary>
            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var user = new AuthUser { UserName = Input.Email, Email = Input.Email,FirstName=Input.FirstName,LastName=Input.LastName };
                var result = await _userManager.CreateAsync(user, Input.Password);
                var roleresult = await _userManager.AddToRoleAsync(user, "Пользователь");
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
