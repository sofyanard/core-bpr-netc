using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CoreBPR.Models;

namespace CoreBPR.Controllers
{
    public class ZNasabahController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ZNasabahController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ZNasabah
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Nasabahs.Include(n => n.BMPKLampauiRefYesNo).Include(n => n.BMPKLebihRefYesNo).Include(n => n.GoPublicRefYesNo).Include(n => n.HomeRefCity).Include(n => n.HomeRefProvince).Include(n => n.KodeHartaRefYesNo).Include(n => n.OfficeRefCity).Include(n => n.OfficeRefHomeStatus).Include(n => n.OfficeRefProvince).Include(n => n.RefBidangUsaha).Include(n => n.RefCitizen).Include(n => n.RefEducation).Include(n => n.RefGender).Include(n => n.RefGolonganNasabah).Include(n => n.RefHomeStatus).Include(n => n.RefHubunganBank).Include(n => n.RefJenisBadanUsaha).Include(n => n.RefJenisIdentity).Include(n => n.RefJobType).Include(n => n.RefLembagaRating).Include(n => n.RefMarital).Include(n => n.RefSourceIncome).Include(n => n.SpouseRefEducation).Include(n => n.SpouseRefJenisIdentity).Include(n => n.SpouseRefJobType);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ZNasabah/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nasabah = await _context.Nasabahs
                .Include(n => n.BMPKLampauiRefYesNo)
                .Include(n => n.BMPKLebihRefYesNo)
                .Include(n => n.GoPublicRefYesNo)
                .Include(n => n.HomeRefCity)
                .Include(n => n.HomeRefProvince)
                .Include(n => n.KodeHartaRefYesNo)
                .Include(n => n.OfficeRefCity)
                .Include(n => n.OfficeRefHomeStatus)
                .Include(n => n.OfficeRefProvince)
                .Include(n => n.RefBidangUsaha)
                .Include(n => n.RefCitizen)
                .Include(n => n.RefEducation)
                .Include(n => n.RefGender)
                .Include(n => n.RefGolonganNasabah)
                .Include(n => n.RefHomeStatus)
                .Include(n => n.RefHubunganBank)
                .Include(n => n.RefJenisBadanUsaha)
                .Include(n => n.RefJenisIdentity)
                .Include(n => n.RefJobType)
                .Include(n => n.RefLembagaRating)
                .Include(n => n.RefMarital)
                .Include(n => n.RefSourceIncome)
                .Include(n => n.SpouseRefEducation)
                .Include(n => n.SpouseRefJenisIdentity)
                .Include(n => n.SpouseRefJobType)
                .FirstOrDefaultAsync(m => m.NasabahId == id);
            if (nasabah == null)
            {
                return NotFound();
            }

            return View(nasabah);
        }

        // GET: ZNasabah/Create
        public IActionResult Create()
        {
            ViewData["BMPKLampaui"] = new SelectList(_context.RefYesNos, "YesNoId", "YesNoId");
            ViewData["BMPKLebih"] = new SelectList(_context.RefYesNos, "YesNoId", "YesNoId");
            ViewData["GoPublic"] = new SelectList(_context.RefYesNos, "YesNoId", "YesNoId");
            ViewData["HomeKotaId"] = new SelectList(_context.RefCities, "CityId", "CityId");
            ViewData["HomePropinsiId"] = new SelectList(_context.RefProvinces, "ProvinceId", "ProvinceId");
            ViewData["KodeHartaId"] = new SelectList(_context.RefYesNos, "YesNoId", "YesNoId");
            ViewData["OfficeKotaId"] = new SelectList(_context.RefCities, "CityId", "CityId");
            ViewData["OfficeStatusId"] = new SelectList(_context.RefHomeStatuses, "HomeStatusId", "HomeStatusId");
            ViewData["OfficePropinsiId"] = new SelectList(_context.RefProvinces, "ProvinceId", "ProvinceId");
            ViewData["BidangUsahaId"] = new SelectList(_context.RefBidangUsahas, "BidangUsahaId", "BidangUsahaId");
            ViewData["CitizenId"] = new SelectList(_context.RefCitizens, "CitizenId", "CitizenId");
            ViewData["EducationId"] = new SelectList(_context.RefEducations, "EducationId", "EducationId");
            ViewData["GenderId"] = new SelectList(_context.RefGenders, "GenderId", "GenderId");
            ViewData["GolonganNasabahId"] = new SelectList(_context.RefGolonganNasabahs, "GolonganNasabahId", "GolonganNasabahId");
            ViewData["HomeStatusId"] = new SelectList(_context.RefHomeStatuses, "HomeStatusId", "HomeStatusId");
            ViewData["HubunganBankId"] = new SelectList(_context.RefHubunganBanks, "HubunganBankId", "HubunganBankId");
            ViewData["JenisBadanUsahaId"] = new SelectList(_context.RefJenisBadanUsahas, "JenisBadanUsahaId", "JenisBadanUsahaId");
            ViewData["JenisIdentityId"] = new SelectList(_context.RefJenisIdentities, "JenisIdentityId", "JenisIdentityId");
            ViewData["JobTypeId"] = new SelectList(_context.RefJobTypes, "JobTypeId", "JobTypeId");
            ViewData["LembagaRatingId"] = new SelectList(_context.RefLembagaRatings, "LembagaRatingId", "LembagaRatingId");
            ViewData["MaritalId"] = new SelectList(_context.RefMaritals, "MaritalId", "MaritalId");
            ViewData["SourceIncomeId"] = new SelectList(_context.RefSourceIncomes, "SourceIncomeId", "SourceIncomeId");
            ViewData["SpouseEducationId"] = new SelectList(_context.RefEducations, "EducationId", "EducationId");
            ViewData["SpouseJenisIdentityId"] = new SelectList(_context.RefJenisIdentities, "JenisIdentityId", "JenisIdentityId");
            ViewData["SpouseJobTypeId"] = new SelectList(_context.RefJobTypes, "JobTypeId", "JobTypeId");
            return View();
        }

        // POST: ZNasabah/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NasabahId,NamaLengkap,NamaIdentity,GenderId,TempatLahir,TanggalLahir,HomeAddress,HomeZipCode,HomePropinsiId,HomeKotaId,HomeKecamatan,HomeKelurahan,HomeStatusId,HomePhone,MobilePhone,NamaIbuKandung,CitizenId,MaritalId,EducationId,JenisIdentityId,IdentityNo,NPWPNo,Email,Tanggungan,KodeHartaId,JenisBadanUsahaId,BidangUsahaId,APPNo,APPDate,APPChangeNo,APPChangeDate,Notaris,OfficeAddress,OfficeZipCode,OfficePropinsiId,OfficeKotaId,OfficeKecamatan,OfficeKelurahan,OfficePhone,OfficeFax,OfficeStatusId,ContactPerson,JobTypeId,TempatBekerja,Income,SpouseName,SpouseTempatLahir,SpouseTanggalLahir,SpouseJenisIdentityId,SpouseIdentityNo,SpouseJobTypeId,SpouseEducationId,NamaPelaporan,SourceIncomeId,GolonganNasabahId,HubunganBankId,BMPKLebih,BMPKLampaui,GoPublic,Peringkat,LembagaRatingId,TanggalRating,GroupUsaha,CreatedDate,CreatedUnitId,UpdatedDate,UpdatedUserId")] Nasabah nasabah)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nasabah);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BMPKLampaui"] = new SelectList(_context.RefYesNos, "YesNoId", "YesNoId", nasabah.BMPKLampaui);
            ViewData["BMPKLebih"] = new SelectList(_context.RefYesNos, "YesNoId", "YesNoId", nasabah.BMPKLebih);
            ViewData["GoPublic"] = new SelectList(_context.RefYesNos, "YesNoId", "YesNoId", nasabah.GoPublic);
            ViewData["HomeKotaId"] = new SelectList(_context.RefCities, "CityId", "CityId", nasabah.HomeKotaId);
            ViewData["HomePropinsiId"] = new SelectList(_context.RefProvinces, "ProvinceId", "ProvinceId", nasabah.HomePropinsiId);
            ViewData["KodeHartaId"] = new SelectList(_context.RefYesNos, "YesNoId", "YesNoId", nasabah.KodeHartaId);
            ViewData["OfficeKotaId"] = new SelectList(_context.RefCities, "CityId", "CityId", nasabah.OfficeKotaId);
            ViewData["OfficeStatusId"] = new SelectList(_context.RefHomeStatuses, "HomeStatusId", "HomeStatusId", nasabah.OfficeStatusId);
            ViewData["OfficePropinsiId"] = new SelectList(_context.RefProvinces, "ProvinceId", "ProvinceId", nasabah.OfficePropinsiId);
            ViewData["BidangUsahaId"] = new SelectList(_context.RefBidangUsahas, "BidangUsahaId", "BidangUsahaId", nasabah.BidangUsahaId);
            ViewData["CitizenId"] = new SelectList(_context.RefCitizens, "CitizenId", "CitizenId", nasabah.CitizenId);
            ViewData["EducationId"] = new SelectList(_context.RefEducations, "EducationId", "EducationId", nasabah.EducationId);
            ViewData["GenderId"] = new SelectList(_context.RefGenders, "GenderId", "GenderId", nasabah.GenderId);
            ViewData["GolonganNasabahId"] = new SelectList(_context.RefGolonganNasabahs, "GolonganNasabahId", "GolonganNasabahId", nasabah.GolonganNasabahId);
            ViewData["HomeStatusId"] = new SelectList(_context.RefHomeStatuses, "HomeStatusId", "HomeStatusId", nasabah.HomeStatusId);
            ViewData["HubunganBankId"] = new SelectList(_context.RefHubunganBanks, "HubunganBankId", "HubunganBankId", nasabah.HubunganBankId);
            ViewData["JenisBadanUsahaId"] = new SelectList(_context.RefJenisBadanUsahas, "JenisBadanUsahaId", "JenisBadanUsahaId", nasabah.JenisBadanUsahaId);
            ViewData["JenisIdentityId"] = new SelectList(_context.RefJenisIdentities, "JenisIdentityId", "JenisIdentityId", nasabah.JenisIdentityId);
            ViewData["JobTypeId"] = new SelectList(_context.RefJobTypes, "JobTypeId", "JobTypeId", nasabah.JobTypeId);
            ViewData["LembagaRatingId"] = new SelectList(_context.RefLembagaRatings, "LembagaRatingId", "LembagaRatingId", nasabah.LembagaRatingId);
            ViewData["MaritalId"] = new SelectList(_context.RefMaritals, "MaritalId", "MaritalId", nasabah.MaritalId);
            ViewData["SourceIncomeId"] = new SelectList(_context.RefSourceIncomes, "SourceIncomeId", "SourceIncomeId", nasabah.SourceIncomeId);
            ViewData["SpouseEducationId"] = new SelectList(_context.RefEducations, "EducationId", "EducationId", nasabah.SpouseEducationId);
            ViewData["SpouseJenisIdentityId"] = new SelectList(_context.RefJenisIdentities, "JenisIdentityId", "JenisIdentityId", nasabah.SpouseJenisIdentityId);
            ViewData["SpouseJobTypeId"] = new SelectList(_context.RefJobTypes, "JobTypeId", "JobTypeId", nasabah.SpouseJobTypeId);
            return View(nasabah);
        }

        // GET: ZNasabah/Edit/5
        public async Task<IActionResult> Edit(string id)
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
            ViewData["BMPKLampaui"] = new SelectList(_context.RefYesNos, "YesNoId", "YesNoId", nasabah.BMPKLampaui);
            ViewData["BMPKLebih"] = new SelectList(_context.RefYesNos, "YesNoId", "YesNoId", nasabah.BMPKLebih);
            ViewData["GoPublic"] = new SelectList(_context.RefYesNos, "YesNoId", "YesNoId", nasabah.GoPublic);
            ViewData["HomeKotaId"] = new SelectList(_context.RefCities, "CityId", "CityId", nasabah.HomeKotaId);
            ViewData["HomePropinsiId"] = new SelectList(_context.RefProvinces, "ProvinceId", "ProvinceId", nasabah.HomePropinsiId);
            ViewData["KodeHartaId"] = new SelectList(_context.RefYesNos, "YesNoId", "YesNoId", nasabah.KodeHartaId);
            ViewData["OfficeKotaId"] = new SelectList(_context.RefCities, "CityId", "CityId", nasabah.OfficeKotaId);
            ViewData["OfficeStatusId"] = new SelectList(_context.RefHomeStatuses, "HomeStatusId", "HomeStatusId", nasabah.OfficeStatusId);
            ViewData["OfficePropinsiId"] = new SelectList(_context.RefProvinces, "ProvinceId", "ProvinceId", nasabah.OfficePropinsiId);
            ViewData["BidangUsahaId"] = new SelectList(_context.RefBidangUsahas, "BidangUsahaId", "BidangUsahaId", nasabah.BidangUsahaId);
            ViewData["CitizenId"] = new SelectList(_context.RefCitizens, "CitizenId", "CitizenId", nasabah.CitizenId);
            ViewData["EducationId"] = new SelectList(_context.RefEducations, "EducationId", "EducationId", nasabah.EducationId);
            ViewData["GenderId"] = new SelectList(_context.RefGenders, "GenderId", "GenderId", nasabah.GenderId);
            ViewData["GolonganNasabahId"] = new SelectList(_context.RefGolonganNasabahs, "GolonganNasabahId", "GolonganNasabahId", nasabah.GolonganNasabahId);
            ViewData["HomeStatusId"] = new SelectList(_context.RefHomeStatuses, "HomeStatusId", "HomeStatusId", nasabah.HomeStatusId);
            ViewData["HubunganBankId"] = new SelectList(_context.RefHubunganBanks, "HubunganBankId", "HubunganBankId", nasabah.HubunganBankId);
            ViewData["JenisBadanUsahaId"] = new SelectList(_context.RefJenisBadanUsahas, "JenisBadanUsahaId", "JenisBadanUsahaId", nasabah.JenisBadanUsahaId);
            ViewData["JenisIdentityId"] = new SelectList(_context.RefJenisIdentities, "JenisIdentityId", "JenisIdentityId", nasabah.JenisIdentityId);
            ViewData["JobTypeId"] = new SelectList(_context.RefJobTypes, "JobTypeId", "JobTypeId", nasabah.JobTypeId);
            ViewData["LembagaRatingId"] = new SelectList(_context.RefLembagaRatings, "LembagaRatingId", "LembagaRatingId", nasabah.LembagaRatingId);
            ViewData["MaritalId"] = new SelectList(_context.RefMaritals, "MaritalId", "MaritalId", nasabah.MaritalId);
            ViewData["SourceIncomeId"] = new SelectList(_context.RefSourceIncomes, "SourceIncomeId", "SourceIncomeId", nasabah.SourceIncomeId);
            ViewData["SpouseEducationId"] = new SelectList(_context.RefEducations, "EducationId", "EducationId", nasabah.SpouseEducationId);
            ViewData["SpouseJenisIdentityId"] = new SelectList(_context.RefJenisIdentities, "JenisIdentityId", "JenisIdentityId", nasabah.SpouseJenisIdentityId);
            ViewData["SpouseJobTypeId"] = new SelectList(_context.RefJobTypes, "JobTypeId", "JobTypeId", nasabah.SpouseJobTypeId);
            return View(nasabah);
        }

        // POST: ZNasabah/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("NasabahId,NamaLengkap,NamaIdentity,GenderId,TempatLahir,TanggalLahir,HomeAddress,HomeZipCode,HomePropinsiId,HomeKotaId,HomeKecamatan,HomeKelurahan,HomeStatusId,HomePhone,MobilePhone,NamaIbuKandung,CitizenId,MaritalId,EducationId,JenisIdentityId,IdentityNo,NPWPNo,Email,Tanggungan,KodeHartaId,JenisBadanUsahaId,BidangUsahaId,APPNo,APPDate,APPChangeNo,APPChangeDate,Notaris,OfficeAddress,OfficeZipCode,OfficePropinsiId,OfficeKotaId,OfficeKecamatan,OfficeKelurahan,OfficePhone,OfficeFax,OfficeStatusId,ContactPerson,JobTypeId,TempatBekerja,Income,SpouseName,SpouseTempatLahir,SpouseTanggalLahir,SpouseJenisIdentityId,SpouseIdentityNo,SpouseJobTypeId,SpouseEducationId,NamaPelaporan,SourceIncomeId,GolonganNasabahId,HubunganBankId,BMPKLebih,BMPKLampaui,GoPublic,Peringkat,LembagaRatingId,TanggalRating,GroupUsaha,CreatedDate,CreatedUnitId,UpdatedDate,UpdatedUserId")] Nasabah nasabah)
        {
            if (id != nasabah.NasabahId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nasabah);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NasabahExists(nasabah.NasabahId))
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
            ViewData["BMPKLampaui"] = new SelectList(_context.RefYesNos, "YesNoId", "YesNoId", nasabah.BMPKLampaui);
            ViewData["BMPKLebih"] = new SelectList(_context.RefYesNos, "YesNoId", "YesNoId", nasabah.BMPKLebih);
            ViewData["GoPublic"] = new SelectList(_context.RefYesNos, "YesNoId", "YesNoId", nasabah.GoPublic);
            ViewData["HomeKotaId"] = new SelectList(_context.RefCities, "CityId", "CityId", nasabah.HomeKotaId);
            ViewData["HomePropinsiId"] = new SelectList(_context.RefProvinces, "ProvinceId", "ProvinceId", nasabah.HomePropinsiId);
            ViewData["KodeHartaId"] = new SelectList(_context.RefYesNos, "YesNoId", "YesNoId", nasabah.KodeHartaId);
            ViewData["OfficeKotaId"] = new SelectList(_context.RefCities, "CityId", "CityId", nasabah.OfficeKotaId);
            ViewData["OfficeStatusId"] = new SelectList(_context.RefHomeStatuses, "HomeStatusId", "HomeStatusId", nasabah.OfficeStatusId);
            ViewData["OfficePropinsiId"] = new SelectList(_context.RefProvinces, "ProvinceId", "ProvinceId", nasabah.OfficePropinsiId);
            ViewData["BidangUsahaId"] = new SelectList(_context.RefBidangUsahas, "BidangUsahaId", "BidangUsahaId", nasabah.BidangUsahaId);
            ViewData["CitizenId"] = new SelectList(_context.RefCitizens, "CitizenId", "CitizenId", nasabah.CitizenId);
            ViewData["EducationId"] = new SelectList(_context.RefEducations, "EducationId", "EducationId", nasabah.EducationId);
            ViewData["GenderId"] = new SelectList(_context.RefGenders, "GenderId", "GenderId", nasabah.GenderId);
            ViewData["GolonganNasabahId"] = new SelectList(_context.RefGolonganNasabahs, "GolonganNasabahId", "GolonganNasabahId", nasabah.GolonganNasabahId);
            ViewData["HomeStatusId"] = new SelectList(_context.RefHomeStatuses, "HomeStatusId", "HomeStatusId", nasabah.HomeStatusId);
            ViewData["HubunganBankId"] = new SelectList(_context.RefHubunganBanks, "HubunganBankId", "HubunganBankId", nasabah.HubunganBankId);
            ViewData["JenisBadanUsahaId"] = new SelectList(_context.RefJenisBadanUsahas, "JenisBadanUsahaId", "JenisBadanUsahaId", nasabah.JenisBadanUsahaId);
            ViewData["JenisIdentityId"] = new SelectList(_context.RefJenisIdentities, "JenisIdentityId", "JenisIdentityId", nasabah.JenisIdentityId);
            ViewData["JobTypeId"] = new SelectList(_context.RefJobTypes, "JobTypeId", "JobTypeId", nasabah.JobTypeId);
            ViewData["LembagaRatingId"] = new SelectList(_context.RefLembagaRatings, "LembagaRatingId", "LembagaRatingId", nasabah.LembagaRatingId);
            ViewData["MaritalId"] = new SelectList(_context.RefMaritals, "MaritalId", "MaritalId", nasabah.MaritalId);
            ViewData["SourceIncomeId"] = new SelectList(_context.RefSourceIncomes, "SourceIncomeId", "SourceIncomeId", nasabah.SourceIncomeId);
            ViewData["SpouseEducationId"] = new SelectList(_context.RefEducations, "EducationId", "EducationId", nasabah.SpouseEducationId);
            ViewData["SpouseJenisIdentityId"] = new SelectList(_context.RefJenisIdentities, "JenisIdentityId", "JenisIdentityId", nasabah.SpouseJenisIdentityId);
            ViewData["SpouseJobTypeId"] = new SelectList(_context.RefJobTypes, "JobTypeId", "JobTypeId", nasabah.SpouseJobTypeId);
            return View(nasabah);
        }

        // GET: ZNasabah/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nasabah = await _context.Nasabahs
                .Include(n => n.BMPKLampauiRefYesNo)
                .Include(n => n.BMPKLebihRefYesNo)
                .Include(n => n.GoPublicRefYesNo)
                .Include(n => n.HomeRefCity)
                .Include(n => n.HomeRefProvince)
                .Include(n => n.KodeHartaRefYesNo)
                .Include(n => n.OfficeRefCity)
                .Include(n => n.OfficeRefHomeStatus)
                .Include(n => n.OfficeRefProvince)
                .Include(n => n.RefBidangUsaha)
                .Include(n => n.RefCitizen)
                .Include(n => n.RefEducation)
                .Include(n => n.RefGender)
                .Include(n => n.RefGolonganNasabah)
                .Include(n => n.RefHomeStatus)
                .Include(n => n.RefHubunganBank)
                .Include(n => n.RefJenisBadanUsaha)
                .Include(n => n.RefJenisIdentity)
                .Include(n => n.RefJobType)
                .Include(n => n.RefLembagaRating)
                .Include(n => n.RefMarital)
                .Include(n => n.RefSourceIncome)
                .Include(n => n.SpouseRefEducation)
                .Include(n => n.SpouseRefJenisIdentity)
                .Include(n => n.SpouseRefJobType)
                .FirstOrDefaultAsync(m => m.NasabahId == id);
            if (nasabah == null)
            {
                return NotFound();
            }

            return View(nasabah);
        }

        // POST: ZNasabah/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var nasabah = await _context.Nasabahs.FindAsync(id);
            _context.Nasabahs.Remove(nasabah);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NasabahExists(string id)
        {
            return _context.Nasabahs.Any(e => e.NasabahId == id);
        }
    }
}
