namespace Assignments
{
    internal class DictionaryModifier
    {
        private static Dictionary<string, int> _students = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

        private static int _maxStudents = 5;

        internal static void ModifyDictionary()
        {
            AddStudent();

            DisplayStudent();

            DeleteStudent();

            DisplayStudent();

            CleanConsole();
        }

        private static void DeleteStudent()
        {
            Console.WriteLine("\n============Delete Student============");
            string studentName = GetStudentName("Student Name");
            if (_students.ContainsKey(studentName))
            {
                _students.Remove(studentName);
                Console.WriteLine("Student details are deleted");
            }
            else
            {
                Console.WriteLine("Student details not available");
            }
        }

        private static void DisplayStudent()
        {
            Console.WriteLine("\n============Student Details============");
            foreach (var student in _students)
            {
                Console.WriteLine($"\nStudent Name: {student.Key}\nStudent Mark: {student.Value}");
            }
        }

        private static void AddStudent()
        {
            Console.WriteLine("\n============Enter student details============");
            for (int index = 1; index <= _maxStudents; index++)
            {
                string studentName = GetStudentName($"\nStudent {index} Name");
                int studentMark = GetStudentMark($"Student {index} Mark");
                if (!_students.ContainsKey(studentName))
                {
                    _students.Add(studentName, studentMark);
                }
                else
                {
                    Console.WriteLine("Student data already exists");
                }
            }
        }

        private static int GetStudentMark(string message)
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
                    return mark;
                }
                else
                {
                    Console.WriteLine($"Data entered is invalid\n{3 - iterator} Tries left");
                }
            }

            Console.WriteLine($"Default mark ({defaultMark}) is returned");
            return defaultMark;
        }

        private static string GetStudentName(string message)
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
                    return userInput.Trim();
                }
                else
                {
                    Console.WriteLine($"Data entered is invalid\n{3 - iterator} Tries left");
                }
            }

            Console.WriteLine($"Default name ({defaultName}) is returned");
            return defaultName;
        }

        private static void CleanConsole()
        {
            Console.WriteLine("\nEnter a key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}