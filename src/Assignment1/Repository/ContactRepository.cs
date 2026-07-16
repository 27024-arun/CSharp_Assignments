using Assignment1.Model;

namespace Assignment1.Repository
{
    /// <summary>
    /// Contact Repository is created for storage and retrieving data
    /// </summary>
    public class ContactRepository
    {
        private static List<ContactInfo> _contacts = new ();

        /// <summary>
        /// Add function is created for adding contact
        /// </summary>
        /// <param name="contact">Contact of the users</param>
        public void Add(ContactInfo contact)
        {
            _contacts.Add(contact);
        }

        /// <summary>
        /// GetAll function is used to retrieve all the contact list in the repository
        /// </summary>
        /// <returns>Returns all the list of contacts</returns>
        public List<ContactInfo> GetAll()
        {
            return _contacts;
        }

        /// <summary>
        /// GetById function is used to retrieve a contact by Guid
        /// </summary>
        /// <param name="id">It is the id of the user</param>
        /// <returns>Returns a single contact with matching Guid</returns>
        public ContactInfo? GetById(Guid id)
        {
            return _contacts.FirstOrDefault(c => c.Id == id);
        }

        /// <summary>
        /// GetByName function is used to retrieve list of contact with the asked name
        /// </summary>
        /// <param name="name">It is the name of the contact</param>
        /// <returns>Return the list of contacts with the matched name</returns>
        public List<ContactInfo> GetByName(string name)
        {
            return _contacts.Where(c => !string.IsNullOrEmpty(c.Name) && c.Name.Equals(name, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        /// <summary>
        /// Update function is used to update a contact in a reposiotry
        /// </summary>
        /// <param name="updatedContact">It is the new contact data for the existing contact</param>
        /// <returns>Returns whether the data is present previously or not</returns>
        public bool Update(ContactInfo updatedContact)
        {
            var existing = this.GetById(updatedContact.Id);
            if (existing == null)
            {
                return false;
            }

            existing.Name = updatedContact.Name;
            existing.Phone = updatedContact.Phone;
            existing.Email = updatedContact.Email;
            existing.Notes = updatedContact.Notes;
            return true;
        }

        /// <summary>
        /// Delete function is used to remove data in the repository
        /// </summary>
        /// <param name="id">It is id of the contact</param>
        /// <returns>Returns whether the data is removed or not</returns>
        public bool Delete(Guid id)
        {
            var contact = this.GetById(id);
            if (contact == null)
            {
                return false;
            }

            _contacts.Remove(contact);
            return true;
        }

        /// <summary>
        /// SortByName function is used to sort the contacts based on the name
        /// </summary>
        public void SortByName()
        {
            _contacts.Sort((c1, c2) => string.Compare(c1?.Name, c2?.Name, StringComparison.OrdinalIgnoreCase));
        }
    }
}