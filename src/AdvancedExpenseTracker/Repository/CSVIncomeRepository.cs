using AdvancedExpenseTracker.Interfaces;
using AdvancedExpenseTracker.Models;

namespace AdvancedExpenseTracker.Repository
{
    /// <summary>
    /// IncomeRepository class is the class where storage of income data is defined.
    /// </summary>
    internal class CSVIncomeRepository : IIncomeRepository
    {
        private readonly string _filePath;

        /// <summary>
        /// Initializes a new instance of the <see cref="CSVIncomeRepository"/> class.
        /// </summary>
        /// <param name="filePath">Filepath where the file for storage is created.</param>
        internal CSVIncomeRepository(string filePath)
        {
            this._filePath = filePath;
        }

        /// <summary>
        /// AddIncome method is used to add income data into the repository.
        /// </summary>
        /// <param name="income">Income is the details of income.</param>
        public void AddIncome(Income income)
        {
            File.AppendAllText(this._filePath, $"{income.Id},{income.Amount},{income.Date},{income.Category}\n");
        }

        /// <summary>
        /// GetAllIncome method is used to retrieve list of incomes from repository.
        /// </summary>
        /// <returns>Returns the list of income in repository.</returns>
        public List<Income> GetAllIncome()
        {
            string[] fileData = File.ReadAllLines(this._filePath);
            List<Income> incomes = new List<Income>();
            foreach (string line in fileData)
            {
                string[] lineData = line.Split(",");
                Enum.TryParse<IncomeCategory>(lineData[3], out IncomeCategory category);
                Income income = new Income()
                {
                    Id = Guid.Parse(lineData[0]),
                    Amount = decimal.Parse(lineData[1]),
                    Date = DateOnly.Parse(lineData[2]),
                    Category = category,
                };
                incomes.Add(income);
            }

            return incomes;
        }

        /// <summary>
        /// GetIncomeById method is used to retrieve a particular income from repository.
        /// </summary>
        /// <param name="id">Id is the unique identifier of the income.</param>
        /// <returns>Returns the income from repository.</returns>
        public Income? GetIncomeById(Guid id)
        {
            List<Income> incomes = this.GetAllIncome();
            return incomes.FirstOrDefault(i => i.Id == id);
        }

        /// <summary>
        /// UpdateIncome method is used update income details in the repository.
        /// </summary>
        /// <param name="income">Income is the income details.</param>
        /// <returns>Returns whether the income is updated or not.</returns>
        public bool UpdateIncome(Income income)
        {
            List<Income> incomes = this.GetAllIncome();
            foreach (var fileIncome in incomes)
            {
                if (fileIncome.Id == income.Id)
                {
                    fileIncome.Amount = income.Amount;
                    fileIncome.Date = income.Date;
                    fileIncome.Category = income.Category;
                }
            }

            this.WriteAll(incomes);
            return true;
        }

        /// <summary>
        /// DeleteIncome method is used to delete a particular income in the repository.
        /// </summary>
        /// <param name="id">Id is the unique identifier of the income.</param>
        /// <returns>Returns whether the income is deleted or not.</returns>
        public bool DeleteIncome(Guid id)
        {
            List<Income> incomes = this.GetAllIncome();
            Income? income = incomes.FirstOrDefault(entry => entry.Id == id);
            if (income == null)
            {
                return false;
            }

            incomes.Remove((Income)income);
            this.WriteAll(incomes);
            return true;
        }

        /// <summary>
        /// IsIncomeEmpty method is used to check whether the income is empty.
        /// </summary>
        /// <returns>Returns whether the income is empty or not.</returns>
        internal bool IsIncomeEmpty()
        {
            if (!File.Exists(this._filePath))
            {
                return true;
            }

            return File.ReadAllLines(this._filePath).Length == 0;
        }

        /// <summary>
        /// GetTotalIncome method is used get the income total.
        /// </summary>
        /// <returns>Returns the income total.</returns>
        internal decimal GetTotalIncome()
        {
            List<Income> incomes = this.GetAllIncome();
            return incomes.Sum(i => i.Amount);
        }

        /// <summary>
        /// IncomeCount method is used to return the number of income in the repository.
        /// </summary>
        /// <returns>Returns the number of incomes.</returns>
        internal int IncomeCount()
        {
            return File.ReadAllLines(this._filePath).Length;
        }

        /// <summary>
        /// WriteAll method is used to rewrite the file data.
        /// </summary>
        /// <param name="incomes">Incomes is list of income in repository.</param>
        private void WriteAll(List<Income> incomes)
        {
            List<string> result = new List<string>();
            foreach (var income in incomes)
            {
                result.Add($"{income.Id},{income.Amount},{income.Date},{income.Category}");
            }

            File.WriteAllLines(this._filePath, result);
        }
    }
}