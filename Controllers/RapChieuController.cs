using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using doan.Data;
using doan.Models;

namespace doan.Controllers
{
    public class RapChieuController : Controller
    {
        private readonly CineSVContext _context;

        public RapChieuController(CineSVContext context)
        {
            _context = context;
        }

        // GET: RapChieu
        public async Task<IActionResult> Index()
        {
            return View(await _context.RapChieus.ToListAsync());
        }

        // GET: RapChieu/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rapChieuModel = await _context.RapChieus
                .FirstOrDefaultAsync(m => m.MARAP == id);
            if (rapChieuModel == null)
            {
                return NotFound();
            }

            return View(rapChieuModel);
        }

        // GET: RapChieu/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RapChieu/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MARAP,TENRAP,DIACHI")] RapChieuModel rapChieuModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rapChieuModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rapChieuModel);
        }

        // GET: RapChieu/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rapChieuModel = await _context.RapChieus.FindAsync(id);
            if (rapChieuModel == null)
            {
                return NotFound();
            }
            return View(rapChieuModel);
        }

        // POST: RapChieu/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("MARAP,TENRAP,DIACHI")] RapChieuModel rapChieuModel)
        {
            if (id != rapChieuModel.MARAP)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rapChieuModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RapChieuModelExists(rapChieuModel.MARAP))
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
            return View(rapChieuModel);
        }

        // GET: RapChieu/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rapChieuModel = await _context.RapChieus
                .FirstOrDefaultAsync(m => m.MARAP == id);
            if (rapChieuModel == null)
            {
                return NotFound();
            }

            return View(rapChieuModel);
        }

        // POST: RapChieu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var rapChieuModel = await _context.RapChieus.FindAsync(id);
            _context.RapChieus.Remove(rapChieuModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RapChieuModelExists(decimal id)
        {
            return _context.RapChieus.Any(e => e.MARAP == id);
        }
    }
}
