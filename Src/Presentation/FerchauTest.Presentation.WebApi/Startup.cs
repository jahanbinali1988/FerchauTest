using FerchauTest.Persistence.EntityFramework.Persistence;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using FerchauTest.Shared.Shared;
using Microsoft.EntityFrameworkCore;
using FerchauTest.Presentation.WebApi.Extensions;

namespace FerchauTest.Presentation.WebApi
{
	public class Startup
	{
		private readonly IWebHostEnvironment _env;
		public IConfiguration Configuration { get; }
		public Startup(IConfiguration configuration, IWebHostEnvironment env)
		{
			_env = env;
			Configuration = configuration;
		}

		public void ConfigureServices(IServiceCollection services)
		{

			services.AddServices(Configuration, _env);

			services.AddControllers()
			   .AddJsonOptions(c =>
			   {
				   c.JsonSerializerOptions.Converters.Add(new CustomLongToStringConverter());
			   });

			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "Sample", Version = "v1" });
			});

			services.AddCors(p => p.AddPolicy("corsapp", builder =>
			{
				builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
			}));
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			//using (var scope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
			//{
			//	scope.ServiceProvider.GetRequiredService<FerchauDbContext>().Database.Migrate();
			//}
			if (_env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseSwagger();
				app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Sample v1"));
			}

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseCors("corsapp");

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
