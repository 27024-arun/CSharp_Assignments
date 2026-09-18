using AdvancedConcepts;

namespace Task5
{
    internal static class ProductSorter
    {
        private static readonly List<Product> _products = new List<Product>();

        private delegate int SortDelegate(Product firstProduct, Product secondProduct);

        public static void PerformProductSort()
        {
            Product firstProduct = new Product
            {
                Name = "Headset",
                Category = "Electronics",
                Price = 2000,
            };

            Product secondProduct = new Product
            {
                Name = "Boost",
                Category = "Malt",
                Price = 500,
            };

            _products.Add(firstProduct);
            _products.Add(secondProduct);

            Console.WriteLine($@"
===========Advanced Delegate Usage===========
Default data in the product list" + Environment.NewLine);
            foreach (var product in _products)
            {
                Console.WriteLine($"Name: {product.Name} Category: {product.Category} Price: {product.Price}");
            }

            SortAndDisplay(SortByName, "Name");
            SortAndDisplay(SortByCategory, "Category");
            SortAndDisplay(SortByPrice, "Price");

            Helper.CleanConsole();
        }

        private static void SortAndDisplay(SortDelegate sortDelegate, string sortType)
        {
            _products.Sort((p1, p2) => sortDelegate(p1, p2));
            Console.WriteLine($"\nSorted Data by {sortType}\n");
            foreach (var product in _products)
            {
                Console.WriteLine($"Name: {product.Name} Category: {product.Category} Price: {product.Price}");
            }
        }

        private static int SortByName(Product firstProduct, Product secondProduct)
        {
            return string.Compare(firstProduct.Name, secondProduct.Name, StringComparison.OrdinalIgnoreCase);
        }

        private static int SortByCategory(Product firstProduct, Product secondProduct)
        {
            return string.Compare(firstProduct.Category, secondProduct.Category, StringComparison.OrdinalIgnoreCase);
        }

        private static int SortByPrice(Product firstProduct, Product secondProduct)
        {
            return firstProduct.Price.CompareTo(secondProduct.Price);
        }
    }
}