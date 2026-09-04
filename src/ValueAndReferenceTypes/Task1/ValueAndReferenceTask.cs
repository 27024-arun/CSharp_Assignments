using ValueAndReferenceTypes.Models;

namespace ValueAndReferenceTypes.Task1
{
    /// <summary>
    /// Monitors the changes of value and reference type objects.
    /// </summary>
    internal class ValueAndReferenceTask
    {
        /// <summary>
        /// Retrieves user choice for performing the task.
        /// </summary>
        public void MemoryTask()
        {
            Student student = new Student();
            Teacher teacher = new ();
            while (true)
            {
                Console.Clear();
                Console.Write(@"
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

                        Console.WriteLine("\n==========Value Type Modification==========");
                        Console.WriteLine("Data Before Modification");
                        Console.WriteLine($"Teacher's Name: {teacher.TeacherName}\nTeacher's Age: {teacher.TeacherAge}");

                        this.ValueTypeModifier(teacher);

                        Console.WriteLine("\nData After Modification (Outside scope)");
                        Console.WriteLine($"Teacher's Name: {teacher.TeacherName}\nTeacher's Age: {teacher.TeacherAge}");

                        this.CleanConsole();
                        break;
                    case ConsoleKey.R:
                        Console.Clear();

                        Console.WriteLine("\n==========Reference Type Modification==========");
                        Console.WriteLine("Data Before Modification");
                        Console.WriteLine($"Student's Name: {student.StudentName}\nStudent's Age: {student.StudentAge}");

                        this.ReferenceTypeModifier(student);

                        Console.WriteLine("\nData After Modification (Outside scope)");
                        Console.WriteLine($"Student's Name: {student.StudentName}\nStudent's Age: {student.StudentAge}");

                        this.CleanConsole();
                        break;

                    case ConsoleKey.E:
                        Console.Clear();
                        return;

                    default:
                        Console.Clear();
                        break;
                }
            }
        }

        /// <summary>
        /// Retrieves data from user for reference type object and displays output.
        /// </summary>
        /// <param name="student">Details of the student.</param>
        private void ReferenceTypeModifier(Student student)
        {
            Console.Write("\nEnter Student Name: ");
            student.StudentName = Console.ReadLine();

            Console.Write("Enter Student Age: ");
            int.TryParse(Console.ReadLine(), out int userAge);
            student.StudentAge = userAge;

            Console.WriteLine("\nData After Modification (Within Scope)");
            Console.WriteLine($"Student's Name: {student.StudentName}\nStudent's Age: {student.StudentAge}");
        }

        /// <summary>
        /// Retrieves data from user for value type object and displays output.
        /// </summary>
        /// <param name="teacher">Details of the teacher.</param>
        private void ValueTypeModifier(Teacher teacher)
        {
            Console.Write("\nEnter Teacher Name: ");
            teacher.TeacherName = Console.ReadLine();

            Console.Write("Enter Teacher Age: ");
            int.TryParse(Console.ReadLine(), out int userAge);
            teacher.TeacherAge = userAge;

            Console.WriteLine("\nData After Modification (Within Scope)");
            Console.WriteLine($"Teacher's Name: {teacher.TeacherName}\nTeacher's Age: {teacher.TeacherAge}");
        }

        private void CleanConsole()
        {
            Console.WriteLine("\nEnter a key to return");
            Console.ReadKey();
        }
    }
}