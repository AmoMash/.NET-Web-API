using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;
using System.Linq;
using System.Threading.Tasks;
using TelemetryAPI_3420.Models;

namespace TelemetryAPI_3420.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TelemetryController : ControllerBase
    {
        private readonly NwutechTrendssContext _context;

        public TelemetryController(NwutechTrendssContext context)
        {
            _context = context;
        }

        // GET: api/Telemetry
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobTelemetry>>> GetJobTelemetries()
        {
            return await _context.JobTelemetries.ToListAsync();
        }

        // GET: api/Telemetry/5
        [HttpGet("{id}")]
        public async Task<ActionResult<JobTelemetry>> GetJobTelemetry(int id)
        {
            var jobTelemetry = await _context.JobTelemetries.FindAsync(id);

            if (jobTelemetry == null)
            {
                return NotFound();
            }

            return jobTelemetry;
        }

        // POST: api/Telemetry
        [HttpPost]
        public async Task<ActionResult<JobTelemetry>> PostJobTelemetry(JobTelemetry jobTelemetry)
        {
            _context.JobTelemetries.Add(jobTelemetry);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetJobTelemetry", new { id = jobTelemetry.Id }, jobTelemetry);
        }

        // PATCH: api/Telemetry/5
        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchJobTelemetry(int id, JobTelemetry jobTelemetry)
        {
            if (id != jobTelemetry.Id)
            {
                return BadRequest();
            }

            _context.Entry(jobTelemetry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobTelemetryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent(); // Return NoContent when the update is successful
        }


        // DELETE: api/Telemetry/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJobTelemetry(int id)
        {
            var jobTelemetry = await _context.JobTelemetries.FindAsync(id);
            if (jobTelemetry == null)
            {
                return NotFound();
            }

            _context.JobTelemetries.Remove(jobTelemetry);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // Private method to check if a telemetry entry exists
        private bool JobTelemetryExists(int id)
        {
            return _context.JobTelemetries.Any(e => e.Id == id);
        }

        /*[HttpGet("GetSavings")]
        public async Task<ActionResult<IEnumerable<SavingsResult>>> GetSavings(
            [FromQuery] DateTime startDate,
            [FromQuery] DateTime endDate,
            [FromQuery] string projectId = null,
            [FromQuery] string clientId = null)
    
        {
            // Validate date range
            if (endDate < startDate)
            {
                return BadRequest("End date must be after start date.");
            }

            // Check if either projectId or clientId is provided
            if (projectId == null && clientId == null)
            {
                return BadRequest("Either projectId or clientId must be provided.");
            }

            // Initialize query
            IQueryable<dynamic> query = null;

            if (projectId != null)
            {
                // Convert projectId to Guid
                if (!Guid.TryParse(projectId, out var projectGuid))
                {
                    return BadRequest("Invalid ProjectId format.");
                }

                // Query Project table by projectId and date range
                query = _context.Projects
                    .Where(p => p.ProjectId == projectGuid && p.ProjectCreationDate >= startDate && p.ProjectCreationDate <= endDate)
                    .GroupBy(p => p.ProjectId)
                    .Select(g => new SavingsResult
                    {
                        Id = g.Key,
                        TimeSavings = g.Sum(p => p.TimeSavings),
                        CostSavings = g.Sum(p => p.CostSavings)
                    });
            }
            else if (clientId != null)
            {
                // Convert clientId to Guid
                if (!Guid.TryParse(clientId, out var clientGuid))
                {
                    return BadRequest("Invalid ClientId format.");
                }

                // Query Client table by clientId and date range
                query = _context.Clients
                    .Where(c => c.ClientId == clientGuid && c.DateOnboarded >= startDate && c.DateOnboarded <= endDate)
                    .GroupBy(c => c.ClientId)
                    .Select(g => new SavingsResult
                    {
                        Id = g.Key,
                        TimeSavings = g.Sum(c => c.TimeSavings),
                        CostSavings = g.Sum(c => c.CostSavings)
                    });
            }


            var savingsResult = await query.ToListAsync();

            if (!savingsResult.Any())
            {
                return NotFound();
            }

            return Ok(savingsResult);
        }
        public class SavingsResult
        {
            public Guid Id { get; set; }
            public double TimeSavings { get; set; }
            public double CostSavings { get; set; }
        }*/
    }
}
