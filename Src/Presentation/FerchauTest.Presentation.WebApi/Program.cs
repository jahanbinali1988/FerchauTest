using System.Diagnostics;

namespace FerchauTest.Presentation.WebApi
{
	public class Program
	{
		public static void Main(string[] args)
		{
			try
			{
				CreateHostBuilder(args).Build().Run();
			}
			catch (Exception ex)
			{
				Debugger.Break();
			}
		}

		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
		.ConfigureWebHostDefaults(webBuilder =>
		{
			webBuilder.UseStartup<Startup>();
		});
	}
}