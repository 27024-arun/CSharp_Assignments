namespace LINQPractices.Model
{
    internal class Supplier
    {
        public Supplier(int supplierID, string supplierName, int productId)
        {
            this.SupplierID = supplierID;
            this.SupplierName = supplierName;
            this.ProductId = productId;
        }

        public int SupplierID { get; set; }

        public string SupplierName { get; set; }

        public int ProductId { get; set; }
    }
}
