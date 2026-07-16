using Assignment1.Model;
using Assignment1.Repository;

namespace Assignment1.Services
{
    /// <summary>Service layer for contact operations</summary>
    public class ContactServices
    {
        private static ContactRepository _repo = new ();
        private Helper _helper = new ();

        /// <summary>Contact Information Class is created</summary>
        /// <param name="name">It is the name of the contact</param>
        /// <param name="phone">It is the phone no of the contact</param>
        /// <param name="email">It is the email of the contact</param>
        /// <param name="notes">It is the notes of contact</param>
        public void AddContact(string name, string phone, string email, string notes)
        {
            Guid id = Guid.NewGuid();
            ContactInfo contact = new ContactInfo
            {
                Id = id,
                Name = name,
                Phone = phone,
                Email = email,
                Notes = notes,
            };
            if (this._helper.Validation(name, phone, email))
            {
                _repo.Add(contact);
                this._helper.AddedMessage();
            }
        }

        /// <summary>ViewContact() function is used to view all contacts</summary>
        /// <returns>The all contact informations as a list</returns>
        public List<ContactInfo> ViewContacts()
        {
            return _repo.GetAll();
        }

        /// <summary>ViewContact() function is used to view all contacts</summary>
        /// <param name="name">It is the name of the contact</param>
        /// <returns>The all contact informations as a list</returns>
        public List<ContactInfo> SearchContact(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return new List<ContactInfo>();
            }

            return _repo.GetByName(name) ?? new List<ContactInfo>();
        }

        /// <summary>EditContact function is used to edit the existing data in the repository</summary>
        /// <param name="id">It is the Guid of the contact</param>
        /// <param name="name">It is the name of the contact</param>
        /// <param name="phone">It is the phone no of the contact</param>
        /// <param name="email">It is the email of the contact</param>
        /// <param name="notes">It is the notes of contact</param>
        /// <returns>Return whether the repository is edited or not</returns>
        public bool EditContact(Guid id, string name, string phone, string email, string notes)
        {
            ContactInfo updated = new ContactInfo
            {
                Id = id,
                Name = name,
                Phone = phone,
                Email = email,
                Notes = notes,
            };
            if (this._helper.Validation(name, phone, email))
            {
                return _repo.Update(updated);
            }

            return false;
        }

        /// <summary>
        /// DeleteContact function is used to remove all the data in the repository of a certain contact using Guid
        /// </summary>
        /// <param name="id">It is the Guid of the contact</param>
        /// <returns>Returns whether the certain contact is deleted or not</returns>
        public bool DeleteContact(Guid id)
        {
            return _repo.Delete(id);
        }

        /// <summary>
        /// SortContactsByName function is used to Sort all the contact by name
        /// </summary>
        public void SortContactsByName()
        {
            _repo.SortByName();
        }
    }
}