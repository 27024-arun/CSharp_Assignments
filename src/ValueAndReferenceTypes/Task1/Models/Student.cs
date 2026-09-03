namespace ValueAndReferenceTypes.Task1.Models
{
    internal class Student
    {
        public Student()
        {
        }

        public Student(string studentName, int studentAge)
        {
            this.StudentName = studentName;
            this.StudentAge = studentAge;
        }

        public string StudentName { get; set; }

        public int StudentAge { get; set; }
    }
}
