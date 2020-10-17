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
    public class RefGroupMenuController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RefGroupMenuController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RefGroupMenu
        public async Task<IActionResult> Index(string group, int pageNumber = 1)
        {
            ViewData["GroupId"] = new SelectList(_context.RefGroups, "GroupId", "GroupName", group);

            var groupMenus = from s in _context.RefGroupMenus
                             select s;

            if (!String.IsNullOrEmpty(group))
            {
                groupMenus = groupMenus.Where(s => s.GroupId == group);
            }

            groupMenus = groupMenus.OrderBy(x => x.GroupId).ThenBy(x => x.MenuId);

            int pageSize = 50;
            int numRows = groupMenus.Count();
            int excludeRecords = (pageSize * pageNumber) - pageSize;

            groupMenus = groupMenus.Skip(excludeRecords).Take(pageSize);
            groupMenus = groupMenus.Include(r => r.RefGroup).Include(r => r.RefMenu).Include(r => r.RefMenu.ParentRefMenu);

            var results = new PagedResult<RefGroupMenu>
            {
                Data = await groupMenus.AsNoTracking().ToListAsync(),
                TotalItems = numRows,
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            return View(results);
        }

        // GET: RefGroupMenu/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var refGroupMenu = await _context.RefGroupMenus
                .Include(r => r.RefGroup)
                .Include(r => r.RefMenu)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (refGroupMenu == null)
            {
                return NotFound();
            }

            return View(refGroupMenu);
        }

        // GET: RefGroupMenu/Create
        public IActionResult Create()
        {
            var menuList = from s in _context.RefMenus.Include(x => x.ParentRefMenu)
                           where (s.Level == 1 || s.Level == 2)
                           orderby s.MenuId
                           select new { MenuId = s.MenuId, 
                                        MenuName = s.Level == 1 ? s.MenuName : s.ParentRefMenu.MenuName + " - " + s.MenuName};

            ViewData["GroupId"] = new SelectList(_context.RefGroups, "GroupId", "GroupName");
            ViewData["MenuId"] = new SelectList(menuList, "MenuId", "MenuName");
            return View();
        }

        // POST: RefGroupMenu/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,GroupId,MenuId")] RefGroupMenu refGroupMenu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(refGroupMenu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GroupId"] = new SelectList(_context.RefGroups, "GroupId", "GroupName", refGroupMenu.GroupId);
            ViewData["MenuId"] = new SelectList(_context.RefMenus, "MenuId", "MenuName", refGroupMenu.MenuId);
            return View(refGroupMenu);
        }

        // GET: RefGroupMenu/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var refGroupMenu = await _context.RefGroupMenus.FindAsync(id);
            if (refGroupMenu == null)
            {
                return NotFound();
            }
            ViewData["GroupId"] = new SelectList(_context.RefGroups, "GroupId", "GroupName", refGroupMenu.GroupId);
            ViewData["MenuId"] = new SelectList(_context.RefMenus, "MenuId", "MenuName", refGroupMenu.MenuId);
            return View(refGroupMenu);
        }

        // POST: RefGroupMenu/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,GroupId,MenuId")] RefGroupMenu refGroupMenu)
        {
            if (id != refGroupMenu.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(refGroupMenu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RefGroupMenuExists(refGroupMenu.Id))
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
            ViewData["GroupId"] = new SelectList(_context.RefGroups, "GroupId", "GroupName", refGroupMenu.GroupId);
            ViewData["MenuId"] = new SelectList(_context.RefMenus, "MenuId", "MenuName", refGroupMenu.MenuId);
            return View(refGroupMenu);
        }

        // GET: RefGroupMenu/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var refGroupMenu = await _context.RefGroupMenus
                .Include(r => r.RefGroup)
                .Include(r => r.RefMenu)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (refGroupMenu == null)
            {
                return NotFound();
            }

            return View(refGroupMenu);
        }

        // POST: RefGroupMenu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var refGroupMenu = await _context.RefGroupMenus.FindAsync(id);
            _context.RefGroupMenus.Remove(refGroupMenu);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RefGroupMenuExists(int id)
        {
            return _context.RefGroupMenus.Any(e => e.Id == id);
        }
    }
}
