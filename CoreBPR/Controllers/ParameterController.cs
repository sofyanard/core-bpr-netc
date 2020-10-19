using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CoreBPR.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoreBPR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParameterController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ParameterController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/<ParameterController>
        [HttpGet]
        [Route("provinces")]
        public async Task<ActionResult<IEnumerable<RefProvince>>> GetRefProvinces()
        {
            return await _context.RefProvinces.ToListAsync();
        }

        // GET api/<ParameterController>/5
        [HttpGet("{id}")]
        [Route("province/{id}")]
        public async Task<ActionResult<RefProvince>> GetProvince(string id)
        {
            var refProvince = await _context.RefProvinces.FindAsync(id);

            if (refProvince == null)
            {
                return NotFound();
            }

            return refProvince;
        }

        // GET api/<ParameterController>/5
        [HttpGet("{id}")]
        [Route("citiesbyprovince/{provinceId}")]
        public async Task<ActionResult<IEnumerable<RefCity>>> GetCitiesByProvince(string provinceId)
        {
            return await _context.RefCities.Where(x => x.ProvinceId == provinceId).ToListAsync();
        }
    }
}
