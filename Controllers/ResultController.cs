using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewWebApp.Database;
using NewWebApp.Database.Models;
using NewWebApp.Models;

namespace NewWebApp.Controllers
{
    [Route("/results")]
    public class ResultController : BaseController
    {
        private readonly CalculationContext _db;

        public ResultController(
            CalculationContext db
        )
        {
            _db = db;
        }

        [Route("create")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Result result)
        {
            _db.Results.Add(result);
            await _db.SaveChangesAsync();
            
            return new ObjectResult(result);
        }

        [Route("list")]
        [HttpGet]
        public IActionResult List(
            [FromQuery] PaginationParameterModel pagination = null,
            [FromQuery] string sortBy = null)
        {
            var results = (from result in _db.Results select result).AsEnumerable();
            
            return new ObjectResult(Pagination(results, pagination));
        }
        
        [Route("get")]
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] int? id)
        {
            if (id == null) return BadRequest("id = null");

            var result = await _db.Results.FirstOrDefaultAsync(r => r.Id == id);

            return Ok(result);
        }
        
        [Route("delete")]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int? id)
        {
            if (id == null) return BadRequest("id = null");

            var result = await _db.Results.FirstOrDefaultAsync(r => r.Id == id);
            _db.Results.Remove(result);
            await _db.SaveChangesAsync();

            return Ok();
        }
    }
}
