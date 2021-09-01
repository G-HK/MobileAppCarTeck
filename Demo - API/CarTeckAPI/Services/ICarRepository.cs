using CarTeckAPI.Entities;
using CarTeckAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarTeckAPI.Services
{
    public interface ICarRepository
    {

        IEnumerable<Car> GetCars();

        Car GetCar(int id);

        void CreateCar(Car car);
        void UpdateCar(Car car);
        void DeleteCar(Car car);
        IEnumerable<Car> GetFilter(CarFilterDto filter);
        
        bool save();


    }
}
