﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using cloudscribe.Pagination.Models;
using CoreBPR.Models;

namespace CoreBPR.Controllers
{
    [Authorize]
    [Route("Nasabah")]
    public class NasabahController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NasabahController(ApplicationDbContext context)
        {
            _context = context;
        }

        private string CIFGenerator(string nama)
        {
            string prefix = nama.Substring(0, 1).ToUpper();
            var row = _context.RefCIFGenerators.Find(prefix);
            if (row == null)
            {
                return "";
            }
            long lastCIF = row.CIFCurrentNo + 1;
            row.CIFCurrentNo = lastCIF;
            _context.Update(row);
            _context.SaveChanges();

            return lastCIF.ToString();
        }

        [Route("Create/Perorangan")]
        public IActionResult CreatePerorangan()
        {
            // ViewData["HomeKotaId"] = new SelectList(_context.RefCities, "CityId", "CityName");
            ViewData["HomePropinsiId"] = new SelectList(_context.RefProvinces, "ProvinceId", "ProvinceName");
            ViewData["KodeHartaId"] = new SelectList(_context.RefYesNos, "YesNoId", "YesNoName");
            ViewData["CitizenId"] = new SelectList(_context.RefCitizens, "CitizenId", "CitizenName");
            ViewData["EducationId"] = new SelectList(_context.RefEducations, "EducationId", "EducationName");
            ViewData["GenderId"] = new SelectList(_context.RefGenders, "GenderId", "GenderName");
            ViewData["HomeStatusId"] = new SelectList(_context.RefHomeStatuses, "HomeStatusId", "HomeStatusName");
            ViewData["JenisIdentityId"] = new SelectList(_context.RefJenisIdentities, "JenisIdentityId", "JenisIdentityName");
            ViewData["MaritalId"] = new SelectList(_context.RefMaritals, "MaritalId", "MaritalName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Create/Perorangan")]
        public async Task<IActionResult> CreatePerorangan(NasabahPerorangan nasabahPerorangan)
        {
            if (ModelState.IsValid)
            {
                Nasabah nasabah = new Nasabah();
                string nasabahId = this.CIFGenerator(nasabahPerorangan.NamaLengkap);
                nasabah.NasabahId = nasabahId;
                nasabah.NasabahType = "1";
                nasabah.NamaLengkap = nasabahPerorangan.NamaLengkap;
                nasabah.NamaIdentity = nasabahPerorangan.NamaIdentity;
                nasabah.GenderId = nasabahPerorangan.GenderId;
                nasabah.TempatLahir = nasabahPerorangan.TempatLahir;
                nasabah.TanggalLahir = nasabahPerorangan.TanggalLahir;
                nasabah.HomeAddress = nasabahPerorangan.HomeAddress;
                nasabah.HomeZipCode = nasabahPerorangan.HomeZipCode;
                nasabah.HomePropinsiId = nasabahPerorangan.HomePropinsiId;
                nasabah.HomeKotaId = nasabahPerorangan.HomeKotaId;
                nasabah.HomeKecamatan = nasabahPerorangan.HomeKecamatan;
                nasabah.HomeKelurahan = nasabahPerorangan.HomeKelurahan;
                nasabah.HomeStatusId = nasabahPerorangan.HomeStatusId;
                nasabah.HomePhone = nasabahPerorangan.HomePhone;
                nasabah.MobilePhone = nasabahPerorangan.MobilePhone;
                nasabah.NamaIbuKandung = nasabahPerorangan.NamaIbuKandung;
                nasabah.CitizenId = nasabahPerorangan.CitizenId;
                nasabah.MaritalId = nasabahPerorangan.MaritalId;
                nasabah.EducationId = nasabahPerorangan.EducationId;
                nasabah.JenisIdentityId = nasabahPerorangan.JenisIdentityId;
                nasabah.IdentityNo = nasabahPerorangan.IdentityNo;
                nasabah.NPWPNo = nasabahPerorangan.NPWPNo;
                nasabah.Email = nasabahPerorangan.Email;
                nasabah.Tanggungan = nasabahPerorangan.Tanggungan;
                nasabah.KodeHartaId = nasabahPerorangan.KodeHartaId;
                nasabah.CreatedDate = DateTime.Now;
                nasabah.CreatedUnitId = ((ClaimsIdentity)User.Identity).FindFirst("UnitId").Value;

                _context.Add(nasabah);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(EditPerorangan), new { id = nasabahId });
            }
            // ViewData["HomeKotaId"] = new SelectList(_context.RefCities, "CityId", "CityName", nasabahPerorangan.HomeKotaId);
            ViewData["HomePropinsiId"] = new SelectList(_context.RefProvinces, "ProvinceId", "ProvinceName", nasabahPerorangan.HomePropinsiId);
            ViewData["KodeHartaId"] = new SelectList(_context.RefYesNos, "YesNoId", "YesNoName", nasabahPerorangan.KodeHartaId);
            ViewData["CitizenId"] = new SelectList(_context.RefCitizens, "CitizenId", "CitizenName", nasabahPerorangan.CitizenId);
            ViewData["EducationId"] = new SelectList(_context.RefEducations, "EducationId", "EducationName", nasabahPerorangan.EducationId);
            ViewData["GenderId"] = new SelectList(_context.RefGenders, "GenderId", "GenderName", nasabahPerorangan.GenderId);
            ViewData["HomeStatusId"] = new SelectList(_context.RefHomeStatuses, "HomeStatusId", "HomeStatusName", nasabahPerorangan.HomeStatusId);
            ViewData["JenisIdentityId"] = new SelectList(_context.RefJenisIdentities, "JenisIdentityId", "JenisIdentityName", nasabahPerorangan.JenisIdentityId);
            ViewData["MaritalId"] = new SelectList(_context.RefMaritals, "MaritalId", "MaritalName", nasabahPerorangan.MaritalId);
            return View(nasabahPerorangan);
        }

        [Route("Create/BadanUsaha")]
        public IActionResult CreateBadanUsaha()
        {
            // ViewData["OfficeKotaId"] = new SelectList(_context.RefCities, "CityId", "CityName");
            ViewData["OfficeStatusId"] = new SelectList(_context.RefHomeStatuses, "HomeStatusId", "HomeStatusName");
            ViewData["OfficePropinsiId"] = new SelectList(_context.RefProvinces, "ProvinceId", "ProvinceName");
            ViewData["BidangUsahaId"] = new SelectList(_context.RefBidangUsahas, "BidangUsahaId", "BidangUsahaName");
            ViewData["JenisBadanUsahaId"] = new SelectList(_context.RefJenisBadanUsahas, "JenisBadanUsahaId", "JenisBadanUsahaName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Create/BadanUsaha")]
        public async Task<IActionResult> CreateBadanUsaha(NasabahBadanUsaha nasabahBadanUsaha)
        {
            if (ModelState.IsValid)
            {
                Nasabah nasabah = new Nasabah();
                string nasabahId = this.CIFGenerator(nasabahBadanUsaha.NamaLengkap);
                nasabah.NasabahId = nasabahId;
                nasabah.NasabahType = "2";
                nasabah.JenisBadanUsahaId = nasabahBadanUsaha.JenisBadanUsahaId;
                nasabah.NamaLengkap = nasabahBadanUsaha.NamaLengkap;
                nasabah.TempatLahir = nasabahBadanUsaha.TempatLahir;
                nasabah.TanggalLahir = nasabahBadanUsaha.TanggalLahir;
                nasabah.OfficeAddress = nasabahBadanUsaha.OfficeAddress;
                nasabah.OfficeZipCode = nasabahBadanUsaha.OfficeZipCode;
                nasabah.OfficePropinsiId = nasabahBadanUsaha.OfficePropinsiId;
                nasabah.OfficeKotaId = nasabahBadanUsaha.OfficeKotaId;
                nasabah.OfficeKecamatan = nasabahBadanUsaha.OfficeKecamatan;
                nasabah.OfficeKelurahan = nasabahBadanUsaha.OfficeKelurahan;
                nasabah.OfficeStatusId = nasabahBadanUsaha.OfficeStatusId;
                nasabah.OfficePhone = nasabahBadanUsaha.OfficePhone;
                nasabah.OfficeFax = nasabahBadanUsaha.OfficeFax;
                nasabah.NPWPNo = nasabahBadanUsaha.NPWPNo;
                nasabah.Email = nasabahBadanUsaha.Email;
                nasabah.BidangUsahaId = nasabahBadanUsaha.BidangUsahaId;
                nasabah.APPNo = nasabahBadanUsaha.APPNo;
                nasabah.APPDate = nasabahBadanUsaha.APPDate;
                nasabah.APPChangeNo = nasabahBadanUsaha.APPChangeNo;
                nasabah.APPChangeDate = nasabahBadanUsaha.APPChangeDate;
                nasabah.Notaris = nasabahBadanUsaha.Notaris;
                nasabah.ContactPerson = nasabahBadanUsaha.ContactPerson;
                nasabah.CreatedDate = DateTime.Now;
                nasabah.CreatedUnitId = ((ClaimsIdentity)User.Identity).FindFirst("UnitId").Value;

                _context.Add(nasabah);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(EditBadanUsaha), new { id = nasabahId });
            }
            ViewData["OfficeKotaId"] = new SelectList(_context.RefCities, "CityId", "CityName", nasabahBadanUsaha.OfficeKotaId);
            ViewData["OfficeStatusId"] = new SelectList(_context.RefHomeStatuses, "HomeStatusId", "HomeStatusName", nasabahBadanUsaha.OfficeStatusId);
            ViewData["OfficePropinsiId"] = new SelectList(_context.RefProvinces, "ProvinceId", "ProvinceName", nasabahBadanUsaha.OfficePropinsiId);
            ViewData["BidangUsahaId"] = new SelectList(_context.RefBidangUsahas, "BidangUsahaId", "BidangUsahaName", nasabahBadanUsaha.BidangUsahaId);
            ViewData["JenisBadanUsahaId"] = new SelectList(_context.RefJenisBadanUsahas, "JenisBadanUsahaId", "JenisBadanUsahaName", nasabahBadanUsaha.JenisBadanUsahaId);
            return View(nasabahBadanUsaha);
        }

        [Route("Edit/Perorangan/{id}")]
        public async Task<IActionResult> EditPerorangan(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nasabah = await _context.Nasabahs.FindAsync(id);
            if (nasabah == null)
            {
                return NotFound();
            }

            NasabahPerorangan nasabahPerorangan = new NasabahPerorangan();
            nasabahPerorangan.NasabahId = nasabah.NasabahId;
            nasabahPerorangan.NamaLengkap = nasabah.NamaLengkap;
            nasabahPerorangan.NamaIdentity = nasabah.NamaIdentity;
            nasabahPerorangan.GenderId = nasabah.GenderId;
            nasabahPerorangan.TempatLahir = nasabah.TempatLahir;
            nasabahPerorangan.TanggalLahir = nasabah.TanggalLahir;
            nasabahPerorangan.HomeAddress = nasabah.HomeAddress;
            nasabahPerorangan.HomeZipCode = nasabah.HomeZipCode;
            nasabahPerorangan.HomePropinsiId = nasabah.HomePropinsiId;
            nasabahPerorangan.HomeKotaId = nasabah.HomeKotaId;
            nasabahPerorangan.HomeKecamatan = nasabah.HomeKecamatan;
            nasabahPerorangan.HomeKelurahan = nasabah.HomeKelurahan;
            nasabahPerorangan.HomeStatusId = nasabah.HomeStatusId;
            nasabahPerorangan.HomePhone = nasabah.HomePhone;
            nasabahPerorangan.MobilePhone = nasabah.MobilePhone;
            nasabahPerorangan.NamaIbuKandung = nasabah.NamaIbuKandung;
            nasabahPerorangan.CitizenId = nasabah.CitizenId;
            nasabahPerorangan.MaritalId = nasabah.MaritalId;
            nasabahPerorangan.EducationId = nasabah.EducationId;
            nasabahPerorangan.JenisIdentityId = nasabah.JenisIdentityId;
            nasabahPerorangan.IdentityNo = nasabah.IdentityNo;
            nasabahPerorangan.NPWPNo = nasabah.NPWPNo;
            nasabahPerorangan.Email = nasabah.Email;
            nasabahPerorangan.Tanggungan = nasabah.Tanggungan;
            nasabahPerorangan.KodeHartaId = nasabah.KodeHartaId;

            ViewData["HomeKotaId"] = new SelectList(_context.RefCities.Where(x => x.ProvinceId == nasabahPerorangan.HomePropinsiId), "CityId", "CityName", nasabahPerorangan.HomeKotaId);
            ViewData["HomePropinsiId"] = new SelectList(_context.RefProvinces, "ProvinceId", "ProvinceName", nasabahPerorangan.HomePropinsiId);
            ViewData["KodeHartaId"] = new SelectList(_context.RefYesNos, "YesNoId", "YesNoName", nasabahPerorangan.KodeHartaId);
            ViewData["CitizenId"] = new SelectList(_context.RefCitizens, "CitizenId", "CitizenName", nasabahPerorangan.CitizenId);
            ViewData["EducationId"] = new SelectList(_context.RefEducations, "EducationId", "EducationName", nasabahPerorangan.EducationId);
            ViewData["GenderId"] = new SelectList(_context.RefGenders, "GenderId", "GenderName", nasabahPerorangan.GenderId);
            ViewData["HomeStatusId"] = new SelectList(_context.RefHomeStatuses, "HomeStatusId", "HomeStatusName", nasabahPerorangan.HomeStatusId);
            ViewData["JenisIdentityId"] = new SelectList(_context.RefJenisIdentities, "JenisIdentityId", "JenisIdentityName", nasabahPerorangan.JenisIdentityId);
            ViewData["MaritalId"] = new SelectList(_context.RefMaritals, "MaritalId", "MaritalName", nasabahPerorangan.MaritalId);
            ViewData["NasabahId"] = id;
            return View(nasabahPerorangan);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Edit/Perorangan/{id}")]
        public async Task<IActionResult> EditPerorangan(string id, NasabahPerorangan nasabahPerorangan)
        {
            if (id != nasabahPerorangan.NasabahId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Nasabah nasabah = _context.Nasabahs.Find(id);
                    nasabah.NasabahId = nasabahPerorangan.NasabahId;
                    nasabah.NamaLengkap = nasabahPerorangan.NamaLengkap;
                    nasabah.NamaIdentity = nasabahPerorangan.NamaIdentity;
                    nasabah.GenderId = nasabahPerorangan.GenderId;
                    nasabah.TempatLahir = nasabahPerorangan.TempatLahir;
                    nasabah.TanggalLahir = nasabahPerorangan.TanggalLahir;
                    nasabah.HomeAddress = nasabahPerorangan.HomeAddress;
                    nasabah.HomeZipCode = nasabahPerorangan.HomeZipCode;
                    nasabah.HomePropinsiId = nasabahPerorangan.HomePropinsiId;
                    nasabah.HomeKotaId = nasabahPerorangan.HomeKotaId;
                    nasabah.HomeKecamatan = nasabahPerorangan.HomeKecamatan;
                    nasabah.HomeKelurahan = nasabahPerorangan.HomeKelurahan;
                    nasabah.HomeStatusId = nasabahPerorangan.HomeStatusId;
                    nasabah.HomePhone = nasabahPerorangan.HomePhone;
                    nasabah.MobilePhone = nasabahPerorangan.MobilePhone;
                    nasabah.NamaIbuKandung = nasabahPerorangan.NamaIbuKandung;
                    nasabah.CitizenId = nasabahPerorangan.CitizenId;
                    nasabah.MaritalId = nasabahPerorangan.MaritalId;
                    nasabah.EducationId = nasabahPerorangan.EducationId;
                    nasabah.JenisIdentityId = nasabahPerorangan.JenisIdentityId;
                    nasabah.IdentityNo = nasabahPerorangan.IdentityNo;
                    nasabah.NPWPNo = nasabahPerorangan.NPWPNo;
                    nasabah.Email = nasabahPerorangan.Email;
                    nasabah.Tanggungan = nasabahPerorangan.Tanggungan;
                    nasabah.KodeHartaId = nasabahPerorangan.KodeHartaId;
                    nasabah.UpdatedDate = DateTime.Now;
                    nasabah.UpdatedUserId = User.Identity.Name;

                    _context.Update(nasabah);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NasabahExists(nasabahPerorangan.NasabahId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(EditPerorangan), new { id = id });
            }
            ViewData["HomeKotaId"] = new SelectList(_context.RefCities.Where(x => x.ProvinceId == nasabahPerorangan.HomePropinsiId), "CityId", "CityName", nasabahPerorangan.HomeKotaId);
            ViewData["HomePropinsiId"] = new SelectList(_context.RefProvinces, "ProvinceId", "ProvinceName", nasabahPerorangan.HomePropinsiId);
            ViewData["KodeHartaId"] = new SelectList(_context.RefYesNos, "YesNoId", "YesNoName", nasabahPerorangan.KodeHartaId);
            ViewData["CitizenId"] = new SelectList(_context.RefCitizens, "CitizenId", "CitizenName", nasabahPerorangan.CitizenId);
            ViewData["EducationId"] = new SelectList(_context.RefEducations, "EducationId", "EducationName", nasabahPerorangan.EducationId);
            ViewData["GenderId"] = new SelectList(_context.RefGenders, "GenderId", "GenderName", nasabahPerorangan.GenderId);
            ViewData["HomeStatusId"] = new SelectList(_context.RefHomeStatuses, "HomeStatusId", "HomeStatusName", nasabahPerorangan.HomeStatusId);
            ViewData["JenisIdentityId"] = new SelectList(_context.RefJenisIdentities, "JenisIdentityId", "JenisIdentityName", nasabahPerorangan.JenisIdentityId);
            ViewData["MaritalId"] = new SelectList(_context.RefMaritals, "MaritalId", "MaritalName", nasabahPerorangan.MaritalId);
            ViewData["NasabahId"] = id;
            return View(nasabahPerorangan);
        }

        [Route("Edit/BadanUsaha/{id}")]
        public async Task<IActionResult> EditBadanUsaha(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nasabah = await _context.Nasabahs.FindAsync(id);
            if (nasabah == null)
            {
                return NotFound();
            }

            NasabahBadanUsaha nasabahBadanUsaha = new NasabahBadanUsaha();
            nasabahBadanUsaha.NasabahId = nasabah.NasabahId;
            nasabahBadanUsaha.JenisBadanUsahaId = nasabah.JenisBadanUsahaId;
            nasabahBadanUsaha.NamaLengkap = nasabah.NamaLengkap;
            nasabahBadanUsaha.TempatLahir = nasabah.TempatLahir;
            nasabahBadanUsaha.TanggalLahir = nasabah.TanggalLahir;
            nasabahBadanUsaha.OfficeAddress = nasabah.OfficeAddress;
            nasabahBadanUsaha.OfficeZipCode = nasabah.OfficeZipCode;
            nasabahBadanUsaha.OfficePropinsiId = nasabah.OfficePropinsiId;
            nasabahBadanUsaha.OfficeKotaId = nasabah.OfficeKotaId;
            nasabahBadanUsaha.OfficeKecamatan = nasabah.OfficeKecamatan;
            nasabahBadanUsaha.OfficeKelurahan = nasabah.OfficeKelurahan;
            nasabahBadanUsaha.OfficeStatusId = nasabah.OfficeStatusId;
            nasabahBadanUsaha.OfficePhone = nasabah.OfficePhone;
            nasabahBadanUsaha.OfficeFax = nasabah.OfficeFax;
            nasabahBadanUsaha.NPWPNo = nasabah.NPWPNo;
            nasabahBadanUsaha.Email = nasabah.Email;
            nasabahBadanUsaha.BidangUsahaId = nasabah.BidangUsahaId;
            nasabahBadanUsaha.APPNo = nasabah.APPNo;
            nasabahBadanUsaha.APPDate = nasabah.APPDate;
            nasabahBadanUsaha.APPChangeNo = nasabah.APPChangeNo;
            nasabahBadanUsaha.APPChangeDate = nasabah.APPChangeDate;
            nasabahBadanUsaha.Notaris = nasabah.Notaris;
            nasabahBadanUsaha.ContactPerson = nasabah.ContactPerson;

            ViewData["OfficeKotaId"] = new SelectList(_context.RefCities.Where(x => x.ProvinceId == nasabahBadanUsaha.OfficePropinsiId), "CityId", "CityName", nasabahBadanUsaha.OfficeKotaId);
            ViewData["OfficeStatusId"] = new SelectList(_context.RefHomeStatuses, "HomeStatusId", "HomeStatusName", nasabahBadanUsaha.OfficeStatusId);
            ViewData["OfficePropinsiId"] = new SelectList(_context.RefProvinces, "ProvinceId", "ProvinceName", nasabahBadanUsaha.OfficePropinsiId);
            ViewData["BidangUsahaId"] = new SelectList(_context.RefBidangUsahas, "BidangUsahaId", "BidangUsahaName", nasabahBadanUsaha.BidangUsahaId);
            ViewData["JenisBadanUsahaId"] = new SelectList(_context.RefJenisBadanUsahas, "JenisBadanUsahaId", "JenisBadanUsahaName", nasabahBadanUsaha.JenisBadanUsahaId);
            ViewData["NasabahId"] = id;
            return View(nasabahBadanUsaha);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Edit/BadanUsaha/{id}")]
        public async Task<IActionResult> EditBadanUsaha(string id, NasabahBadanUsaha nasabahBadanUsaha)
        {
            if (id != nasabahBadanUsaha.NasabahId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Nasabah nasabah = _context.Nasabahs.Find(id);
                    nasabah.NasabahId = nasabahBadanUsaha.NasabahId;
                    nasabah.JenisBadanUsahaId = nasabahBadanUsaha.JenisBadanUsahaId;
                    nasabah.NamaLengkap = nasabahBadanUsaha.NamaLengkap;
                    nasabah.TempatLahir = nasabahBadanUsaha.TempatLahir;
                    nasabah.TanggalLahir = nasabahBadanUsaha.TanggalLahir;
                    nasabah.OfficeAddress = nasabahBadanUsaha.OfficeAddress;
                    nasabah.OfficeZipCode = nasabahBadanUsaha.OfficeZipCode;
                    nasabah.OfficePropinsiId = nasabahBadanUsaha.OfficePropinsiId;
                    nasabah.OfficeKotaId = nasabahBadanUsaha.OfficeKotaId;
                    nasabah.OfficeKecamatan = nasabahBadanUsaha.OfficeKecamatan;
                    nasabah.OfficeKelurahan = nasabahBadanUsaha.OfficeKelurahan;
                    nasabah.OfficeStatusId = nasabahBadanUsaha.OfficeStatusId;
                    nasabah.OfficePhone = nasabahBadanUsaha.OfficePhone;
                    nasabah.OfficeFax = nasabahBadanUsaha.OfficeFax;
                    nasabah.NPWPNo = nasabahBadanUsaha.NPWPNo;
                    nasabah.Email = nasabahBadanUsaha.Email;
                    nasabah.BidangUsahaId = nasabahBadanUsaha.BidangUsahaId;
                    nasabah.APPNo = nasabahBadanUsaha.APPNo;
                    nasabah.APPDate = nasabahBadanUsaha.APPDate;
                    nasabah.APPChangeNo = nasabahBadanUsaha.APPChangeNo;
                    nasabah.APPChangeDate = nasabahBadanUsaha.APPChangeDate;
                    nasabah.Notaris = nasabahBadanUsaha.Notaris;
                    nasabah.ContactPerson = nasabahBadanUsaha.ContactPerson;
                    nasabah.UpdatedDate = DateTime.Now;
                    nasabah.UpdatedUserId = User.Identity.Name;

                    _context.Update(nasabah);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NasabahExists(nasabahBadanUsaha.NasabahId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(EditBadanUsaha), new { id = id });
            }
            ViewData["OfficeKotaId"] = new SelectList(_context.RefCities, "CityId", "CityId", nasabahBadanUsaha.OfficeKotaId);
            ViewData["OfficeStatusId"] = new SelectList(_context.RefHomeStatuses, "HomeStatusId", "HomeStatusId", nasabahBadanUsaha.OfficeStatusId);
            ViewData["OfficePropinsiId"] = new SelectList(_context.RefProvinces, "ProvinceId", "ProvinceId", nasabahBadanUsaha.OfficePropinsiId);
            ViewData["BidangUsahaId"] = new SelectList(_context.RefBidangUsahas, "BidangUsahaId", "BidangUsahaId", nasabahBadanUsaha.BidangUsahaId);
            ViewData["JenisBadanUsahaId"] = new SelectList(_context.RefJenisBadanUsahas, "JenisBadanUsahaId", "JenisBadanUsahaId", nasabahBadanUsaha.JenisBadanUsahaId);
            ViewData["NasabahId"] = id;
            return View(nasabahBadanUsaha);
        }

        [Route("ListEdit")]
        public async Task<IActionResult> ListEdit(
            string NasabahId,
            string IdentityNo,
            string NPWPNo,
            string NamaLengkap,
            string TanggalLahir,
            string Address,
            string KotaId,
            int pageNumber = 1)
        {
            ViewData["CityId"] = new SelectList(_context.RefCities.OrderBy(x => x.CityId), "CityId", "CityName", KotaId);

            ViewData["NasabahId"] = NasabahId;
            ViewData["IdentityNo"] = IdentityNo;
            ViewData["NPWPNo"] = NPWPNo;
            ViewData["NamaLengkap"] = NamaLengkap;
            ViewData["TanggalLahir"] = TanggalLahir;
            ViewData["Address"] = Address;
            ViewData["KotaId"] = KotaId;

            var nasabahs = from s in _context.Nasabahs
                        select s;

            if (!String.IsNullOrEmpty(NasabahId))
            {
                nasabahs = nasabahs.Where(s => s.NasabahId == NasabahId);
            }

            if (!String.IsNullOrEmpty(IdentityNo))
            {
                nasabahs = nasabahs.Where(s => s.IdentityNo == IdentityNo
                    || s.APPNo == IdentityNo || s.APPChangeNo == IdentityNo);
            }

            if (!String.IsNullOrEmpty(NPWPNo))
            {
                nasabahs = nasabahs.Where(s => s.NPWPNo == NPWPNo);
            }

            if (!String.IsNullOrEmpty(NamaLengkap))
            {
                nasabahs = nasabahs.Where(s => s.NamaLengkap.ToLower().Contains(NamaLengkap.ToLower()));
            }

            if (!String.IsNullOrEmpty(Address))
            {
                nasabahs = nasabahs.Where(s => s.HomeAddress.ToLower().Contains(Address.ToLower())
                    || s.OfficeAddress.ToLower().Contains(Address.ToLower()));
            }

            if (!String.IsNullOrEmpty(TanggalLahir))
            {
                nasabahs = nasabahs.Where(s => s.TanggalLahir.ToString().Contains(TanggalLahir));
            }

            if (!String.IsNullOrEmpty(KotaId))
            {
                nasabahs = nasabahs.Where(s => s.HomeKotaId == KotaId ||
                    s.OfficeKotaId == KotaId);
            }

            int pageSize = 10;

            int numRows = nasabahs.Count();

            int excludeRecords = (pageSize * pageNumber) - pageSize;

            nasabahs = nasabahs.Skip(excludeRecords).Take(pageSize);

            nasabahs = nasabahs.Include(r => r.RefJenisBadanUsaha).Include(r => r.HomeRefCity).Include(r => r.OfficeRefCity);

            List<NasabahList> nasabahLists = new List<NasabahList>();

            foreach (var nasabah in nasabahs)
            {
                NasabahList nasabahList = new NasabahList();
                nasabahList.NasabahId = nasabah.NasabahId;
                nasabahList.NasabahType = nasabah.NasabahType;
                nasabahList.NamaLengkap = nasabah.NasabahType == "1" ? nasabah.NamaLengkap : nasabah.RefJenisBadanUsaha.JenisBadanUsahaName + " " + nasabah.NamaLengkap;
                nasabahList.TanggalLahir = nasabah.TanggalLahir;
                nasabahList.Address = nasabah.NasabahType == "1" ? nasabah.HomeAddress : nasabah.OfficeAddress;
                nasabahList.KotaId = nasabah.NasabahType == "1" ? nasabah.HomeKotaId : nasabah.OfficeKotaId;
                nasabahList.RefCity = nasabah.NasabahType == "1" ? nasabah.HomeRefCity : nasabah.OfficeRefCity;
                nasabahList.IdentityNo = nasabah.NasabahType == "1" ? nasabah.IdentityNo : nasabah.APPNo;
                nasabahList.NPWPNo = nasabah.NPWPNo;
                nasabahList.Action = nasabah.NasabahType == "1" ? "EditPerorangan" : "EditBadanUsaha";

                nasabahLists.Add(nasabahList);
            }

            var results = new PagedResult<NasabahList>
            {
                Data = nasabahLists.ToList(),
                TotalItems = numRows,
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            return View(results);
        }

        [Route("Edit/JobnSpouse/{id}")]
        public async Task<IActionResult> EditJobnSpouse(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nasabah = await _context.Nasabahs.FindAsync(id);
            if (nasabah == null)
            {
                return NotFound();
            }

            NasabahJobnSpouse nasabahJobnSpouse = new NasabahJobnSpouse();
            nasabahJobnSpouse.NasabahId = nasabah.NasabahId;
            nasabahJobnSpouse.JobTypeId = nasabah.JobTypeId;
            nasabahJobnSpouse.TempatBekerja = nasabah.TempatBekerja;
            nasabahJobnSpouse.BidangUsahaId = nasabah.BidangUsahaId;
            nasabahJobnSpouse.OfficeAddress = nasabah.OfficeAddress;
            nasabahJobnSpouse.OfficePropinsiId = nasabah.OfficePropinsiId;
            nasabahJobnSpouse.OfficeKotaId = nasabah.OfficeKotaId;
            nasabahJobnSpouse.OfficeKecamatan = nasabah.OfficeKecamatan;
            nasabahJobnSpouse.OfficeKelurahan = nasabah.OfficeKelurahan;
            nasabahJobnSpouse.OfficeZipCode = nasabah.OfficeZipCode;
            nasabahJobnSpouse.Income = nasabah.Income;
            nasabahJobnSpouse.SpouseName = nasabah.SpouseName;
            nasabahJobnSpouse.SpouseTempatLahir = nasabah.SpouseTempatLahir;
            nasabahJobnSpouse.SpouseTanggalLahir = nasabah.SpouseTanggalLahir;
            nasabahJobnSpouse.SpouseJenisIdentityId = nasabah.SpouseJenisIdentityId;
            nasabahJobnSpouse.SpouseIdentityNo = nasabah.SpouseIdentityNo;
            nasabahJobnSpouse.SpouseJobTypeId = nasabah.SpouseJobTypeId;
            nasabahJobnSpouse.NasabahId = nasabah.NasabahId;
            nasabahJobnSpouse.NasabahId = nasabah.NasabahId;
            nasabahJobnSpouse.NasabahId = nasabah.NasabahId;

            ViewData["JobTypeId"] = new SelectList(_context.RefJobTypes, "JobTypeId", "JobTypeName", nasabahJobnSpouse.JobTypeId);
            ViewData["BidangUsahaId"] = new SelectList(_context.RefBidangUsahas, "BidangUsahaId", "BidangUsahaName", nasabahJobnSpouse.BidangUsahaId);
            ViewData["OfficePropinsiId"] = new SelectList(_context.RefProvinces, "ProvinceId", "ProvinceName", nasabahJobnSpouse.OfficePropinsiId);
            ViewData["OfficeKotaId"] = new SelectList(_context.RefCities.Where(x => x.ProvinceId == nasabahJobnSpouse.OfficePropinsiId), "CityId", "CityName", nasabahJobnSpouse.OfficeKotaId);
            ViewData["SpouseJenisIdentityId"] = new SelectList(_context.RefJenisIdentities, "JenisIdentityId", "JenisIdentityName", nasabahJobnSpouse.SpouseJenisIdentityId);
            ViewData["SpouseJobTypeId"] = new SelectList(_context.RefJobTypes, "JobTypeId", "JobTypeName", nasabahJobnSpouse.SpouseJobTypeId);
            ViewData["SpouseEducationId"] = new SelectList(_context.RefEducations, "EducationId", "EducationName", nasabahJobnSpouse.SpouseEducationId);
            ViewData["NasabahId"] = id;
            return View(nasabahJobnSpouse);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Edit/JobnSpouse/{id}")]
        public async Task<IActionResult> EditJobnSpouse(string id, NasabahJobnSpouse nasabahJobnSpouse)
        {
            if (id != nasabahJobnSpouse.NasabahId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Nasabah nasabah = _context.Nasabahs.Find(id);
                    nasabah.NasabahId = nasabahJobnSpouse.NasabahId;
                    nasabah.JobTypeId = nasabahJobnSpouse.JobTypeId;
                    nasabah.TempatBekerja = nasabahJobnSpouse.TempatBekerja;
                    nasabah.BidangUsahaId = nasabahJobnSpouse.BidangUsahaId;
                    nasabah.OfficeAddress = nasabahJobnSpouse.OfficeAddress;
                    nasabah.OfficePropinsiId = nasabahJobnSpouse.OfficePropinsiId;
                    nasabah.OfficeKotaId = nasabahJobnSpouse.OfficeKotaId;
                    nasabah.OfficeKecamatan = nasabahJobnSpouse.OfficeKecamatan;
                    nasabah.OfficeKelurahan = nasabahJobnSpouse.OfficeKelurahan;
                    nasabah.OfficeZipCode = nasabahJobnSpouse.OfficeZipCode;
                    nasabah.Income = nasabahJobnSpouse.Income;
                    nasabah.SpouseName = nasabahJobnSpouse.SpouseName;
                    nasabah.SpouseTempatLahir = nasabahJobnSpouse.SpouseTempatLahir;
                    nasabah.SpouseTanggalLahir = nasabahJobnSpouse.SpouseTanggalLahir;
                    nasabah.SpouseJenisIdentityId = nasabahJobnSpouse.SpouseJenisIdentityId;
                    nasabah.SpouseIdentityNo = nasabahJobnSpouse.SpouseIdentityNo;
                    nasabah.SpouseJobTypeId = nasabahJobnSpouse.SpouseJobTypeId;
                    nasabah.NasabahId = nasabahJobnSpouse.NasabahId;
                    nasabah.NasabahId = nasabahJobnSpouse.NasabahId;
                    nasabah.NasabahId = nasabahJobnSpouse.NasabahId;
                    nasabah.UpdatedDate = DateTime.Now;
                    nasabah.UpdatedUserId = User.Identity.Name;

                    _context.Update(nasabah);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NasabahExists(nasabahJobnSpouse.NasabahId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(EditJobnSpouse), new { id = id });
            }
            ViewData["JobTypeId"] = new SelectList(_context.RefJobTypes, "JobTypeId", "JobTypeName", nasabahJobnSpouse.JobTypeId);
            ViewData["BidangUsahaId"] = new SelectList(_context.RefBidangUsahas, "BidangUsahaId", "BidangUsahaName", nasabahJobnSpouse.BidangUsahaId);
            ViewData["OfficePropinsiId"] = new SelectList(_context.RefProvinces, "ProvinceId", "ProvinceName", nasabahJobnSpouse.OfficePropinsiId);
            ViewData["OfficeKotaId"] = new SelectList(_context.RefCities.Where(x => x.ProvinceId == nasabahJobnSpouse.OfficePropinsiId), "CityId", "CityName", nasabahJobnSpouse.OfficeKotaId);
            ViewData["SpouseJenisIdentityId"] = new SelectList(_context.RefJenisIdentities, "JenisIdentityId", "JenisIdentityName", nasabahJobnSpouse.SpouseJenisIdentityId);
            ViewData["SpouseJobTypeId"] = new SelectList(_context.RefJobTypes, "JobTypeId", "JobTypeName", nasabahJobnSpouse.SpouseJobTypeId);
            ViewData["SpouseEducationId"] = new SelectList(_context.RefEducations, "EducationId", "EducationName", nasabahJobnSpouse.SpouseEducationId);
            ViewData["NasabahId"] = id;
            return View(nasabahJobnSpouse);
        }

        [Route("Edit/LaporPerorangan/{id}")]
        public async Task<IActionResult> EditLaporPerorangan(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nasabah = await _context.Nasabahs.FindAsync(id);
            if (nasabah == null)
            {
                return NotFound();
            }

            NasabahLaporPerorangan nasabahLaporPerorangan = new NasabahLaporPerorangan();
            nasabahLaporPerorangan.NasabahId = nasabah.NasabahId;
            nasabahLaporPerorangan.NamaPelaporan = nasabah.NamaPelaporan;
            nasabahLaporPerorangan.GolonganNasabahId = nasabah.GolonganNasabahId;
            nasabahLaporPerorangan.HubunganBankId = nasabah.HubunganBankId;
            nasabahLaporPerorangan.SourceIncomeId = nasabah.SourceIncomeId;
            nasabahLaporPerorangan.BMPKLebih = nasabah.BMPKLebih;
            nasabahLaporPerorangan.BMPKLampaui = nasabah.BMPKLampaui;

            ViewData["GolonganNasabahId"] = new SelectList(_context.RefGolonganNasabahs, "GolonganNasabahId", "GolonganNasabahName", nasabahLaporPerorangan.GolonganNasabahId);
            ViewData["HubunganBankId"] = new SelectList(_context.RefHubunganBanks, "HubunganBankId", "HubunganBankName", nasabahLaporPerorangan.HubunganBankId);
            ViewData["SourceIncomeId"] = new SelectList(_context.RefSourceIncomes, "SourceIncomeId", "SourceIncomeName", nasabahLaporPerorangan.SourceIncomeId);
            ViewData["BMPKLebih"] = new SelectList(_context.RefYesNos, "YesNoId", "YesNoName", nasabahLaporPerorangan.BMPKLebih);
            ViewData["BMPKLampaui"] = new SelectList(_context.RefYesNos, "YesNoId", "YesNoName", nasabahLaporPerorangan.BMPKLampaui);
            ViewData["NasabahId"] = id;
            return View(nasabahLaporPerorangan);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Edit/LaporPerorangan/{id}")]
        public async Task<IActionResult> EditLaporPerorangan(string id, NasabahLaporPerorangan nasabahLaporPerorangan)
        {
            if (id != nasabahLaporPerorangan.NasabahId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Nasabah nasabah = _context.Nasabahs.Find(id);
                    nasabah.NasabahId = nasabahLaporPerorangan.NasabahId;
                    nasabah.NamaPelaporan = nasabahLaporPerorangan.NamaPelaporan;
                    nasabah.GolonganNasabahId = nasabahLaporPerorangan.GolonganNasabahId;
                    nasabah.HubunganBankId = nasabahLaporPerorangan.HubunganBankId;
                    nasabah.SourceIncomeId = nasabahLaporPerorangan.SourceIncomeId;
                    nasabah.BMPKLebih = nasabahLaporPerorangan.BMPKLebih;
                    nasabah.BMPKLampaui = nasabahLaporPerorangan.BMPKLampaui;
                    nasabah.UpdatedDate = DateTime.Now;
                    nasabah.UpdatedUserId = User.Identity.Name;

                    _context.Update(nasabah);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NasabahExists(nasabahLaporPerorangan.NasabahId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(EditLaporPerorangan), new { id = id });
            }
            ViewData["GolonganNasabahId"] = new SelectList(_context.RefGolonganNasabahs, "GolonganNasabahId", "GolonganNasabahName", nasabahLaporPerorangan.GolonganNasabahId);
            ViewData["HubunganBankId"] = new SelectList(_context.RefHubunganBanks, "HubunganBankId", "HubunganBankName", nasabahLaporPerorangan.HubunganBankId);
            ViewData["SourceIncomeId"] = new SelectList(_context.RefSourceIncomes, "SourceIncomeId", "SourceIncomeName", nasabahLaporPerorangan.SourceIncomeId);
            ViewData["BMPKLebih"] = new SelectList(_context.RefYesNos, "YesNoId", "YesNoName", nasabahLaporPerorangan.BMPKLebih);
            ViewData["BMPKLampaui"] = new SelectList(_context.RefYesNos, "YesNoId", "YesNoName", nasabahLaporPerorangan.BMPKLampaui);
            ViewData["NasabahId"] = id;
            return View(nasabahLaporPerorangan);
        }

        [Route("Edit/LaporBadanUsaha/{id}")]
        public async Task<IActionResult> EditLaporBadanUsaha(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nasabah = await _context.Nasabahs.FindAsync(id);
            if (nasabah == null)
            {
                return NotFound();
            }

            NasabahLaporBadanUsaha nasabahLaporBadanUsaha = new NasabahLaporBadanUsaha();
            nasabahLaporBadanUsaha.NasabahId = nasabah.NasabahId;
            nasabahLaporBadanUsaha.NamaPelaporan = nasabah.NamaPelaporan;
            nasabahLaporBadanUsaha.GolonganNasabahId = nasabah.GolonganNasabahId;
            nasabahLaporBadanUsaha.HubunganBankId = nasabah.HubunganBankId;
            nasabahLaporBadanUsaha.SourceIncomeId = nasabah.SourceIncomeId;
            nasabahLaporBadanUsaha.BMPKLebih = nasabah.BMPKLebih;
            nasabahLaporBadanUsaha.BMPKLampaui = nasabah.BMPKLampaui;
            nasabahLaporBadanUsaha.GoPublic = nasabah.GoPublic;
            nasabahLaporBadanUsaha.Peringkat = nasabah.Peringkat;
            nasabahLaporBadanUsaha.LembagaRatingId = nasabah.LembagaRatingId;
            nasabahLaporBadanUsaha.TanggalRating = nasabah.TanggalRating;
            nasabahLaporBadanUsaha.GroupUsaha = nasabah.GroupUsaha;

            ViewData["GolonganNasabahId"] = new SelectList(_context.RefGolonganNasabahs, "GolonganNasabahId", "GolonganNasabahName", nasabahLaporBadanUsaha.GolonganNasabahId);
            ViewData["HubunganBankId"] = new SelectList(_context.RefHubunganBanks, "HubunganBankId", "HubunganBankName", nasabahLaporBadanUsaha.HubunganBankId);
            ViewData["SourceIncomeId"] = new SelectList(_context.RefSourceIncomes, "SourceIncomeId", "SourceIncomeName", nasabahLaporBadanUsaha.SourceIncomeId);
            ViewData["BMPKLebih"] = new SelectList(_context.RefYesNos, "YesNoId", "YesNoName", nasabahLaporBadanUsaha.BMPKLebih);
            ViewData["BMPKLampaui"] = new SelectList(_context.RefYesNos, "YesNoId", "YesNoName", nasabahLaporBadanUsaha.BMPKLampaui);
            ViewData["GoPublic"] = new SelectList(_context.RefYesNos, "YesNoId", "YesNoName", nasabahLaporBadanUsaha.GoPublic);
            ViewData["LembagaRatingId"] = new SelectList(_context.RefLembagaRatings, "LembagaRatingId", "LembagaRatingName", nasabahLaporBadanUsaha.LembagaRatingId);
            ViewData["NasabahId"] = id;
            return View(nasabahLaporBadanUsaha);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Edit/LaporBadanUsaha/{id}")]
        public async Task<IActionResult> EditLaporBadanUsaha(string id, NasabahLaporBadanUsaha nasabahLaporBadanUsaha)
        {
            if (id != nasabahLaporBadanUsaha.NasabahId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Nasabah nasabah = _context.Nasabahs.Find(id);
                    nasabah.NasabahId = nasabahLaporBadanUsaha.NasabahId;
                    nasabah.NamaPelaporan = nasabahLaporBadanUsaha.NamaPelaporan;
                    nasabah.GolonganNasabahId = nasabahLaporBadanUsaha.GolonganNasabahId;
                    nasabah.HubunganBankId = nasabahLaporBadanUsaha.HubunganBankId;
                    nasabah.SourceIncomeId = nasabahLaporBadanUsaha.SourceIncomeId;
                    nasabah.BMPKLebih = nasabahLaporBadanUsaha.BMPKLebih;
                    nasabah.BMPKLampaui = nasabahLaporBadanUsaha.BMPKLampaui;
                    nasabah.GoPublic = nasabahLaporBadanUsaha.GoPublic;
                    nasabah.Peringkat = nasabahLaporBadanUsaha.Peringkat;
                    nasabah.LembagaRatingId = nasabahLaporBadanUsaha.LembagaRatingId;
                    nasabah.TanggalRating = nasabahLaporBadanUsaha.TanggalRating;
                    nasabah.GroupUsaha = nasabahLaporBadanUsaha.GroupUsaha;
                    nasabah.UpdatedDate = DateTime.Now;
                    nasabah.UpdatedUserId = User.Identity.Name;

                    _context.Update(nasabah);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NasabahExists(nasabahLaporBadanUsaha.NasabahId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(EditLaporBadanUsaha), new { id = id });
            }
            ViewData["GolonganNasabahId"] = new SelectList(_context.RefGolonganNasabahs, "GolonganNasabahId", "GolonganNasabahName", nasabahLaporBadanUsaha.GolonganNasabahId);
            ViewData["HubunganBankId"] = new SelectList(_context.RefHubunganBanks, "HubunganBankId", "HubunganBankName", nasabahLaporBadanUsaha.HubunganBankId);
            ViewData["SourceIncomeId"] = new SelectList(_context.RefSourceIncomes, "SourceIncomeId", "SourceIncomeName", nasabahLaporBadanUsaha.SourceIncomeId);
            ViewData["BMPKLebih"] = new SelectList(_context.RefYesNos, "YesNoId", "YesNoName", nasabahLaporBadanUsaha.BMPKLebih);
            ViewData["BMPKLampaui"] = new SelectList(_context.RefYesNos, "YesNoId", "YesNoName", nasabahLaporBadanUsaha.BMPKLampaui);
            ViewData["GoPublic"] = new SelectList(_context.RefYesNos, "YesNoId", "YesNoName", nasabahLaporBadanUsaha.GoPublic);
            ViewData["LembagaRatingId"] = new SelectList(_context.RefLembagaRatings, "LembagaRatingId", "LembagaRatingName", nasabahLaporBadanUsaha.LembagaRatingId);
            ViewData["NasabahId"] = id;
            return View(nasabahLaporBadanUsaha);
        }

        [Route("ListCatatan")]
        public async Task<IActionResult> ListCatatan(
            string NasabahId,
            string IdentityNo,
            string NPWPNo,
            string NamaLengkap,
            string TanggalLahir,
            string Address,
            string KotaId,
            int pageNumber = 1)
        {
            ViewData["CityId"] = new SelectList(_context.RefCities.OrderBy(x => x.CityId), "CityId", "CityName", KotaId);

            ViewData["NasabahId"] = NasabahId;
            ViewData["IdentityNo"] = IdentityNo;
            ViewData["NPWPNo"] = NPWPNo;
            ViewData["NamaLengkap"] = NamaLengkap;
            ViewData["TanggalLahir"] = TanggalLahir;
            ViewData["Address"] = Address;
            ViewData["KotaId"] = KotaId;

            var nasabahs = from s in _context.Nasabahs
                           select s;

            if (!String.IsNullOrEmpty(NasabahId))
            {
                nasabahs = nasabahs.Where(s => s.NasabahId == NasabahId);
            }

            if (!String.IsNullOrEmpty(IdentityNo))
            {
                nasabahs = nasabahs.Where(s => s.IdentityNo == IdentityNo
                    || s.APPNo == IdentityNo || s.APPChangeNo == IdentityNo);
            }

            if (!String.IsNullOrEmpty(NPWPNo))
            {
                nasabahs = nasabahs.Where(s => s.NPWPNo == NPWPNo);
            }

            if (!String.IsNullOrEmpty(NamaLengkap))
            {
                nasabahs = nasabahs.Where(s => s.NamaLengkap.ToLower().Contains(NamaLengkap.ToLower()));
            }

            if (!String.IsNullOrEmpty(Address))
            {
                nasabahs = nasabahs.Where(s => s.HomeAddress.ToLower().Contains(Address.ToLower())
                    || s.OfficeAddress.ToLower().Contains(Address.ToLower()));
            }

            if (!String.IsNullOrEmpty(TanggalLahir))
            {
                nasabahs = nasabahs.Where(s => s.TanggalLahir.ToString().Contains(TanggalLahir));
            }

            if (!String.IsNullOrEmpty(KotaId))
            {
                nasabahs = nasabahs.Where(s => s.HomeKotaId == KotaId ||
                    s.OfficeKotaId == KotaId);
            }

            int pageSize = 10;

            int numRows = nasabahs.Count();

            int excludeRecords = (pageSize * pageNumber) - pageSize;

            nasabahs = nasabahs.Skip(excludeRecords).Take(pageSize);

            nasabahs = nasabahs.Include(r => r.RefJenisBadanUsaha).Include(r => r.HomeRefCity).Include(r => r.OfficeRefCity);

            List<NasabahList> nasabahLists = new List<NasabahList>();

            foreach (var nasabah in nasabahs)
            {
                NasabahList nasabahList = new NasabahList();
                nasabahList.NasabahId = nasabah.NasabahId;
                nasabahList.NasabahType = nasabah.NasabahType;
                nasabahList.NamaLengkap = nasabah.NasabahType == "1" ? nasabah.NamaLengkap : nasabah.RefJenisBadanUsaha.JenisBadanUsahaName + " " + nasabah.NamaLengkap;
                nasabahList.TanggalLahir = nasabah.TanggalLahir;
                nasabahList.Address = nasabah.NasabahType == "1" ? nasabah.HomeAddress : nasabah.OfficeAddress;
                nasabahList.KotaId = nasabah.NasabahType == "1" ? nasabah.HomeKotaId : nasabah.OfficeKotaId;
                nasabahList.RefCity = nasabah.NasabahType == "1" ? nasabah.HomeRefCity : nasabah.OfficeRefCity;
                nasabahList.IdentityNo = nasabah.NasabahType == "1" ? nasabah.IdentityNo : nasabah.APPNo;
                nasabahList.NPWPNo = nasabah.NPWPNo;
                nasabahList.Action = "EditCatatan";

                nasabahLists.Add(nasabahList);
            }

            var results = new PagedResult<NasabahList>
            {
                Data = nasabahLists.ToList(),
                TotalItems = numRows,
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            return View(results);
        }

        [Route("Edit/Catatan/{id}")]
        public async Task<IActionResult> EditCatatan(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nasabah = await _context.Nasabahs.FindAsync(id);
            if (nasabah == null)
            {
                return NotFound();
            }

            NasabahCatatan nasabahCatatan = new NasabahCatatan();
            nasabahCatatan.NasabahId = nasabah.NasabahId;
            nasabahCatatan.KategoriCatatanId = nasabah.KategoriCatatanId;
            nasabahCatatan.CatatanSource = nasabah.CatatanSource;
            nasabahCatatan.CatatanExpiredDate = nasabah.CatatanExpiredDate;
            nasabahCatatan.Catatan = nasabah.Catatan;

            ViewData["KategoriCatatanId"] = new SelectList(_context.RefKategoriCatatans, "KategoriCatatanId", "KategoriCatatanName", nasabahCatatan.KategoriCatatanId);
            ViewData["NasabahId"] = id;
            return View(nasabahCatatan);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Edit/Catatan/{id}")]
        public async Task<IActionResult> EditCatatan(string id, NasabahCatatan nasabahCatatan)
        {
            if (id != nasabahCatatan.NasabahId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Nasabah nasabah = _context.Nasabahs.Find(id);
                    nasabah.NasabahId = nasabahCatatan.NasabahId;
                    nasabah.KategoriCatatanId = nasabahCatatan.KategoriCatatanId;
                    nasabah.CatatanSource = nasabahCatatan.CatatanSource;
                    nasabah.CatatanExpiredDate = nasabahCatatan.CatatanExpiredDate;
                    nasabah.Catatan = nasabahCatatan.Catatan;

                    _context.Update(nasabah);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NasabahExists(nasabahCatatan.NasabahId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(EditCatatan), new { id = id });
            }
            ViewData["KategoriCatatanId"] = new SelectList(_context.RefKategoriCatatans, "KategoriCatatanId", "KategoriCatatanName", nasabahCatatan.KategoriCatatanId);
            ViewData["NasabahId"] = id;
            return View(nasabahCatatan);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Delete/Catatan/{id}")]
        public async Task<IActionResult> DeleteCatatan(string id)
        {
            Nasabah nasabah = _context.Nasabahs.Find(id);
            nasabah.KategoriCatatanId = null;
            nasabah.CatatanSource = null;
            nasabah.CatatanExpiredDate = null;
            nasabah.Catatan = null;

            _context.Update(nasabah);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(EditCatatan), new { id = id });
        }

        private bool NasabahExists(string id)
        {
            return _context.Nasabahs.Any(e => e.NasabahId == id);
        }
    }
}
