namespace EmployeeHierarchy.Model
{
    /// <summary>
    /// Manager is the class that has the properties of the manager and inherits the class Employee
    /// </summary>
    internal class Manager : Employee
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Manager"/> class.
        /// Manager method is the constructor of the Manager class
        /// </summary>
        /// <param name="name">Name is the name of the Manager</param>
        /// <param name="salary">Salary is the salary of the manager</param>
        public Manager(string name, double salary)
        {
            this.Name = name;
            this.Salary = salary;
        }

        /// <summary>
        /// CalculateBonus method calculates the bonus of the Manager
        /// </summary>
        /// <returns>Returns the bonus of the manager</returns>
        public override double CalculateBonus()
        {
            return this.Salary * 0.20;
        }
    }
}