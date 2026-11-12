namespace CashReconciliationPortal.Core.DTOs
{
	public record DataTableRequest(
		int Draw,
		int Start,
		int Length,
		DtSearch Search,
		List<DtOrder> Order,
		List<DtColumn> Columns
	);

	public record DtSearch(string Value, bool Regex);

	public record DtOrder(int Column, string Dir);

	public record DtColumn(string? Data, string Name, bool Searchable, bool Orderable, DtSearch Search);
}
