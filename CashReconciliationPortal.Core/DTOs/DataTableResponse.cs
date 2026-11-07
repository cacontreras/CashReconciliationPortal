namespace CashReconciliationPortal.Core.DTOs
{
	public record DataTableResponse<T>(
		int Draw,
		int RecordsTotal,
		int RecordsFiltered,
		IEnumerable<T> Data
	);
}
