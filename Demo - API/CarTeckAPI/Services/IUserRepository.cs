using CarTeckAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarTeckAPI.Services
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsers();
        User GetUser(string UserName, string Password);

        bool ValidUsername(string Username);
        bool ValidEmail(string Emai);
        bool CheckPsw(string Email, string psw);
        bool UserExists(int id);
        void CreateUser(User user);
        void UpdateUser(User user);
        void DeleteUser(User user);
        bool save();

    }
}
