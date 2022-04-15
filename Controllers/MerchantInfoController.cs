using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Santander.Models;

namespace Santander.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MerchantInfoController : ControllerBase
    {
        private readonly DB_Service_MerchantContext _context;

        public MerchantInfoController(DB_Service_MerchantContext context)
        {
            _context = context;
        }

        // GET: api/MerchantInfo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MerchantInfo>>> GetMerchantInfo()
        {
            return await _context.MerchantInfo.ToListAsync();
        }

        // GET: api/MerchantInfo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MerchantInfo>> GetMerchantInfo(int id)
        {
            var merchantInfo = await _context.MerchantInfo.FindAsync(id);

            if (merchantInfo == null)
            {
                return NotFound();
            }

            return merchantInfo;
        }

        // PUT: api/MerchantInfo/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMerchantInfo(int id, MerchantInfo merchantInfo)
        {
            if (id != merchantInfo.MerchantId)
            {
                return BadRequest();
            }

            _context.Entry(merchantInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MerchantInfoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/MerchantInfo
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MerchantInfo>> PostMerchantInfo(MerchantInfo merchantInfo)
        {
            _context.MerchantInfo.Add(merchantInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMerchantInfo", new { id = merchantInfo.MerchantId }, merchantInfo);
        }

        // DELETE: api/MerchantInfo/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MerchantInfo>> DeleteMerchantInfo(int id)
        {
            var merchantInfo = await _context.MerchantInfo.FindAsync(id);
            if (merchantInfo == null)
            {
                return NotFound();
            }

            _context.MerchantInfo.Remove(merchantInfo);
            await _context.SaveChangesAsync();

            return merchantInfo;
        }

        private bool MerchantInfoExists(int id)
        {
            return _context.MerchantInfo.Any(e => e.MerchantId == id);
        }
    }
}
