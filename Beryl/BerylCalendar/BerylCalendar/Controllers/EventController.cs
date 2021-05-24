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
using BerylCalendar.Data;
using BerylCalendar.Data.Abstract;
using Microsoft.AspNetCore.Http;


namespace BerylCalendar.Controllers
{
    public class EventController : Controller
    {
        private readonly IEventRepository _eveRepo;
        private BerylDbContext db;
        private readonly UserManager<IdentityUser> userManager;
        private IHttpContextAccessor _httpContextAccessor;

        public EventController(BerylDbContext db, UserManager<IdentityUser> userManager, IEventRepository eveRepo, IHttpContextAccessor httpContextAccessor)
        {
            this.db = db;
            this.userManager = userManager;
            _eveRepo = eveRepo;
            _httpContextAccessor = httpContextAccessor;
        } 

        [HttpGet]
        [Authorize]
        public IActionResult CreateEvent() {
            CrudEvent crud = new CrudEvent();
            crud.errorNum = 0;
            crud.types = db.Types.Select(e => e.Name).ToArray();
            crud.eve = new Event();

            if (Request.Cookies.ContainsKey("EventTitle")){
                crud.eve.Title = Request.Cookies["EventTitle"];
                SetCreateEventTitle("");
            }
            return View("CreateEvent", crud);
        } 

        [Authorize]
        public IActionResult CreateEvent(int i) {
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
                if (ev.eve.StartDateTime.CompareTo(ev.eve.EndDateTime) != -1){
                    return RedirectToAction("CreateEvent", 2);
                }
                db.Events.Add(ev.eve);
                db.SaveChanges();
                return View("EventCreateSuccess");
            }
            return RedirectToAction("CreateEvent", 1);
        }

        [Authorize]
        [Route("Event/Display/{filter?}")]
        public async Task<IActionResult> Display(string filter)
        {
            string userName = userManager.GetUserName(User);
            var events = await _eveRepo.GetAllEvents(filter, userName);
            ViewData["today"] = DateTime.Today;
            if (filter != null)
            {
                string filterUndercase = filter.ToLower();
                if (filterUndercase == "meal" || filterUndercase == "activity" || filterUndercase == "visit" || filterUndercase == "shopping")
                {
                    var eventType = await _eveRepo.GetEventsByType(filter, userName);
                    if (eventType.Any())
                    {
                        return View("Display", eventType);
                    }
                }

                bool isPossiblyType = char.IsLetter(filter.FirstOrDefault());

                if(isPossiblyType == true)
                {
                    var eventType = await _eveRepo.GetEventsByLocation(filter, userName);
                    if (eventType.Any())
                    {
                        return View("Display", eventType);
                    }
                }

                Console.WriteLine(filter);
                string[] dates = filter.Split(' ');
                if (dates.Length == 2)
                {
                    string stringOne = dates[0];
                    string stringTwo = dates[1];

                    if (DateTime.TryParse(stringOne, out DateTime startDate))
                    {
                        if (DateTime.TryParse(stringTwo, out DateTime endDate))
                        {
                            var events2 = await _eveRepo.GetEventsByDate(filter, userName, startDate, endDate);
                            return View("Display", events2);
                        }
                    }
                }
                ViewData["status"] = "1";
                return View("Display", events);
            }
            return View("Display", events);
        }

        [Authorize]
        [Route("Event/Display/{day}/{month}/{year}")]
        public async Task<IActionResult> Display(int day, int month, int year, string filter)
        {
            string userName = userManager.GetUserName(User);
            var events = await _eveRepo.GetAllEvents("", userName);
            ViewData["today"] = new DateTime(year, month, day, 0, 0, 0);

            var events3 = await _eveRepo.GetAllEvents(filter, userName);
            if (filter != null)
            {
                string filterUndercase = filter.ToLower();
                if (filterUndercase == "meal" || filterUndercase == "activity" || filterUndercase == "visit" || filterUndercase == "shopping")
                {
                    var eventType = await _eveRepo.GetEventsByType(filter, userName);
                    if (eventType.Any())
                    {
                        return View("Display", eventType);
                    }
                }

                bool isPossiblyType = char.IsLetter(filter.FirstOrDefault());

                if (isPossiblyType == true)
                {
                    var eventType = await _eveRepo.GetEventsByLocation(filter, userName);
                    if (eventType.Any())
                    {
                        return View("Display", eventType);
                    }
                }

                Console.WriteLine(filter);
                string[] dates = filter.Split(' ');
                if (dates.Length == 2)
                {
                    string stringOne = dates[0];
                    string stringTwo = dates[1];

                    if (DateTime.TryParse(stringOne, out DateTime startDate))
                    {
                        if (DateTime.TryParse(stringTwo, out DateTime endDate))
                        {
                            var events2 = await _eveRepo.GetEventsByDate(filter, userName, startDate, endDate);
                            return View("Display", events2);
                        }
                    }
                }
                ViewData["status"] = "1";
                return View("Display", events3);
            }

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
            return RedirectToAction("Display");
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
                    return RedirectToAction("Display"); 
                }
                return View(model);
            }
            return RedirectToAction("Display");
        }

        [HttpGet]
        [Authorize]
        public IActionResult DeleteEvent(int id){
            if (userManager.GetUserName(User) == db.Events.Include(e => e.Account).Where(e => e.Id == id).Select(e => e.Account.Username).First()){
                return View(id);
            }
            return RedirectToAction("Display");
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
            return RedirectToAction("Display");
        }

        [Authorize]
        public async Task<IActionResult> Week()
        {
            string userName = userManager.GetUserName(User);
            DateTime startAtSunday = DateTime.Now.AddDays(DayOfWeek.Sunday - DateTime.Now.DayOfWeek);
            DateTime endAtSaturday = DateTime.Now.AddDays(DayOfWeek.Saturday - DateTime.Now.DayOfWeek);
            TimeSpan startOfDay = new TimeSpan(0, 0, 0);
            TimeSpan endOfDay = new TimeSpan(23, 59, 59);

            startAtSunday = startAtSunday.Date + startOfDay;
            endAtSaturday = endAtSaturday.Date + endOfDay;

            var events = await _eveRepo.GetEventsFromThisWeek(userName, startAtSunday, endAtSaturday);
            if (events.Any())
            {
                return View("Week", events);
            }
            return View("Week");
        }

        [Authorize]
        public void SetCreateEventTitle(string title){
            CookieOptions options = new CookieOptions();

            options.Domain = "localhost";
            options.Path = "/Event/CreateEvent";
            options.Secure = true;
            options.HttpOnly = true;

            Response.Cookies.Append("EventTitle", title, options);
        }
    }
}