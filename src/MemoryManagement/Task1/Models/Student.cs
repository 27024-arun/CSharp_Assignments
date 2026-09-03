namespace MemoryManagement.Task1.Models
{

    internal class Student
    {
        public Student()
        {
        }

        public Student(string StudentName, int StudentAge)
        {
            this.StudentName = StudentName;
            this.StudentAge = StudentAge;
        }

        public string StudentName { get; set; }

        public int StudentAge { get; set; }
    }
}
