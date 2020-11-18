using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NewWebApp.Models;
using System.Diagnostics;
using System.Threading.Tasks;
using NewWebApp.Database;
using NewWebApp.Database.Models;

namespace NewWebApp.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly CalculationContext _dbContext;

		public HomeController(ILogger<HomeController> logger, CalculationContext dbContext)
		{
			_logger = logger;
			_dbContext = dbContext;
		}

		[HttpPost]
		public async Task<IActionResult> Result([FromQuery]int userId, string text)
		{
			var result = new Result() {UserId = 1, Data = text};

			_dbContext.Results.Add(result);
			// _dbContext.Results.Add(new Result() { UserId = userId, Data = text });
			await _dbContext.SaveChangesAsync();
			return Ok(result);
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
