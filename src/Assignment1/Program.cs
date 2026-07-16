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
                        string? name = Console.ReadLine();
                        Console.Write("Phone: ");
                        string? phone = Console.ReadLine();
                        Console.Write("Email: ");
                        string? email = Console.ReadLine();
                        Console.Write("Notes: ");
                        string? notes = Console.ReadLine();
                        if (name != null && phone != null && email != null && notes != null)
                        {
                            service.AddContact(name, phone, email, notes);
                        }

                        break;

                    case "v":
                        var contacts = service.ViewContacts();
                        if (contacts.Count == 0)
                        {
                            Console.WriteLine("No contacts found.");
                        }
                        else
                        {
                            int i = 0;
                            foreach (var c in contacts)
                            {
                                Console.Write($"{++i}. Name: {c.Name} ");
                                Console.Write($"Phone: {c.Phone} ");
                                Console.Write($"Email: {c.Email} ");
                                Console.Write($"Notes: {c.Notes} ");
                                Console.WriteLine();
                            }
                        }

                        break;

                    case "s":
                        Console.Write("Enter Name: ");
                        string? searchName = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(searchName))
                        {
                            Console.WriteLine("The Name is not valid");
                        }
                        else
                        {
                            var foundContacts = service.SearchContact(searchName);
                            if (foundContacts.Count == 0)
                            {
                                Console.WriteLine("No contacts found.");
                            }
                            else
                            {
                                foreach (var c in foundContacts)
                                {
                                    Console.WriteLine($"Name: {c.Name}");
                                    Console.WriteLine($"Phone: {c.Phone}");
                                    Console.WriteLine($"Email: {c.Email}");
                                    Console.WriteLine($"Notes: {c.Notes}");
                                }
                            }
                        }

                        break;

                    case "e":
                        Console.Write("Enter Sno of the contact to edit : ");
                        var contactlist = service.ViewContacts();
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

                            if (!string.IsNullOrWhiteSpace(newName) && !string.IsNullOrWhiteSpace(newPhone) && !string.IsNullOrWhiteSpace(newEmail) && !string.IsNullOrWhiteSpace(newNotes) && service.EditContact(contactlist[index].Id, newName, newPhone, newEmail, newNotes))
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
                        Console.Write("Enter Contact Sno of the contact to delete: ");
                        var contactlists = service.ViewContacts();
                        if (int.TryParse(Console.ReadLine(), out int indexValue) && indexValue > 0 && indexValue <= contactlists.Count())
                        {
                            indexValue -= 1;
                            if (service.DeleteContact(contactlists[indexValue].Id))
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
                        service.SortContactsByName();
                        var contact = service.ViewContacts();
                        if (contact.Count == 0)
                        {
                            Console.WriteLine("No contacts found.");
                        }
                        else
                        {
                            int i = 0;
                            foreach (var c in contact)
                            {
                                Console.Write($"{++i}. Name: {c.Name} ");
                                Console.Write($"Phone: {c.Phone} ");
                                Console.Write($"Email: {c.Email} ");
                                Console.Write($"Notes: {c.Notes} ");
                                Console.WriteLine();
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