using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using cloudscribe.Pagination.Models;
using CoreBPR.Models;

namespace CoreBPR.Controllers
{
    public class RefUnitController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RefUnitController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RefUnit
        public async Task<IActionResult> Index(string sort, string city, string nama, int pageNumber = 1)
        {
            ViewData["CityId"] = new SelectList(_context.RefCities.OrderBy(x => x.CityId), "CityId", "CityName", city);

            ViewData["sort"] = sort;
            ViewData["city"] = city;
            ViewData["nama"] = nama;

            ViewData["IdSortParm"] = String.IsNullOrEmpty(sort) ? "id_desc" : "";
            ViewData["NameSortParm"] = sort == "name" ? "name_desc" : "name";

            var units = from s in _context.RefUnits
                         select s;

            if (!String.IsNullOrEmpty(city))
            {
                units = units.Where(s => s.CityId == city);
            }

            if (!String.IsNullOrEmpty(nama))
            {
                units = units.Where(s => s.UnitName.ToLower().Contains(nama.ToLower()) 
                                        || s.Address.ToLower().Contains(nama.ToLower()));
            }

            units = sort switch
            {
                "id_desc" => units.OrderByDescending(s => s.UnitId),
                "name" => units.OrderBy(s => s.UnitName),
                "name_desc" => units.OrderByDescending(s => s.UnitName),
                _ => units.OrderBy(s => s.UnitId)
            };

            int pageSize = 10;

            int numRows = units.Count();

            int excludeRecords = (pageSize * pageNumber) - pageSize;

            units = units.Skip(excludeRecords).Take(pageSize);
            units = units.Include(r => r.RefCity);

            var results = new PagedResult<RefUnit>
            {
                Data = await units.AsNoTracking().ToListAsync(),
                TotalItems = numRows,
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            return View(results);
        }

        // GET: RefUnit/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var refUnit = await _context.RefUnits
                .Include(r => r.RefCity)
                .FirstOrDefaultAsync(m => m.UnitId == id);
            if (refUnit == null)
            {
                return NotFound();
            }

            return View(refUnit);
        }

        // GET: RefUnit/Create
        public IActionResult Create()
        {
            ViewData["CityId"] = new SelectList(_context.RefCities.OrderBy(x => x.CityId), "CityId", "CityName");
            return View();
        }

        // POST: RefUnit/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UnitId,UnitName,KodeBPR,Address,CityId,IsActive")] RefUnit refUnit)
        {
            if (ModelState.IsValid)
            {
                _context.Add(refUnit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CityId"] = new SelectList(_context.RefCities.OrderBy(x => x.CityId), "CityId", "CityName", refUnit.CityId);
            return View(refUnit);
        }

        // GET: RefUnit/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var refUnit = await _context.RefUnits.FindAsync(id);
            if (refUnit == null)
            {
                return NotFound();
            }
            ViewData["CityId"] = new SelectList(_context.RefCities.OrderBy(x => x.CityId), "CityId", "CityName", refUnit.CityId);
            return View(refUnit);
        }

        // POST: RefUnit/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("UnitId,UnitName,KodeBPR,Address,CityId,IsActive")] RefUnit refUnit)
        {
            if (id != refUnit.UnitId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(refUnit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RefUnitExists(refUnit.UnitId))
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
            ViewData["CityId"] = new SelectList(_context.RefCities.OrderBy(x => x.CityId), "CityId", "CityName", refUnit.CityId);
            return View(refUnit);
        }

        // GET: RefUnit/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var refUnit = await _context.RefUnits
                .Include(r => r.RefCity)
                .FirstOrDefaultAsync(m => m.UnitId == id);
            if (refUnit == null)
            {
                return NotFound();
            }

            return View(refUnit);
        }

        // POST: RefUnit/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var refUnit = await _context.RefUnits.FindAsync(id);
            _context.RefUnits.Remove(refUnit);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RefUnitExists(string id)
        {
            return _context.RefUnits.Any(e => e.UnitId == id);
        }
    }
}
