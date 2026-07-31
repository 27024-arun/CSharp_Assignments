using Inventory_Management.Model;
using Inventory_Management.Services;

namespace Inventory_View
{
    /// <summary>
    /// Program Class is the entry point of the program (It is the view level of the program).
    /// </summary>
    internal class Program
    {
        private static readonly InventoryServices _service = new InventoryServices();

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
Enter Choice: ";
                Console.Write(inventoryMenu);
                try
                {
                    int choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case (int)InventoryModel.InventoryMenu.AddProduct:
                            AddProduct();
                            break;

                        case (int)InventoryModel.InventoryMenu.ViewProducts:
                            ViewProducts();
                            break;

                        case (int)InventoryModel.InventoryMenu.SearchProduct:
                            SearchProduct();
                            break;

                        case (int)InventoryModel.InventoryMenu.UpdateProduct:
                            UpdateProduct();
                            break;

                        case (int)InventoryModel.InventoryMenu.DeleteProduct:
                            DeleteProduct();
                            break;

                        case (int)InventoryModel.InventoryMenu.Exit:
                            Helper.WriteColored("Exiting...", ConsoleColor.Cyan);
                            Thread.Sleep(1000);
                            return;

                        default:
                            Helper.WriteColored("Invalid Choice.", ConsoleColor.Red);
                            break;
                    }
                }
                catch (FormatException)
                {
                    Helper.WriteColored("Invalid Input. Please enter numeric value.", ConsoleColor.Red);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error:" + ex.Message);
                }
            }
        }

        private static void DeleteProduct()
        {
            if (_service.InventoryIsEmpty())
            {
                Helper.WriteColored("Inventory is empty.", ConsoleColor.Red);
                return;
            }

            Console.Write("Enter Product ID: ");
            int deleteId = Convert.ToInt32(Console.ReadLine());

            if (_service.DeleteProduct(deleteId))
            {
                Helper.WriteColored("Product Deleted.", ConsoleColor.Green);
            }
            else
            {
                Helper.WriteColored("Product Not Found.", ConsoleColor.Red);
            }
        }

        private static void UpdateProduct()
        {
            if (_service.InventoryIsEmpty())
            {
                Helper.WriteColored("Inventory is empty.", ConsoleColor.Red);
                return;
            }

            InventoryModel update = new InventoryModel();

            update.ProductID = Helper.GetIntData("Product ID");
            if (update.ProductID == 0 || !_service.IsProductAvailable(update.ProductID))
            {
                Helper.WriteColored("Id is Invalid\nReturning to main menu...", ConsoleColor.Yellow);
                return;
            }

            update.ProductName = Helper.GetStringData("New Product Name");
            if (update.ProductName == string.Empty)
            {
                Helper.WriteColored("Returning to main menu...", ConsoleColor.Yellow);
                return;
            }

            update.Price = Helper.GetDecimalData("New Price");
            if (update.Price == 0)
            {
                Helper.WriteColored("Returning to main menu...", ConsoleColor.Yellow);
                return;
            }

            update.Quantity = Helper.GetIntData("New Quantity");
            if (update.Quantity == 0)
            {
                Helper.WriteColored("Returning to main menu...", ConsoleColor.Yellow);
                return;
            }

            if (_service.UpdateProduct(update))
            {
                Helper.WriteColored("Product Updated.", ConsoleColor.Green);
            }
            else
            {
                Helper.WriteColored("Product Not Found.", ConsoleColor.Red);
            }
        }

        private static void SearchProduct()
        {
            if (_service.InventoryIsEmpty())
            {
                Helper.WriteColored("Inventory is empty.", ConsoleColor.Red);
                return;
            }

            Console.Write("Enter Product Name or ID: ");
            string? input = Console.ReadLine()?.Trim();

            if (string.IsNullOrWhiteSpace(input))
            {
                Helper.WriteColored("Invalid input. Please enter a product name or ID.", ConsoleColor.Red);
                return;
            }

            if (int.TryParse(input, out int id))
            {
                var item = _service.SearchById(id);

                if (item == null)
                {
                    Helper.WriteColored("Product Not Found.", ConsoleColor.Red);
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
                    Helper.WriteColored("No Products Found.", ConsoleColor.Red);
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
            if (_service.InventoryIsEmpty())
            {
                Helper.WriteColored("Inventory is empty.", ConsoleColor.Red);
                return;
            }

            var products = _service.GetProducts();

            if (products.Count == 0)
            {
                Helper.WriteColored("No Products Available.", ConsoleColor.Red);
            }
            else
            {
                Helper.PrintingTable(products);
            }
        }

        private static void AddProduct()
        {
            InventoryModel product = new InventoryModel();

            product.ProductID = Helper.GetIntData("Product ID");
            if (product.ProductID == 0)
            {
                Helper.WriteColored("Returning to main menu...", ConsoleColor.Yellow);
                return;
            }

            string productName = Helper.GetStringData("Product Name");
            product.ProductName = productName.Trim();
            if (product.ProductName == string.Empty)
            {
                Helper.WriteColored("Returning to main menu...", ConsoleColor.Yellow);
                return;
            }

            product.Price = Helper.GetDecimalData("Price");
            if (product.Price == 0)
            {
                Helper.WriteColored("Returning to main menu...", ConsoleColor.Yellow);
                return;
            }

            product.Quantity = Helper.GetIntData("Quantity");
            if (product.Quantity == 0)
            {
                Helper.WriteColored("Returning to main menu...", ConsoleColor.Yellow);
                return;
            }

            if (_service.AddProduct(product))
            {
                Helper.WriteColored("Product Added Successfully.", ConsoleColor.Green);
            }
            else
            {
                Helper.WriteColored("Product ID already exists.", ConsoleColor.Red);
            }
        }
    }
}