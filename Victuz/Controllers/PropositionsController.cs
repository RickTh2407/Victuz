using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Victuz.Data;
using Victuz.Models;

namespace Victuz.Controllers
{
    public class PropositionsController : Controller
    {
        private readonly VictuzDB _context;

        public PropositionsController(VictuzDB context)
        {
            _context = context;
        }

        // GET: Propositions
        public async Task<IActionResult> Index()
        {
            return View(await _context.Propositions.ToListAsync());
        }

        // GET: Propositions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proposition = await _context.Propositions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (proposition == null)
            {
                return NotFound();
            }

            return View(proposition);
        }

        // GET: Propositions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Propositions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Date,MemberName,StatusDisplay")] Proposition proposition)
        {
            if (ModelState.IsValid)
            {
                _context.Add(proposition);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(proposition);
        }

        // GET: Propositions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proposition = await _context.Propositions.FindAsync(id);
            if (proposition == null)
            {
                return NotFound();
            }
            return View(proposition);
        }

        // POST: Propositions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Date,MemberName,StatusDisplay")] Proposition proposition)
        {
            if (id != proposition.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(proposition);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PropositionExists(proposition.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(proposition);
        }

        // GET: Propositions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proposition = await _context.Propositions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (proposition == null)
            {
                return NotFound();
            }

            return View(proposition);
        }

        // POST: Propositions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var proposition = await _context.Propositions.FindAsync(id);
            if (proposition != null)
            {
                _context.Propositions.Remove(proposition);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PropositionExists(int id)
        {
            return _context.Propositions.Any(e => e.Id == id);
        }
    }
}
