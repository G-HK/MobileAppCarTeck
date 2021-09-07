using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarTeckM.Data
{
    public interface ICRTKDatabase
    {
        void seeddata();
        Task AddCar(Car car);
        Task<IEnumerable<Car>> GetCars();
        Task<Car> GetCar(int id);
        Task RemoveCar(int id);
        Task UpdateCar(Car car);
    }
}

