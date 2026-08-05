using Assignment1.Model;

namespace Assignment1.Repository
{
    /// <summary>
    /// IRepository is the interface for the repository.
    /// </summary>
    internal interface IRepository
    {
        /// <summary>
        /// Add method is the method blueprint used to add data in repository.
        /// </summary>
        /// <param name="contact">Contact of the users</param>
        public void Add(ContactInfo contact);

        /// <summary>
        /// GetAll function is the method blueprint used to retrieve all the contact list in the repository.
        /// </summary>
        /// <returns>Returns all the list of contacts</returns>
        public List<ContactInfo> GetAll();

        /// <summary>
        /// GetById function is the method blueprint used to retrieve a contact by Guid.
        /// </summary>
        /// <param name="id">id is the unique identification of the user</param>
        /// <returns>Returns a single contact with matching Guid</returns>
        public ContactInfo? GetById(Guid id);

        /// <summary>
        /// GetByName function is the method blueprint used to retrieve list of contact with the asked name.
        /// </summary>
        /// <param name="name">Name of the user</param>
        /// <returns>Return the list of contacts with the matched name</returns>
        public List<ContactInfo> GetByName(string name);

        /// <summary>
        /// Update function is the method blueprint used to update a contact in a reposiotry.
        /// </summary>
        /// <param name="updatedContact">updatedContact is the new contact data for the existing contact</param>
        /// <returns>Returns whether the data is present previously or not</returns>
        public bool Update(ContactInfo updatedContact);

        /// <summary>
        /// Delete function is the method blueprint used to remove data in the repository.
        /// </summary>
        /// <param name="id">id is the unique identification of the user</param>
        /// <returns>Returns whether the data is removed or not</returns>
        public bool Delete(Guid id);

        /// <summary>
        /// SortByName function is used to sort the contacts based on the name.
        /// </summary>
        public void SortByName();
    }
}
