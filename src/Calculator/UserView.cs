using CalculatorUtility;

namespace Calculator
{
    /// <summary>
    /// Helps to retrieve data from user and displays the processed result.
    /// </summary>
    internal class UserView
    {
        private readonly MathUtils _mathUtils;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserView"/> class.
        /// </summary>
        /// <param name="mathUtils">Utilities of mathematical operations.</param>
        public UserView(MathUtils mathUtils)
        {
            this._mathUtils = mathUtils;
        }

        /// <summary>
        /// Collects data for addition and displays the result to user.
        /// </summary>
        internal void AddUserData()
        {
            Console.Clear();
            Console.Write("\nEnter First Number: ");
            double.TryParse(Console.ReadLine(), out double firstNumber);
            Console.Write("Enter Second Number: ");
            double.TryParse(Console.ReadLine(), out double secondNumber);

            double additionResult = this._mathUtils.AddNumbers(firstNumber, secondNumber);
            Console.WriteLine($"\nThe Addition Result of {firstNumber} and {secondNumber} is {additionResult}");

            Console.WriteLine($"\nEnter any key to return to main menu");
            Console.ReadKey();
            Console.Clear();
        }

        /// <summary>
        /// Collects data for subtraction and displays the result to user.
        /// </summary>
        internal void SubtractUserData()
        {
            Console.Clear();
            Console.Write("\nEnter First Number: ");
            double.TryParse(Console.ReadLine(), out double firstNumber);
            Console.Write("Enter Second Number: ");
            double.TryParse(Console.ReadLine(), out double secondNumber);

            double subtractionResult = this._mathUtils.SubtractNumbers(firstNumber, secondNumber);
            Console.WriteLine($"\nThe Subtraction Result of {firstNumber} and {secondNumber} is {subtractionResult}");

            Console.WriteLine($"\nEnter any key to return to main menu");
            Console.ReadKey();
            Console.Clear();
        }

        /// <summary>
        /// Collects data for multiplication and displays the result to user.
        /// </summary>
        internal void MultiplyUserData()
        {
            Console.Clear();
            Console.Write("\nEnter First Number: ");
            double.TryParse(Console.ReadLine(), out double firstNumber);
            Console.Write("Enter Second Number: ");
            double.TryParse(Console.ReadLine(), out double secondNumber);

            double multiplicationResult = this._mathUtils.MultipleNumbers(firstNumber, secondNumber);
            Console.WriteLine($"\nThe Multiplication Result of {firstNumber} and {secondNumber} is {multiplicationResult}");

            Console.WriteLine($"\nEnter any key to return to main menu");
            Console.ReadKey();
            Console.Clear();
        }

        /// <summary>
        /// Collects data for division and displays the result to user.
        /// </summary>
        internal void DivideUserData()
        {
            Console.Clear();
            Console.Write("\nEnter First Number: ");
            double.TryParse(Console.ReadLine(), out double firstNumber);
            Console.Write("Enter Second Number: ");
            double.TryParse(Console.ReadLine(), out double secondNumber);
            if (secondNumber is 0)
            {
                Console.WriteLine("\nEntered data is not valid (Enter value greater than 0)");
                goto exit;
            }

            double divisionResult = this._mathUtils.DivideNumbers(firstNumber, secondNumber);
            Console.WriteLine($"\nThe Division Result of {firstNumber} and {secondNumber} is {divisionResult}");

        exit:
            Console.WriteLine($"\nEnter any key to return to main menu");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
