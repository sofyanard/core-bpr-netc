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
    // [Authorize]
    [Route("NasabahDocument")]
    public class NasabahDocumentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NasabahDocumentController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: NasabahDocument
        [Route("Index/{nasabahId}")]
        public async Task<IActionResult> Index(string nasabahId)
        {
            var applicationDbContext = _context.NasabahDocuments.Where(x => x.NasabahId == nasabahId)
                .Include(n => n.RefDocumentType);
            ViewData["NasabahId"] = nasabahId;
            string nasabahType = _context.Nasabahs.Where(x => x.NasabahId == nasabahId).Select(x => x.NasabahType).FirstOrDefault();
            ViewData["NasabahType"] = nasabahType;
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: NasabahDocument/Create
        [Route("Create/{nasabahId}")]
        public IActionResult Create(string nasabahId)
        {
            ViewData["DocTypeId"] = new SelectList(_context.RefDocumentTypes, "DocTypeId", "DocTypeName");
            ViewData["NasabahId"] = nasabahId;
            string nasabahType = _context.Nasabahs.Where(x => x.NasabahId == nasabahId).Select(x => x.NasabahType).FirstOrDefault();
            ViewData["NasabahType"] = nasabahType;
            return View();
        }

        // POST: NasabahDocument/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Create/{nasabahId}")]
        public async Task<IActionResult> Create(string nasabahId, [Bind("DocumentId,NasabahId,DocTypeId,Caption,FileName")] NasabahDocument nasabahDocument)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nasabahDocument);
                await _context.SaveChangesAsync();
                ViewData["NasabahId"] = nasabahId;
                ViewData["NasabahType"] = _context.Nasabahs.Where(x => x.NasabahId == nasabahId).Select(x => x.NasabahType).FirstOrDefault();
                return RedirectToAction(nameof(Index), new { nasabahId = nasabahId });
            }
            ViewData["DocTypeId"] = new SelectList(_context.RefDocumentTypes, "DocTypeId", "DocTypeName", nasabahDocument.DocTypeId);
            ViewData["NasabahId"] = nasabahId;
            string nasabahType = _context.Nasabahs.Where(x => x.NasabahId == nasabahId).Select(x => x.NasabahType).FirstOrDefault();
            ViewData["NasabahType"] = nasabahType;
            return View(nasabahDocument);
        }

        // POST: NasabahDocument/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("Delete/{nasabahId}/{id}")]
        public async Task<IActionResult> DeleteConfirmed(string nasabahId, int id)
        {
            var nasabahDocument = await _context.NasabahDocuments.FindAsync(id);
            _context.NasabahDocuments.Remove(nasabahDocument);
            await _context.SaveChangesAsync();
            ViewData["NasabahId"] = nasabahId;
            string nasabahType = _context.Nasabahs.Where(x => x.NasabahId == nasabahId).Select(x => x.NasabahType).FirstOrDefault();
            ViewData["NasabahType"] = nasabahType;
            return RedirectToAction(nameof(Index), new { nasabahId = nasabahId });
        }

        private bool NasabahDocumentExists(int id)
        {
            return _context.NasabahDocuments.Any(e => e.DocumentId == id);
        }
    }
}
