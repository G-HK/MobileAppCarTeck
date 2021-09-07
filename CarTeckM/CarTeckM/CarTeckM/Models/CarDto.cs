using CarTeckM.Data;
using System;
using System.Collections.Generic;
using System.Text;
using MvvmHelpers;
using MvvmHelpers.Commands;

using Command = MvvmHelpers.Commands.Command;
using System.Threading.Tasks;
using CarTeckM.Services;
using Xamarin.Forms;
using CarTeckM.Car;

namespace CarTeckM.Models
{
    public  class CarDto : BaseViewModel
    {
        public ObservableRangeCollection<Data.Car> Car { get; set; }

        public AsyncCommand RefreshCommand { get; }
        public AsyncCommand AddCommand { get; }
        public AsyncCommand<Data.Car> RemoveCommand { get; }
        public AsyncCommand<Data.Car> SelectedCommand { get; }

        ICRTKDatabase cRTKDatabase;

        public CarDto()
        {
            Car = new ObservableRangeCollection<Data.Car>();

            RefreshCommand = new AsyncCommand(Refresh);
            //AddCommand = new AsyncCommand(Add);
            //RemoveCommand = new AsyncCommand<Data.Car>(Remove);
            //SelectedCommand = new AsyncCommand<Data.Car>(Selected);

            cRTKDatabase = DependencyService.Get<ICRTKDatabase>();

        }
    




        public int CarID { get; set; }

        public string Brand { get; set; }
        public string Model { get; set; }

        public string Transmission { get; set; } ///Handbak, auto

        public string BodyType { get; set; }

        public string FuelType { get; set; }

        public char Currency { get; set; }

        public decimal Price { get; set; }

        public string Color { get; set; }

        public string RangeType { get; set; } //KM or Mile
        public int Range { get; set; }


        public int BuildYear { get; set; }

        public string Torque { get; set; }

        public string Power { get; set; } // Kw/Pk

        //  path of the images are been save in db; split by;
        public string  Picture { get; set; }

        public string Description { get; set; }


        public string IdentityID { get; set; }
        // id of the car onwer or Dealer.
        public User User { get; set; }

        //  // QR Code

        //   //public QRCode qRCode { get; set; }


        async Task Refresh()
        {
            IsBusy = true;

            await Task.Delay(2000);

            Car.Clear();

            var coffees = await cRTKDatabase.GetCars();

            Car.AddRange(coffees);

            IsBusy = false;

            DependencyService.Get<IToast>()?.MakeToast("Refreshed!");
        }
    }
}
