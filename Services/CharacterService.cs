using DnDStock.Data;
using SQLite;

namespace DnDStock.Services
{
    public class CharacterService
    {
        private SQLiteAsyncConnection _connection { get; set; }
        private string _dbPath { get; set; }

        public CharacterService(string dbPath)
        {
            _dbPath = dbPath;
        }

        private async Task InitAsync()
        {
            if (_connection is not null)
                return;

            _connection = new SQLiteAsyncConnection(_dbPath);
            await _connection.CreateTableAsync<Character>();
        }

        public async Task<List<Character>> GetAllAsync()
        {
            await InitAsync();
            return await _connection.Table<Character>().ToListAsync();
        }

        public async Task<Character> CreateCharacterAsync(Character character)
        {
            await InitAsync();
            await _connection.InsertAsync(character);

            return character;
        }

        public async Task<Character> UpdateCharacterAsync(Character character)
        {
            await InitAsync();
            await _connection.UpdateAsync(character);

            return character;
        }

        public async Task DeleteCharacterAsync(Character character)
        {
            await InitAsync();
            await _connection.DeleteAsync(character);
        }
    }
}
