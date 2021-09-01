using CarTeckAPI.Data;
using CarTeckAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarTeckAPI.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly CarTeckInfoContext _context;

        public UserRepository(CarTeckInfoContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IEnumerable<User> GetUsers()
        {
            return _context.Users.OrderBy(c => c.UserName).ToList();
        }

        public User GetUser(string email, string Password)
        {
            return _context.Users.FirstOrDefault(c => c.Email == email && c.Password == Password);
        }

        public bool CheckPsw(string Email, string psw)
        {
            User user = _context.Users.FirstOrDefault(x => x.Email == Email);
            try
            {
                if (user.Email != null && user.Password == psw)
                {
                     return true;
                }
                return false;

            }
            catch (Exception ex)
            {
                throw new ArgumentException();
                
            }
            

            

        }

        public bool ValidUsername(string username)
        {
            var userValid = _context.Users.FirstOrDefault(u => u.UserName == username);
            if (userValid == null)
            {
                return true;
            }
            return false;
        }

        public bool ValidEmail(string email)
        {
            var userValid =  _context.Users.FirstOrDefault(u => u.Email == email);
            if (userValid == null)
            {
                return true;
            }
            return false;

        }
        public void CreateUser(User user)
        {
            _context.Users.Add(user);
            save();
        }

        public void DeleteUser(User user)
        {
            _context.Users.Remove(user);
            save();

        }
        public void UpdateUser(User user)
        {
            _context.Users.Update(user);
            save();

        }

        public bool UserExists(int id)
        {
            return _context.Users.Any( u => u.UserID == id);
        }

        public bool save()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
