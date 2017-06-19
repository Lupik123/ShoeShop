using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShop
{
    public class OrderDatabase
    {
        private SQLiteAsyncConnection database;

        public OrderDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Order>().Wait();
        }

        // Query using SQL query string
        public Task<List<Order>> GetItemsAsync()
        {
            return database.Table<Order>().ToListAsync();
        }

        // Query using LINQ
        public Task<Order> GetItemAsync(int id)
        {
            return database.Table<Order>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(Order order)
        {
            if (order.ID != 0)
            {
                return database.UpdateAsync(order);
            }
            else
            {
                return database.InsertAsync(order);
            }
        }

        public Task<int> DeleteItemAsync(Order order)
        {
            return database.DeleteAsync(order);
        }

        public Task<List<Order>> DeleteItems()
        {
            return database.QueryAsync<Order>("Delete FROM [Order]");
        }
    }
}
