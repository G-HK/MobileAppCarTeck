using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
namespace CarTeckM.Data
{
    public class CRTKDatabase
    {
        readonly SQLiteAsyncConnection database;

        public CRTKDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<User>().Wait();
            database.CreateTableAsync<Car>().Wait();
        }


    }
}
