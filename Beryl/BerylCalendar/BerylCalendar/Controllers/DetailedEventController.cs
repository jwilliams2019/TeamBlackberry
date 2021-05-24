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
    public class DetailedEventController : Controller
    {
        private BerylDbContext db;
        private readonly UserManager<IdentityUser> userManager;

        public DetailedEventController(BerylDbContext db, UserManager<IdentityUser> userManager)
        {
            this.db = db;
            this.userManager = userManager;
        }


        [Authorize]
        [HttpGet]
        public IActionResult SeeDetailedEvents(int? id)
        {
            var events = db.Events.Where(c => c.Id == id).Include(d => d.Type);
            var idNumber = db.Events.Where(e => e.Id == id).Select(e => e.Id).ToArray()[0];
            if (idNumber != id)
            {
                return View("index");
            }
            return View(events);
        }
    }
}