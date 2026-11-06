namespace CashReconciliationPortal.Core.DTOs
{
	public record DashboardMetricsDto(
		int TotalPending,
		int TotalReconciled,
		int TotalShortages,
		int TotalOverages,
		decimal TotalExpectedAmount,
		decimal TotalActualAmount
	);
}
