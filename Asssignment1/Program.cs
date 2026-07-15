using System.ComponentModel.DataAnnotations;
using System.Linq;
using Assignment1.Services;

namespace Assignments
{
    /// <summary>
    /// Program is the initialising Class (It is in View level)
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Main is the initialising function
        /// </summary>
        public static void Main()
        {
            ContactServices service = new ();

            while (true)
            {
                Console.WriteLine("Contact Management");
                Console.WriteLine("1. [A]dd Contact");
                Console.WriteLine("2. [V]iew Contacts");
                Console.WriteLine("3. [S]earch Contact");
                Console.WriteLine("4. [E]dit Contact");
                Console.WriteLine("5. [D]elete Contact");
                Console.WriteLine("6. [O]Sort Contacts");
                Console.WriteLine("7. [X]Exit");
                Console.Write("Enter your choice: ");

                var choice = Console.ReadLine()?.ToLower();

                switch (choice)
                {
                    case "a":
                        Console.Write("Name: ");
                        string name = Console.ReadLine();
                        Console.Write("Phone: ");
                        string phone = Console.ReadLine();
                        Console.Write("Email: ");
                        string email = Console.ReadLine();
                        Console.Write("Notes: ");
                        string notes = Console.ReadLine();

                        service.AddContact(name, phone, email, notes);
                        break;

                    case "v":
                        var contacts = service.ViewContacts();
                        if (contacts.Count == 0)
                        {
                            Console.WriteLine("No contacts found.");
                        }
                        else
                        {
                            foreach (var c in contacts)
                            {
                                Console.WriteLine($"ID: {c.Id}");
                                Console.WriteLine($"Name: {c.Name}");
                                Console.WriteLine($"Phone: {c.Phone}");
                                Console.WriteLine($"Email: {c.Email}");
                                Console.WriteLine($"Notes: {c.Notes}");
                                Console.WriteLine();
                            }
                        }

                        break;

                    case "s":
                        Console.Write("Enter Name: ");
                        string searchName = Console.ReadLine();
                        var foundContacts = service.SearchContact(searchName);
                        if (foundContacts.Count == 0)
                        {
                            Console.WriteLine("No contacts found.");
                        }
                        else
                        {
                            foreach (var c in foundContacts)
                            {
                                Console.WriteLine($"ID: {c.Id}");
                                Console.WriteLine($"Name: {c.Name}");
                                Console.WriteLine($"Phone: {c.Phone}");
                                Console.WriteLine($"Email: {c.Email}");
                                Console.WriteLine($"Notes: {c.Notes}");
                            }
                        }

                        break;

                    case "e":
                        Console.Write("Enter Contact ID to edit: ");
                        if (Guid.TryParse(Console.ReadLine(), out Guid editId))
                        {
                            Console.Write("New Name: ");
                            string newName = Console.ReadLine();
                            Console.Write("New Phone: ");
                            string newPhone = Console.ReadLine();
                            Console.Write("New Email: ");
                            string newEmail = Console.ReadLine();
                            Console.Write("New Notes: ");
                            string newNotes = Console.ReadLine();

                            if (service.EditContact(editId, newName, newPhone, newEmail, newNotes))
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
                            Console.WriteLine("Invalid Guid.");
                        }

                        break;

                    case "d":
                        Console.Write("Enter Contact ID to delete: ");
                        if (Guid.TryParse(Console.ReadLine(), out Guid deleteId))
                        {
                            if (service.DeleteContact(deleteId))
                            {
                                Console.WriteLine("Deleted successfully.");
                            }
                            else
                            {
                                Console.WriteLine("Contact not found.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid Guid.");
                        }

                        break;

                    case "o":
                        var sortedContacts = service.SortContactsByName();
                        if (sortedContacts.Count == 0)
                        {
                            Console.WriteLine("No contacts to sort.");
                        }
                        else
                        {
                            Console.WriteLine("Contacts sorted by name:");
                            foreach (var c in sortedContacts)
                            {
                                Console.WriteLine($"ID: {c.Id}");
                                Console.WriteLine($"Name: {c.Name}");
                                Console.WriteLine($"Phone: {c.Phone}");
                                Console.WriteLine($"Email: {c.Email}");
                                Console.WriteLine($"Notes: {c.Notes}");
                            }
                        }

                        break;

                    case "x":
                        return;

                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
        }
    }
}