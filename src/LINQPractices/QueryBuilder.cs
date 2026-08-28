using System.Linq.Expressions;

namespace LINQPractices
{
    /// <summary>
    /// Query builder class which helps to perform custom LINQ Queries.
    /// </summary>
    /// <typeparam name="T">Type parameter contains the IQueryable</typeparam>
    public class QueryBuilder<T>
        where T : class
    {
        private IQueryable<T> _list;

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryBuilder{T}"/> class.
        /// </summary>
        /// <param name="list">A list of elements</param>
        public QueryBuilder(IEnumerable<T> list)
        {
            this._list = list.AsQueryable();
        }

        /// <summary>
        /// Filters the collection
        /// </summary>
        /// <param name="condition">Predicate</param>
        /// <returns>returns the predicate</returns>
        public QueryBuilder<T> Filter(Func<T, bool> condition)
        {
            this._list = this._list.Where(condition).AsQueryable();
            return this;
        }

        /// <summary>
        /// Sorts the collection
        /// </summary>
        /// <typeparam name="TKey">Type parameter</typeparam>
        /// <param name="keySelector">Key selector</param>
        /// <returns>A filtered result for sort</returns>
        public QueryBuilder<T> Sort<TKey>(Func<T, TKey> keySelector)
        {
            this._list = this._list.OrderBy(keySelector).AsQueryable();
            return this;
        }

        /// <summary>
        /// Joins the Collection based on common data.
        /// </summary>
        /// <typeparam name="TInner">Type of Inner object.</typeparam>
        /// <typeparam name="TKey">Key Selector for Inner Object.</typeparam>
        /// <typeparam name="TResult">Type of result selector of both inner and outer object.</typeparam>
        /// <param name="inner">Object of </param>
        /// <param name="outerKeySelector">Outer object key selector.</param>
        /// <param name="innerKeySelector">Inner Object key selector.</param>
        /// <param name="resultSelector">Result selector of both inner and outer object.</param>
        /// <returns>Returns the joined object.</returns>
        public QueryBuilder<TResult> Combine<TInner, TKey, TResult>(
            IEnumerable<TInner> inner,
            Expression<Func<T, TKey>> outerKeySelector,
            Expression<Func<TInner, TKey>> innerKeySelector,
            Expression<Func<T, TInner, TResult>> resultSelector)
            where TResult : class
        {
            var joined = this._list.Join(
                inner.AsQueryable(),
                outerKeySelector,
                innerKeySelector,
                resultSelector);

            return new QueryBuilder<TResult>(joined);
        }

        /// <summary>
        /// Executes and materialize the collections.
        /// </summary>
        /// <returns>A materialized collection</returns>
        public List<T> Execute()
        {
            return this._list.ToList();
        }
    }
}