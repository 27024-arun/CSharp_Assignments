namespace LINQPractices.Model
{
    internal class Product
    {
        public Product(int productId, string productName, int price, ProductCategory category)
        {
            this.ProductId = productId;
            this.ProductName = productName;
            this.Price = price;
            this.Category = category;
        }

        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public int Price { get; set; }

        public ProductCategory Category { get; set; }
    }
}
