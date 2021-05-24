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
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.Extensions.Configuration;

namespace BerylCalendar.Controllers
{
    public class LuisController : Controller
    { 
        private readonly string apiKey;
        private readonly IEventRepository _eveRepo;
        private BerylDbContext db;
        private readonly UserManager<IdentityUser> userManager;
        private IHttpContextAccessor _httpContextAccessor;

        public LuisController(BerylDbContext db, UserManager<IdentityUser> userManager, IEventRepository eveRepo, IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
        {
            apiKey = configuration["LuisAPIKeyValue"];
            this.db = db;
            this.userManager = userManager;
            _eveRepo = eveRepo;
            _httpContextAccessor = httpContextAccessor;
        } 

        [HttpPost]
        [Authorize]
        public IActionResult Interpret(string command){
            Debug.WriteLine(command);
            LuisAPI luis = new LuisAPI(apiKey+command);
            string luisResponse = luis.LuisListen();
            Debug.WriteLine(luisResponse);

            JObject response = JObject.Parse(luisResponse);
            string intent = "Error in C# call";
            try {
                intent = (string)response["prediction"]["topIntent"];
            } catch (NullReferenceException e) {
                Debug.WriteLine("Error in C# call");
            }

            if (intent.Equals("Error in C# call") == false){
                if (intent.Equals("Calendar.CreateEventWithTitle") != false){
                    SetCreateEventTitle((string)response["prediction"]["entities"]["Title"][0]);
                }
            }
            return Json(intent);
        }

        [Authorize]
        public void SetCreateEventTitle(string title){
            CookieOptions options = new CookieOptions();

            //options.Domain = "localhost";
            options.Domain = "berylcalendarapp.azurewebsites.net";
            options.Path = "/Event/CreateEvent";
            options.Secure = true;
            options.HttpOnly = true;

            Response.Cookies.Append("EventTitle", title, options);
        }
    }
}