using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using CoreBPR.Models;

namespace CoreBPR.Controllers
{
    [Authorize]
    [Route("NasabahPengurus")]
    public class NasabahPengurusController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NasabahPengurusController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: NasabahPengurus
        [Route("Index/{nasabahId}")]
        public async Task<IActionResult> Index(string nasabahId)
        {
            var applicationDbContext = _context.NasabahPengurus.Where(x => x.NasabahId == nasabahId)
                .Include(n => n.RefCity).Include(n => n.RefGenderPlus).Include(n => n.RefJabatan).Include(n => n.RefJenisIdentity).Include(n => n.RefProvince);
            ViewData["NasabahId"] = nasabahId;
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: NasabahPengurus/Create
        [Route("Create/{nasabahId}")]
        public IActionResult Create(string nasabahId)
        {
            // ViewData["KotaId"] = new SelectList(_context.RefCities, "CityId", "CityName");
            ViewData["GenderPlusId"] = new SelectList(_context.Set<RefGenderPlus>(), "GenderPlusId", "GenderPlusName");
            ViewData["JabatanId"] = new SelectList(_context.Set<RefJabatan>(), "JabatanId", "JabatanName");
            ViewData["JenisIdentityId"] = new SelectList(_context.RefJenisIdentities, "JenisIdentityId", "JenisIdentityName");
            ViewData["PropinsiId"] = new SelectList(_context.RefProvinces, "ProvinceId", "ProvinceName");
            ViewData["NasabahId"] = nasabahId;
            return View();
        }

        // POST: NasabahPengurus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Create/{nasabahId}")]
        public async Task<IActionResult> Create(string nasabahId, [Bind("PengurusId,NasabahId,PengurusName,GenderPlusId,JabatanId,PercentSaham,JenisIdentityId,IdentityNo,Address,ZipCode,PropinsiId,KotaId,Kecamatan,Kelurahan,IsActive")] NasabahPengurus nasabahPengurus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nasabahPengurus);
                await _context.SaveChangesAsync();
                ViewData["NasabahId"] = nasabahId;
                return RedirectToAction(nameof(Index), new { nasabahId = nasabahId });
            }
            // ViewData["KotaId"] = new SelectList(_context.RefCities, "CityId", "CityName", nasabahPengurus.KotaId);
            ViewData["GenderPlusId"] = new SelectList(_context.Set<RefGenderPlus>(), "GenderPlusId", "GenderPlusName", nasabahPengurus.GenderPlusId);
            ViewData["JabatanId"] = new SelectList(_context.Set<RefJabatan>(), "JabatanId", "JabatanName", nasabahPengurus.JabatanId);
            ViewData["JenisIdentityId"] = new SelectList(_context.RefJenisIdentities, "JenisIdentityId", "JenisIdentityName", nasabahPengurus.JenisIdentityId);
            ViewData["PropinsiId"] = new SelectList(_context.RefProvinces, "ProvinceId", "ProvinceName", nasabahPengurus.PropinsiId);
            ViewData["NasabahId"] = nasabahId;
            return View(nasabahPengurus);
        }

        // GET: NasabahPengurus/Edit/5
        [Route("Edit/{nasabahId}/{id}")]
        public async Task<IActionResult> Edit(string nasabahId, int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nasabahPengurus = await _context.NasabahPengurus.FindAsync(id);
            if (nasabahPengurus == null)
            {
                return NotFound();
            }
            ViewData["KotaId"] = new SelectList(_context.RefCities.Where(x => x.ProvinceId == nasabahPengurus.PropinsiId), "CityId", "CityName", nasabahPengurus.KotaId);
            ViewData["GenderPlusId"] = new SelectList(_context.Set<RefGenderPlus>(), "GenderPlusId", "GenderPlusName", nasabahPengurus.GenderPlusId);
            ViewData["JabatanId"] = new SelectList(_context.Set<RefJabatan>(), "JabatanId", "JabatanName", nasabahPengurus.JabatanId);
            ViewData["JenisIdentityId"] = new SelectList(_context.RefJenisIdentities, "JenisIdentityId", "JenisIdentityName", nasabahPengurus.JenisIdentityId);
            ViewData["PropinsiId"] = new SelectList(_context.RefProvinces, "ProvinceId", "ProvinceName", nasabahPengurus.PropinsiId);
            ViewData["NasabahId"] = nasabahId;
            return View(nasabahPengurus);
        }

        // POST: NasabahPengurus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Edit/{nasabahId}/{id}")]
        public async Task<IActionResult> Edit(string nasabahId, int id, [Bind("PengurusId,NasabahId,PengurusName,GenderPlusId,JabatanId,PercentSaham,JenisIdentityId,IdentityNo,Address,ZipCode,PropinsiId,KotaId,Kecamatan,Kelurahan,IsActive")] NasabahPengurus nasabahPengurus)
        {
            if (id != nasabahPengurus.PengurusId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nasabahPengurus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NasabahPengurusExists(nasabahPengurus.PengurusId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                ViewData["NasabahId"] = nasabahId;
                return RedirectToAction(nameof(Index), new { nasabahId = nasabahId });
            }
            ViewData["KotaId"] = new SelectList(_context.RefCities.Where(x => x.ProvinceId == nasabahPengurus.PropinsiId), "CityId", "CityName", nasabahPengurus.KotaId);
            ViewData["GenderPlusId"] = new SelectList(_context.Set<RefGenderPlus>(), "GenderPlusId", "GenderPlusName", nasabahPengurus.GenderPlusId);
            ViewData["JabatanId"] = new SelectList(_context.Set<RefJabatan>(), "JabatanId", "JabatanName", nasabahPengurus.JabatanId);
            ViewData["JenisIdentityId"] = new SelectList(_context.RefJenisIdentities, "JenisIdentityId", "JenisIdentityName", nasabahPengurus.JenisIdentityId);
            ViewData["PropinsiId"] = new SelectList(_context.RefProvinces, "ProvinceId", "ProvinceName", nasabahPengurus.PropinsiId);
            ViewData["NasabahId"] = nasabahId;
            return View(nasabahPengurus);
        }

        // POST: NasabahPengurus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("Delete/{nasabahId}/{id}")]
        public async Task<IActionResult> DeleteConfirmed(string nasabahId, int id)
        {
            var nasabahPengurus = await _context.NasabahPengurus.FindAsync(id);
            _context.NasabahPengurus.Remove(nasabahPengurus);
            await _context.SaveChangesAsync();
            ViewData["NasabahId"] = nasabahId;
            return RedirectToAction(nameof(Index), new { nasabahId = nasabahId });
        }

        private bool NasabahPengurusExists(int id)
        {
            return _context.NasabahPengurus.Any(e => e.PengurusId == id);
        }
    }
}
