using CashReconciliationPortal.Core.DTOs;
using CashReconciliationPortal.Core.Entities;

namespace CashReconciliationPortal.BLL.Interfaces
{
	public interface IDepositService
	{
		Task<IEnumerable<Deposit>> GetAllDepositsAsync();

		Task<Deposit?> GetDepositByIdAsync(int id);

		Task<Deposit> RegisterDepositAsync(CreateDepositDto depositDto, string userId);

		Task<Deposit> ReconcileDepositAsync(ReconcileDepositDto reconcileDto);

		Task<IEnumerable<DepositAuditDto>> GetAuditTrailAsync(int depositId);
	}
}
