using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult US3Submit(DateTime input1, DateTime input2)
        {

            //var date1test = DateTime.Parse(test1);
            //Console.WriteLine(input1);
            if (ModelState.IsValid)
            {
                int result = DateTime.Compare(input1, input2);
                if (result < 0)
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
