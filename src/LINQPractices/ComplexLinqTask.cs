using LINQPractices.Model;

namespace LINQPractices
{
    /// <summary>
    /// Performs complex Linq tasks.
    /// </summary>
    internal class ComplexLinqTask
    {
        private readonly List<Product> _products;
        private readonly List<Supplier> _suppliers;

        /// <summary>
        /// Initializes a new instance of the <see cref="ComplexLinqTask"/> class.
        /// </summary>
        /// <param name="products">Details of the product.</param>
        /// <param name="suppliers">Details of the supplier.</param>
        public ComplexLinqTask(List<Product> products, List<Supplier> suppliers)
        {
            this._products = products;
            this._suppliers = suppliers;
        }

        /// <summary>
        /// Performs LINQ queries for grouping and joining the product and supplier data.
        /// </summary>
        internal void GroupData()
        {
            var groupedData = this._products.OrderBy(product => product.Price).GroupBy(product => product.Category);
            foreach (var groups in groupedData)
            {
                Console.WriteLine($"=================================\nGroup Category: {groups.Key}");
                foreach (var value in groups)
                {
                    Console.WriteLine($"\nProduct Name: {value.ProductName}\nProduct Price: {value.Price}");
                }
            }

            var joinResult = this._products.Join(
                this._suppliers,
                product => product.ProductId,
                supplier => supplier.ProductId,
                (product, supplier) => new
                {
                    ProductName = product.ProductName,
                    SupplierName = supplier.SupplierName,
                });

            foreach (var result in joinResult)
            {
                Console.WriteLine($"Product Name: {result.ProductName}      Supplier Name: {result.SupplierName}\n");
            }

            Console.WriteLine($"Enter any key to return to main menu");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
