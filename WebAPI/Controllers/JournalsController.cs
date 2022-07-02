using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JournalsController : ControllerBase
    {
        private readonly JournalContext _context;

        public JournalsController(JournalContext context)
        {
            _context = context;
        }

        // GET: api/Journals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Journal>>> GetJournals()
        {
            return await _context.Journals.ToListAsync();
        }

        // GET: api/Journals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Journal>> GetJournal(Guid id)
        {
            var journal = await _context.Journals.FindAsync(id);

            if (journal == null)
            {
                return NotFound();
            }

            return journal;
        }

        // POST: api/Journals
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Journal>> PostJournal(Journal journal)
        {
            _context.Journals.Add(journal);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetJournal), new { id = journal.Id }, journal);
        }

        // DELETE: api/Journals/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJournal(Guid id)
        {
            var journal = await _context.Journals.FindAsync(id);
            if (journal == null)
            {
                return NotFound();
            }

            _context.Journals.Remove(journal);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool JournalExists(Guid id)
        {
            return _context.Journals.Any(e => e.Id == id);
        }

        [HttpPatch]
        public IActionResult JsonPatchWithModelState([FromBody] JsonPatchDocument<Journal> patchDoc)
        {
            if (patchDoc != null)
            {
                var customer = CreateJournal();

                patchDoc.ApplyTo(customer, ModelState);

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                return new ObjectResult(customer);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        private Journal CreateJournal()
        {
            return new Journal();
        }
    }
}
