using Inventory_Management.Model;

namespace Inventory_Management.Repository
{
    /// <summary>
    /// InventoryRepository Class is used to store datas of the inventory.
    /// </summary>
    public class InventoryRepository
    {
        private readonly List<InventoryModel> _products = new List<InventoryModel>();

        /// <summary>
        /// GetAllProducts method is used to get the details of all the products.
        /// </summary>
        /// <returns>Returns the products in the inventory.</returns>
        internal List<InventoryModel> GetAllProducts()
        {
            return this._products;
        }

        /// <summary>
        /// AddProduct method is used to add products to the inventory.
        /// </summary>
        /// <param name="product">Product is the details of the product that is needed to be added.</param>
        internal void AddProduct(InventoryModel product)
        {
            this._products.Add(product);
        }

        /// <summary>
        /// GetProductById method is used to get the product details with the same id.
        /// </summary>
        /// <param name="id">Id is the unique identifier of the product.</param>
        /// <returns>Returns the product with the same id.</returns>
        internal InventoryModel? GetProductById(int id)
        {
            return this._products.FirstOrDefault(p => p.ProductID == id);
        }

        /// <summary>
        /// DeleteProduct Method is used to delete the product in the inventory.
        /// </summary>
        /// <param name="id">Id is the unique identifier of the product.</param>
        /// <returns>Returns whether the product is deleted or not.</returns>
        internal bool DeleteProduct(int id)
        {
            var product = this.GetProductById(id);

            if (product == null)
            {
                return false;
            }

            this._products.Remove(product);
            return true;
        }

        /// <summary>
        /// SearchByName method is used to search the product with the same name.
        /// </summary>
        /// <param name="name">Name is the name of the product.</param>
        /// <returns>Returns the products with the same name.</returns>
        internal List<InventoryModel> SearchByName(string name)
        {
            return this._products.Where(p => p.ProductName!.ToLower().Contains(name.ToLower())).ToList();
        }

        /// <summary>
        /// UpdateProduct method is used to update the details of the product in the inventory.
        /// </summary>
        /// <param name="product">Product is the details of the product.</param>
        internal void UpdateProduct(InventoryModel product)
        {
            var existing = this.GetProductById(product.ProductID);

            if (existing != null)
            {
                existing.ProductName = product.ProductName;
                existing.Price = product.Price;
                existing.Quantity = product.Quantity;
            }
        }

        /// <summary>
        /// IsEmpty method is used to return whether the inventory is empty or not.
        /// </summary>
        /// <returns>Returns whether the inventory is empty or not.</returns>
        internal bool IsEmpty()
        {
            return this._products.Count == 0;
        }

        /// <summary>
        /// IsProductAvail method is used to check whether a product with same id exists.
        /// </summary>
        /// <param name="id">Id is the unique identifier of the product.</param>
        /// <returns>Returns whether the product already present or not.</returns>
        internal bool IsProductAvail(int id)
        {
            return this._products.Any(p => p.ProductID == id);
        }
    }
}
