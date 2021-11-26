using Microsoft.AspNetCore.Identity;
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
        private readonly DataDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public TransactionsController(DataDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
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

        [HttpPost]
        public async Task<IActionResult> Create(int id, [FromBody] List<TransactionItem> transactionItems)
        {
            if (User.Identity.IsAuthenticated)
            {
                DateTime transactionSubmission = DateTime.Now;
                ApplicationUser curAppUser = await _userManager.GetUserAsync(User);
                Volunteer volunteer = await _context.Volunteers
                    .FirstOrDefaultAsync(m => m.Id == id);

                Transaction newTransaction = new Transaction()
                {
                    Date = transactionSubmission,
                    ApplicationUser = curAppUser,
                    Volunteer = volunteer
                };

                _context.Add(newTransaction);
                _context.SaveChanges();


                for (int i = 0; i < transactionItems.Count; i++)
                {
                    Item selectedItem = await _context.Items.FirstOrDefaultAsync(m => m.Id == transactionItems[i].ItemId);

                    Transaction_Details transactionDetail = new Transaction_Details()
                    {
                        Item = selectedItem,
                        Quantity = transactionItems[i].Quantity,
                        Transaction = newTransaction
                    };

                    _context.Add(transactionDetail);
                    await _context.SaveChangesAsync();
                }

                return PartialView("~/Views/Shared/_Success.cshtml");
            }
            return RedirectToAction("Index", "Home");
        }
    }

    public class TransactionItem
    {
        public int ItemId { get; set; }
        public int Quantity { get; set; }
    }
}
