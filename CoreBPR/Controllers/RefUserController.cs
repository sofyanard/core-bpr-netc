using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using cloudscribe.Pagination.Models;
using CoreBPR.Models;
using Microsoft.AspNetCore.Authorization;

namespace CoreBPR.Controllers
{
    [Authorize(Policy = "AdministratorOnly")]
    public class RefUserController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RefUserController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RefUser
        public async Task<IActionResult> Index(string sort, string group, string unit, string nama, int pageNumber = 1)
        {
            ViewData["GroupId"] = new SelectList(_context.RefGroups.OrderBy(x => x.GroupId), "GroupId", "GroupName", group);
            ViewData["UnitId"] = new SelectList(_context.RefUnits.OrderBy(x => x.UnitId), "UnitId", "UnitName", unit);

            ViewData["sort"] = sort;
            ViewData["group"] = group;
            ViewData["unit"] = unit;
            ViewData["nama"] = nama;

            ViewData["IdSortParm"] = String.IsNullOrEmpty(sort) ? "id_desc" : "";
            ViewData["NameSortParm"] = sort == "name" ? "name_desc" : "name";

            var users = from s in _context.ApplicationUsers
                        select s;

            if (!String.IsNullOrEmpty(group))
            {
                users = users.Where(s => s.GroupId == group);
            }

            if (!String.IsNullOrEmpty(unit))
            {
                users = users.Where(s => s.UnitId == unit);
            }

            if (!String.IsNullOrEmpty(nama))
            {
                users = users.Where(s => s.FullName.ToLower().Contains(nama.ToLower()));
            }

            users = sort switch
            {
                "id_desc" => users.OrderByDescending(s => s.UserId),
                "name" => users.OrderBy(s => s.FullName),
                "name_desc" => users.OrderByDescending(s => s.FullName),
                _ => users.OrderBy(s => s.UserId)
            };

            int pageSize = 3;

            int numRows = users.Count();

            int excludeRecords = (pageSize * pageNumber) - pageSize;

            users = users.Skip(excludeRecords).Take(pageSize);
            users = users.Include(a => a.RefGroup).Include(a => a.RefUnit);

            var results = new PagedResult<ApplicationUser>
            {
                Data = await users.AsNoTracking().ToListAsync(),
                TotalItems = numRows,
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            return View(results);
        }

        // GET: RefUser/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationUser = await _context.ApplicationUsers
                .Include(a => a.RefGroup)
                .Include(a => a.RefUnit)
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (applicationUser == null)
            {
                return NotFound();
            }

            return View(applicationUser);
        }

        // GET: RefUser/Create
        public IActionResult Create()
        {
            ViewData["GroupId"] = new SelectList(_context.RefGroups, "GroupId", "GroupName");
            ViewData["UnitId"] = new SelectList(_context.RefUnits, "UnitId", "UnitName");
            return View();
        }

        // POST: RefUser/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ApplicationUserCreateModel inputUser)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser applicationUser = new ApplicationUser();
                applicationUser.UserId = inputUser.UserId;
                applicationUser.FullName = inputUser.FullName;
                string initialPassword = _context.ApplicationInitials.Where(x => x.ParamKey == "DefaultPassword").FirstOrDefault().ParamValue;
                CustomPasswordHasher customPasswordHasher = new CustomPasswordHasher();
                string hashedPassword = customPasswordHasher.HashPassword(initialPassword);
                applicationUser.Password = hashedPassword;
                applicationUser.GroupId = inputUser.GroupId;
                applicationUser.UnitId = inputUser.UnitId;
                applicationUser.Email = inputUser.Email;
                applicationUser.Phone = inputUser.Phone;
                applicationUser.ApprovalLimit = inputUser.ApprovalLimit;
                applicationUser.RekBukuBesar = inputUser.RekBukuBesar;
                applicationUser.IsActive = "1";
                applicationUser.IsLogon = "0";
                applicationUser.IsRevoke = "0";
                applicationUser.FalsePwdCount = 0;
                applicationUser.CreatedDate = DateTime.Now;
                applicationUser.CreatedBy = "";
                // applicationUser.UpdatedDate = DateTime.Now;
                // applicationUser.UpdatedBy = "";
                string initialExpMonth = _context.ApplicationInitials.Where(x => x.ParamKey == "PasswordExpirationMonth").FirstOrDefault().ParamValue;
                DateTime expiredDate = DateTime.Now.AddMonths(int.Parse(initialExpMonth));
                applicationUser.ExpiredDate = expiredDate;
                // applicationUser.LastLoginDate = DateTime.Now;
                // applicationUser.LastLoginHost = "";

                _context.Add(applicationUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GroupId"] = new SelectList(_context.RefGroups, "GroupId", "GroupName", inputUser.GroupId);
            ViewData["UnitId"] = new SelectList(_context.RefUnits, "UnitId", "UnitName", inputUser.UnitId);
            return View(inputUser);
        }

        // GET: RefUser/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationUser = await _context.ApplicationUsers.FindAsync(id);
            if (applicationUser == null)
            {
                return NotFound();
            }
            ViewData["GroupId"] = new SelectList(_context.RefGroups, "GroupId", "GroupName", applicationUser.GroupId);
            ViewData["UnitId"] = new SelectList(_context.RefUnits, "UnitId", "UnitName", applicationUser.UnitId);
            return View(applicationUser);
        }

        // POST: RefUser/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, ApplicationUserCreateModel inputUser)
        {
            if (id != inputUser.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    ApplicationUser applicationUser = _context.ApplicationUsers.SingleOrDefault(x => x.UserId == inputUser.UserId);
                    // applicationUser.UserId = inputUser.UserId;
                    applicationUser.FullName = inputUser.FullName;
                    // applicationUser.Password = hashedPassword;
                    applicationUser.GroupId = inputUser.GroupId;
                    applicationUser.UnitId = inputUser.UnitId;
                    applicationUser.Email = inputUser.Email;
                    applicationUser.Phone = inputUser.Phone;
                    applicationUser.ApprovalLimit = inputUser.ApprovalLimit;
                    applicationUser.RekBukuBesar = inputUser.RekBukuBesar;
                    // applicationUser.IsActive = "1";
                    // applicationUser.IsLogon = "0";
                    // applicationUser.IsRevoke = "0";
                    // applicationUser.FalsePwdCount = 0;
                    // applicationUser.CreatedDate = DateTime.Now;
                    // applicationUser.CreatedBy = "";
                    applicationUser.UpdatedDate = DateTime.Now;
                    applicationUser.UpdatedBy = "";
                    // applicationUser.ExpiredDate = expiredDate;
                    // applicationUser.LastLoginDate = DateTime.Now;
                    // applicationUser.LastLoginHost = "";

                    // _context.Update(applicationUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApplicationUserExists(inputUser.UserId))
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
            ViewData["GroupId"] = new SelectList(_context.RefGroups, "GroupId", "GroupName", inputUser.GroupId);
            ViewData["UnitId"] = new SelectList(_context.RefUnits, "UnitId", "UnitName", inputUser.UnitId);
            return View(inputUser);
        }

        // GET: RefUser/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationUser = await _context.ApplicationUsers
                .Include(a => a.RefGroup)
                .Include(a => a.RefUnit)
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (applicationUser == null)
            {
                return NotFound();
            }

            return View(applicationUser);
        }

        // POST: RefUser/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var applicationUser = await _context.ApplicationUsers.FindAsync(id);
            _context.ApplicationUsers.Remove(applicationUser);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApplicationUserExists(string id)
        {
            return _context.ApplicationUsers.Any(e => e.UserId == id);
        }
    }
}
