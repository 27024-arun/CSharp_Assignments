using EmployeeHierarchy.Model;
using EmployeeHierarchy.Services;

namespace EmployeeHierarchy.View
{
    /// <summary>
    /// EmployeeView class is the view level of the EmployeeHierarchy.
    /// </summary>
    internal class EmployeeView
    {
        private readonly EmployeeServices _service;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeView"/> class.
        /// EmployeeView method is the constructor of the View level class
        /// </summary>
        public EmployeeView()
        {
            this._service = new EmployeeServices();
        }

        /// <summary>
        /// ViewRun method is the view level of the program.
        /// </summary>
        /// <returns>Returns whether the user wants to exit or not</returns>
        public bool ViewRun()
        {
            try
            {
                Console.WriteLine("\nEnter Employee Type:");
                Console.WriteLine("Press M -> Manager / D -> Developer / E -> Exit:");

                string? employeeType = Console.ReadLine()?.ToLower();
                if (employeeType == "e")
                {
                    return false;
                }

                Console.Write("Enter Name: ");
                string? name = Console.ReadLine();
                if (name == null)
                {
                    Console.WriteLine("Name cannot be null");
                    return true;
                }

                Console.Write("Enter Salary: ");
                string? salaryInput = Console.ReadLine();
                double.TryParse(salaryInput, out double salary);
                Employee employee;

                if (employeeType == "m")
                {
                    employee = this._service.CreateEmployee("manager", name, salary);
                }
                else if (employeeType == "d")
                {
                    employee = this._service.CreateEmployee("developer", name, salary);
                }
                else
                {
                    Console.WriteLine("Invalid Employee Type.");
                    return true;
                }

                Console.WriteLine();
                Console.WriteLine(this._service.GetEmployeeDetails(employee));
                return true;
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid Salary.");
                return true;
            }
        }
    }
}