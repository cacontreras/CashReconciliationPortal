using System.Collections.Frozen;

namespace CashReconciliationPortal.DAL.Helpers
{
	public sealed class SortingMap<TEntity>
	{
		private readonly FrozenDictionary<string, Func<IQueryable<TEntity>, bool, IOrderedQueryable<TEntity>>> _columns;

		internal SortingMap(FrozenDictionary<string, Func<IQueryable<TEntity>, bool, IOrderedQueryable<TEntity>>> columns)
		{
			_columns = columns;
		}

		public IOrderedQueryable<TEntity> Apply(IQueryable<TEntity> query, string column, bool descending, string defaultColumn)
		{
			if (!_columns.TryGetValue(column, out var orderBy))
				orderBy = _columns[defaultColumn];

			return orderBy(query, descending);
		}
	}
}
