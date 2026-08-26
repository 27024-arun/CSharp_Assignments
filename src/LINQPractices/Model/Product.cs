namespace LINQPractices.Model
{
    internal class Product
    {
        public Product(string productId, string productName, int price, ProductCategory category)
        {
            this.ProductId = productId;
            this.ProductName = productName;
            this.Price = price;
            this.Category = category;
        }

        public string ProductId { get; set; }

        public string ProductName { get; set; }

        public int Price { get; set; }

        public ProductCategory Category { get; set; }
    }
}
