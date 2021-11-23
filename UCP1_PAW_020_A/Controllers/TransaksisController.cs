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
    public class TransaksisController : Controller
    {
        private readonly PenjualanBarangContext _context;

        public TransaksisController(PenjualanBarangContext context)
        {
            _context = context;
        }

        // GET: Transaksis
        public async Task<IActionResult> Index()
        {
            var penjualanBarangContext = _context.Transaksis.Include(t => t.IdBarangNavigation);
            return View(await penjualanBarangContext.ToListAsync());
        }

        // GET: Transaksis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaksi = await _context.Transaksis
                .Include(t => t.IdBarangNavigation)
                .FirstOrDefaultAsync(m => m.IdBarang == id);
            if (transaksi == null)
            {
                return NotFound();
            }

            return View(transaksi);
        }

        // GET: Transaksis/Create
        public IActionResult Create()
        {
            ViewData["IdBarang"] = new SelectList(_context.Customers, "IdCustomer", "IdCustomer");
            return View();
        }

        // POST: Transaksis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdBarang,IdJumlah,IdHarga,IdBayar")] Transaksi transaksi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(transaksi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdBarang"] = new SelectList(_context.Customers, "IdCustomer", "IdCustomer", transaksi.IdBarang);
            return View(transaksi);
        }

        // GET: Transaksis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaksi = await _context.Transaksis.FindAsync(id);
            if (transaksi == null)
            {
                return NotFound();
            }
            ViewData["IdBarang"] = new SelectList(_context.Customers, "IdCustomer", "IdCustomer", transaksi.IdBarang);
            return View(transaksi);
        }

        // POST: Transaksis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdBarang,IdJumlah,IdHarga,IdBayar")] Transaksi transaksi)
        {
            if (id != transaksi.IdBarang)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transaksi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransaksiExists(transaksi.IdBarang))
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
            ViewData["IdBarang"] = new SelectList(_context.Customers, "IdCustomer", "IdCustomer", transaksi.IdBarang);
            return View(transaksi);
        }

        // GET: Transaksis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaksi = await _context.Transaksis
                .Include(t => t.IdBarangNavigation)
                .FirstOrDefaultAsync(m => m.IdBarang == id);
            if (transaksi == null)
            {
                return NotFound();
            }

            return View(transaksi);
        }

        // POST: Transaksis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var transaksi = await _context.Transaksis.FindAsync(id);
            _context.Transaksis.Remove(transaksi);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TransaksiExists(int id)
        {
            return _context.Transaksis.Any(e => e.IdBarang == id);
        }
    }
}
