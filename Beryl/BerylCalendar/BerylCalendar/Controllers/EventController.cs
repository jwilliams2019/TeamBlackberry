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

namespace BerylCalendar.Controllers
{
    public class EventController : Controller
    {
        private BerylDbContext db;
        private readonly UserManager<IdentityUser> userManager;

        public EventController(BerylDbContext db, UserManager<IdentityUser> userManager)
        {
            this.db = db;
            this.userManager = userManager;
        } 

        [Authorize]
        public IActionResult CreateEvent() {
            return View();
        }

        public IActionResult AddEvent(CreateEvent ev){
            ev.eve.Id = Int32.Parse(userManager.GetUserId(User));
            db.Events.Add(ev.eve);
            db.SaveChanges();
            return View("/Home/HomePage");
        }
    }
}