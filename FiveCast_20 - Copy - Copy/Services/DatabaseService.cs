
using SQLite;
using FiveCast.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using FiveCastFinal.Model;

namespace FiveCast.Services
{
    public class DatabaseService
    {
        private readonly SQLiteAsyncConnection _database;

        public DatabaseService()
        {
            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "destinations.db3");
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Destination>().Wait();
        }

        public Task<List<Destination>> GetDestinationsAsync() =>
            _database.Table<Destination>().ToListAsync();

        public Task<int> SaveDestinationAsync(Destination destination) =>
            destination.Id != 0 ? _database.UpdateAsync(destination) : _database.InsertAsync(destination);

        public Task<int> DeleteDestinationAsync(Destination destination) =>
            _database.DeleteAsync(destination);

        public Task<List<Expense>> GetExpensesAsync(int destinationId) =>
    _database.Table<Expense>().Where(e => e.DestinationId == destinationId).ToListAsync();

        public Task<int> SaveExpenseAsync(Expense expense) =>
            expense.Id != 0 ? _database.UpdateAsync(expense) : _database.InsertAsync(expense);

        public Task<int> DeleteExpenseAsync(Expense expense) =>
            _database.DeleteAsync(expense);
    }
}
