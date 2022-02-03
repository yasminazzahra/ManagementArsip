using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ManagementArsip.Models;

namespace ManagementArsip.Controllers
{
    public class LokasisController : Controller
    {
        private readonly ArsipContext _context;

        public LokasisController(ArsipContext context)
        {
            _context = context;
        }

        // GET: Lokasis
        public async Task<IActionResult> Index()
        {
            return View(await _context.Lokasis.ToListAsync());
        }

        // GET: Lokasis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lokasi = await _context.Lokasis
                .FirstOrDefaultAsync(m => m.IdLokasi == id);
            if (lokasi == null)
            {
                return NotFound();
            }

            return View(lokasi);
        }

        // GET: Lokasis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Lokasis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdLokasi,NamaLokasi,IdUser")] Lokasi lokasi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lokasi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lokasi);
        }

        // GET: Lokasis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lokasi = await _context.Lokasis.FindAsync(id);
            if (lokasi == null)
            {
                return NotFound();
            }
            return View(lokasi);
        }

        // POST: Lokasis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdLokasi,NamaLokasi,IdUser")] Lokasi lokasi)
        {
            if (id != lokasi.IdLokasi)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lokasi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LokasiExists(lokasi.IdLokasi))
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
            return View(lokasi);
        }

        // GET: Lokasis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lokasi = await _context.Lokasis
                .FirstOrDefaultAsync(m => m.IdLokasi == id);
            if (lokasi == null)
            {
                return NotFound();
            }

            return View(lokasi);
        }

        // POST: Lokasis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lokasi = await _context.Lokasis.FindAsync(id);
            _context.Lokasis.Remove(lokasi);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LokasiExists(int id)
        {
            return _context.Lokasis.Any(e => e.IdLokasi == id);
        }
    }
}
