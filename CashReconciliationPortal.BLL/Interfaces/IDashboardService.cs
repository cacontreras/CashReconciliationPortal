using CashReconciliationPortal.Core.DTOs;

namespace CashReconciliationPortal.BLL.Interfaces
{
	public interface IDashboardService
	{
		Task<DashboardMetricsDto> GetMetricsAsync();
	}
}
