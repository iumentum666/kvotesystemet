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
    public class TblMaterialMastersController : Controller
    {
        private readonly kvotesystem_SQLSQLContext _context;

        public TblMaterialMastersController(kvotesystem_SQLSQLContext context)
        {
            _context = context;
        }

        // GET: TblMaterialMasters
        public async Task<IActionResult> Index(string varenr, string varenvn)
        {
            var materialmaster = from m in _context.TblMaterialMaster
                      select m;

            if (!String.IsNullOrEmpty(varenr))
            {
                materialmaster = materialmaster.Where(s => s.Bsp1.Equals(Convert.ToDouble(varenr)));
            }

            if (!String.IsNullOrEmpty(varenvn))
            {
                materialmaster = materialmaster.Where(s => s.Tekst.Contains(varenvn));
            }

            return View(await materialmaster.ToListAsync());
        }

        // GET: TblMaterialMasters/Details/5
        public async Task<IActionResult> Details(double? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblMaterialMaster = await _context.TblMaterialMaster
                .FirstOrDefaultAsync(m => m.Bsp1 == id);
            if (tblMaterialMaster == null)
            {
                return NotFound();
            }

            return View(tblMaterialMaster);
        }

        // GET: TblMaterialMasters/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TblMaterialMasters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Legacy,Bsp1,Tekst,Liter,Mg1,IkkeTillatt,Brus,Øl,UpsizeTs")] TblMaterialMaster tblMaterialMaster)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblMaterialMaster);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblMaterialMaster);
        }

        // GET: TblMaterialMasters/Edit/5
        public async Task<IActionResult> Edit(double? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblMaterialMaster = await _context.TblMaterialMaster.FindAsync(id);
            if (tblMaterialMaster == null)
            {
                return NotFound();
            }
            return View(tblMaterialMaster);
        }

        // POST: TblMaterialMasters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(double id, [Bind("Legacy,Bsp1,Tekst,Liter,Mg1,IkkeTillatt,Brus,Øl,UpsizeTs")] TblMaterialMaster tblMaterialMaster)
        {
            if (id != tblMaterialMaster.Bsp1)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblMaterialMaster);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblMaterialMasterExists(tblMaterialMaster.Bsp1))
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
            return View(tblMaterialMaster);
        }

        // GET: TblMaterialMasters/Delete/5
        public async Task<IActionResult> Delete(double? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblMaterialMaster = await _context.TblMaterialMaster
                .FirstOrDefaultAsync(m => m.Bsp1 == id);
            if (tblMaterialMaster == null)
            {
                return NotFound();
            }

            return View(tblMaterialMaster);
        }

        // POST: TblMaterialMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(double id)
        {
            var tblMaterialMaster = await _context.TblMaterialMaster.FindAsync(id);
            _context.TblMaterialMaster.Remove(tblMaterialMaster);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblMaterialMasterExists(double id)
        {
            return _context.TblMaterialMaster.Any(e => e.Bsp1 == id);
        }
    }
}
