
using Microsoft.EntityFrameworkCore;

namespace CashReconciliationPortal.API
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			builder.Services.AddDbContext<CashReconciliationPortal.DAL.Context.AppDbContext>(options =>
			options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

			builder.Services.AddScoped<CashReconciliationPortal.DAL.Interfaces.IDepositRepository, CashReconciliationPortal.DAL.Repositories.DepositRepository>();
			builder.Services.AddScoped<CashReconciliationPortal.BLL.Interfaces.IDepositService, CashReconciliationPortal.BLL.Services.DepositService>();
			builder.Services.AddScoped<CashReconciliationPortal.BLL.Interfaces.IDashboardService, CashReconciliationPortal.BLL.Services.DashboardService>();

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseDefaultFiles();

			app.UseStaticFiles();

			app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}
	}
}
