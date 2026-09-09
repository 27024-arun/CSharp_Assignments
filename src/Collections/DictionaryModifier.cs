namespace Collections
{
    /// <summary>
    /// Performs display and manipulation of dictionary data.
    /// </summary>
    /// <typeparam name="TKey">Key of the dictionary.</typeparam>
    /// <typeparam name="TValue">Value of the dictionary</typeparam>
    internal class DictionaryModifier<TKey, TValue>
        where TKey : class
    {
        private static Dictionary<TKey, TValue> _students = new Dictionary<TKey, TValue>();

        private static int _maxStudents = 5;

        /// <summary>
        /// Calls methods to modify the dictionary.
        /// </summary>
        internal static void ModifyDictionary()
        {
            AddStudent();

            DisplayStudent();

            DeleteStudent();

            DisplayStudent();

            Helper.CleanConsole();
        }

        /// <summary>
        /// Deletes the student data in the dictionary.
        /// </summary>
        private static void DeleteStudent()
        {
            Console.WriteLine("\n============Delete Student============");
            TKey studentName = GetStudentName("Student Name");
            if (_students.ContainsKey(studentName)
            {
                _students.Remove(studentName);
                Helper.WriteColored("Student details are deleted", ConsoleColor.Green);
            }
            else
            {
                Helper.WriteColored("Student details not available", ConsoleColor.Red);
            }
        }

        /// <summary>
        /// Displays the student data in the dictionary.
        /// </summary>
        private static void DisplayStudent()
        {
            Console.WriteLine("\n============Student Details============");
            foreach (var student in _students)
            {
                Console.WriteLine($"\nStudent Name: {student.Key}\nStudent Mark: {student.Value}");
            }
        }

        /// <summary>
        /// Adds student data to the dictionary.
        /// </summary>
        private static void AddStudent()
        {
            Console.WriteLine("\n============Enter student details============");
            for (int index = 1; index <= _maxStudents; index++)
            {
                TKey studentName = GetStudentName($"\nStudent {index} Name");
                TValue studentMark = GetStudentMark($"Student {index} Mark");
                if (!_students.ContainsKey(studentName))
                {
                    _students.Add(studentName, studentMark);
                    Helper.WriteColored($"Student data is added.", ConsoleColor.Green);
                }
                else
                {
                    Helper.WriteColored("Student data already exists", ConsoleColor.Red);
                }
            }
        }

        /// <summary>
        /// Retrieves marks of the student and performs validation.
        /// </summary>
        /// <param name="message">Message to be displayed to user for retrieving data.</param>
        /// <returns>Value of the dictionary.</returns>
        private static TValue GetStudentMark(string message)
        {
            int defaultMark = 100;
            int maxTries = 3;
            string? userInput;
            for (int iterator = 1; iterator <= maxTries; iterator++)
            {
                Console.Write($"{message}: ");
                userInput = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(userInput) && int.TryParse(userInput, out int mark) && mark >= 0 && mark <= 100)
                {
                    return (TValue)(object)mark;
                }
                else
                {
                    Helper.WriteColored($"Data entered is invalid\n{3 - iterator} Tries left (Range: 0 - 100)", ConsoleColor.Red);
                }
            }

            Helper.WriteColored($"Default mark ({defaultMark}) is returned", ConsoleColor.Yellow);
            return (TValue)(object)defaultMark;
        }

        /// <summary>
        /// Retrieves the name of the student and performs validation.
        /// </summary>
        /// <param name="message">Message to be displayed to user for retrieving data.</param>
        /// <returns>Key of the dictionary.</returns>
        private static TKey GetStudentName(string message)
        {
            string defaultName = "Parker";
            int maxTries = 3;
            string? userInput;
            for (int iterator = 1; iterator <= maxTries; iterator++)
            {
                Console.Write($"{message}: ");
                userInput = Console.ReadLine();
                if (!string.IsNullOrEmpty(userInput))
                {
                    return (TKey)(object)userInput;
                }
                else
                {
                    Helper.WriteColored($"Data entered is invalid\n{3 - iterator} Tries left", ConsoleColor.Red);
                }
            }

            Helper.WriteColored($"Default name ({defaultName}) is returned", ConsoleColor.Yellow);
            return (TKey)(object)defaultName;
        }
    }
}