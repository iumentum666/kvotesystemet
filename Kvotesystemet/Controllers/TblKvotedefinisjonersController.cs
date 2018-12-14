using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Kvotesystemet.Models;

namespace Kvotesystemet.Controllers
{
    public class TblKvotedefinisjonersController : Controller
    {
        private readonly kvotesystem_SQLSQLContext _context;

        public TblKvotedefinisjonersController(kvotesystem_SQLSQLContext context)
        {
            _context = context;
        }

        // GET: TblKvotedefinisjoners
        public async Task<IActionResult> Index()
        {
            return View(await _context.TblKvotedefinisjoner.ToListAsync());
        }

        // GET: TblKvotedefinisjoners/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblKvotedefinisjoner = await _context.TblKvotedefinisjoner
                .FirstOrDefaultAsync(m => m.Kvote == id);
            if (tblKvotedefinisjoner == null)
            {
                return NotFound();
            }

            return View(tblKvotedefinisjoner);
        }

        // GET: TblKvotedefinisjoners/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TblKvotedefinisjoners/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Kvote,Øl,Brus,Gratis,UpsizeTs")] TblKvotedefinisjoner tblKvotedefinisjoner)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblKvotedefinisjoner);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblKvotedefinisjoner);
        }

        // GET: TblKvotedefinisjoners/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblKvotedefinisjoner = await _context.TblKvotedefinisjoner.FindAsync(id);
            if (tblKvotedefinisjoner == null)
            {
                return NotFound();
            }
            return View(tblKvotedefinisjoner);
        }

        // POST: TblKvotedefinisjoners/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Kvote,Øl,Brus,Gratis,UpsizeTs")] TblKvotedefinisjoner tblKvotedefinisjoner)
        {
            if (id != tblKvotedefinisjoner.Kvote)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblKvotedefinisjoner);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblKvotedefinisjonerExists(tblKvotedefinisjoner.Kvote))
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
            return View(tblKvotedefinisjoner);
        }

        // GET: TblKvotedefinisjoners/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblKvotedefinisjoner = await _context.TblKvotedefinisjoner
                .FirstOrDefaultAsync(m => m.Kvote == id);
            if (tblKvotedefinisjoner == null)
            {
                return NotFound();
            }

            return View(tblKvotedefinisjoner);
        }

        // POST: TblKvotedefinisjoners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var tblKvotedefinisjoner = await _context.TblKvotedefinisjoner.FindAsync(id);
            _context.TblKvotedefinisjoner.Remove(tblKvotedefinisjoner);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblKvotedefinisjonerExists(string id)
        {
            return _context.TblKvotedefinisjoner.Any(e => e.Kvote == id);
        }
    }
}
