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
            Converters =
            {
                new JsonStringEnumConverter(),
                new DateOnlyJsonConverter(),
            },
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="JSONExpenseRepository"/> class.
        /// </summary>
        /// <param name="filepath">Filepath where the file for storage is created.</param>
        internal JSONExpenseRepository(string filepath)
        {
            this._filePath = filepath;
            this._expenses = this.LoadAll();
        }

        /// <inheritdoc/>
        public void AddExpense(Expense expense)
        {
            this._expenses.Add(expense);
            this.WriteAll();
        }

        /// <inheritdoc/>
        public List<Expense> GetAllExpense()
        {
            return this._expenses;
        }

        /// <inheritdoc/>
        public Expense? GetExpenseById(Guid id)
        {
            return this._expenses.FirstOrDefault(e => e.Id == id);
        }

        /// <inheritdoc/>
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

        /// <inheritdoc/>
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
        private void WriteAll()
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