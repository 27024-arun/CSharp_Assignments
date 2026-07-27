using Inventory_Management.Model;
using Inventory_Management.Repository;

namespace Inventory_Management.Services
{
    /// <summary>
    /// InventoryServices Class is used to provide inventory services.
    /// </summary>
    public class InventoryServices
    {
        private readonly InventoryRepository _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="InventoryServices"/> class.
        /// InventoryServices method is the contructor for InventoryServices class.
        /// </summary>
        public InventoryServices()
        {
            this._repository = new InventoryRepository();
        }

        /// <summary>
        /// AddProduct method is used to add products to the inventory.
        /// </summary>
        /// <param name="product">Product is the product details that is needed to be added in inventory.</param>
        /// <returns>Returns whether the product is added or not.</returns>
        internal bool AddProduct(InventoryModel product)
        {
            if (this._repository.GetProductById(product.ProductID) != null)
            {
                return false;
            }

            this._repository.AddProduct(product);
            return true;
        }

        /// <summary>
        /// GetProducts method is used to get the details of all the products in the inventory.
        /// </summary>
        /// <returns>Returns the products in the inventory.</returns>
        internal List<InventoryModel> GetProducts()
        {
            return this._repository.GetAllProducts().OrderBy(p => p.ProductName).ToList();
        }

        /// <summary>
        /// DeleteProduct method is used to Delete the product in the inventory.
        /// </summary>
        /// <param name="id">Id is the id of the product.</param>
        /// <returns>Returns whether the product is deleted or not.</returns>
        internal bool DeleteProduct(int id)
        {
            return this._repository.DeleteProduct(id);
        }

        /// <summary>
        /// UpdateProduct method is used to update the details of the product in the inventory.
        /// </summary>
        /// <param name="product">Product is the one that is needed to be updated with new data.</param>
        /// <returns>Returns whether the product is updated or not.</returns>
        internal bool UpdateProduct(InventoryModel product)
        {
            if (this._repository.GetProductById(product.ProductID) == null)
            {
                return false;
            }

            this._repository.UpdateProduct(product);
            return true;
        }

        /// <summary>
        /// SearchById method is used to search the product based on Id.
        /// </summary>
        /// <param name="id">Id is the unique identifier of the product.</param>
        /// <returns>Returns the product details with matching id.</returns>
        internal InventoryModel SearchById(int id)
        {
            return this._repository.GetProductById(id);
        }

        /// <summary>
        /// SearchByName method is used to find the product with the matching name.
        /// </summary>
        /// <param name="name">Name is the name of the product.</param>
        /// <returns>Returns the Products with the entered name.</returns>
        internal List<InventoryModel> SearchByName(string name)
        {
            return this._repository.SearchByName(name);
        }
    }
}