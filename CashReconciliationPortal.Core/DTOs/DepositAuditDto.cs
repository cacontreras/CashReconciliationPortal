namespace CashReconciliationPortal.Core.DTOs
{
	public record DepositAuditDto(
		int DepositAuditId,
		int DespositId,
		string OldValues,
		string NewValues,
		string Action,
		DateTime TimeStamp,
		string UserId
	);
}
