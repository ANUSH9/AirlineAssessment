// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using MVC_Airline.Areas.Identity.Data;
using MVC_Airline.Models;

namespace MVC_Airline.Areas.Identity.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly MvcDbcontext _mvcDbcontext;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<MVC_AirlineUser> _signInManager;
        private readonly UserManager<MVC_AirlineUser> _userManager;
        private readonly IUserStore<MVC_AirlineUser> _userStore;
        private readonly IUserEmailStore<MVC_AirlineUser> _emailStore;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;

        public RegisterModel(

          MvcDbcontext mvcDbcontext,
        RoleManager<IdentityRole>roleManager,
            UserManager<MVC_AirlineUser> userManager,
            IUserStore<MVC_AirlineUser> userStore,
            SignInManager<MVC_AirlineUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender)
        {
            _mvcDbcontext = mvcDbcontext;

            _roleManager = roleManager;
            _userManager = userManager;
            _userStore = userStore;
            _emailStore = GetEmailStore();
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            
        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [BindProperty]
        public InputModel Input { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public string ReturnUrl { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public class InputModel
        {
            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Required]
            [EmailAddress]
            [StringLength(50, ErrorMessage = "Email max length should be 50 characters")]
            [Display(Name = "Email")]
            public string Email { get; set; }
            [Required]
            [StringLength(10, ErrorMessage = "Pan Number at least must be 10 characters.")]
            public string PANNO { get; set; }
            public string RoleName { get; set; }

            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Required]
            [StringLength(10, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 8)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            /// 
            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            
            [StringLength(10, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 8)]

            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
            


        }
        public void SendEmail()
        {

            SmtpClient email = new SmtpClient
            {
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                EnableSsl = true,
                Host = "smtp.gmail.com",
                Port = 587,
                Credentials = new NetworkCredential("loginidanushgupta@gmail.com", "gbbtanvbmgfwvkye")
            };
            string subject = "Welcome";
            string body = $"Dear , Thanks for registering with us";

            try
            {

                email.EnableSsl = true;
                email.Send("loginidanushgupta@gmail.com", $"{Input.Email}", subject, body);

            }
            catch (SmtpException e)
            {
                Console.WriteLine(e);
            }

        }






        public async Task OnGetAsync(string returnUrl = null)
        {
            //ViewData["roles"] = _roleManager.Roles.ToList();

            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            var role = Input.RoleName;



            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var user = CreateUser();
                user.PANNO = Input.PANNO;
                var data = new Admin()
                {
                    Email = Input.Email,
                    PANNO = Input.PANNO,
                    Password = Input.Password,
                    ConfirmPassword = Input.ConfirmPassword,
                    RoleName = "Operator",
                    Status = "Pending"


                };
                var Result1 = await _mvcDbcontext.adminModel.AddAsync(data);
                _mvcDbcontext.SaveChanges();

                await _userStore.SetUserNameAsync(user, Input.Email, CancellationToken.None);
                await _emailStore.SetEmailAsync(user, Input.Email, CancellationToken.None);
                var result = await _userManager.CreateAsync(user, Input.Password);

                if (result.Succeeded)
                {
                    SendEmail();
                    //_logger.LogInformation("User created a new account with password.");

                    //await _userManager.AddToRoleAsync(user,role.ToString());
                    var userId = await _userManager.GetUserIdAsync(user);
                    //var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    //code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    //var callbackUrl = Url.Page(
                    //    "/Account/ConfirmEmail",
                    //    pageHandler: null,
                    //    values: new { area = "Identity", userId = userId, code = code, returnUrl = returnUrl },
                    //    protocol: Request.Scheme);

                    //await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                    //    $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

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

        private MVC_AirlineUser CreateUser()
        {
            try
            {
                return Activator.CreateInstance<MVC_AirlineUser>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(MVC_AirlineUser)}'. " +
                    $"Ensure that '{nameof(MVC_AirlineUser)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                    $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
            }
        }

        private IUserEmailStore<MVC_AirlineUser> GetEmailStore()
        {
            if (!_userManager.SupportsUserEmail)
            {
                throw new NotSupportedException("The default UI requires a user store with email support.");
            }
            return (IUserEmailStore<MVC_AirlineUser>)_userStore;
        }
    }
}
