using DnDStock.Data;
using SQLite;

namespace DnDStock.Services
{
    public class StockService
    {
        private SQLiteAsyncConnection _connection { get; set; }
        private string _dbPath { get; set; }

        public StockService(string dbPath) { _dbPath = dbPath; }

        private async Task InitAsync() {
            if (_connection is not null)
                return;

            _connection= new SQLiteAsyncConnection(_dbPath);
            await _connection.CreateTableAsync<Stock>();
        }

        public async Task<List<Stock>> GetAllAsync()
        { 
            await InitAsync();
            return await _connection.Table<Stock>().ToListAsync();
        }

        public async Task<Stock> CreateStockAsync(Stock stock) { 
            await InitAsync();

            await _connection.InsertAsync(stock);

            return stock;
        }
        
        public async Task<Stock> UpdateStockAsync(Stock stock) {
            await InitAsync();

            await _connection.UpdateAsync(stock);

            return stock;
        }
        
        public async Task DeleteStockAsync(Stock stock) {
            await InitAsync();

            await _connection.InsertAsync(stock);
        }
    }
}
