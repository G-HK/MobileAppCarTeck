using CarTeckM.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace CarTeckM.Api
{
    public class ApiService : IApiService
    {
        HttpClient Client;

        public ApiService()
        {
            Client = new HttpClient { BaseAddress = new Uri("http://f73a2fc5ebb7.ngrok.io") };//http://10.0.2.2:3866
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        ///Get Request
        public object HttpRequestGet(string url)
        {
            HttpResponseMessage message = Client.GetAsync(url).Result;
            if (message.IsSuccessStatusCode)
            {
                var context = message.Content.ReadAsStringAsync().Result;
                //  var result = JsonConvert.DeserializeObject<dynamic>(context);
                return context;
            }
            return false;
        }


        public UserDto CreateUser(UserDto user)
        {
            throw new NotImplementedException();
        }

        public UserDto DeleteUser(UserDto user)
        {
            throw new NotImplementedException();
        }

        public UserDto GetUser(LoginDto login)
        {
            throw new NotImplementedException();
        }

        public UserDto UpdateUser(UserDto user)
        {
            throw new NotImplementedException();
        }
    }
}
