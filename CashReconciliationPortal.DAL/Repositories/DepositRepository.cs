using CashReconciliationPortal.Core.Entities;
using CashReconciliationPortal.DAL.Context;
using CashReconciliationPortal.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CashReconciliationPortal.DAL.Repositories
{
	public class DepositRepository : IDepositRepository
	{
		private readonly AppDbContext _context;

		public DepositRepository(AppDbContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<Deposit>> GetAllAsync()
		{
			return await _context.Deposits.ToListAsync();
		}

		public async Task<Deposit?> GetByIdAsync(int id)
		{
			return await _context.Deposits.FindAsync(id);
		}

		public async Task AddAsync(Deposit deposit)
		{
			await _context.Deposits.AddAsync(deposit);
			await _context.SaveChangesAsync();
		}

		public async Task UpdateAsync(Deposit deposit)
		{
			_context.Deposits.Update(deposit);
			await _context.SaveChangesAsync();
		}

		public async Task AddAuditAsync(DepositAudit audit)
		{
			await _context.DepositAudits.AddAsync(audit);
			await _context.SaveChangesAsync();
		}

		public async Task<IEnumerable<DepositAudit>> GetAuditTrailAsync(int depositId)
		{
			return await _context.DepositAudits
				.Where(a => a.DespositId == depositId)
				.OrderByDescending(a => a.TimeStamp)
				.ToListAsync();
		}
	}
}
