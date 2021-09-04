using CarTeckAPI.Models;
using CarTeckAPI.Models.ModelView;
using CarTeckAPI.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CarTeckAPI.Controllers
{
    [ApiController]
    [Route("Api/Car")]
    public class CarController : Controller
    {
        private readonly ICarRepository _carRepository;
        

        public CarController(ICarRepository carRepository)
        {
            _carRepository = carRepository ?? throw new ArgumentNullException(nameof(carRepository));
        }

        [HttpGet]
        [Route("GetCars")]
        public IEnumerable<Car> GetCars()
        {
            return _carRepository.GetCars();
        }

        // GET:
        [HttpGet]
        [Route("GetCar/{id}")]
        public Car Details(int id)
        {
            return _carRepository.GetCar(id);
        }




      //  private readonly IWebHostEnvironment hostingEnvironment;


        // Post:
        [HttpPost]
        [Route("Create")]
        public IActionResult Create([Bind("Merk,Model,Transmission,BodyType,Price,Kilometer,FuelType,BouwJaar,PK,UserID")] Car car)
        {
            //Car carData = new Car();
            //string uniqueName = Guid.NewGuid().ToString() + "_" + car.Img;

            //System.IO.File.WriteAllBytes($"~/Images/{uniqueName}", car.Img);

            if (ModelState.IsValid)
            {
            //    string uniqueName = Guid.NewGuid().ToString() + "_" + car.Img;

            //    carData.Model = car.Model;


            //     System.IO.File.WriteAllBytes($"~/Images/{uniqueName}",car.Img );

            //    // IFormFile file = new FormFile(car.Img, 0, byteArray.Length, "name", "fileName");

            //   // string uploadFolder = Path.Combine(hostingEnvironment.EnvironmentName, "~/Images");

                _carRepository.CreateCar(car);

                return Ok();
            }
            return BadRequest();
        }


        [HttpGet]
        [Route("Filter")]
        public IEnumerable<Car> Filter( CarSelectDto carSelect )
        {
            return _carRepository.GetFilter(carSelect);
        }

    }
}
