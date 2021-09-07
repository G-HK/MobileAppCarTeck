using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarTeckM.Models
{
    public class UserDto : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;


        public int _userID;



        public int UserID
        {
            get => _userID;
            set
            {
                _userID = value;
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(UserID)));
            }
        }




        public string _username;

        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(Username)));
            }
        }



        //
        public string _email;

        [Required(ErrorMessage = "You should provide a Email value.")]
        [EmailAddress]
        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(Email)));
            }
        }
        //

        public string _password;

        [Required(ErrorMessage = "You should provide a Password value.")]
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(Password)));
            }
        }


        [DataType(DataType.DateTime)]
        public DateTime _birthDate;

        public DateTime BirthDate
        {
            get => _birthDate;
            set
            {
                _birthDate = value;
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(BirthDate)));
            }
        }
    }
}
