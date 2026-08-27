using LINQPractices.Model;

namespace LINQPractices
{
    /// <summary>
    /// Performs simple and basic Linq tasks.
    /// </summary>
    internal class BasicLinqTask
    {
        private readonly List<Product> _products = new List<Product>();

        /// <summary>
        /// Initializes a new instance of the <see cref="BasicLinqTask"/> class.
        /// </summary>
        /// <param name="products">Details of the product.</param>
        public BasicLinqTask(List<Product> products)
        {
            this._products = products;
        }

        /// <summary>
        /// Perform linq queries on filtering data.
        /// </summary>
        public void FilterData()
        {
            var filterValue = this._products.
            Where(product => product.Category is ProductCategory.Electronics && product.Price > 500).
            Select(product => new { product.ProductName, product.Price, });
            Console.WriteLine("\nFiltered product list: \n");
            foreach (var value in filterValue)
            {
                Console.WriteLine($"Product Name:{value.ProductName}\nProduct Price:{value.Price}\n");
            }

            var priceFilterValue = filterValue.OrderByDescending(product => product.Price);
            Console.WriteLine("\nProducts in descending order: \n");
            foreach (var value in priceFilterValue)
            {
                Console.WriteLine($"Product Name:{value.ProductName}\nProduct Price:{value.Price}\n");
            }

            int averagePrice = (int)priceFilterValue.Average(product => product.Price);
            Console.WriteLine($"Average: {averagePrice}");

            Console.WriteLine($"Enter any key to return to main menu");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
