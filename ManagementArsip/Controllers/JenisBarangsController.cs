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
    public class JenisBarangsController : Controller
    {
        private readonly ArsipContext _context;

        public JenisBarangsController(ArsipContext context)
        {
            _context = context;
        }

        // GET: JenisBarangs
        public async Task<IActionResult> Index()
        {
            return View(await _context.JenisBarangs.ToListAsync());
        }

        // GET: JenisBarangs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jenisBarang = await _context.JenisBarangs
                .FirstOrDefaultAsync(m => m.IdJenisbarang == id);
            if (jenisBarang == null)
            {
                return NotFound();
            }

            return View(jenisBarang);
        }

        // GET: JenisBarangs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: JenisBarangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdJenisbarang,NamaJenisbarang,IdBarang")] JenisBarang jenisBarang)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jenisBarang);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(jenisBarang);
        }

        // GET: JenisBarangs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jenisBarang = await _context.JenisBarangs.FindAsync(id);
            if (jenisBarang == null)
            {
                return NotFound();
            }
            return View(jenisBarang);
        }

        // POST: JenisBarangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdJenisbarang,NamaJenisbarang,IdBarang")] JenisBarang jenisBarang)
        {
            if (id != jenisBarang.IdJenisbarang)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jenisBarang);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JenisBarangExists(jenisBarang.IdJenisbarang))
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
            return View(jenisBarang);
        }

        // GET: JenisBarangs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jenisBarang = await _context.JenisBarangs
                .FirstOrDefaultAsync(m => m.IdJenisbarang == id);
            if (jenisBarang == null)
            {
                return NotFound();
            }

            return View(jenisBarang);
        }

        // POST: JenisBarangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jenisBarang = await _context.JenisBarangs.FindAsync(id);
            _context.JenisBarangs.Remove(jenisBarang);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JenisBarangExists(int id)
        {
            return _context.JenisBarangs.Any(e => e.IdJenisbarang == id);
        }
    }
}
