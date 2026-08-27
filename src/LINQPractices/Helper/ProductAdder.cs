using LINQPractices.Model;

namespace LINQPractices
{
    /// <summary>
    /// Helps to perform population of products.
    /// </summary>
    internal class ProductAdder
    {
        /// <summary>
        /// AddProduct method is used to populate product list and returns the populated list.
        /// </summary>
        /// <returns>Product list.</returns>
        public List<Product> AddProduct()
        {
            List<Product> products = new List<Product>();
            products.Add(new Product(100, "Headset", 1500, ProductCategory.Electronics));
            products.Add(new Product(101, "Shampoo", 100, ProductCategory.Cosmetics));
            products.Add(new Product(102, "Knife", 1500, ProductCategory.Utensils));
            products.Add(new Product(103, "Bandage", 20, ProductCategory.Medicine));
            products.Add(new Product(104, "Frypan", 3700, ProductCategory.Utensils));
            products.Add(new Product(105, "Spatula", 450, ProductCategory.Utensils));
            products.Add(new Product(106, "Cookies", 600, ProductCategory.Snacks));
            products.Add(new Product(107, "Waterbottle", 850, ProductCategory.Utensils));
            products.Add(new Product(108, "Monitor", 14500, ProductCategory.Electronics));
            products.Add(new Product(109, "Paracetamol Strip", 120, ProductCategory.Medicine));
            products.Add(new Product(110, "Chips", 1200, ProductCategory.Snacks));
            products.Add(new Product(111, "Perfume", 2500, ProductCategory.Cosmetics));
            products.Add(new Product(112, "Chocolate", 1500, ProductCategory.Snacks));
            products.Add(new Product(113, "Toaster", 5000, ProductCategory.Electronics));
            products.Add(new Product(114, "Mouse", 500, ProductCategory.Electronics));
            products.Add(new Product(115, "Soap", 200, ProductCategory.Cosmetics));
            products.Add(new Product(116, "Harry Potter", 1600, ProductCategory.Books));
            products.Add(new Product(117, "Happiness in Sadness", 700, ProductCategory.Books));
            products.Add(new Product(118, "Will of wills", 1350, ProductCategory.Books));
            products.Add(new Product(119, "Shaolin Days", 2600, ProductCategory.Books));
            products.Add(new Product(120, "DC Comics", 400, ProductCategory.Books));
            return products;
        }
    }
}
