using System;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using Torok_Erika_Lab7.Models;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Torok_Erika_Lab7.Data
{
    public class ShoppingListDatabase
    {
        readonly SQLiteAsyncConnection _database;
        public ShoppingListDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Shoplist>().Wait();
        }
        public Task<List<Shoplist>> GetShopListsAsync()
        {
            return _database.Table<Shoplist>().ToListAsync();
        }
        public Task<Shoplist> GetShopListAsync(int id)
        {
            return _database.Table<Shoplist>()
            .Where(i => i.ID == id)
           .FirstOrDefaultAsync();
        }
        public Task<int> SaveShopListAsync(Shoplist slist)
        {
            if (slist.ID != 0)
            {
                return _database.UpdateAsync(slist);
            }
            else
            {
                return _database.InsertAsync(slist);
            }
        }
        public Task<int> DeleteShopListAsync(Shoplist slist)
        {
            return _database.DeleteAsync(slist);
        }

    }
}
