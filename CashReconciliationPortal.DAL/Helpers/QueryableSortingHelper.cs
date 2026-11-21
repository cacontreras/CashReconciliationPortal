using System.Linq.Expressions;
using System.Windows.Markup;

namespace CashReconciliationPortal.DAL.Helpers
{
	public static class QueryableSortingHelper
	{
		public static Func<IQueryable<TEntity>, bool, IOrderedQueryable<TEntity>> CreateOrder<TEntity, TKey>(Expression<Func<TEntity, TKey>> selector)
		{
			return (query, descending) => descending ? query.OrderByDescending(selector) : query.OrderBy(selector);
		}
	}
}
