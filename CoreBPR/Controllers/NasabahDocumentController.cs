using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using CoreBPR.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace CoreBPR.Controllers
{
    // [Authorize]
    [Route("NasabahDocument")]
    public class NasabahDocumentController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;

        public NasabahDocumentController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            this.webHostEnvironment = webHostEnvironment;
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
        public async Task<IActionResult> Create(string nasabahId, NasabahDocumentUploadModel model)
        {
            if (ModelState.IsValid)
            {
                NasabahDocument nasabahDocument = new NasabahDocument();
                nasabahDocument.NasabahId = nasabahId;
                nasabahDocument.DocTypeId = model.DocTypeId;
                nasabahDocument.Caption = model.Caption;

                string uploadFolder = Path.Combine(webHostEnvironment.WebRootPath, "upload");
                string uploadFileName = model.FileUpload.FileName;
                string uploadFilePath = Path.Combine(uploadFolder, uploadFileName);

                if (System.IO.File.Exists(uploadFilePath))
                {
                    string fileNameWithoutExt = Path.GetFileNameWithoutExtension(uploadFilePath);
                    string fileExt = Path.GetExtension(uploadFilePath);

                    int i = 1;
                    string newFilePath = Path.Combine(uploadFolder, fileNameWithoutExt + "(" + i.ToString() + ")" + fileExt);
                    while (System.IO.File.Exists(newFilePath))
                    {
                        i++;
                        newFilePath = Path.Combine(uploadFolder, fileNameWithoutExt + "(" + i.ToString() + ")" + fileExt);
                    }

                    uploadFileName = fileNameWithoutExt + "(" + i.ToString() + ")" + fileExt;
                    uploadFilePath = Path.Combine(uploadFolder, uploadFileName);
                }

                await model.FileUpload.CopyToAsync(new FileStream(uploadFilePath, FileMode.Create));

                nasabahDocument.FileName = uploadFileName;

                _context.Add(nasabahDocument);
                await _context.SaveChangesAsync();
                ViewData["NasabahId"] = nasabahId;
                ViewData["NasabahType"] = _context.Nasabahs.Where(x => x.NasabahId == nasabahId).Select(x => x.NasabahType).FirstOrDefault();
                return RedirectToAction(nameof(Index), new { nasabahId = nasabahId });
            }
            ViewData["DocTypeId"] = new SelectList(_context.RefDocumentTypes, "DocTypeId", "DocTypeName", model.DocTypeId);
            ViewData["NasabahId"] = nasabahId;
            string nasabahType = _context.Nasabahs.Where(x => x.NasabahId == nasabahId).Select(x => x.NasabahType).FirstOrDefault();
            ViewData["NasabahType"] = nasabahType;
            return View(model);
        }

        // POST: NasabahDocument/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("Delete/{nasabahId}/{id}")]
        public async Task<IActionResult> DeleteConfirmed(string nasabahId, int id)
        {
            var nasabahDocument = await _context.NasabahDocuments.FindAsync(id);

            string uploadFolder = Path.Combine(webHostEnvironment.WebRootPath, "upload");
            string fileName = nasabahDocument.FileName;
            string filePath = Path.Combine(uploadFolder, fileName);
            if (System.IO.File.Exists(filePath))
            {
                try
                {
                    System.IO.File.Delete(filePath);
                }
                catch (Exception ex) { }
            }

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
