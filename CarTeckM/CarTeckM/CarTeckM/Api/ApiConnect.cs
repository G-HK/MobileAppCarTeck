using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using CarTeckM.Models;
using CarTeckM.Data;

namespace CarTeckM.Models
{
    //Account APi
    public class ApiConnect : HttpClient
    {
        HttpClient httpClient; 
       // private readonly IMapper _mapper;

        public ApiConnect()
        {
            httpClient =  new HttpClient { BaseAddress = new Uri("http://ade5-2a02-1810-c40c-e500-a5c7-f42c-b55e-8787.ngrok.io") };//http://10.0.2.2:3866
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        //    _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        // Test For Connection
        public dynamic TestExist()
        {
            var url = "Api/Account/test"; //"/Api/Account/1";
            // var result = "";

            HttpResponseMessage message = httpClient.GetAsync(url).Result;
            if (message.IsSuccessStatusCode)
            {
                string context = message.Content.ReadAsStringAsync().Result;
                var result = JsonConvert.DeserializeObject<dynamic>(context);
               // return result;
            }
            return "";
        }
        ///Get Request
        public object HttpRequestGet(string url)
        {
            HttpResponseMessage message = httpClient.GetAsync(url).Result;
            if (message.IsSuccessStatusCode)
            {
                var context = message.Content.ReadAsStringAsync().Result;
              //  var result = JsonConvert.DeserializeObject<dynamic>(context);
                return context;
            }
            return false;
        }

        //Post Request 
        public dynamic HttpRequestPost(string url ,object obj)
        {
            HttpContent content = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
            HttpResponseMessage message = httpClient.PostAsync(url, content).Result;
            if (message.IsSuccessStatusCode)
            {
                return message;
            }

            return false ;
        }


        // Validuser Get
        public bool ValidUser(string username)
        {
            string url = $"Api/Account/ValidUser/{username}";
            var checker = HttpRequestGet(url);

            return (bool)checker;
        }

        //ValidEmail Get
        public bool ValidEmail(string email)
        {
            string url = $"Api/Account/ValidEmail/{email}";
            var checker = HttpRequestGet(url);
            return bool.Parse(checker.ToString());
        }

        //ValidPsw Get;
        public bool ValidPsw(string email,string psw)
        {
            string url = $"Api/Account/CheckPsw/{email}/{psw}";
            var checker = HttpRequestGet(url);
            return bool.Parse(checker.ToString());
        }

        //GetUser Get;
        public User GetUser(string email,  string psw)
        {
            string url = $"Api/Account/Email/{email}/Psw/{psw}";
           // var user = JsonConvert.DeserializeObject(HttpRequestGet(url).ToString()); 
            User ise = JsonConvert.DeserializeObject<User>(HttpRequestGet(url).ToString());
            UserDto dto = new UserDto();


            dto._userID = ise.UserID;

            dto._username = ise.Username;

            dto._email = ise.Email ?? throw new ArgumentNullException(nameof(ise.Email));
            dto._password = ise.Password;
            dto._birthDate = ise.BirthDate;




            // var test = _mapper.Map(user,checker);
            //user.UserID = checker.UserID;
            return ise;
        }

        // PostUser Created
        public bool PostUser(UserDto user)
        {

            string url = $"Api/Account/CreateUser";
            //var userCreated = HttpRequestPost(url, user);

            //if (userCreated.Ok())
            //{
            //    return true;
            //}
            return false;


        }







    }
}
