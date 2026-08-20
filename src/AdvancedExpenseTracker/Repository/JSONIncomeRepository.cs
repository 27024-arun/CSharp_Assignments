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

        private readonly string _filepath = "Income.json";

        private readonly JsonSerializerOptions _options = new JsonSerializerOptions()
        {
            WriteIndented = true,
            Converters = { new JsonStringEnumConverter() },
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="JSONIncomeRepository"/> class.
        /// </summary>
        internal JSONIncomeRepository()
        {
            this._options.Converters.Add(new DateOnlyJsonConverter());
            this._incomes = this.LoadAll();
        }

        /// <summary>
        /// AddIncome method is used to add income data into the repository.
        /// </summary>
        /// <param name="income">Income is the details of income.</param>
        public void AddIncome(Income income)
        {
            this._incomes.Add(income);
            this.WriteAll();
        }

        /// <summary>
        /// DeleteIncome method is used to delete a particular income in the repository.
        /// </summary>
        /// <param name="id">Id is the unique identifier of the income.</param>
        /// <returns>Returns whether the income is deleted or not.</returns>
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

        /// <summary>
        /// GetAllIncome method is used to retrieve list of incomes from repository.
        /// </summary>
        /// <returns>Returns the list of income in repository.</returns>
        public List<Income> GetAllIncome()
        {
            return this._incomes;
        }

        /// <summary>
        /// GetIncomeById method is used to retrieve a particular income from repository.
        /// </summary>
        /// <param name="id">Id is the unique identifier of the income.</param>
        /// <returns>Returns the income from repository.</returns>
        public Income? GetIncomeById(Guid id)
        {
            return this._incomes.FirstOrDefault(income => income.Id == id);
        }

        /// <summary>
        /// UpdateIncome method is used update income details in the repository.
        /// </summary>
        /// <param name="newIncome">Income is the income details.</param>
        /// <returns>Returns whether the income is updated or not.</returns>
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
