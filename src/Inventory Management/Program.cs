using Inventory_Management.Model;
using Inventory_Management.Services;
using Inventory_Management.View;

namespace Inventory_View
{
    /// <summary>
    /// Program Class is the entry point of the program.
    /// </summary>
    internal class Program
    {
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
                            InventoryView.AddProduct();
                            break;

                        case (int)InventoryModel.InventoryMenu.ViewProducts:
                            InventoryView.ViewProducts();
                            break;

                        case (int)InventoryModel.InventoryMenu.SearchProduct:
                            InventoryView.SearchProduct();
                            break;

                        case (int)InventoryModel.InventoryMenu.UpdateProduct:
                            InventoryView.UpdateProduct();
                            break;

                        case (int)InventoryModel.InventoryMenu.DeleteProduct:
                            InventoryView.DeleteProduct();
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
    }
}