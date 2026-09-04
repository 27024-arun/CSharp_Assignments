namespace ValueAndReferenceTypes.Models
{
    /// <summary>
    /// Model defining properties of the Student.
    /// </summary>
    internal class Student
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Student"/> class.
        /// </summary>
        public Student()
        {
            this.StudentName = string.Empty;
            this.StudentAge = 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Student"/> class.
        /// </summary>
        /// <param name="studentName">Name of the student.</param>
        /// <param name="studentAge">Age of the student.</param>
        public Student(string studentName, int studentAge)
        {
            this.StudentName = studentName;
            this.StudentAge = studentAge;
        }

        /// <summary>
        /// Gets or Sets the name of the student.
        /// </summary>
        /// <value>Name of the student.</value>
        public string StudentName { get; set; }

        /// <summary>
        /// Gets or Sets the age of the student.
        /// </summary>
        /// <value>Age of the student.</value>
        public int StudentAge { get; set; }
    }
}
