using CashReconciliationPortal.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace CashReconciliationPortal.DAL.Context
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
		
		public DbSet<Deposit> Deposits { get; set; }
		public DbSet<DepositAudit> DepositAudits { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			var dummyData = Enumerable.Range(1, 25).Select(i => new Deposit
			{ 
				DepositId = i,
				DepositNumber = $"DEP-{DateTime.UtcNow.Year}-{i:D4}",
				StoreNumber = $"STR-{(i % 5) + 1:D3}",
				ExpectedAmount = 1500m + (i * 45.50m),
				ActualAmount = 0m,
				Status = "Pending",
				DepositDate = DateTime.UtcNow.AddDays(-i)
			}).ToArray();

			modelBuilder.Entity<Deposit>().HasData(dummyData);
		}
	}
}
