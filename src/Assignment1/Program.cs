using System.Numerics;
using System.Xml.Linq;
using Assignment1.Model;
using Assignment1.Services;

namespace Assignments
{
    /// <summary>
    /// Program is the initialising Class (It is in View level).
    /// </summary>
    internal class Program
    {
        private static ContactServices _service = new ();

        /// <summary>
        /// Main is the initialising function.
        /// </summary>
        public static void Main()
        {
            while (true)
            {
                string verbatimString = $@"
Contact Management
1. [A]dd Contact
2. [V]iew Contacts
3. [S]earch Contact
4. [E]dit Contact
5. [D]elete Contact
6. [O]Sort Contacts
7. [X]Exit
Enter your choice: ";

                Console.WriteLine(verbatimString);
                var choice = Console.ReadLine()?.ToLower();

                switch (choice)
                {
                    case "a":
                        AddContact();
                        break;

                    case "v":
                        ViewContact();
                        break;

                    case "s":
                        SearchContact();
                        break;

                    case "e":
                        UpdateContact();
                        break;

                    case "d":
                        RemoveContact();
                        break;

                    case "o":
                        SortContact();
                        break;

                    case "x":
                        return;

                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
        }

        /// <summary>
        /// SearchContact method is used for getting details in view layer and passing it to service layer for searching it in repository.
        /// </summary>
        private static void SearchContact()
        {
            Console.Write("Enter Name: ");
            string? searchName = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(searchName))
            {
                Console.WriteLine("The Name is not valid.");
            }
            else
            {
                var foundContacts = _service.SearchContact(searchName);
                if (foundContacts.Count == 0)
                {
                    Console.WriteLine("No contacts found.");
                }
                else
                {
                    foreach (var c in foundContacts)
                    {
                        Console.Write($"Name: {c.Name} Phone: {c.Phone} Email: {c.Email} Notes: {c.Notes}");
                    }
                }
            }
        }

        /// <summary>
        /// AddContact method is view level method which would trigger service layer methods for adding data.
        /// </summary>
        private static void AddContact()
        {
            Console.Write("Name: ");
            string? name = Console.ReadLine();
            Console.Write("Phone: ");
            string? phone = Console.ReadLine();
            Console.Write("Email: ");
            string? email = Console.ReadLine();
            Console.Write("Notes: ");
            string? notes = Console.ReadLine();
            if (name != null && phone != null && email != null && notes != null)
            {
                ContactInfo contact = new ContactInfo
                {
                    Name = name,
                    Phone = phone,
                    Email = email,
                    Notes = notes,
                };
                _service.AddContact(contact);
            }
        }

        /// <summary>
        /// RemoveContact method is view level method for accessing service layer Remove.
        /// </summary>
        private static void RemoveContact()
        {
            Console.Write("Enter Contact Serial No of the contact to delete: ");
            var contactlists = _service.ViewContacts();
            if (int.TryParse(Console.ReadLine(), out int indexValue) && indexValue > 0 && indexValue <= contactlists.Count())
            {
                indexValue -= 1;
                if (_service.DeleteContact(contactlists[indexValue].Id))
                {
                    Console.WriteLine("Deleted successfully");
                }
                else
                {
                    Console.WriteLine("Contact not found");
                }
            }
            else
            {
                Console.WriteLine("Invalid Index");
            }
        }

        /// <summary>
        /// UpdateContact method is used to access service layer update contact methods.
        /// </summary>
        private static void UpdateContact()
        {
            Console.Write("Enter Serial No of the contact to edit : ");
            var contactlist = _service.ViewContacts();
            if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= contactlist.Count())
            {
                index = index - 1;
                Console.Write("New Name: ");
                string? newName = Console.ReadLine();
                Console.Write("New Phone: ");
                string? newPhone = Console.ReadLine();
                Console.Write("New Email: ");
                string? newEmail = Console.ReadLine();
                Console.Write("New Notes: ");
                string? newNotes = Console.ReadLine();
                ContactInfo updated = new ContactInfo
                {
                    Name = newName,
                    Phone = newPhone,
                    Email = newEmail,
                    Notes = newNotes,
                };
                if (!string.IsNullOrWhiteSpace(newName) && !string.IsNullOrWhiteSpace(newPhone) && !string.IsNullOrWhiteSpace(newEmail) && !string.IsNullOrWhiteSpace(newNotes) && _service.EditContact(contactlist[index].Id, updated))
                {
                    Console.WriteLine("Contact updated successfully.");
                }
                else
                {
                    Console.WriteLine("Contact not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid Index");
            }
        }

        /// <summary>
        /// ViewContact method is used to display the contacts to the user.
        /// </summary>
        private static void ViewContact()
        {
            var contacts = _service.ViewContacts();
            if (contacts.Count == 0)
            {
                Console.WriteLine("No contacts found.");
            }
            else
            {
                int i = 0;
                foreach (var c in contacts)
                {
                    Console.Write($"{++i}. Name: {c.Name} Phone: {c.Phone} Email: {c.Email} Notes: {c.Notes}");
                    Console.WriteLine();
                }
            }
        }

        /// <summary>
        /// SortContact method is used to sort the contacts based on the name.
        /// </summary>
        private static void SortContact()
        {
            _service.SortContactsByName();
            var contact = _service.ViewContacts();
            if (contact.Count == 0)
            {
                Console.WriteLine("No contacts found.");
            }
            else
            {
                int i = 0;
                foreach (var c in contact)
                {
                    Console.Write($"{++i}. Name: {c.Name} Phone: {c.Phone} Email: {c.Email} Notes: {c.Notes}");
                    Console.WriteLine();
                }
            }
        }
    }
}