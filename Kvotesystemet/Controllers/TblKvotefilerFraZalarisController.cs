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
    public class TblKvotefilerFraZalarisController : Controller
    {
        private readonly kvotesystem_SQLSQLContext _context;

        public TblKvotefilerFraZalarisController(kvotesystem_SQLSQLContext context)
        {
            _context = context;
        }

        // GET: TblKvotefilerFraZalaris
        public async Task<IActionResult> Index(string ansnr)
        {
            var kvotefiler = from m in _context.TblKvotefilerFraZalaris
                                 select m;


            if (!String.IsNullOrEmpty(ansnr))
            {
                kvotefiler = kvotefiler.Where(s => s.Ansattnummer.Equals(Convert.ToDouble(ansnr)));
            }


            return View(await kvotefiler.ToListAsync());
        }

        // GET: TblKvotefilerFraZalaris/Details/5
        public async Task<IActionResult> Details(double? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var tblKvotefilerFraZalaris = await _context.TblKvotefilerFraZalaris
            //    .FirstOrDefaultAsync(m => m.Ansattnummer == id);
            //if (tblKvotefilerFraZalaris == null)
            //{
            //    return NotFound();
            //}

            //return View(tblKvotefilerFraZalaris);
            var kvotefiler = from m in _context.TblKvotefilerFraZalaris
                             select m;
                kvotefiler = kvotefiler.Where(s => s.Ansattnummer.Equals(id));
            


            return View(await kvotefiler.ToListAsync());


        }

        // GET: TblKvotefilerFraZalaris/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TblKvotefilerFraZalaris/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Ansattnummer,Status,Fornavn,Etternavn,Ansettelsesdato,Kvotekode,StillingStatus,Stilling,OppdatertDato,Materialnummer,Antall,SalgsDato,Øl,Brus,Gratis,GratisBrus,UpsizeTs")] TblKvotefilerFraZalaris tblKvotefilerFraZalaris)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblKvotefilerFraZalaris);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblKvotefilerFraZalaris);
        }

        // GET: TblKvotefilerFraZalaris/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblKvotefilerFraZalaris = await _context.TblKvotefilerFraZalaris.FindAsync(id);
            if (tblKvotefilerFraZalaris == null)
            {
                return NotFound();
            }
            return View(tblKvotefilerFraZalaris);
        }

        // POST: TblKvotefilerFraZalaris/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Ansattnummer,Status,Fornavn,Etternavn,Ansettelsesdato,Kvotekode,StillingStatus,Stilling,OppdatertDato,Materialnummer,Antall,SalgsDato,Øl,Brus,Gratis,GratisBrus,UpsizeTs")] TblKvotefilerFraZalaris tblKvotefilerFraZalaris)
        {
            if (id != tblKvotefilerFraZalaris.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblKvotefilerFraZalaris);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblKvotefilerFraZalarisExists(tblKvotefilerFraZalaris.Id))
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
            return View(tblKvotefilerFraZalaris);
        }

        // GET: TblKvotefilerFraZalaris/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblKvotefilerFraZalaris = await _context.TblKvotefilerFraZalaris
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblKvotefilerFraZalaris == null)
            {
                return NotFound();
            }

            return View(tblKvotefilerFraZalaris);
        }

        // POST: TblKvotefilerFraZalaris/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblKvotefilerFraZalaris = await _context.TblKvotefilerFraZalaris.FindAsync(id);
            _context.TblKvotefilerFraZalaris.Remove(tblKvotefilerFraZalaris);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblKvotefilerFraZalarisExists(int id)
        {
            return _context.TblKvotefilerFraZalaris.Any(e => e.Id == id);
        }
    }
}
