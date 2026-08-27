using LINQPractices.Model;

namespace LINQPractices
{
    /// <summary>
    /// Peforms the creation and operation in QueryBuilder..
    /// </summary>
    internal class QueryBuilderTask
    {
        private readonly List<Product> _products;

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryBuilderTask"/> class.
        /// </summary>
        /// <param name="products">Details of the product.</param>
        public QueryBuilderTask(List<Product> products)
        {
            this._products = products;
        }
    }
}
