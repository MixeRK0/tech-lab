using System;
using Microsoft.AspNetCore.Mvc;
using NewWebApp.Models;
using System.Threading.Tasks;
using NewWebApp.Analysis;

namespace NewWebApp.Controllers
{
	[Route("/analyse")]
	public class HomeController : Controller
	{
		[Route("synt")]
		[HttpPost]
		public IActionResult Create([FromBody] TextModel textModel)
		{
			var result = TextAnalyser.Analyse(textModel.text);
			return Ok(result);
		}
	}
}
