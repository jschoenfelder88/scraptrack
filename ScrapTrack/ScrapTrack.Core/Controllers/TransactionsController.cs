﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ScrapTrack.Data.DataAccess;
using ScrapTrack.Data.Models;

namespace ScrapTrack.Core.Controllers
{
    public class TransactionsController : Controller
    {
        private readonly AppDataDbContext _context;

        public TransactionsController(AppDataDbContext context)
        {
            _context = context;
        }

        // GET: Transactions
        public async Task<IActionResult> Index()
        {
            var appDataDbContext = _context.Transactions.Include(t => t.Item).Include(t => t.Volunteer);
            return PartialView("~/Views/Transactions/_ListTransaction.cshtml", await appDataDbContext.ToListAsync());
        }

        // GET: Transactions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaction = await _context.Transactions
                .Include(t => t.Item)
                .Include(t => t.Volunteer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (transaction == null)
            {
                return NotFound();
            }

            return View(transaction);
        }

        // GET: Transactions/Create
        public IActionResult Create()
        {
            ViewData["ItemId"] = new SelectList(_context.Items, "Id", "Description");
            ViewData["VolunteerId"] = new SelectList(_context.Volunteers, "Id", "FirstName");
            return PartialView("~/Views/Transactions/_CreateTransaction.cshtml");
        }

        // POST: Transactions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Date,VolunteerId,ItemId,Quantity")] Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                _context.Add(transaction);
                await _context.SaveChangesAsync();
                return PartialView("~/Views/Shared/_Success.cshtml");
            }
            ViewData["ItemId"] = new SelectList(_context.Items, "Id", "Description", transaction.ItemId);
            ViewData["VolunteerId"] = new SelectList(_context.Volunteers, "Id", "FirstName", transaction.VolunteerId);
            return PartialView("~/Views/Transactions/_CreateTransaction.cshtml", transaction);
        }

        // GET: Transactions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaction = await _context.Transactions.FindAsync(id);
            if (transaction == null)
            {
                return NotFound();
            }
            ViewData["ItemId"] = new SelectList(_context.Items, "Id", "Description", transaction.ItemId);
            ViewData["VolunteerId"] = new SelectList(_context.Volunteers, "Id", "FirstName", transaction.VolunteerId);
            return PartialView("~/Views/Transactions/_EditTransaction.cshtml", transaction);
        }

        // POST: Transactions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Date,VolunteerId,ItemId,Quantity")] Transaction transaction)
        {
            if (id != transaction.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transaction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransactionExists(transaction.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return PartialView("~/Views/Shared/_Success.cshtml");
            }
            ViewData["ItemId"] = new SelectList(_context.Items, "Id", "Description", transaction.ItemId);
            ViewData["VolunteerId"] = new SelectList(_context.Volunteers, "Id", "FirstName", transaction.VolunteerId);
            return PartialView("~/Views/Transactions/_EditTransaction.cshtml", transaction);
        }

        // GET: Transactions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaction = await _context.Transactions
                .Include(t => t.Item)
                .Include(t => t.Volunteer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (transaction == null)
            {
                return NotFound();
            }

            return PartialView("~/Views/Transactions/_DeleteTransaction.cshtml", transaction);
        }

        // POST: Transactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var transaction = await _context.Transactions.FindAsync(id);
            _context.Transactions.Remove(transaction);
            await _context.SaveChangesAsync();
            return PartialView("~/Views/Shared/_Success.cshtml");
        }

        private bool TransactionExists(int id)
        {
            return _context.Transactions.Any(e => e.Id == id);
        }
    }
}
