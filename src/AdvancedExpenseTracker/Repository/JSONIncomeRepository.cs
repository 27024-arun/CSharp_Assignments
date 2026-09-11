using System.Text.Json;
using System.Text.Json.Serialization;
using AdvancedExpenseTracker.Interfaces;
using AdvancedExpenseTracker.Models;
using FinanceTracker.Repository.Utility;

namespace AdvancedExpenseTracker.Repository
{
    /// <summary>
    /// IncomeRepository class is the class where storage of income data is defined.
    /// </summary>
    internal class JSONIncomeRepository : IIncomeRepository
    {
        private readonly List<Income> _incomes;

        private readonly string _filepath;

        private readonly JsonSerializerOptions _options = new JsonSerializerOptions()
        {
            WriteIndented = true,
            Converters =
            {
                new JsonStringEnumConverter(),
                new DateOnlyJsonConverter(),
            },
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="JSONIncomeRepository"/> class.
        /// </summary>
        /// <param name="filepath">Filepath where the file for storage is created.</param>
        internal JSONIncomeRepository(string filepath)
        {
            this._filepath = filepath;
            this._incomes = this.LoadAll();
        }

        /// <inheritdoc/>
        public void AddIncome(Income income)
        {
            this._incomes.Add(income);
            this.WriteAll();
        }

        /// <inheritdoc/>
        public bool DeleteIncome(Guid id)
        {
            Income? income = this.GetIncomeById(id);
            if (income == null)
            {
                return false;
            }

            this._incomes.Remove(income);
            this.WriteAll();
            return true;
        }

        /// <inheritdoc/>
        public List<Income> GetAllIncome()
        {
            return this._incomes;
        }

        /// <inheritdoc/>
        public Income? GetIncomeById(Guid id)
        {
            return this._incomes.FirstOrDefault(income => income.Id == id);
        }

        /// <inheritdoc/>
        public bool UpdateIncome(Income newIncome)
        {
            foreach (Income income in this._incomes)
            {
                if (income.Id == newIncome.Id)
                {
                    income.Amount = newIncome.Amount;
                    income.Date = newIncome.Date;
                    income.Category = newIncome.Category;
                }
            }

            this.WriteAll();
            return true;
        }

        /// <summary>
        /// IsIncomeEmpty method is used to check whether the income is empty.
        /// </summary>
        /// <returns>Returns whether the income is empty or not.</returns>
        internal bool IsIncomeEmpty()
        {
            if (!File.Exists(this._filepath))
            {
                return false;
            }

            return this._incomes.Count == 0;
        }

        /// <summary>
        /// GetTotalIncome method is used get the income total.
        /// </summary>
        /// <returns>Returns the income total.</returns>
        internal decimal GetTotalIncome()
        {
            return this._incomes.Sum(income => income.Amount);
        }

        /// <summary>
        /// IncomeCount method is used to return the number of income in the repository.
        /// </summary>
        /// <returns>Returns the number of incomes.</returns>
        internal int IncomeCount()
        {
            return this._incomes.Count;
        }

        private void WriteAll()
        {
            string json = JsonSerializer.Serialize(this._incomes, this._options);
            File.WriteAllText(this._filepath, json);
        }

        private List<Income> LoadAll()
        {
            if (!File.Exists(this._filepath))
            {
                return new List<Income>();
            }

            string json = File.ReadAllText(this._filepath);
            return JsonSerializer.Deserialize<List<Income>>(json, this._options) ?? new List<Income>();
        }
    }
}
