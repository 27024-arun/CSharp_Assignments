using LINQPractices.Model;

namespace LINQPractices
{
    internal class ComplexLinqTask
    {
        private readonly List<Product> _products;

        public ComplexLinqTask(List<Product> products)
        {
            this._products = products;
        }

        internal void GroupData()
        {
            var groupedData = this._products.GroupBy(product => product.Category);
            foreach (var groups in groupedData)
            {
                Console.WriteLine($"Group Category: {groups.Key}");
                foreach (var value in groups)
                {
                    Console.WriteLine($"\nProduct Id: {value.ProductId}\nProduct Name: {value.ProductName}\nProduct Price: {value.Price}\n");
                }
            }
        }
    }
}
