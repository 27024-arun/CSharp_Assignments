using System.Text.RegularExpressions;

namespace Assignment1.Services
{
    /// <summary>
    /// Helper class is used to perform service level help functions.
    /// </summary>
    public class Helper
    {
        /// <summary>
        /// AddedMessage indicates whether the message is added or not.
        /// </summary>
        internal void AddedMessage()
        {
            Console.WriteLine("Contacts added Successfully.");
        }

        /// <summary>
        /// NameValidation method is used to validate whether the entered name is correct or not.
        /// </summary>
        /// <param name="name">Name is the name of the user</param>
        /// <returns>Returns whether the name is valid or not</returns>
        internal bool NameValidation(string name)
        {
            if (string.IsNullOrWhiteSpace(name) || name.Length <= 2)
            {
                Console.WriteLine("Enter Valid Name (i.e: Peter).");
                return false;
            }

            return true;
        }

        /// <summary>
        /// PhoneValidation method is used to validate whether the entered phone number is correct or not.
        /// </summary>
        /// <param name="phone">Phone is the phone number of the user</param>
        /// <returns>Returns whether the phone is valid or not</returns>
        internal bool PhoneValidation(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone) || phone.Length != 10)
            {
                Console.WriteLine("Enter Valid Phone Number (i.e: 9876543210).");
                return false;
            }

            return true;
        }

        /// <summary>
        /// EmailValidation method is used to validate whether the entered email is correct or not.
        /// </summary>
        /// <param name="email">Email is the email id number of the user</param>
        /// <returns>Returns whether the email is valid or not</returns>
        internal bool EmailValidation(string email)
        {
            string emailpattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (email == string.Empty || !Regex.IsMatch(email, emailpattern))
            {
                Console.WriteLine("Enter Valid Email (i.e: example@gmail.com)");
                return false;
            }

            return true;
        }
    }
}
