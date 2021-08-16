using CarTeckM.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace CarTeckM.Api
{
    public interface IApiService
    {

        UserDto GetUser(LoginDto login);
        UserDto CreateUser(UserDto user);
        UserDto UpdateUser(UserDto user);
        UserDto DeleteUser(UserDto user);
    }
}
