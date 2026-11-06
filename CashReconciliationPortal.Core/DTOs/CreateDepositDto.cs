namespace CashReconciliationPortal.Core.DTOs
{
	public record CreateDepositDto(
		string DepositNumber,
		string StoreNumber,
		decimal ExpectedAmount
	);
}
