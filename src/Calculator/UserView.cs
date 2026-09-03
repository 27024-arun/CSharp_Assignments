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
            double firstNumber;
            if (!this.GetData(out firstNumber, "First Number"))
            {
                this.CleanUpConsole();
                return;
            }

            double secondNumber;
            if (!this.GetData(out secondNumber, "Second Number"))
            {
                this.CleanUpConsole();
                return;
            }

            double additionResult = this._mathUtils.AddNumbers(firstNumber, secondNumber);
            Console.WriteLine($"\nThe Addition Result of {firstNumber} and {secondNumber} is {additionResult}");

            this.CleanUpConsole();
        }

        /// <summary>
        /// Collects data for subtraction and displays the result to user.
        /// </summary>
        internal void SubtractUserData()
        {
            Console.Clear();
            double firstNumber;
            if (!this.GetData(out firstNumber, "First Number"))
            {
                this.CleanUpConsole();
                return;
            }

            double secondNumber;
            if (!this.GetData(out secondNumber, "Second Number"))
            {
                this.CleanUpConsole();
                return;
            }

            double subtractionResult = this._mathUtils.SubtractNumbers(firstNumber, secondNumber);
            Console.WriteLine($"\nThe Subtraction Result of {firstNumber} and {secondNumber} is {subtractionResult}");

            this.CleanUpConsole();
        }

        /// <summary>
        /// Collects data for multiplication and displays the result to user.
        /// </summary>
        internal void MultiplyUserData()
        {
            Console.Clear();
            double firstNumber;
            if (!this.GetData(out firstNumber, "First Number"))
            {
                this.CleanUpConsole();
                return;
            }

            double secondNumber;
            if (!this.GetData(out secondNumber, "Second Number"))
            {
                this.CleanUpConsole();
                return;
            }

            double multiplicationResult = this._mathUtils.MultipleNumbers(firstNumber, secondNumber);
            Console.WriteLine($"\nThe Multiplication Result of {firstNumber} and {secondNumber} is {multiplicationResult}");

            this.CleanUpConsole();
        }

        /// <summary>
        /// Collects data for division and displays the result to user.
        /// </summary>
        internal void DivideUserData()
        {
            Console.Clear();
            double firstNumber;
            if (!this.GetData(out firstNumber, "First Number"))
            {
                this.CleanUpConsole();
                return;
            }

            double secondNumber;
            if (!this.GetData(out secondNumber, "Second Number"))
            {
                this.CleanUpConsole();
                return;
            }

            double divisionResult = this._mathUtils.DivideNumbers(firstNumber, secondNumber);
            Console.WriteLine($"\nThe Division Result of {firstNumber} and {secondNumber} is {divisionResult}");

            this.CleanUpConsole();
        }

        private bool GetData(out double data, string message)
        {
            int tries = 3;
            string? userInput;
            data = 0;
            for (int i = 1; i <= tries; i++)
            {
                Console.Write($"{message}: ");
                userInput = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(userInput) && double.TryParse(userInput, out data))
                {
                    return true;
                }
                else
                {
                    Console.WriteLine($"Data entered is invalid\n{3 - i} Tries left");
                }
            }

            return false;
        }

        private void CleanUpConsole()
        {
            Console.WriteLine($"\nEnter any key to return to main menu");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
