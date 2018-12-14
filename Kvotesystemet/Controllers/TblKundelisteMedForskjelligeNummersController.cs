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
    public class TblKundelisteMedForskjelligeNummersController : Controller
    {
        private readonly kvotesystem_SQLSQLContext _context;

        public TblKundelisteMedForskjelligeNummersController(kvotesystem_SQLSQLContext context)
        {
            _context = context;
        }

        // GET: TblKundelisteMedForskjelligeNummers
        public async Task<IActionResult> Index(string ansnr, string kunnr, string forn, string ettern)
        {
            var anr = from m in _context.TblKundelisteMedForskjelligeNummer
                         select m;

            if (!String.IsNullOrEmpty(ansnr))
            {
                anr = anr.Where(s => s.Ansattnr.Equals(Convert.ToDouble(ansnr)));
            }

            if (!String.IsNullOrEmpty(kunnr))
            {
                anr = anr.Where(s => s.T0e.Equals(kunnr));
            }

            if (!String.IsNullOrEmpty(forn))
            {
                anr = anr.Where(s => s.Fornavn.Contains(forn));
            }

            if (!String.IsNullOrEmpty(ettern))
            {
                anr = anr.Where(s => s.Etternavn.Contains(ettern));
            }

            return View(await anr.ToListAsync());
        }

        // GET: TblKundelisteMedForskjelligeNummers/Details/5
        public async Task<IActionResult> Details(double? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblKundelisteMedForskjelligeNummer = await _context.TblKundelisteMedForskjelligeNummer
                .FirstOrDefaultAsync(m => m.Ansattnr == id);
            if (tblKundelisteMedForskjelligeNummer == null)
            {
                return NotFound();
            }

            return View(tblKundelisteMedForskjelligeNummer);
        }

        // GET: TblKundelisteMedForskjelligeNummers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TblKundelisteMedForskjelligeNummers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("C47Nummer,C47Navn,Ansattnr,T0e,T0eNavn,Fornavn,Etternavn")] TblKundelisteMedForskjelligeNummer tblKundelisteMedForskjelligeNummer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblKundelisteMedForskjelligeNummer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblKundelisteMedForskjelligeNummer);
        }

        // GET: TblKundelisteMedForskjelligeNummers/Edit/5
        public async Task<IActionResult> Edit(double? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblKundelisteMedForskjelligeNummer = await _context.TblKundelisteMedForskjelligeNummer.FindAsync(id);
            if (tblKundelisteMedForskjelligeNummer == null)
            {
                return NotFound();
            }
            return View(tblKundelisteMedForskjelligeNummer);
        }

        // POST: TblKundelisteMedForskjelligeNummers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(double id, [Bind("C47Nummer,C47Navn,Ansattnr,T0e,T0eNavn,Fornavn,Etternavn")] TblKundelisteMedForskjelligeNummer tblKundelisteMedForskjelligeNummer)
        {
            if (id != tblKundelisteMedForskjelligeNummer.Ansattnr)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblKundelisteMedForskjelligeNummer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblKundelisteMedForskjelligeNummerExists(tblKundelisteMedForskjelligeNummer.Ansattnr))
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
            return View(tblKundelisteMedForskjelligeNummer);
        }

        // GET: TblKundelisteMedForskjelligeNummers/Delete/5
        public async Task<IActionResult> Delete(double? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblKundelisteMedForskjelligeNummer = await _context.TblKundelisteMedForskjelligeNummer
                .FirstOrDefaultAsync(m => m.Ansattnr == id);
            if (tblKundelisteMedForskjelligeNummer == null)
            {
                return NotFound();
            }

            return View(tblKundelisteMedForskjelligeNummer);
        }

        // POST: TblKundelisteMedForskjelligeNummers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(double id)
        {
            var tblKundelisteMedForskjelligeNummer = await _context.TblKundelisteMedForskjelligeNummer.FindAsync(id);
            _context.TblKundelisteMedForskjelligeNummer.Remove(tblKundelisteMedForskjelligeNummer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblKundelisteMedForskjelligeNummerExists(double id)
        {
            return _context.TblKundelisteMedForskjelligeNummer.Any(e => e.Ansattnr == id);
        }
    }
}
