using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ScrapTrack.Core.Models;
using ScrapTrack.Data.DataAccess;
using ScrapTrack.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScrapTrack.Core.Controllers
{
    public class TransactionsController : Controller
    {
        private readonly AppDataDbContext _context;

        public TransactionsController(AppDataDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> SelectVolunteer()
        {
            return PartialView("~/Views/Transactions/_SelectVolunteer.cshtml", await _context.Volunteers.ToListAsync());
        }

        public async Task<IActionResult> Create(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var volunteer = await _context.Volunteers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (volunteer == null)
            {
                return NotFound();
            }
            var viewModel = new TransactionViewModel()
            {
                volunteer = volunteer,
                items = await _context.Items.Include(i => i.Category).ToListAsync()
            };
            return PartialView("~/Views/Transactions/_CreateTransaction.cshtml", viewModel);
        }
    }
}
