using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using CarTeckM.Models;
using SQLite;
using Xamarin.Essentials;

namespace CarTeckM.Data
{
    public class CRTKDatabase : ICRTKDatabase
    {
        SQLiteAsyncConnection database;

        // Temporarily used for the Demo

        //public CRTKDatabase(string dbPath)
        //{
        //    database = new SQLiteAsyncConnection(dbPath);
        //    database.CreateTableAsync<User>().Wait();
        //    database.CreateTableAsync<Car>().Wait();
        //}

        public async Task Init()
        {
            if (database != null)
                return;

            // Get an absolute path to the database file
            var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Crtk.db");

            database = new SQLiteAsyncConnection(databasePath);

            await database.CreateTableAsync<Car>();
            await database.CreateTableAsync<User>();
            seeddata();
            await database.CreateTableAsync<Mediaitem>();
        }

        public async void seeddata()
        {

            //await database.DeleteAllAsync<Car>();


            Car car1 = new Car
            {
                CarID = 1,
                Brand = "BMW",
                Model = "M3",
                Transmission = "Manual",
                BodyType = "Berline",
                BuildYear = 2021,
                RangeType = "KM",
                Range = 30000,
                Torque = "510",
                Power = 480,
                Price = 99999,
                Description = "A Car for Enthusiast,The Porsche 911 (pronounced Nine Eleven or in German: Neunelfer) is a two-door, " +
                    "2+2 high performance rear-engined sports car. Introduced in September 1964 by Porsche AG of Stuttgart, Germany." +
                    " It has a rear-mounted flat-six engine and all round independent suspension. It has undergone continuous development, " +
                    "though the basic concept has remained unchanged.[1] The engines were air-cooled until the introduction of the Type 996 in 1998, " +
                    "with the 993, produced from 1994–1998 model years, being the last of the air-cooled Porsche sports cars." +
                    "The 911 has been modified by private teams and by the factory itself for racing, rallying, and other forms of automotive competition." +
                    "It is among the most successful competition cars. In the mid-1970s, the naturally aspirated 911 Carrera RSR won major world championship sports car races," +
                    " such as Targa Florio and 24 Hours of Daytona, even against prototypes." +
                    "The 911-derived 935 turbo also won the 24 Hours of Le Mans in 1979 and Porsche won World Championship for Makes titles in 1976, ",
                Picture =  "BMW1.png",
                Color = "Black",
                FuelType = "Benzine",
                UserID = 1,
                Currency = "€",

            };

            Car car2 = new Car
            {
                CarID = 2,
                Brand = "Porsche",
                Model = "911 Turbo s",
                Transmission = "Manual",
                BodyType = "Coupé",
                BuildYear = 2020,
                RangeType = "mil",
                Range = 30000,
                Torque = "650",
                Power = 590,
                Currency = "$",
                Price = 99999,
                Description = "A Car for Enthusiast.",
                Picture = "porsche911turbos.png",
                FuelType = "Diesel",
                UserID = 2,
                Color = "Metalic Black"


            };
            Car car3 = new Car
            {
                CarID = 3,
                Brand = "Porsche",
                Model = "911 995",
                Transmission = "Manual",
                BodyType = "Coupé",
                BuildYear = 1969,
                RangeType = "km",
                Range = 30000,
                Torque = "400",
                Power = 350,
                Currency = "$",
                Price = 99999,
                Description = "A Car for Enthusiast.",
                Picture = "porsche911992.jpg",
                FuelType = "Benzine",
                UserID = 1,
                Color = "Green"


            };


            await AddCar(car1);
            await AddCar(car2);
            await AddCar(car3);
        }

        public async Task AddCar(Car car)
        {
            await Init();
            var id = await database.InsertAsync(car); // ? return ID as int
        }

        public async Task RemoveCar(int id)
        {

            await Init();

            await database.DeleteAsync<Car>(id);
        }

        // return all cars
        public async Task<IEnumerable<Car>> GetCars()
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

        public async Task<IEnumerable<Car>> GetCarsFilter(FilterCars filter)
        {
            await Init();


            var car = await database.Table<Car>().Where(c => 
                c.Brand == filter.Brand 
                &&
                c.Transmission == filter.Transmission

                //( c.BuildYear >= filter.BeginBuildYear  && c.BuildYear <= filter.EndBuildYear)  



            ).ToListAsync();




            return car;
        }

        public async Task<IEnumerable<Car>> GetUserCars(int  userID)
        {
            await Init();

            var car = await database.Table<Car>().Where(x=> x.UserID == userID).ToListAsync();
            return car;
        }
    }
}
