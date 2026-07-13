using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Assignments
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Contact Manager!");
            List<(string name, string phone, string email, string notes)> contacts = new List<(string, string, string, string)>();
            bool isNeededToReOccur = false;
            while (!isNeededToReOccur)
            {
                Console.WriteLine("1.[A]dd new Contact\n2.[V]iew Contact\n3.[D]elete new Contact\n4.[E]dit Contact\n5.[S]earch Contact\n6.[X]Exit");
                var userChoice = Console.ReadLine();
                switch (userChoice)
                {
                    case "A":
                    case "a":
                        AddContactNumber(contacts);
                        break;
                    case "V":
                    case "v":
                        ViewContact(contacts);
                        break;
                    case "D":
                    case "d":
                        DeleteContact(contacts);
                        break;
                    case "E":
                    case "e":
                        EditContact(contacts);
                        break;
                    case "S":
                    case "s":
                        SearchContact(contacts);
                        break;
                    case "X":
                    case "x":
                        isNeededToReOccur = true;
                        break;
                    default:
                        Console.WriteLine("Enter a Valid Choice\n");
                        break;
                }
            }
        }

        private static void SearchContact(List<(string name, string phone, string email, string notes)> contacts)
        {
            bool isIndexCorrect = false;

            while (!isIndexCorrect)
            {
                Console.WriteLine($"Select the index of the contact you want to search:");
                var userInput = Console.ReadLine();

                if (int.TryParse(userInput, out int index) && index >= 1 && index <= contacts.Count)
                {
                    var contact = contacts[index - 1];
                    Console.WriteLine($" Name : {contact.name}");
                    Console.WriteLine($" Phone: {contact.phone}");
                    Console.WriteLine($" Email: {contact.email}");
                    Console.WriteLine($" Notes: {contact.notes}");
                    Console.WriteLine();
                    isIndexCorrect = true;
                }
                else
                {
                    Console.WriteLine("Invalid index. Please try again.");
                }
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

        private static void DeleteContact(List<(string, string, string, string)> contacts)
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

        private static void AddContactNumber(List<(string, string, string, string)> contacts)
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

        private static void ViewContact(List<(string, string, string, string)> contacts)
        {
            for (int i = 0; i < contacts.Count; i++)
            {
                (string, string, string, string) contact = contacts[i];
                Console.WriteLine($"[{i + 1}]Name: {contact.Item1}");
                Console.WriteLine($" Phone: {contact.Item2}");
                Console.WriteLine($" Email: {contact.Item3}");
                Console.WriteLine($" Notes: {contact.Item4}");
                Console.WriteLine();
            }
        }
    }
}