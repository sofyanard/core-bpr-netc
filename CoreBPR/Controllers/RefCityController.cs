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
    public class RefCityController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RefCityController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RefCity
        public async Task<IActionResult> Index(string sort, string prov, string nama, int pageNumber = 1)
        {
            ViewData["ProvinceId"] = new SelectList(_context.RefProvinces.OrderBy(x => x.ProvinceId), "ProvinceId", "ProvinceName", prov);

            ViewData["sort"] = sort;
            ViewData["prov"] = prov;
            ViewData["nama"] = nama;

            ViewData["IdSortParm"] = String.IsNullOrEmpty(sort) ? "id_desc" : "";
            ViewData["NameSortParm"] = sort == "name" ? "name_desc" : "name";

            var cities = from s in _context.RefCities
                            select s;

            if (!String.IsNullOrEmpty(prov))
            {
                cities = cities.Where(s => s.ProvinceId == prov);
            }

            if (!String.IsNullOrEmpty(nama))
            {
                cities = cities.Where(s => s.CityName.ToLower().Contains(nama.ToLower()));
            }

            cities = sort switch
            {
                "id_desc" => cities.OrderByDescending(s => s.CityId),
                "name" => cities.OrderBy(s => s.CityName),
                "name_desc" => cities.OrderByDescending(s => s.CityName),
                _ => cities.OrderBy(s => s.CityId)
            };

            int pageSize = 10;

            int numRows = cities.Count();

            int excludeRecords = (pageSize * pageNumber) - pageSize;

            cities = cities.Skip(excludeRecords).Take(pageSize);
            cities = cities.Include(r => r.RefProvince);

            var results = new PagedResult<RefCity>
            {
                Data = await cities.AsNoTracking().ToListAsync(),
                TotalItems = numRows,
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            return View(results);
        }

        // GET: RefCity/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var refCity = await _context.RefCities
                .Include(r => r.RefProvince)
                .FirstOrDefaultAsync(m => m.CityId == id);
            if (refCity == null)
            {
                return NotFound();
            }

            return View(refCity);
        }

        // GET: RefCity/Create
        public IActionResult Create()
        {
            ViewData["ProvinceId"] = new SelectList(_context.RefProvinces.OrderBy(x => x.ProvinceId), "ProvinceId", "ProvinceName");
            return View();
        }

        // POST: RefCity/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CityId,ProvinceId,CityName")] RefCity refCity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(refCity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProvinceId"] = new SelectList(_context.RefProvinces.OrderBy(x => x.ProvinceId), "ProvinceId", "ProvinceName", refCity.ProvinceId);
            return View(refCity);
        }

        // GET: RefCity/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var refCity = await _context.RefCities.FindAsync(id);
            if (refCity == null)
            {
                return NotFound();
            }
            ViewData["ProvinceId"] = new SelectList(_context.RefProvinces.OrderBy(x => x.ProvinceId), "ProvinceId", "ProvinceName", refCity.ProvinceId);
            return View(refCity);
        }

        // POST: RefCity/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("CityId,ProvinceId,CityName")] RefCity refCity)
        {
            if (id != refCity.CityId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(refCity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RefCityExists(refCity.CityId))
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
            ViewData["ProvinceId"] = new SelectList(_context.RefProvinces.OrderBy(x => x.ProvinceId), "ProvinceId", "ProvinceName", refCity.ProvinceId);
            return View(refCity);
        }

        // GET: RefCity/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var refCity = await _context.RefCities
                .Include(r => r.RefProvince)
                .FirstOrDefaultAsync(m => m.CityId == id);
            if (refCity == null)
            {
                return NotFound();
            }

            return View(refCity);
        }

        // POST: RefCity/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var refCity = await _context.RefCities.FindAsync(id);
            _context.RefCities.Remove(refCity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RefCityExists(string id)
        {
            return _context.RefCities.Any(e => e.CityId == id);
        }
    }
}
