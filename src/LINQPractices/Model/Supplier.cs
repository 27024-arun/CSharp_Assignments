namespace LINQPractices.Model
{
    /// <summary>
    /// Defines the properties of the Supplier.
    /// </summary>
    internal class Supplier
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Supplier"/> class.
        /// </summary>
        /// <param name="supplierID">Unique id of the supplier.</param>
        /// <param name="supplierName">Name of the supplier.</param>
        /// <param name="productId">Product ID which the supplier supplies.</param>
        public Supplier(int supplierID, string supplierName, int productId)
        {
            this.SupplierID = supplierID;
            this.SupplierName = supplierName;
            this.ProductId = productId;
        }

        /// <summary>
        /// Gets or Sets the Supplier ID of the supplier.
        /// </summary>
        /// <value>Id of the supplier.</value>
        public int SupplierID { get; set; }

        /// <summary>
        /// Gets or Sets the Supplier name of the supplier.
        /// </summary>
        /// <value>Name of the supplier.</value>
        public string SupplierName { get; set; }

        /// <summary>
        /// Gets or Sets the Product ID of that the supplier supplies.
        /// </summary>
        /// <value>Product Id supplied by the supplier.</value>
        public int ProductId { get; set; }
    }
}
