namespace EmployeeHierarchy.Model
{
    /// <summary>
    /// Employee is the class that has employee properties.
    /// </summary>
    internal abstract class Employee
    {
        /// <summary>
        /// Gets or Sets the name of the employee.
        /// </summary>
        /// <value>
        /// Name of the employee
        /// </value>
        public string? Name { get; set; }

        /// <summary>
        /// Gets or Sets the salary of the employee.
        /// </summary>
        /// <value>
        /// Salary of the employee
        /// </value>
        public double Salary { get; set; }

        /// <summary>
        /// CalculateBonus is the abstract method of bonus calculation.
        /// </summary>
        /// <returns>Returns the bonus of the emplyee</returns>
        public abstract double CalculateBonus();
    }
}