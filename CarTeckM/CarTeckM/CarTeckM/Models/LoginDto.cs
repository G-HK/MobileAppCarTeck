using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarTeckM.Models
{
    public  class LoginDto : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;


        private string _username;

        public string Username 
        { 
            get=> _username;
            set {
                _username = value;
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(Username)));
            } 
        }

        //
        private string _email;

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
        private string _password;

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
    }
}
