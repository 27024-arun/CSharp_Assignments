using System.Text;
using Assignment1.Model;

namespace Assignment1.Repository
{
    /// <summary>
    /// CSVContactRepository class is used to store data in CSV format.
    /// </summary>
    public class CSVContactRepository : IRepository
    {
        private readonly string _filePath;

        /// <summary>
        /// Initializes a new instance of the <see cref="CSVContactRepository"/> class.
        /// </summary>
        /// <param name="filePath">filePath is the name of the CSV file.</param>
        public CSVContactRepository(string filePath)
        {
            this._filePath = filePath;
            this.EnsureFileExists();
        }

        /// <summary>
        /// Add method is used to add data in the repository.
        /// </summary>
        /// <param name="contact">Contact is the contact details of the user.</param>
        /// <exception cref="InvalidOperationException">Throws exception if the ID already exists.</exception>
        public void Add(ContactInfo contact)
        {
            var contacts = this.ReadAllContacts();
            if (contacts.Any(c => c.Id == contact.Id))
            {
                throw new InvalidOperationException("Contact with this ID already exists.");
            }

            contacts.Add(contact);
            this.WriteAllContacts(contacts);
        }

        /// <summary>
        /// GetAll function is used to retrieve all the contact list in the repository.
        /// </summary>
        /// <returns>Returns all the list of contacts</returns>
        public List<ContactInfo> GetAll()
        {
            return this.ReadAllContacts();
        }

        /// <summary>
        /// GetById function is used to retrieve a contact by Guid.
        /// </summary>
        /// <param name="id">id is the unique identification of the user</param>
        /// <returns>Returns a single contact with matching Guid</returns>
        public ContactInfo? GetById(Guid id)
        {
            return this.ReadAllContacts().FirstOrDefault(c => c.Id == id);
        }

        /// <summary>
        /// GetByName function is used to retrieve list of contact with the asked name.
        /// </summary>
        /// <param name="name">Name of the user</param>
        /// <returns>Return the list of contacts with the matched name</returns>
        public List<ContactInfo> GetByName(string name)
        {
            return this.ReadAllContacts()
                   .Where(c => !string.IsNullOrEmpty(c.Name) &&
                               c.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                   .ToList();
        }

        /// <summary>
        /// Update function is used to update a contact in a reposiotry.
        /// </summary>
        /// <param name="updatedContact">updatedContact is the new contact data for the existing contact</param>
        /// <returns>Returns whether the data is present previously or not</returns>
        public bool Update(ContactInfo updatedContact)
        {
            var contacts = this.ReadAllContacts();
            var index = contacts.FindIndex(c => c.Id == updatedContact.Id);
            if (index == -1)
            {
                return false;
            }

            contacts[index] = updatedContact;
            this.WriteAllContacts(contacts);
            return true;
        }

        /// <summary>
        /// Delete function is used to remove data in the repository.
        /// </summary>
        /// <param name="id">id is the unique identification of the user</param>
        /// <returns>Returns whether the data is removed or not</returns>
        public bool Delete(Guid id)
        {
            var contacts = this.ReadAllContacts();
            int removed = contacts.RemoveAll(c => c.Id == id);
            if (removed > 0)
            {
                this.WriteAllContacts(contacts);
                return true;
            }

            return false;
        }

        /// <summary>
        /// SortByName function is used to sort the contacts based on the name.
        /// </summary>
        public void SortByName()
        {
            var contacts = this.ReadAllContacts().OrderBy(c => c.Name, StringComparer.OrdinalIgnoreCase).ToList();
            this.WriteAllContacts(contacts);
        }

        private void EnsureFileExists()
        {
            if (!File.Exists(this._filePath))
            {
                File.WriteAllText(this._filePath, "Id,Name,Phone,Email,Notes\n", Encoding.UTF8);
            }
        }

        private string EscapeCsv(string field)
        {
            if (field.Contains(',') || field.Contains('"') || field.Contains('\n'))
            {
                field = field.Replace("\"", "\"\"");
                return $"\"{field}\"";
            }

            return field;
        }

        private List<ContactInfo> ReadAllContacts()
        {
            return File.ReadAllLines(this._filePath)
                       .Skip(1)
                       .Where(line => !string.IsNullOrWhiteSpace(line))
                       .Select(line =>
                       {
                           var parts = this.ParseCsvLine(line);
                           return new ContactInfo
                           {
                               Id = Guid.Parse(parts[0]),
                               Name = parts[1],
                               Phone = parts[2],
                               Email = parts[3],
                               Notes = parts[4],
                           };
                       })
                       .ToList();
        }

        private void WriteAllContacts(List<ContactInfo> contacts)
        {
            var lines = new List<string> { "Id,Name,Phone,Email,Notes" };
            lines.AddRange(contacts.Select(c =>
                $"{c.Id},{this.EscapeCsv(c.Name ?? string.Empty)},{this.EscapeCsv(c.Phone ?? string.Empty)},{this.EscapeCsv(c.Email ?? string.Empty)},{this.EscapeCsv(c.Notes ?? string.Empty)}"));
            File.WriteAllLines(this._filePath, lines, Encoding.UTF8);
        }

        private string[] ParseCsvLine(string line)
        {
            var fields = new List<string>();
            bool inQuotes = false;
            StringBuilder field = new StringBuilder();

            foreach (char c in line)
            {
                if (c == '"' && !inQuotes)
                {
                    inQuotes = true;
                }
                else if (c == '"' && inQuotes)
                {
                    inQuotes = false;
                }
                else if (c == ',' && !inQuotes)
                {
                    fields.Add(field.ToString());
                    field.Clear();
                }
                else
                {
                    field.Append(c);
                }
            }

            fields.Add(field.ToString());
            return fields.ToArray();
        }
    }
}
