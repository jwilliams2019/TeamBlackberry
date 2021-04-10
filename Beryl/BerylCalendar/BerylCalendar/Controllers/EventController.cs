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

        [HttpGet]
        [Authorize]
        public IActionResult CreateEvent() {
            CrudEvent crud = new CrudEvent();
            crud.errorNum = 0;
            crud.types = db.Types.Select(e => e.Name).ToArray();
            return View("CreateEvent", crud);
        } 

        [HttpGet]
        [Authorize]
        public IActionResult CreateEventError(int i) {
            CrudEvent crud = new CrudEvent();
            crud.errorNum = i;
            crud.types = db.Types.Select(e => e.Name).ToArray();
            return View("CreateEvent", crud);
        } 

        [HttpPost]
        [Authorize]
        public IActionResult AddEvent(CrudEvent ev){ 
            if (ModelState.IsValid){
                ev.eve.TypeId = Int32.Parse(ev.name);
                ev.eve.AccountId = db.Accounts.Where(e => e.Username == userManager.GetUserName(User)).Select(e => e.Id).ToArray()[0];
                ev.eve.StartDateTime = CombineDateTime(ev.eve.StartDateTime, ev.startTime);
                ev.eve.EndDateTime = CombineDateTime(ev.eve.EndDateTime, ev.endTime);
                // if (ev.eve.StartDateTime.CompareTo(ev.eve.StartDateTime) =! -1){
                //     return RedirectToAction("CreateEventError", 2);
                // }
                db.Events.Add(ev.eve);
                db.SaveChanges();
                return View("EventCreateSuccess");
            }
            return RedirectToAction("CreateEventError", 1);
        }

        public DateTime CombineDateTime(DateTime date, DateTime time){
            date.Date.Add(time.TimeOfDay);
            return date;
        }
    }
}