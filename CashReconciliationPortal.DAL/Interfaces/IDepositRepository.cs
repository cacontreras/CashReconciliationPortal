using CashReconciliationPortal.Core.DTOs;
using CashReconciliationPortal.Core.Entities;

namespace CashReconciliationPortal.DAL.Interfaces
{
	public interface IDepositRepository
	{
		Task<IEnumerable<Deposit>> GetAllAsync();

		Task<Deposit?> GetByIdAsync(int id);

		Task AddAsync(Deposit deposit);

		Task UpdateAsync(Deposit deposit);

		Task AddAuditAsync(DepositAudit audit);

		Task<IEnumerable<DepositAudit>> GetAuditTrailAsync(int depositId);

		Task<(int TotalRecords, int FilteredRecords, IEnumerable<Deposit> Data)> GetPagedDepositsAsync(
			string searchValue,
			string sortColumn,
			string sortDirection,
			int skip,
			int take
		);
	}
}
