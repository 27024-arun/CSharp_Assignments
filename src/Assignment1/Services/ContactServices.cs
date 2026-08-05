using Assignment1.Model;
using Assignment1.Repository;

namespace Assignment1.Services
{
    /// <summary>Service layer for contact operations</summary>
    public class ContactServices
    {
        private static CSVContactRepository _repo = new ("Contacts.csv");
        private Helper _helper = new ();

        /// <summary>
        /// AddContact Method is used to perform function call for validation and add the datas to repository.
        /// </summary>
        /// <param name="contact">contact is the contact details of the user</param>
        public void AddContact(ContactInfo contact)
        {
            Guid id = Guid.NewGuid();
            contact.Id = id;
            if (this._helper.NameValidation(contact.Name!) && this._helper.PhoneValidation(contact.Phone!) && this._helper.EmailValidation(contact.Email!))
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

        /// <summary>
        /// EditContact function is used to edit the existing data in the repository.
        /// </summary>
        /// <param name="id">id is parameter used for unique identification of the user</param>
        /// <param name="updated">updated</param>
        /// <returns>Returns whether the contact is updated or not</returns>
        public bool EditContact(Guid id, ContactInfo updated)
        {
            updated.Id = id;
            if (updated.Name != null && updated.Phone != null && updated.Email != null)
            {
                if (this._helper.NameValidation(updated.Name) && this._helper.PhoneValidation(updated.Phone) && this._helper.EmailValidation(updated.Email))
                {
                    return _repo.Update(updated);
                }
            }

            return false;
        }

        /// <summary>
        /// DeleteContact function is used to remove all the data in the repository of a certain contact using Guid.
        /// </summary>
        /// <param name="id">id is the Guid of the contact</param>
        /// <returns>Returns whether the certain contact is deleted or not</returns>
        public bool DeleteContact(Guid id)
        {
            return _repo.Delete(id);
        }

        /// <summary>
        /// SortContactsByName function is used to Sort all the contact by name.
        /// </summary>
        public void SortContactsByName()
        {
            _repo.SortByName();
        }
    }
}