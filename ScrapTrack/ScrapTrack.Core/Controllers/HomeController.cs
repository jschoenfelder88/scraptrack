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
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Http;
using System.IO;
using OfficeOpenXml;

namespace ScrapTrack.Core.Controllers
{
    [Authorize]    
    public class HomeController : Controller
    {
        //database object
        db dbop = new db();

        private readonly ILogger<HomeController> _logger;

        private readonly DataDbContext _context;
        public HomeController(ILogger<HomeController> logger, DataDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            DataSet ds = dbop.Getrecord();
            var dashboardModel = new DashboardViewModel()
            {
                TransactionList = _context.Transactions.Include(t => t.Volunteer ).Include(t => t.ApplicationUser).ToList(),
                ItemList = _context.Items.Include(a => a.Category).ToList(),
                VolunteerList = _context.Volunteers.ToList(),
                CategoryId = new SelectList(_context.Categories, "Id", "Description")
            };

            return View(dashboardModel);
        }

        //method for button Export Reports
        public IActionResult ExporttoExcel()
        {
            DataSet ds = dbop.Getrecord();
            var stream = new MemoryStream();

            using (var package = new ExcelPackage(stream))
            {
                var worksheet = package.Workbook.Worksheets.Add("Sheet1");
                worksheet.Cells.LoadFromDataTable(ds.Tables[0], true);
                package.Save();
            }
            stream.Position = 0;
            string excelname = $"ScrapTrack-Report-{DateTime.Now.ToString("yyyyMMddHHmmssfff")}.xlsx";
            return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", excelname);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
