using System.Text.Json;
using System.Text.Json.Serialization;
using AdvancedExpenseTracker.Interfaces;
using AdvancedExpenseTracker.Models;
using FinanceTracker.Repository.Utility;

namespace AdvancedExpenseTracker.Repository
{
    /// <summary>
    /// ExpenseRepository class is the class where storage of expense data is defined.
    /// </summary>
    internal class JSONExpenseRepository : IExpenseRepository
    {
        private readonly List<Expense> _expenses = new List<Expense>();

        private readonly string _filePath = "Expenses.json";

        private readonly JsonSerializerOptions _options = new JsonSerializerOptions
        {
            WriteIndented = true,
            Converters = { new JsonStringEnumConverter() },
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="JSONExpenseRepository"/> class.
        /// </summary>
        internal JSONExpenseRepository()
        {
            this._options.Converters.Add(new DateOnlyJsonConverter());
            this._expenses = this.LoadAll();
        }

        /// <summary>
        /// AddExpense method is used to add expense details into the repository.
        /// </summary>
        /// <param name="expense">Expense is the details of expense.</param>
        public void AddExpense(Expense expense)
        {
            this._expenses.Add(expense);
            this.WriteAll();
        }

        /// <summary>
        /// GetAllExpense method is used to retrieve list of expense from repository.
        /// </summary>
        /// <returns>Returns the list of expense in repository.</returns>
        public List<Expense> GetAllExpense()
        {
            return this._expenses;
        }

        /// <summary>
        /// GetExpenseById method is used to retrieve a particular expense from repository.
        /// </summary>
        /// <param name="id">Id is the unique identifier of the expense.</param>
        /// <returns>Returns the expense from repository.</returns>
        public Expense? GetExpenseById(Guid id)
        {
            return this._expenses.FirstOrDefault(e => e.Id == id);
        }

        /// <summary>
        /// UpdateExpense method is used to update the expense details in the repository.
        /// </summary>
        /// <param name="newExpense">Expense is the expense details.</param>
        /// <returns>Returns whether the expense is updated or not.</returns>
        public bool UpdateExpense(Expense newExpense)
        {
            foreach (var expense in this._expenses)
            {
                if (expense.Id == newExpense.Id)
                {
                    expense.Amount = newExpense.Amount;
                    expense.Date = newExpense.Date;
                    expense.Category = newExpense.Category;
                }
            }

            this.WriteAll();
            return true;
        }

        /// <summary>
        /// DeleteExpense method is used to delete a particular expense in the repository.
        /// </summary>
        /// <param name="id">Id is the unique identifier of the expense.</param>
        /// <returns>Returns whether the expense is deleted or not.</returns>
        public bool DeleteExpense(Guid id)
        {
            Expense? expense = this._expenses.FirstOrDefault(entry => entry.Id == id);
            if (expense == null)
            {
                return false;
            }

            this._expenses.Remove(expense);
            this.WriteAll();
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

            return this._expenses.Count == 0;
        }

        /// <summary>
        /// GetTotalExpense method is used get the expense total.
        /// </summary>
        /// <returns>Returns the expense total.</returns>
        internal decimal GetTotalExpense()
        {
            return this._expenses.Sum(e => e.Amount);
        }

        /// <summary>
        /// ExpenseCount method is used to return the number of expenses in the repository.
        /// </summary>
        /// <returns>Returns the number of expenses in the repository.</returns>
        internal int ExpenseCount()
        {
            return this._expenses.Count;
        }

        /// <summary>
        /// WriteAll method is used rewrite the contents of the CSV file.
        /// </summary>
        /// <param name="expenses">Expenses is the list of expenses.</param>
        internal void WriteAll()
        {
            string json = JsonSerializer.Serialize(this._expenses, this._options);
            File.WriteAllText(this._filePath, json);
        }

        private List<Expense> LoadAll()
        {
            if (!File.Exists(this._filePath))
            {
                return new List<Expense>();
            }

            string json = File.ReadAllText(this._filePath);
            return JsonSerializer.Deserialize<List<Expense>>(json, this._options) ?? new List<Expense>();
        }
    }
}