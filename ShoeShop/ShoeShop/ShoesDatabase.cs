using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShop
{
    public class ShoesDatabase
    {
        private SQLiteAsyncConnection database;

        public ShoesDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Shoes>().Wait();
        }

        // Query using SQL query string
        public Task<List<Shoes>> GetItemsAsync()
        {
            return database.Table<Shoes>().ToListAsync();
        }

        // Query using LINQ
        public Task<List<Shoes>> GetItemsCategory(string cat)
        {
            return database.Table<Shoes>().Where(i => i.Category == cat).ToListAsync();
        }

        public Task<int> SaveItemAsync(Shoes shoes)
        {
            if (shoes.ID != 0)
            {
                return database.UpdateAsync(shoes);
            }
            else
            {
                return database.InsertAsync(shoes);
            }
        }

        public Task<int> DeleteItemAsync(Shoes shoes)
        {
            return database.DeleteAsync(shoes);
        }

        public Task<List<Shoes>> DeleteItems()
        {
            return database.QueryAsync<Shoes>("Delete FROM [Shoes]");
        }
    }
}
