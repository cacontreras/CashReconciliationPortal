using CashReconciliationPortal.BLL.Interfaces;
using CashReconciliationPortal.Core.DTOs;
using CashReconciliationPortal.DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace CashReconciliationPortal.BLL.Services
{
	public class DashboardService : IDashboardService
	{
		private readonly AppDbContext _context;

		public DashboardService(AppDbContext context)
		{
			_context = context;
		}

		public async Task<DashboardMetricsDto> GetMetricsAsync()
		{
			return new DashboardMetricsDto(
				TotalPending: await _context.Deposits.CountAsync(d => d.Status == "Pending"),
				TotalReconciled: await _context.Deposits.CountAsync(d => d.Status == "Balanced"),
				TotalShortages: await _context.Deposits.CountAsync(d => d.Status == "Shortage"),
				TotalOverages: await _context.Deposits.CountAsync(d => d.Status == "Overage"),
				TotalExpectedAmount: await _context.Deposits.SumAsync(d => (decimal?)d.ExpectedAmount) ?? 0,
				TotalActualAmount: await _context.Deposits.SumAsync(d => (decimal?)d.ActualAmount) ?? 0
			);
		}
	}
}
