using DnDStock.Data;
using SQLite;

namespace DnDStock.Services
{
    public class ItemService
    {
        private SQLiteAsyncConnection _connection { get; set; }
        private string _dbPath { get; set; }

        public ItemService(string dbPath)
        {
            _dbPath = dbPath;
        }

        private async Task InitAsync() {
            if (_connection is not null)
                return;

            _connection = new SQLiteAsyncConnection(_dbPath);
            await _connection.CreateTableAsync<Item>();
        }

        public async Task<List<Item>> GetAllAsync() { 
            await InitAsync();
            return await _connection.Table<Item>().ToListAsync();
        }

        public async Task<Item> CreateItemAsync(Item item) { 
            await InitAsync();
            await _connection.InsertAsync(item);

            return item;
        }

        public async Task<Item> UpdateItemAsync(Item item) {
            await InitAsync();
            await _connection.UpdateAsync(item);

            return item;
        }

        public async Task DeleteItemAsync(Item item) {
            await InitAsync();
            await _connection.DeleteAsync(item);
        }
    }
}
