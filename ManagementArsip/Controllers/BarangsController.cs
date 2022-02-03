﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ManagementArsip.Models;

namespace ManagementArsip.Controllers
{
    public class BarangsController : Controller
    {
        private readonly ArsipContext _context;

        public BarangsController(ArsipContext context)
        {
            _context = context;
        }

        // GET: Barangs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Barangs.ToListAsync());
        }

        // GET: Barangs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var barang = await _context.Barangs
                .FirstOrDefaultAsync(m => m.IdBarang == id);
            if (barang == null)
            {
                return NotFound();
            }

            return View(barang);
        }

        // GET: Barangs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Barangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdBarang,DeskripsiBarang,KodeBarang,TahunPengadaan,MerkBarang,StatusBarang,IdUser,TanggalMasuk")] Barang barang)
        {
            if (ModelState.IsValid)
            {
                _context.Add(barang);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(barang);
        }

        // GET: Barangs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var barang = await _context.Barangs.FindAsync(id);
            if (barang == null)
            {
                return NotFound();
            }
            return View(barang);
        }

        // POST: Barangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdBarang,DeskripsiBarang,KodeBarang,TahunPengadaan,MerkBarang,StatusBarang,IdUser,TanggalMasuk")] Barang barang)
        {
            if (id != barang.IdBarang)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(barang);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BarangExists(barang.IdBarang))
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
            return View(barang);
        }

        // GET: Barangs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var barang = await _context.Barangs
                .FirstOrDefaultAsync(m => m.IdBarang == id);
            if (barang == null)
            {
                return NotFound();
            }

            return View(barang);
        }

        // POST: Barangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var barang = await _context.Barangs.FindAsync(id);
            _context.Barangs.Remove(barang);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BarangExists(int id)
        {
            return _context.Barangs.Any(e => e.IdBarang == id);
        }
    }
}
