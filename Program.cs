using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NewWebApp.Database;

namespace NewWebApp
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var host = CreateHostBuilder(args).Build();

			using (var scope = host.Services.CreateScope())
			{
				var dbContext = scope.ServiceProvider.GetRequiredService<CalculationContext>();
				ApplyMigrations(dbContext);
			}

			host.Run();
		}

		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.ConfigureWebHostDefaults(webBuilder =>
				{
					webBuilder.UseStartup<Startup>();
				});

		private static void ApplyMigrations(CalculationContext context)
		{
			if (context.Database.GetPendingMigrations().Any())
			{
				context.Database.Migrate();
			}
		}
	}
}
