using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CougBites.Models;
using SQLite;

namespace CougBites
{
    public class Database
    {
        public SQLiteAsyncConnection _database;

        public Database(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
        }

        public Task<List<Models.FoodItem>> GetFoodAsync()
        {
            return _database.Table<Models.FoodItem>().ToListAsync();
        }

        public Task<int> SaveFoodAsync(Models.FoodItem food)
        {
            return _database.InsertAsync(food);
        }

        public Task<int> SaveLocationAsync(Models.Location loc)
        {
            return _database.InsertAsync(loc);
        }

        public Task<List<Models.Location>> GetLocationAsync()
        {
            return _database.Table<Models.Location>().ToListAsync();
        }

        public Task<int> SaveProfileAsync(Models.Profile profile)
        {
            return _database.InsertAsync(profile);
        }

        public Task<List<Models.Profile>> GetProfileAsync()
        {
            return _database.Table<Models.Profile>().ToListAsync();
        }

        public Task<int> SaveRatingAsync(Models.Rating rat)
        {
            return _database.InsertAsync(rat);
        }

        public Task<List<Models.Rating>> GetRatingAsync()
        {
            return _database.Table<Models.Rating>().ToListAsync();
        }

    }
}
