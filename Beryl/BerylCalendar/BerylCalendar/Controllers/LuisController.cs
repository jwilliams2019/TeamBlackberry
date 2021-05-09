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
    }
}