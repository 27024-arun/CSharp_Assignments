using Assignment1.Model;

namespace Assignment1.Repository
{
    /// <summary>
    /// Contact Repository is created for storage and retrieving data.
    /// </summary>
    public class CSVContactRepository : IRepository
    {
        private readonly string _filePath = "Contacts.csv";

        /// <summary>
        /// Add function is created for adding contact in the repository.
        /// </summary>
        /// <param name="contact">Contact of the users</param>
        public void Add(ContactInfo contact)
        {
            File.AppendAllText(this._filePath, $"{contact.Id},{contact.Name},{contact.Phone},{contact.Email},{contact.Notes}\n");
        }

        /// <summary>
        /// GetAll function is used to retrieve all the contact list in the repository.
        /// </summary>
        /// <returns>Returns all the list of contacts</returns>
        public List<ContactInfo> GetAll()
        {
            string[] fileData = File.ReadAllLines(this._filePath);
            List<ContactInfo> contacts = new List<ContactInfo>();
            foreach (string line in fileData)
            {
                string[] value = line.Split(",");
                ContactInfo contact = new ContactInfo()
                {
                    Id = Guid.Parse(value[0]),
                    Name = value[1],
                    Phone = value[2],
                    Email = value[3],
                    Notes = value[4],
                };
                contacts.Add(contact);
            }

            return contacts;
        }

        /// <summary>
        /// GetById function is used to retrieve a contact by Guid.
        /// </summary>
        /// <param name="id">id is the unique identification of the user</param>
        /// <returns>Returns a single contact with matching Guid</returns>
        public ContactInfo? GetById(Guid id)
        {
            List<ContactInfo> contacts = this.GetAll();
            return contacts.FirstOrDefault(c => c.Id == id);
        }

        /// <summary>
        /// GetByName function is used to retrieve list of contact with the asked name.
        /// </summary>
        /// <param name="name">Name of the user</param>
        /// <returns>Return the list of contacts with the matched name</returns>
        public List<ContactInfo> GetByName(string name)
        {
            List<ContactInfo> contacts = this.GetAll();
            return contacts.Where(c => !string.IsNullOrEmpty(c.Name) && c.Name.Equals(name, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        /// <summary>
        /// Update function is used to update a contact in a reposiotry.
        /// </summary>
        /// <param name="updatedContact">updatedContact is the new contact data for the existing contact</param>
        /// <returns>Returns whether the data is present previously or not</returns>
        public bool Update(ContactInfo updatedContact)
        {
            List<ContactInfo> contacts = this.GetAll();

            foreach (var contact in contacts)
            {
                if (contact.Id == updatedContact.Id)
                {
                    contact.Name = updatedContact.Name;
                    contact.Phone = updatedContact.Phone;
                    contact.Email = updatedContact.Email;
                    contact.Notes = updatedContact.Notes;
                }
            }

            this.WriteAll(contacts);
            return true;
        }

        /// <summary>
        /// WriteAll method is used to write all lines of data in CSV file.
        /// </summary>
        /// <param name="contacts">Contacts is the contact details of the user.</param>
        public void WriteAll(List<ContactInfo> contacts)
        {
            List<string> res = new List<string>();
            foreach (var contact in contacts)
            {
                res.Add($"{contact.Id},{contact.Name},{contact.Phone},{contact.Email},{contact.Notes}");
            }

            File.WriteAllLines(this._filePath, res);
        }

        /// <summary>
        /// Delete function is used to remove data in the repository.
        /// </summary>
        /// <param name="id">id is the unique identification of the user</param>
        /// <returns>Returns whether the data is removed or not</returns>
        public bool Delete(Guid id)
        {
            List<ContactInfo> contacts = this.GetAll();
            int index = contacts.FindIndex(x => x.Id == id);
            if (index == -1)
            {
                return false;
            }

            contacts.RemoveAt(index);
            this.WriteAll(contacts);
            return true;
        }

        /// <summary>
        /// SortByName function is used to sort the contacts based on the name.
        /// </summary>
        public void SortByName()
        {
            List<ContactInfo> contact = this.GetAll();
            contact.Sort((c1, c2) => string.Compare(c1?.Name, c2?.Name, StringComparison.OrdinalIgnoreCase));
            this.WriteAll(contact);
        }
    }
}