using LINQPractices.Model;

namespace LINQPractices
{
    /// <summary>
    /// Peforms the creation and operation in QueryBuilder..
    /// </summary>
    internal class QueryBuilderTask
    {
        private readonly List<Product> _products;
        private readonly List<Supplier> _supplier;

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryBuilderTask"/> class.
        /// </summary>
        /// <param name="products">Details of the product.</param>
        /// <param name="supplier">Details of the Supplier.</param>
        public QueryBuilderTask(List<Product> products, List<Supplier> supplier)
        {
            this._products = products;
            this._supplier = supplier;
        }

        /// <summary>
        /// Custom class QueryBuilder LINQ query methods are accessed and performed.
        /// </summary>
        public void PeformQueryAction()
        {
            var filteredProduct = new QueryBuilder<Product>(this._products)
                .Filter(product => product.Category == ProductCategory.Electronics)
                .Sort(product => product.Price)
                .Execute();
            Console.WriteLine($"\nFiltered Products: \n");
            foreach (var product in filteredProduct)
            {
                Console.WriteLine($"Product Name: {product.ProductName}\nPrice: {product.Price}\n");
            }

            var joinedProduct = new QueryBuilder<Product>(this._products).Combine(
                this._supplier,
                product => product.ProductId,
                supplier => supplier.ProductId,
                (product, supplier) => new
                {
                    ProductName = product.ProductName,
                    SupplierName = supplier.SupplierName,
                }).Execute();

            Console.WriteLine($"\nJoined Query Result: \n");
            foreach (var product in joinedProduct)
            {
                Console.WriteLine($"Product Name: {product.ProductName}\nSupplier Name: {product.SupplierName}\n");
            }

            Console.WriteLine($"Enter any key to return to main menu");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
