namespace MemoryManagement.Task1.Models
{
    internal struct Teacher
    {
        public Teacher()
        {
        }

        public Teacher(string TeacherName, int TeacherAge)
        {
            this.TeacherName = TeacherName;
            this.TeacherAge = TeacherAge;
        }

        public string TeacherName { get; set; }

        public int TeacherAge { get; set; }
    }
}
