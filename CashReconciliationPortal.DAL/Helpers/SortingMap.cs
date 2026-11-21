using System.Linq.Expressions;

namespace CashReconciliationPortal.DAL.Helpers
{
	public sealed class SortingMap<TEntity>
	{
		private readonly Dictionary<string, Func<IQueryable<TEntity>, bool, IOrderedQueryable<TEntity>>> _columns = new(StringComparer.OrdinalIgnoreCase);

		public SortingMap<TEntity> Add<TKey>(string name, Expression<Func<TEntity, TKey>> selector)
		{
			_columns.Add(name, QueryableSortingHelper.CreateOrder(selector));
			return this;
		}

		public IOrderedQueryable<TEntity> Apply(IQueryable<TEntity> query, string column, bool descending, string defaultColumn)
		{
			if (!_columns.TryGetValue(column, out var orderBy))
				orderBy = _columns[defaultColumn];

			return orderBy(query, descending);
		}
	}
}
