using Inventory_Management.Model;
using Inventory_Management.Services;

namespace Assignments
{
    /// <summary>
    /// Program Class is the entry point of the program (It is the view level of the program)
    /// </summary>
    internal class Program
    {
        private static InventoryServices _service = new InventoryServices();

        /// <summary>
        /// InventoryMenu is a enum.
        /// </summary>
        internal enum InventoryMenu
        {
            /// <summary>
            /// AddProduct is a enum value assigned with value 1.
            /// </summary>
            AddProduct = 1,

            /// <summary>
            /// ViewProduct is a enum value assigned with value 2.
            /// </summary>
            ViewProducts = 2,

            /// <summary>
            /// SearchProduct is a enum value assigned with value 3.
            /// </summary>
            SearchProduct = 3,

            /// <summary>
            /// UpdateProduct is a enum value assigned with value 4.
            /// </summary>
            UpdateProduct = 4,

            /// <summary>
            /// DeleteProduct is a enum value assigned with value 5.
            /// </summary>
            DeleteProduct = 5,

            /// <summary>
            /// Exit is a enum value assigned with value 6.
            /// </summary>
            Exit = 6,
        }

        /// <summary>
        /// Main method is the entry point of the program.
        /// </summary>
        public static void Main()
        {
            while (true)
            {
                string inventoryMenu = $@"
Inventory Manager
1. Add Product
2. View Products
3. Search Product
4. Update Product
5. Delete Product
6. Exit
Enter Choice:";
                Console.WriteLine(inventoryMenu);
                try
                {
                    int choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case (int)InventoryMenu.AddProduct:
                            AddProduct();
                            break;

                        case (int)InventoryMenu.ViewProducts:
                            ViewProducts();
                            break;

                        case (int)InventoryMenu.SearchProduct:
                            SearchProduct();
                            break;

                        case (int)InventoryMenu.UpdateProduct:
                            UpdateProduct();
                            break;

                        case (int)InventoryMenu.DeleteProduct:
                            DeleteProduct();
                            break;

                        case (int)InventoryMenu.Exit:
                            Helper.WriteColored("Exiting...", ConsoleColor.Red);
                            Thread.Sleep(1000);
                            return;

                        default:
                            Console.WriteLine("Invalid Choice.");
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid Input. Please enter numeric value.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error:" + ex.Message);
                }
            }
        }

        private static void DeleteProduct()
        {
            Console.Write("Enter Product ID: ");
            int deleteId = Convert.ToInt32(Console.ReadLine());

            if (_service.DeleteProduct(deleteId))
            {
                Console.WriteLine("Product Deleted.");
            }
            else
            {
                Console.WriteLine("Product Not Found.");
            }
        }

        private static void UpdateProduct()
        {
            InventoryModel update = new InventoryModel();

            Console.Write("Enter Product ID : ");
            update.ProductID = Convert.ToInt32(Console.ReadLine());

            Console.Write("New Name: ");
            update.ProductName = Console.ReadLine();

            Console.Write("New Price: ");
            update.Price = Convert.ToDecimal(Console.ReadLine());

            Console.Write("New Quantity: ");
            update.Quantity = Convert.ToInt32(Console.ReadLine());

            if (_service.UpdateProduct(update))
            {
                Console.WriteLine("Product Updated.");
            }
            else
            {
                Console.WriteLine("Product Not Found.");
            }
        }

        private static void SearchProduct()
        {
            Console.Write("Enter Product Name or ID: ");
            string? input = Console.ReadLine()?.Trim();

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Invalid input. Please enter a product name or ID.");
                return;
            }

            if (int.TryParse(input, out int id))
            {
                var item = _service.SearchById(id);

                if (item == null)
                {
                    Console.WriteLine("Product Not Found.");
                }
                else
                {
                    Console.WriteLine("ID\tName\tPrice\tQuantity");
                    Console.WriteLine($"{item.ProductID}\t{item.ProductName}\t{item.Price}\t{item.Quantity}");
                }
            }
            else
            {
                var results = _service.SearchByName(input);

                if (results == null || results.Count == 0)
                {
                    Console.WriteLine("No Product Found.");
                }
                else
                {
                    Console.WriteLine("ID\tName\tPrice\tQuantity");
                    foreach (var p in results)
                    {
                        Console.WriteLine($"{p.ProductID}\t{p.ProductName}\t{p.Price}\t{p.Quantity}");
                    }
                }
            }
        }

        private static void ViewProducts()
        {
            var products = _service.GetProducts();

            if (products.Count == 0)
            {
                Console.WriteLine("No Products Available.");
            }
            else
            {
                Console.WriteLine("ID\tName\tPrice\tQuantity");

                foreach (var p in products)
                {
                    Console.WriteLine($"{p.ProductID}\t{p.ProductName}\t{p.Price}\t{p.Quantity}");
                }
            }
        }

        private static void AddProduct()
        {
            InventoryModel product = new InventoryModel();

            Console.Write("Product ID: ");
            product.ProductID = Convert.ToInt32(Console.ReadLine());

            Console.Write("Product Name: ");
            product.ProductName = Console.ReadLine();

            Console.Write("Price: ");
            product.Price = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Quantity: ");
            product.Quantity = Convert.ToInt32(Console.ReadLine());

            if (_service.AddProduct(product))
            {
                Console.WriteLine("Product Added Successfully.");
            }
            else
            {
                Console.WriteLine("Product ID already exists.");
            }
        }
    }
}