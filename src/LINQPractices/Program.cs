using LINQPractices;
using LINQPractices.Helper;
using LINQPractices.Model;

namespace Assignments
{
    internal class Program
    {
        public static void Main()
        {
            ProductAdder productAdder = new ProductAdder();
            List<Product> products = productAdder.Add();
            SupplierAdder supplierAdder = new SupplierAdder();
            List<Supplier> supplier = supplierAdder.AddSupplier();

            BasicLinqTask basicLinqTask = new BasicLinqTask(products);
            // basicLinqTask.FilterData();

            ComplexLinqTask complexLinqTask = new ComplexLinqTask(products);
            complexLinqTask.GroupData();
            Console.ReadKey();
        }
    }
}