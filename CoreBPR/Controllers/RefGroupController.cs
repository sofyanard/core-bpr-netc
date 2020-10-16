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
    public class RefGroupController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RefGroupController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RefGroup
        public async Task<IActionResult> Index(string sort, string nama, int pageNumber = 1)
        {
            ViewData["sort"] = sort;
            ViewData["nama"] = nama;

            ViewData["IdSortParm"] = String.IsNullOrEmpty(sort) ? "id_desc" : "";
            ViewData["NameSortParm"] = sort == "name" ? "name_desc" : "name";

            var groups = from s in _context.RefGroups
                        select s;

            if (!String.IsNullOrEmpty(nama))
            {
                groups = groups.Where(s => s.GroupName.ToLower().Contains(nama.ToLower()));
            }

            groups = sort switch
            {
                "id_desc" => groups.OrderByDescending(s => s.GroupId),
                "name" => groups.OrderBy(s => s.GroupName),
                "name_desc" => groups.OrderByDescending(s => s.GroupName),
                _ => groups.OrderBy(s => s.GroupId)
            };

            int pageSize = 3;

            int numRows = groups.Count();

            int excludeRecords = (pageSize * pageNumber) - pageSize;

            groups = groups.Skip(excludeRecords).Take(pageSize);

            var results = new PagedResult<RefGroup>
            {
                Data = await groups.AsNoTracking().ToListAsync(),
                TotalItems = numRows,
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            return View(results);
        }

        // GET: RefGroup/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var refGroup = await _context.RefGroups
                .FirstOrDefaultAsync(m => m.GroupId == id);
            if (refGroup == null)
            {
                return NotFound();
            }

            return View(refGroup);
        }

        // GET: RefGroup/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RefGroup/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GroupId,GroupName,IsActive")] RefGroup refGroup)
        {
            if (ModelState.IsValid)
            {
                _context.Add(refGroup);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(refGroup);
        }

        // GET: RefGroup/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var refGroup = await _context.RefGroups.FindAsync(id);
            if (refGroup == null)
            {
                return NotFound();
            }
            return View(refGroup);
        }

        // POST: RefGroup/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("GroupId,GroupName,IsActive")] RefGroup refGroup)
        {
            if (id != refGroup.GroupId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(refGroup);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RefGroupExists(refGroup.GroupId))
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
            return View(refGroup);
        }

        // GET: RefGroup/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var refGroup = await _context.RefGroups
                .FirstOrDefaultAsync(m => m.GroupId == id);
            if (refGroup == null)
            {
                return NotFound();
            }

            return View(refGroup);
        }

        // POST: RefGroup/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var refGroup = await _context.RefGroups.FindAsync(id);
            _context.RefGroups.Remove(refGroup);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RefGroupExists(string id)
        {
            return _context.RefGroups.Any(e => e.GroupId == id);
        }
    }
}
