namespace CashReconciliationPortal.Core.DTOs
{
	public record ReconcileDepositDto(
		int DepositId,
		decimal ActualAmount,
		string UserId
	);
}
