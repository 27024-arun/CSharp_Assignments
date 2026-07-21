namespace EmployeeHierarchy.Model
{
    /// <summary>
    /// Developer is the class that has the properties of Developer that inherits employee class
    /// </summary>
    internal class Developer : Employee
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Developer"/> class.
        /// Developer method is the constructor of the Developer class
        /// </summary>
        /// <param name="name">Name is the name of the developer</param>
        /// <param name="salary">Salary is the salary of the developer</param>
        public Developer(string name, double salary)
        {
            this.Name = name;
            this.Salary = salary;
        }

        /// <summary>
        /// CalculateBonus method calculated the bonus of the developer
        /// </summary>
        /// <returns>Returns the bonus of the developer</returns>
        public override double CalculateBonus()
        {
            return this.Salary * 0.10;
        }
    }
}