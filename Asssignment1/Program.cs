using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Assignments
{
    /// <summary>
    /// Program is a initialising class with Main function
    /// </summary>
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Contact Manager!");
            List<(string name, string phone, string email, string notes)> contacts = new List<(string, string, string, string)>();
            bool isNeededToReOccur = false;
            while (!isNeededToReOccur)
            {
                Console.WriteLine("1.[A]dd new Contact\n2.[V]iew Contact\n3.[D]elete new Contact\n4.[E]dit Contact\n5.[S]earch Contact\n6.[O]Sort Contacts\n7.[X]Exit");
                var userChoice = Console.ReadLine();
                switch (userChoice.ToLower())
                {
                    case "a":
                        AddContactNumber(contacts);
                        break;
                    case "v":
                        ViewContact(contacts);
                        break;
                    case "d":
                        DeleteContact(contacts);
                        break;
                    case "e":
                        EditContact(contacts);
                        break;
                    case "s":
                        SearchContact(contacts);
                        break;
                    case "o":
                        contacts = SortContacts(contacts);
                        break;
                    case "x":
                        isNeededToReOccur = true;
                        break;
                    default:
                        Console.WriteLine("Enter a Valid Choice\n");
                        break;
                }
            }
        }

        private static List<(string name, string phone, string email, string notes)> SortContacts(List<(string name, string phone, string email, string notes)> contacts)
        {
            contacts = contacts.OrderBy(c => c.name, StringComparer.OrdinalIgnoreCase).ToList();
            Console.WriteLine("Contacts are Sorted\n");
            return contacts;
        }

        private static void SearchContact(List<(string name, string phone, string email, string notes)> contacts)
        {
            Console.Write("Enter name to search: ");
            string searchName = Console.ReadLine();
            int index = contacts.FindIndex(c => c.name.Equals(searchName, StringComparison.OrdinalIgnoreCase));
            if (index != -1)
            {
                Console.WriteLine($"Name : {contacts[index].name}");
                Console.WriteLine($"Phone: {contacts[index].phone}");
                Console.WriteLine($"Email: {contacts[index].email}");
                Console.WriteLine($"Notes: {contacts[index].notes}");
            }
        }

        private static void EditContact(List<(string name, string phone, string email, string notes)> contacts)
        {
            bool isIndexCorrect = false;
            while (!isIndexCorrect)
            {
                Console.WriteLine("Select the index of the Contact you want to edit");
                ViewContact(contacts);
                var userInput = Console.ReadLine();
                if (int.TryParse(userInput, out int index) && index >= 1 && index <= contacts.Count)
                {
                    var contact = contacts[index - 1];
                    Console.Write("Enter new name: ");
                    string newName = Console.ReadLine();
                    contact.name = newName;

                    Console.Write("Enter new phone: ");
                    string newPhone = Console.ReadLine();
                    contact.phone = newPhone;

                    Console.Write("Enter new email: ");
                    string newEmail = Console.ReadLine();
                    contact.email = newEmail;

                    Console.Write("Enter new notes: ");
                    string newNotes = Console.ReadLine();
                    contact.notes = newNotes;

                    contacts[index - 1] = contact;
                    isIndexCorrect = true;
                    Console.WriteLine("Contact updated successfully\n");
                }
            }
        }

        private static void DeleteContact(List<(string name, string phone, string email, string notes)> contacts)
        {
            bool isIndexCorrect = false;
            while (!isIndexCorrect)
            {
                Console.WriteLine("Select the index of the Contact you want to delete");
                ViewContact(contacts);
                var userInput = Console.ReadLine();
                if (int.TryParse(userInput, out int index) && index >= 1 && index <= contacts.Count)
                {
                    contacts.RemoveAt(index - 1);
                    isIndexCorrect = true;
                    Console.WriteLine("Contact Removed\n");
                }
            }
        }

        private static void AddContactNumber(List<(string name, string phone, string email, string notes)> contacts)
        {
            Console.WriteLine("Enter Name:");
            var name = Console.ReadLine();
            Console.WriteLine("Enter Phone Number:");
            string phone = Console.ReadLine();
            Console.WriteLine("Enter Email:");
            string email = Console.ReadLine();
            Console.WriteLine("Enter Some Notes:");
            string notes = Console.ReadLine();
            contacts.Add((name, phone, email, notes));
        }

        private static void ViewContact(List<(string name, string phone, string email, string notes)> contacts)
        {
            for (int i = 0; i < contacts.Count; i++)
            {
                (string name, string phone, string email, string notes) contact = contacts[i];
                Console.WriteLine($"[{i + 1}]Name: {contact.name}");
                Console.WriteLine($" Phone: {contact.phone}");
                Console.WriteLine($" Email: {contact.email}");
                Console.WriteLine($" Notes: {contact.notes}");
                Console.WriteLine();
            }
        }
    }
}