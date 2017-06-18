using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShop
{
    public class PersonDatabase
    {
        private SQLiteAsyncConnection database;

        public PersonDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<User>().Wait();
        }

        // Query using SQL query string
        public Task<List<User>> GetItemsAsync()
        {
            return database.Table<User>().ToListAsync();
        }

        // Query using LINQ
        public Task<User> GetItemAsync(int id)
        {
            return database.Table<User>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(User user)
        {
            if (user.ID != 0)
            {
                return database.UpdateAsync(user);
            }
            else
            {
                return database.InsertAsync(user);
            }
        }

        public Task<int> DeleteItemAsync(User user)
        {
            return database.DeleteAsync(user);
        }

        public Task<List<User>> DeleteItems()
        {
            return database.QueryAsync<User>("Delete FROM [User]");
        }
    }
}
