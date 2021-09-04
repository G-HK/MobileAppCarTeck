using CarTeckM.Account;
using CarTeckM.Car;
using CarTeckM.Models;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CarTeckM.MasterDetail
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MDPMaster : ContentPage
    {
        public ListView ListView;

        public MDPMaster()
        {
            InitializeComponent();

            BindingContext = new MDPMasterViewModel();
            ListView = MenuItemsListView;

            UserDto userDto = new UserDto();
           // UserNamelbl.Text = BindableProperty.

            
        }

        class MDPMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MDPMasterMenuItem> MenuItems { get; set; }

            public MDPMasterViewModel()
            {
                MenuItems = new ObservableCollection<MDPMasterMenuItem>(new[]
                {
                    new MDPMasterMenuItem { Id = 0, Title = "My Profile" , IconSource="user.png",  TargetType=typeof(ProfilePage) },
                    new MDPMasterMenuItem { Id = 1, Title = "Saved" , IconSource="save.png" ,  TargetType=typeof(Favorite)},
                    new MDPMasterMenuItem { Id = 2, Title =  "SearchCar" , IconSource="search.png" ,  TargetType=typeof(SearchCar) },
                    new MDPMasterMenuItem { Id = 3, Title = "SellCar", IconSource="car.png" ,  TargetType=typeof(SellCar) },
                    new MDPMasterMenuItem { Id = 4, Title = "Setttings", IconSource="settings.png" , TargetType=typeof(Setting)},
                    new MDPMasterMenuItem { Id = 4, Title = "Carpage", IconSource="car.png" , TargetType=typeof(CarPage)},
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion


          
        } 
        private async void LoginBtn_Clicked(object sender, EventArgs e)
        {
                await PopupNavigation.Instance.PushAsync(new Login());

                // UsrNamelbl.Text = Preferences.Get("UserName", "Geust");
        }

    }
}