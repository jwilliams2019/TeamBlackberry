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
        public IActionResult PasswordChangeRequest(){
            return View();
        }

        [HttpPost]
        public IActionResult PasswordChangeRequest(string emailForPass){
            Debug.WriteLine(emailForPass);

            var callbackUrl = Url.Page(
                "/Home/PasswordChange/?email="+emailForPass,
                pageHandler: null,
                values: new { area = "" },
                protocol: Request.Scheme);
            return RedirectToAction("PasswordRequestSent", "Home");
        }

        [HttpGet]
        public IActionResult PasswordRquestSent(){
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> PasswordChange(string email){
            var user = await userManager.FindByEmailAsync(email);
            if (user == null){
                return RedirectToAction("PasswordChangeRequest");
            }
            ViewData["email"] = email;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> PasswordChange(string email, string newPassword){
            var user = await userManager.FindByEmailAsync(email);
            if (user == null){
                return RedirectToAction("PasswordChangeRequest");
            }
            user.PasswordHash = userManager.PasswordHasher.HashPassword(user, newPassword);
            var result = await userManager.UpdateAsync(user);
            if (!result.Succeeded){
                return RedirectToAction("PasswordChange", "Home", new { email = email });
            }
            return RedirectToAction("Index");
        }
    }
}
