using System.Diagnostics;
using LINQPractices.Model;

namespace LINQPractices
{
    internal class LinqOptimisationTask
    {
        private readonly List<Product> _products;

        public LinqOptimisationTask(List<Product> products)
        {
            this._products = products;
        }

        public void PerformOptimisationTask()
        {
            Stopwatch stopWatch = new Stopwatch();

            Console.WriteLine($"Result in Unoptimised query:");
            stopWatch.Start();
            var filteredProducts = this._products.OrderBy(product => product.Price).Where(product => product.Category == ProductCategory.Books);
            foreach (var product in filteredProducts)
            {
                Console.WriteLine($"Product Name: {product.ProductName}     Price: {product.Price}");
            }

            stopWatch.Stop();
            Console.WriteLine($"Time taken for Unoptimised query: {stopWatch.ElapsedMilliseconds} ms");
            Console.WriteLine($"Time taken for Unoptimised query: {stopWatch.ElapsedTicks} ticks\n");


            Console.WriteLine($"Result in Optimised query:");
            stopWatch.Restart();
            var optimisedFilteredProducts = this._products.Where(product => product.Category == ProductCategory.Books).OrderBy(product => product.Price);
            foreach (var product in optimisedFilteredProducts)
            {
                Console.WriteLine($"Product Name: {product.ProductName}     Price: {product.Price}");
            }

            stopWatch.Stop();
            Console.WriteLine($"Time taken for Optimised query: {stopWatch.ElapsedMilliseconds} ms");
            Console.WriteLine($"Time taken for Unoptimised query: {stopWatch.ElapsedTicks} ticks\n");

            Console.WriteLine($"Enter any key to return to main menu");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
