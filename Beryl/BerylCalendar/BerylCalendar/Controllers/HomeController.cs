using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BerylCalendar.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.UI.Services;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;

namespace BerylCalendar.Controllers
{
    public class HomeController : Controller
    {
        private BerylDbContext db;
        private readonly UserManager<IdentityUser> userManager;
        private readonly IEmailSender _emailSender;

        public HomeController(BerylDbContext db, UserManager<IdentityUser> userManager, IEmailSender emailSender)
        {
            this.db = db;
            this.userManager = userManager;
            _emailSender = emailSender;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult PasswordChangeRequest(int code = 0){
            return View(code);
        }

        [HttpPost]
        public async Task<IActionResult> PasswordChangeRequest(string emailForPass){
            if (ModelState.IsValid){
                var user = await userManager.FindByEmailAsync(emailForPass);
                if (user == null){
                    return View(1);
                }

                var token = await userManager.GeneratePasswordResetTokenAsync(user);
                token = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(token));

                string link = "https://localhost:5001/Home/PasswordChange/?token=" + token;
                
                await _emailSender.SendEmailAsync(emailForPass, "Change your Password", 
                    htmlMessage: $"Change your password by <a href='{HtmlEncoder.Default.Encode(link)}'>clicking here</a>.");

                return RedirectToAction("PasswordRequestSent");
            }
            return View(2);
        }

        [HttpGet]
        public IActionResult PasswordRequestSent(){
            return View();
        }

        [HttpGet]
        public IActionResult PasswordChange(string token){
            token = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(token));
            ViewData["PasswordChangeToken"] = token;
            return View(0);
        }

        [HttpPost]
        public async Task<IActionResult> PasswordChange(string token, string email, string newPassword, string newPasswordConfirm){
            var user = await userManager.FindByEmailAsync(email);
            if (user == null){
                return RedirectToAction("PasswordChangeRequest");
            }
            if (!newPassword.Equals(newPasswordConfirm))
            {
                ViewData["PasswordChangeToken"] = token;
                return View(1);
            }

            var result = userManager.ResetPasswordAsync(user, token, newPassword);
            Debug.WriteLine(result.Result.ToString());
            if (!result.Result.Succeeded){
                ViewData["PasswordChangeToken"] = token;
                return View(3);
            }

            user.PasswordHash = userManager.PasswordHasher.HashPassword(user, newPassword);
            var result2 = await userManager.UpdateAsync(user);
            if (!result2.Succeeded){
                ViewData["PasswordChangeToken"] = token;
                return View(2);
            }

            return RedirectToAction("Index");
        }
    }
}
