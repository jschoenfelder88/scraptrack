using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ScrapTrack.Core.Models;
using ScrapTrack.Data.DataAccess;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ScrapTrack.Core.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly DataDbContext _context;
        public HomeController(ILogger<HomeController> logger, DataDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var dashboardModel = new DashboardViewModel()
            {
                TransactionList = _context.Transactions.Include(t => t.Volunteer ).Include(t => t.ApplicationUser).ToList(),
                ItemList = _context.Items.Include(a => a.Category).ToList(),
                VolunteerList = _context.Volunteers.ToList(),
                CategoryId = new SelectList(_context.Categories, "Id", "Description")
            };

            return View(dashboardModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
