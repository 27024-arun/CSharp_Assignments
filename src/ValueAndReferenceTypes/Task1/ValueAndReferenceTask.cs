using ValueAndReferenceTypes.Models;

namespace ValueAndReferenceTypes.Task1
{
    /// <summary>
    /// Monitors the changes of value and reference type objects.
    /// </summary>
    internal static class ValueAndReferenceTask
    {
        /// <summary>
        /// Retrieves user choice for performing the task.
        /// </summary>
        public static void MemoryTask()
        {
            Student student = new Student();
            Teacher teacher = new ();
            while (true)
            {
                Console.Clear();
                Console.Write($@"
=========MEMORY TASK========
[V]alue Type Task
[R]eference Type Task
[E]xit to main menu
Enter Choice: ");
                ConsoleKey menuChoice = Console.ReadKey().Key;
                switch (menuChoice)
                {
                    case ConsoleKey.V:
                        Console.Clear();

                        Console.WriteLine($@"
==========Value Type Modification==========
Data Before Modification
Teacher's Name: {teacher.TeacherName}
Teacher's Age: {teacher.TeacherAge}");

                        ValueTypeModifier(teacher);

                        Console.WriteLine($@"
Data After Modification (Outside scope)
Teacher's Name: {teacher.TeacherName}
Teacher's Age: {teacher.TeacherAge}");

                        CleanConsole();
                        break;

                    case ConsoleKey.R:
                        Console.Clear();

                        Console.WriteLine($@"
==========Reference Type Modification==========
Data Before Modification
Student's Name: {student.StudentName}
Student's Age: {student.StudentAge}");

                        ReferenceTypeModifier(student);

                        Console.WriteLine($@"
Data After Modification (Outside scope)
Student's Name: {student.StudentName}
Student's Age: {student.StudentAge}");

                        CleanConsole();
                        break;

                    case ConsoleKey.E:
                        Console.WriteLine("\nReturning to main menu...");
                        Thread.Sleep(1200);
                        Console.Clear();
                        return;

                    default:
                        Console.WriteLine("\nEntered Wrong Data");
                        Thread.Sleep(1200);
                        Console.Clear();
                        break;
                }
            }
        }

        /// <summary>
        /// Retrieves data from user for reference type object and displays output.
        /// </summary>
        /// <param name="student">Details of the student.</param>
        private static void ReferenceTypeModifier(Student student)
        {
            Console.Write("\nEnter Student Name: ");
            student.StudentName = Console.ReadLine();

            Console.Write("Enter Student Age: ");
            int.TryParse(Console.ReadLine(), out int userAge);
            student.StudentAge = userAge;

            Console.WriteLine($@"
Data After Modification (Within Scope)
Student's Name: {student.StudentName}
Student's Age: {student.StudentAge}");
        }

        /// <summary>
        /// Retrieves data from user for value type object and displays output.
        /// </summary>
        /// <param name="teacher">Details of the teacher.</param>
        private static void ValueTypeModifier(Teacher teacher)
        {
            Console.Write("\nEnter Teacher Name: ");
            teacher.TeacherName = Console.ReadLine();

            Console.Write("Enter Teacher Age: ");
            int.TryParse(Console.ReadLine(), out int userAge);
            teacher.TeacherAge = userAge;

            Console.WriteLine($@"
Data After Modification (Within Scope)
Teacher's Name: {teacher.TeacherName}
Teacher's Age: {teacher.TeacherAge}");
        }

        private static void CleanConsole()
        {
            Console.WriteLine("\nEnter a key to return");
            Console.ReadKey();
        }
    }
}