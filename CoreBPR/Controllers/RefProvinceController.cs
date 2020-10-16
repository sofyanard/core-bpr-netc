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
    public class RefProvinceController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RefProvinceController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RefProvince
        public IActionResult Index(string sortOrder, string currentFilter, string searchString, int pageNumber = 1)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["IdSortParm"] = String.IsNullOrEmpty(sortOrder) ? "id_desc" : "";
            ViewData["NameSortParm"] = sortOrder == "name" ? "name_desc" : "name";
            ViewData["CurrentFilter"] = searchString;

            if (searchString != null)
            {
                // pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var provinces = from s in _context.RefProvinces
                            select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                provinces = provinces.Where(s => s.ProvinceName.ToLower().Contains(searchString.ToLower()));
            }

            provinces = sortOrder switch
            {
                "id_desc" => provinces.OrderByDescending(s => s.ProvinceId),
                "name" => provinces.OrderBy(s => s.ProvinceName),
                "name_desc" => provinces.OrderByDescending(s => s.ProvinceName),
                _ => provinces.OrderBy(s => s.ProvinceId)
            };

            int pageSize = 10;

            int numRows = provinces.Count();

            int excludeRecords = (pageSize * pageNumber) - pageSize;

            provinces = provinces.Skip(excludeRecords).Take(pageSize);

            var results = new PagedResult<RefProvince>
            {
                Data = provinces.AsNoTracking().ToList(),
                TotalItems = numRows,
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            return View(results);
        }

        // GET: RefProvince/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var refProvince = await _context.RefProvinces
                .FirstOrDefaultAsync(m => m.ProvinceId == id);
            if (refProvince == null)
            {
                return NotFound();
            }

            return View(refProvince);
        }

        // GET: RefProvince/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RefProvince/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProvinceId,ProvinceName")] RefProvince refProvince)
        {
            if (ModelState.IsValid)
            {
                _context.Add(refProvince);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(refProvince);
        }

        // GET: RefProvince/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var refProvince = await _context.RefProvinces.FindAsync(id);
            if (refProvince == null)
            {
                return NotFound();
            }
            return View(refProvince);
        }

        // POST: RefProvince/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ProvinceId,ProvinceName")] RefProvince refProvince)
        {
            if (id != refProvince.ProvinceId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(refProvince);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RefProvinceExists(refProvince.ProvinceId))
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
            return View(refProvince);
        }

        // GET: RefProvince/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var refProvince = await _context.RefProvinces
                .FirstOrDefaultAsync(m => m.ProvinceId == id);
            if (refProvince == null)
            {
                return NotFound();
            }

            return View(refProvince);
        }

        // POST: RefProvince/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var refProvince = await _context.RefProvinces.FindAsync(id);
            _context.RefProvinces.Remove(refProvince);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RefProvinceExists(string id)
        {
            return _context.RefProvinces.Any(e => e.ProvinceId == id);
        }
    }
}
