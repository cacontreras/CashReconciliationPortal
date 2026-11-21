using System.Collections.Frozen;
using System.Linq.Expressions;

namespace CashReconciliationPortal.DAL.Helpers
{
	public sealed class SortingMapBuilder<TEntity>
	{
		private readonly Dictionary<string, Func<IQueryable<TEntity>, bool, IOrderedQueryable<TEntity>>> _columns = new(StringComparer.InvariantCulture);

		public SortingMapBuilder<TEntity> Add<TKey>(string name, Expression<Func<TEntity, TKey>> selector)
		{
			_columns.Add(name, QueryableSortingHelper.CreateOrder(selector));

			return this;
		}

		public SortingMap<TEntity> Build()
		{
			return new SortingMap<TEntity>(_columns.ToFrozenDictionary(StringComparer.OrdinalIgnoreCase));
		}
	}
}
