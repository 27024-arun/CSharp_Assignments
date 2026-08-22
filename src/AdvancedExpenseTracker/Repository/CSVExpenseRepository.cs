using AdvancedExpenseTracker.Interfaces;
using AdvancedExpenseTracker.Models;

namespace AdvancedExpenseTracker.Repository
{
    /// <summary>
    /// ExpenseRepository class is the class where storage of expense data is defined.
    /// </summary>
    internal class CSVExpenseRepository : IExpenseRepository
    {
        private readonly string _filePath;

        /// <summary>
        /// Initializes a new instance of the <see cref="CSVExpenseRepository"/> class.
        /// </summary>
        /// <param name="filePath">Filepath where the file for storage is created.</param>
        internal CSVExpenseRepository(string filePath)
        {
            this._filePath = filePath;
        }

        /// <summary>
        /// AddExpense method is used to add expense details into the repository.
        /// </summary>
        /// <param name="expense">Expense is the details of expense.</param>
        public void AddExpense(Expense expense)
        {
            File.AppendAllText(this._filePath, $"{expense.Id},{expense.Amount},{expense.Date},{expense.Category}\n");
        }

        /// <summary>
        /// GetAllExpense method is used to retrieve list of expense from repository.
        /// </summary>
        /// <returns>Returns the list of expense in repository.</returns>
        public List<Expense> GetAllExpense()
        {
            string[] fileData = File.ReadAllLines(this._filePath);
            List<Expense> expenses = new List<Expense>();
            foreach (string line in fileData)
            {
                string[] lineData = line.Split(",");
                Enum.TryParse<ExpenseCategory>(lineData[3], out ExpenseCategory category);
                Expense expense = new Expense()
                {
                    Id = Guid.Parse(lineData[0]),
                    Amount = decimal.Parse(lineData[1]),
                    Date = DateOnly.Parse(lineData[2]),
                    Category = category,
                };
                expenses.Add(expense);
            }

            return expenses;
        }

        /// <summary>
        /// GetExpenseById method is used to retrieve a particular expense from repository.
        /// </summary>
        /// <param name="id">Id is the unique identifier of the expense.</param>
        /// <returns>Returns the expense from repository.</returns>
        public Expense? GetExpenseById(Guid id)
        {
            List<Expense> expenses = this.GetAllExpense();
            return expenses.FirstOrDefault(e => e.Id == id);
        }

        /// <summary>
        /// UpdateExpense method is used to update the expense details in the repository.
        /// </summary>
        /// <param name="newExpense">Expense is the expense details.</param>
        /// <returns>Returns whether the expense is updated or not.</returns>
        public bool UpdateExpense(Expense newExpense)
        {
            List<Expense> expenses = this.GetAllExpense();
            foreach (var expense in expenses)
            {
                if (expense.Id == newExpense.Id)
                {
                    expense.Amount = newExpense.Amount;
                    expense.Date = newExpense.Date;
                    expense.Category = newExpense.Category;
                }
            }

            this.WriteAll(expenses);
            return true;
        }

        /// <summary>
        /// DeleteExpense method is used to delete a particular expense in the repository.
        /// </summary>
        /// <param name="id">Id is the unique identifier of the expense.</param>
        /// <returns>Returns whether the expense is deleted or not.</returns>
        public bool DeleteExpense(Guid id)
        {
            List<Expense> expenses = this.GetAllExpense();
            int index = expenses.FindIndex(x => x.Id == id);
            if (index == -1)
            {
                return false;
            }

            expenses.RemoveAt(index);
            this.WriteAll(expenses);
            return true;
        }

        /// <summary>
        /// IsExpenseEmpty method is used to check whether the expense is empty.
        /// </summary>
        /// <returns>Returns whether the income is empty or not.</returns>
        internal bool IsExpenseEmpty()
        {
            if (!File.Exists(this._filePath))
            {
                return true;
            }

            return File.ReadAllLines(this._filePath).Length == 0;
        }

        /// <summary>
        /// GetTotalExpense method is used get the expense total.
        /// </summary>
        /// <returns>Returns the expense total.</returns>
        internal decimal GetTotalExpense()
        {
            List<Expense> expenses = this.GetAllExpense();
            return expenses.Sum(e => e.Amount);
        }

        /// <summary>
        /// ExpenseCount method is used to return the number of expenses in the repository.
        /// </summary>
        /// <returns>Returns the number of expenses in the repository.</returns>
        internal int ExpenseCount()
        {
            return File.ReadAllLines(this._filePath).Length;
        }

        /// <summary>
        /// WriteAll method is used rewrite the contents of the CSV file.
        /// </summary>
        /// <param name="expenses">Expenses is the list of expenses.</param>
        private void WriteAll(List<Expense> expenses)
        {
            List<string> result = new List<string>();
            foreach (var expense in expenses)
            {
                result.Add($"{expense.Id},{expense.Amount},{expense.Date},{expense.Category}");
            }

            File.WriteAllLines(this._filePath, result);
        }
    }
}