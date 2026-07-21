using EmployeeHierarchy.Model;

namespace EmployeeHierarchy.Services
{
    /// <summary>
    /// EmployeeServices class is the service level of the EmployeeHierarchy
    /// </summary>
    internal class EmployeeServices
    {
        /// <summary>
        /// CreateEmployee class is used to create employe
        /// </summary>
        /// <param name="employeeType">EmployeeType refers to Manager or Developer</param>
        /// <param name="name">Name is the name of the employee</param>
        /// <param name="salary">Salary is the salary of the employee</param>
        /// <returns>Returns the created employee properties</returns>
        public Employee CreateEmployee(string employeeType, string name, double salary)
        {
            if (employeeType == "manager")
            {
                return new Manager(name, salary);
            }

            return new Developer(name, salary);
        }

        /// <summary>
        /// GetEmployeeDetails returns the details of employee
        /// </summary>
        /// <param name="employee">Employee is the employee property</param>
        /// <returns>Returns the format of details to be displayed</returns>
        public string GetEmployeeDetails(Employee employee)
        {
            return $"Name     : {employee.Name}\n" + $"Position : {employee.GetType().Name}\n" + $"Salary   : {employee.Salary}\n" + $"Bonus    : {employee.CalculateBonus()}";
        }
    }
}