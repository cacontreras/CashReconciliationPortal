namespace CashReconciliationPortal.Core.Entities
{
	public class DepositAudit
	{
		public int DepositAuditId { get; set; }

		public int DespositId { get; set; }

		public required string OldValues { get; set; }

		public required string NewValues { get; set; }

		public required string Action { get; set; }

		public DateTime TimeStamp { get; set; }

		public required string UserId { get; set; }
	}
}
