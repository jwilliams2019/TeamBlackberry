using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using classProject.Models;
using Microsoft.EntityFrameworkCore;

namespace classProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly HimalayanDbContext _context;

        public HomeController(HimalayanDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            int peaknum = _context.Peaks.Count();
            return View("Index", peaknum);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult US2Submit(String peak, DateTime start, DateTime end)
        {
            if (ModelState.IsValid)
            {
                int result = DateTime.Compare(start, end);
                if (result > 0 || peak is null)
                {
                    return View("US2");
                }

                IEnumerable<Expedition> results = _context.Expeditions
                                                    .Include(e => e.Peak)
                                                    .Include(d => d.TrekkingAgency)
                                                    .Where(x => x.Peak.Name == peak && x.StartDate >= start && x.StartDate < end);
                return View("US2", results);
            }
            return View("US2");
        }

        public IActionResult US2()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult US3Submit(DateTime input1, DateTime input2)
        {
            if (ModelState.IsValid)
            {
                int result = DateTime.Compare(input1, input2);
                if (result > 0)
                {
                    return View("US3");
                }

                IEnumerable<Expedition> all = _context.Expeditions.Include(e => e.Peak).Include(d => d.TrekkingAgency).Where(x => x.StartDate >= input1 && x.StartDate < input2);
                return View("US3", all);
            }
            return View("Index");
        }

        public IActionResult US3()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
