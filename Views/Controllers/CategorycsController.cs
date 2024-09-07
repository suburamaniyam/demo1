using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HomeWorkOfProductAndCategory.Models;

namespace HomeWorkOfProductAndCategory.Controllers
{
    public class CategorycsController : Controller
    {
        private readonly ProductDbContextcs _context;

        public CategorycsController(ProductDbContextcs context)
        {
            _context = context;
        }

        // GET: Categorycs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Categorycs.ToListAsync());
        }

        // GET: Categorycs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categorycs = await _context.Categorycs
                .FirstOrDefaultAsync(m => m.Catid == id);
            if (categorycs == null)
            {
                return NotFound();
            }

            return View(categorycs);
        }

        // GET: Categorycs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categorycs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Catid,CatName")] Categorycs categorycs)
        {
            if (ModelState.IsValid)
            {
                _context.Add(categorycs);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(categorycs);
        }

        // GET: Categorycs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categorycs = await _context.Categorycs.FindAsync(id);
            if (categorycs == null)
            {
                return NotFound();
            }
            return View(categorycs);
        }

        // POST: Categorycs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Catid,CatName")] Categorycs categorycs)
        {
            if (id != categorycs.Catid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categorycs);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategorycsExists(categorycs.Catid))
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
            return View(categorycs);
        }

        // GET: Categorycs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categorycs = await _context.Categorycs
                .FirstOrDefaultAsync(m => m.Catid == id);
            if (categorycs == null)
            {
                return NotFound();
            }

            return View(categorycs);
        }

        // POST: Categorycs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var categorycs = await _context.Categorycs.FindAsync(id);
            if (categorycs != null)
            {
                _context.Categorycs.Remove(categorycs);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategorycsExists(int id)
        {
            return _context.Categorycs.Any(e => e.Catid == id);
        }
    }
}
