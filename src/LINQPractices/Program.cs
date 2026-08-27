using LINQPractices;
using LINQPractices.Helper;
using LINQPractices.Model;

namespace Assignments
{
    /// <summary>
    /// Program class is the entry class.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Main method is the (starting) entry point of the application.
        /// </summary>
        public static void Main()
        {
            ProductAdder productAdder = new ProductAdder();
            List<Product> products = productAdder.AddProduct();
            SupplierAdder supplierAdder = new SupplierAdder();
            List<Supplier> supplier = supplierAdder.AddSupplier();

            BasicLinqTask basicLinqTask = new BasicLinqTask(products);
            ComplexLinqTask complexLinqTask = new ComplexLinqTask(products, supplier);
            ArrayLinqTask arrayLinqTask = new ArrayLinqTask();
            LinqOptimisationTask linqOptimisation = new LinqOptimisationTask(products);
            QueryBuilderTask queryBuilderTask = new QueryBuilderTask(products);

            while (true)
            {
                string mainMenu = $@"
1. Basic Linq Task
2. Complex Liqn Task
3. Array Linq Task
4. Linq Optiminsation Task
5. Query Builder Task
6. Exit
Enter Choice: ";
                Console.Write(mainMenu);
                int.TryParse(Console.ReadLine(), out int userChoice);
                switch (userChoice)
                {
                    case 1:
                        Console.Clear();
                        basicLinqTask.FilterData();
                        break;
                    case 2:
                        Console.Clear();
                        complexLinqTask.GroupData();
                        break;
                    case 3:
                        Console.Clear();
                        arrayLinqTask.ManipulateArray();
                        break;
                    case 4:
                        Console.Clear();
                        linqOptimisation.PerformOptimisationTask();
                        break;
                    case 5:
                        break;
                    case 6:
                        return;
                    default:
                        Console.WriteLine("Invaild Choice\n");
                        break;
                }
            }
        }
    }
}