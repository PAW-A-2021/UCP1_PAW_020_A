using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UCP1_PAW_020_A.Models;

namespace UCP1_PAW_020_A.Controllers
{
    public class BonusController : Controller
    {
        private readonly PenjualanBarangContext _context;

        public BonusController(PenjualanBarangContext context)
        {
            _context = context;
        }

        // GET: Bonus
        public async Task<IActionResult> Index()
        {
            var penjualanBarangContext = _context.Bonus.Include(b => b.IdBonusNavigation);
            return View(await penjualanBarangContext.ToListAsync());
        }

        // GET: Bonus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bonu = await _context.Bonus
                .Include(b => b.IdBonusNavigation)
                .FirstOrDefaultAsync(m => m.IdBonus == id);
            if (bonu == null)
            {
                return NotFound();
            }

            return View(bonu);
        }

        // GET: Bonus/Create
        public IActionResult Create()
        {
            ViewData["IdBonus"] = new SelectList(_context.Transaksis, "IdBarang", "IdBarang");
            return View();
        }

        // POST: Bonus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdBonus,JumlahBonus")] Bonu bonu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bonu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdBonus"] = new SelectList(_context.Transaksis, "IdBarang", "IdBarang", bonu.IdBonus);
            return View(bonu);
        }

        // GET: Bonus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bonu = await _context.Bonus.FindAsync(id);
            if (bonu == null)
            {
                return NotFound();
            }
            ViewData["IdBonus"] = new SelectList(_context.Transaksis, "IdBarang", "IdBarang", bonu.IdBonus);
            return View(bonu);
        }

        // POST: Bonus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdBonus,JumlahBonus")] Bonu bonu)
        {
            if (id != bonu.IdBonus)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bonu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BonuExists(bonu.IdBonus))
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
            ViewData["IdBonus"] = new SelectList(_context.Transaksis, "IdBarang", "IdBarang", bonu.IdBonus);
            return View(bonu);
        }

        // GET: Bonus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bonu = await _context.Bonus
                .Include(b => b.IdBonusNavigation)
                .FirstOrDefaultAsync(m => m.IdBonus == id);
            if (bonu == null)
            {
                return NotFound();
            }

            return View(bonu);
        }

        // POST: Bonus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bonu = await _context.Bonus.FindAsync(id);
            _context.Bonus.Remove(bonu);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BonuExists(int id)
        {
            return _context.Bonus.Any(e => e.IdBonus == id);
        }
    }
}
