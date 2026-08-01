using BuySellBeater.Api.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BuySellBeater.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MakesController : ControllerBase
    {
        private readonly BuySellBeaterDBContext _context;

        public MakesController(BuySellBeaterDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MakeDto>>> GetMakes()
        {
            var makes = await _context.Makes
                .Include(m => m.Models)
                .AsNoTracking()
                .Select(m => new MakeDto
                {
                    Id = m.Id,
                    Name = m.Name,
                    Models = m.Models.Select(x => new ModelDto
                    {
                        Id = x.Id,
                        Name = x.Name
                    }).ToList()
                })
                .ToListAsync();

            return Ok(makes);
        }
    }

    public class MakeDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<ModelDto> Models { get; set; } = new();
    }

    public class ModelDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
