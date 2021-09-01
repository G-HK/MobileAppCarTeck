using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarTeckAPI.Data;
using CarTeckAPI.Entities;

namespace CarTeckAPI.Services
{
    public class CarRepository : ICarRepository
    {
        private readonly CarTeckInfoContext _context;

        public CarRepository(CarTeckInfoContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Car GetCar(int id)
        {
            return _context.Cars.Where(x => x.CarID == id).FirstOrDefault();
        }


        public IEnumerable<Car> GetFilter(CarSelectDto filter)
        {


            return _context.Cars.AsEnumerable()
                .Where(x => x.Brand.Equals(filter.Merk))
                .Where(x => x.Model.Equals(filter.Model))
                .Where(x => x.Transmission.Equals(filter.Transmission))
                .Where(x => x.Price >= filter.LowerPrice && x.Price <= filter.UpperPrice)
                .Where(x => x.BodyType.Equals(filter.BodyType))
                .Where(x => x.BouwJaar >= filter.BeginJaar && x.BouwJaar <= filter.EndJaar)
                .Where(x => x.Kilometer >= filter.KilometerLowerLimit && x.Kilometer <= filter.KilometerUpperLimit)
                .Where(x => x.PK <= filter.PK)
                .Where(x => x.FuelType.Equals(filter.Fuel));
               

        }

        public IEnumerable<Car> GetCars()
        {
            return _context.Cars.AsEnumerable();
        }



        public void CreateCar(Car car)
        {
            _context.Cars.Add(car);
            save();
        }

        public void DeleteCar(Car car)
        {
            _context.Cars.Remove(car);
            save();
        }

         public void UpdateCar(Car car)
        {
            _context.Cars.Update(car);
            save();
        }

        public bool save()
        {
            return (_context.SaveChanges() >= 0);
        }

    }
}
