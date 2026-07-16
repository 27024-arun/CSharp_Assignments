using System.Text.RegularExpressions;

namespace Assignment1.Services
{
    /// <summary>
    /// Helper class is used to perform service level help functions
    /// </summary>
    internal class Helper
    {
        /// <summary>
        /// AddedMessage indicates whether the message is added or not
        /// </summary>
        internal void AddedMessage()
        {
            Console.WriteLine("Contacts added Successfully");
        }

        /// <summary>
        /// Validation Method is used to validate the fields of contact
        /// </summary>
        /// <param name="name">It is the name of the contact</param>
        /// <param name="phone">It is the phone number of the contact</param>
        /// <param name="email">It is the email of the contact</param>
        /// <returns>Returns whether the all the fields are valid or not</returns>
        internal bool Validation(string name, string phone, string email)
        {
            string emailpattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (string.IsNullOrWhiteSpace(name) || name.Length < 2)
            {
                Console.WriteLine("Enter Valid Name");
                return false;
            }
            else if (string.IsNullOrWhiteSpace(phone) || phone.Length != 10)
            {
                Console.WriteLine("Enter Valid Phone Number");
                return false;
            }
            else if (email == string.Empty || !Regex.IsMatch(email, emailpattern))
            {
                Console.WriteLine("Enter Valid Email");
                return false;
            }

            return true;
        }
    }
}
