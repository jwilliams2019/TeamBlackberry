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
using BerylCalendar.Utilities;

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
                ev.eve.TypeId = Int32.Parse(ev.typeId);
                ev.eve.AccountId = db.Accounts.Where(e => e.Username == userManager.GetUserName(User)).Select(e => e.Id).ToArray()[0];
                ev.eve.StartDateTime = DateTimeUtilities.CombineDateTime(ev.eve.StartDateTime, ev.startTime);
                ev.eve.EndDateTime = DateTimeUtilities.CombineDateTime(ev.eve.EndDateTime, ev.endTime);
                // if (ev.eve.StartDateTime.CompareTo(ev.eve.StartDateTime) =! -1){
                //     return RedirectToAction("CreateEventError", 2);
                // }
                db.Events.Add(ev.eve);
                db.SaveChanges();
                return View("EventCreateSuccess");
            }
            return RedirectToAction("CreateEventError", 1);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> HomePage()
        {
            var events = await db.Events.Include(x => x.Account).Where(e => e.Account.Username == userManager.GetUserName(User)).OrderBy(y => y.StartDateTime).ToListAsync();
            return View(events);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> UpdateEvent(int id){
            if (userManager.GetUserName(User) == db.Events.Include(e => e.Account).Where(e => e.Id == id).Select(e => e.Account.Username).First()){
                var ev = await db.Events.FindAsync(id);
                CrudEvent crud = new CrudEvent();
                crud.errorNum = 0;
                crud.eve = ev;
                crud.types = await db.Types.Select(e => e.Name).ToArrayAsync();
                return View(crud);
            }
            return RedirectToAction("HomePage");
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> UpdateEvent(CrudEvent model){
            if (userManager.GetUserName(User) == db.Events.Include(e => e.Account).Where(e => e.Id == model.eve.Id).Select(e => e.Account.Username).First()){
                if (ModelState.IsValid){
                    model.eve.TypeId = Int32.Parse(model.typeId);
                    model.eve.AccountId = await db.Accounts.Where(e => e.Username == userManager.GetUserName(User)).Select(e => e.Id).FirstAsync();
                    model.eve.StartDateTime = DateTimeUtilities.CombineDateTime(model.eve.StartDateTime, model.startTime);
                    model.eve.EndDateTime = DateTimeUtilities.CombineDateTime(model.eve.EndDateTime, model.endTime);
                    db.Update(model.eve);
                    await db.SaveChangesAsync();
                    return RedirectToAction("HomePage"); 
                }
                return View(model);
            }
            return RedirectToAction("HomePage");
        }

        [HttpGet]
        [Authorize]
        public IActionResult DeleteEvent(int id){
            if (userManager.GetUserName(User) == db.Events.Include(e => e.Account).Where(e => e.Id == id).Select(e => e.Account.Username).First()){
                return View(id);
            }
            return RedirectToAction("HomePage");
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> EraseEvent(int id){
            var eve = await db.Events.Include(e => e.Account).Where(e => e.Id == id).FirstAsync();
            if (eve != null){
                if (userManager.GetUserName(User) == eve.Account.Username){
                    db.Events.Remove(eve);
                    await db.SaveChangesAsync();
                }
            }
            return RedirectToAction("HomePage");
        }
    }
}