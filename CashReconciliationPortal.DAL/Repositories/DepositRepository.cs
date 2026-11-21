using System.Linq.Expressions;
using CashReconciliationPortal.Core.DTOs;
using CashReconciliationPortal.Core.Entities;
using CashReconciliationPortal.DAL.Context;
using CashReconciliationPortal.DAL.Helpers;
using CashReconciliationPortal.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CashReconciliationPortal.DAL.Repositories
{
	public class DepositRepository : IDepositRepository
	{
		private readonly AppDbContext _context;

		private static readonly SortingMap<Deposit> SortColumns = new SortingMap<Deposit>()
			.Add(DepositsDataTableConstants.DepositNumber, d => d.DepositNumber)
			.Add(DepositsDataTableConstants.ExpectedAmount, d => d.ExpectedAmount)
			.Add(DepositsDataTableConstants.ActualAmount, d => d.ActualAmount)
			.Add(DepositsDataTableConstants.Status, d => d.Status);

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

		public async Task<(int TotalRecords, int FilteredRecords, IEnumerable<Deposit> Data)> GetPagedDepositsAsync(string searchValue, string sortColumn, bool sortDescending, int skip, int take)
		{
			// 1. Iniciamos la consulta sin ejecutarla en BD todavía
			var query = _context.Deposits.AsNoTracking().AsQueryable();

			// 2. Obtenemos el total de registros en la tabla (antes de filtrar)
			int totalRecords = await query.CountAsync();

			// 3. Aplicamos el filtro de búsqueda si el usuario escribió algo
			if (!string.IsNullOrWhiteSpace(searchValue))
			{
				// Ajusta las propiedades por las que quieras permitir que el usuario busque
				query = query.Where(d =>
					 d.DepositNumber.Contains(searchValue) ||
					 d.Status.Contains(searchValue));
			}

			// Obtenemos el total de registros que coinciden con la búsqueda
			int filteredRecords = await query.CountAsync();

			// 4. Ordenamiento Dinámico
			var orderedQuery = SortColumns.Apply(query, sortColumn, sortDescending, DepositsDataTableConstants.DepositNumber).ThenBy(d => d.DepositId);

			// 5. Aplicamos la Paginación del lado del servidor (El verdadero jefe final)
			//var data = await query.Skip(skip).Take(take).ToListAsync();
			var data = await orderedQuery.Skip(skip).Take(take).ToListAsync();

			return (totalRecords, filteredRecords, data);
		}
	}

	public static class DepositsDataTableConstants
	{
		public const int DefaultPageSize = 5;

		public const int MaxPageSize = 20;

		public const string DepositNumber = "depositNumber";

		public const string ExpectedAmount = "expectedAmount";

		public const string ActualAmount = "actualAmount";

		public const string Status = "status";
	}
}
