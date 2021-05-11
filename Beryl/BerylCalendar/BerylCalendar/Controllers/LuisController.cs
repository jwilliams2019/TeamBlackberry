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
    public class LuisController : Controller
    {
        private readonly IEventRepository _eveRepo;
        private BerylDbContext db;
        private readonly UserManager<IdentityUser> userManager;

        public LuisController(BerylDbContext db, UserManager<IdentityUser> userManager, IEventRepository eveRepo)
        {
            this.db = db;
            this.userManager = userManager;
            _eveRepo = eveRepo;
        } 

        [HttpPost]
        [Authorize]
        public IActionResult Interpret(string command){
            Debug.WriteLine(command);
            LuisAPI luis = new LuisAPI("https://westus.api.cognitive.microsoft.com/luis/prediction/v3.0/apps/31f1ec6d-0937-4be3-b27d-d174706a3a9d/slots/staging/predict?subscription-key=a47c74c982a54480962b3fcae8b9bb64&verbose=true&show-all-intents=true&log=true&query="+command);
            string intent = luis.LuisListen();
            return Json(intent);
        }

        
    }
}