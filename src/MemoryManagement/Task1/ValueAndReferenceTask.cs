using MemoryManagement.Task1.Models;

namespace MemoryManagement.Task1
{
    internal class ValueAndReferenceTask
    {
        public void MemoryTask()
        {
            Student student = new Student();
            Teacher teacher = new ();

            Console.WriteLine()
            this.ValueTypeModifier(teacher);
            this.ReferenceTypeModifier(student);
            Console.WriteLine("");
        }

        private void ReferenceTypeModifier(Student student)
        {
            Console.WriteLine("");
            student.StudentName = "Arun";
            student.StudentAge = 29;
        }

        private void ValueTypeModifier(Teacher teacher)
        {
            teacher.TeacherName = "Rosy";
            teacher.TeacherAge = 28;
        }
    }
}
