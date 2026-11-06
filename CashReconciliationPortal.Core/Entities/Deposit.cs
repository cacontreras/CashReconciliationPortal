namespace CashReconciliationPortal.Core.Entities
{
	public class Deposit
	{
		public int DepositId { get; set; }

		public required string DepositNumber { get; set; }

		public required string StoreNumber { get; set; }

		public decimal ExpectedAmount { get; set; }

		public decimal ActualAmount { get; set; }

		public decimal Variance { get; set; }

		public required string Status { get; set; }

		public DateTime DepositDate { get; set; }
	}
}
