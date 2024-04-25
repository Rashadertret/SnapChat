using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SnapChatUserApi.Models;

namespace SnapChatUserApi.Controllers
{
    public class SegmentController : Controller
    {
        private readonly SnapChatUserApiContext _context;

        public SegmentController(SnapChatUserApiContext context)
        {
            _context = context;
        }

        // GET: Segment
        public async Task<IActionResult> Index()
        {
            return View(await _context.Segment.ToListAsync());
        }

        // GET: Segment/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var segment = await _context.Segment
                .FirstOrDefaultAsync(m => m.Id == id);
            if (segment == null)
            {
                return NotFound();
            }

            return View(segment);
        }

        // GET: Segment/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Segment/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Segment segment)
        {
            if (ModelState.IsValid)
            {
                segment.Id = Guid.NewGuid();
                _context.Add(segment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(segment);
        }

        // GET: Segment/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var segment = await _context.Segment.FindAsync(id);
            if (segment == null)
            {
                return NotFound();
            }
            return View(segment);
        }

        // POST: Segment/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name")] Segment segment)
        {
            if (id != segment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(segment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SegmentExists(segment.Id))
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
            return View(segment);
        }

        // GET: Segment/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var segment = await _context.Segment
                .FirstOrDefaultAsync(m => m.Id == id);
            if (segment == null)
            {
                return NotFound();
            }

            return View(segment);
        }

        // POST: Segment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var segment = await _context.Segment.FindAsync(id);
            if (segment != null)
            {
                _context.Segment.Remove(segment);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SegmentExists(Guid id)
        {
            return _context.Segment.Any(e => e.Id == id);
        }
    }
}
