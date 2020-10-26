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
    [Route("NasabahKeuangan")]
    public class NasabahKeuanganController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NasabahKeuanganController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: NasabahKeuangan
        [Route("Index/{nasabahId}")]
        public async Task<IActionResult> Index(string nasabahId)
        {
            ViewData["NasabahId"] = nasabahId;
            return View(await _context.NasabahKeuangans.Where(x => x.NasabahId == nasabahId).ToListAsync());
        }

        // GET: NasabahKeuangan/Create
        [Route("Create/{nasabahId}")]
        public IActionResult Create(string nasabahId)
        {
            ViewData["NasabahId"] = nasabahId;
            return View();
        }

        // POST: NasabahKeuangan/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Create/{nasabahId}")]
        public async Task<IActionResult> Create(string nasabahId, [Bind("KeuanganId,NasabahId,Periode,Kas,Piutang,Investasi,AsetLancarLain,AsetTidakLancar,PinjamanPendek,UtangUsahaPendek,LiabilitasPendekLain,PinjamanPanjang,UtangUsahaPanjang,LiabilitasPanjangLain,Modal,PendapatanOperasi,BebanOperasi,PendapatanNonOperasi,BebanNonOperasi,LabaBruto,LabaSebelumPajak,LabaTahunBerjalan")] NasabahKeuangan nasabahKeuangan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nasabahKeuangan);
                await _context.SaveChangesAsync();
                ViewData["NasabahId"] = nasabahId;
                return RedirectToAction(nameof(Index), new { nasabahId = nasabahId });
            }
            ViewData["NasabahId"] = nasabahId;
            return View(nasabahKeuangan);
        }

        // GET: NasabahKeuangan/Edit/5
        [Route("Edit/{nasabahId}/{id}")]
        public async Task<IActionResult> Edit(string nasabahId, int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nasabahKeuangan = await _context.NasabahKeuangans.FindAsync(id);
            if (nasabahKeuangan == null)
            {
                return NotFound();
            }
            ViewData["NasabahId"] = nasabahId;
            return View(nasabahKeuangan);
        }

        // POST: NasabahKeuangan/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Edit/{nasabahId}/{id}")]
        public async Task<IActionResult> Edit(string nasabahId, int id, [Bind("KeuanganId,NasabahId,Periode,Kas,Piutang,Investasi,AsetLancarLain,AsetTidakLancar,PinjamanPendek,UtangUsahaPendek,LiabilitasPendekLain,PinjamanPanjang,UtangUsahaPanjang,LiabilitasPanjangLain,Modal,PendapatanOperasi,BebanOperasi,PendapatanNonOperasi,BebanNonOperasi,LabaBruto,LabaSebelumPajak,LabaTahunBerjalan")] NasabahKeuangan nasabahKeuangan)
        {
            if (id != nasabahKeuangan.KeuanganId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nasabahKeuangan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NasabahKeuanganExists(nasabahKeuangan.KeuanganId))
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
            ViewData["NasabahId"] = nasabahId;
            return View(nasabahKeuangan);
        }

        // POST: NasabahKeuangan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("Delete/{nasabahId}/{id}")]
        public async Task<IActionResult> DeleteConfirmed(string nasabahId, int id)
        {
            var nasabahKeuangan = await _context.NasabahKeuangans.FindAsync(id);
            _context.NasabahKeuangans.Remove(nasabahKeuangan);
            await _context.SaveChangesAsync();
            ViewData["NasabahId"] = nasabahId;
            return RedirectToAction(nameof(Index), new { nasabahId = nasabahId });
        }

        private bool NasabahKeuanganExists(int id)
        {
            return _context.NasabahKeuangans.Any(e => e.KeuanganId == id);
        }
    }
}
