using LINQPractices.Model;

namespace LINQPractices.Helper
{
    /// <summary>
    /// Helps to perform population of products.
    /// </summary>
    internal class SupplierAdder
    {
        /// <summary>
        /// AddSupplier method is used to populate supplier list and returns the populated list.
        /// </summary>
        /// <returns>Suppiler list.</returns>
        public List<Supplier> AddSupplier()
        {
            List<Supplier> list = new List<Supplier>();
            list.Add(new Supplier(1000, "TechCorp", 100));
            list.Add(new Supplier(1001, "BeautyWorld", 101));
            list.Add(new Supplier(1002, "KitchenPro", 102));
            list.Add(new Supplier(1003, "MediCare", 103));
            list.Add(new Supplier(1004, "KitchenPro", 104));
            list.Add(new Supplier(1005, "KitchenPro", 105));
            list.Add(new Supplier(1006, "SnackHouse", 106));
            list.Add(new Supplier(1007, "KitchenPro", 107));
            list.Add(new Supplier(1008, "TechCorp", 108));
            list.Add(new Supplier(1009, "MediCare", 109));
            list.Add(new Supplier(1010, "SnackHouse", 110));
            list.Add(new Supplier(1011, "BeautyWorld", 111));
            list.Add(new Supplier(1012, "SnackHouse", 112));
            list.Add(new Supplier(1013, "TechCorp", 113));
            list.Add(new Supplier(1014, "TechCorp", 114));
            list.Add(new Supplier(1015, "BeautyWorld", 115));
            list.Add(new Supplier(1016, "BookRanger", 116));
            list.Add(new Supplier(1017, "BookRanger", 117));
            list.Add(new Supplier(1018, "BookRanger", 118));
            list.Add(new Supplier(1019, "BookRanger", 119));
            list.Add(new Supplier(1020, "BookRanger", 120));
            return list;
        }
    }
}
