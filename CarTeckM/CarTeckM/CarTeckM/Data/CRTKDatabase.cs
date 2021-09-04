using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Essentials;

namespace CarTeckM.Data
{
    public class CRTKDatabase : ICRTKDatabase
    {
        SQLiteAsyncConnection database;

        // Temporarily used for the Demo

        public CRTKDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<User>().Wait();
            database.CreateTableAsync<Car>().Wait();
        }

        async Task Init()
        {
            if (database != null)
                return;

            // Get an absolute path to the database file
            var databasePath = Path.Combine(FileSystem.AppDataDirectory, "Crtk.db");

            database = new SQLiteAsyncConnection(databasePath);

            await database.CreateTableAsync<Car>();
        }


        public async Task AddCar(Car car)
        {
            await Init();
            var image = "https://www.yesplz.coffee/app/uploads/2020/11/emptybag-min.png";
            //var car = new Car
            //{
            //    //Name = name,
            //    //Roaster = roaster,
            //    //Image = image
            //};
            //????

            var id = await database.InsertAsync(car); // ? return ID as int
        }

        public async Task RemoveCar(int id)
        {

            await Init();

            await database.DeleteAsync<Car>(id);
        }

        // return all cars
        public async Task<IEnumerable<Car>> GetCar()
        {
            await Init();

            var car = await database.Table<Car>().ToListAsync();
            return car;
        }

        public async Task<Car> GetCar(int id)
        {
            await Init();

            var car = await database.Table<Car>().FirstOrDefaultAsync(c => c.CarID == id);

            return car;
        }

        public async Task UpdateCar(Car car)
        {
            await Init();

            await database.UpdateAsync(car);

        }
    }
}
