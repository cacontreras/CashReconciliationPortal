namespace CashReconciliationPortal.Core.DTOs
{
	public record DepositDto(
		int DepositId,
		string DepositNumber,
		string StoreNumber,
		decimal ExpectedAmount,
		decimal ActualAmount,
		decimal Variance,
		string Status,
		DateTime DepositDate
	);
}
