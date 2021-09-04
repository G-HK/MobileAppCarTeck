using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using CarTeckAPI.Models;
using System.Threading.Tasks;
using CarTeckAPI.Services;
using AutoMapper;

namespace CarTeckAPI.Controllers
{
    [ApiController]
    [Route("Api/Account")]
    public class AccountController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public AccountController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _mapper = mapper;
        }
        // check 
        [HttpGet]
        [Route("test")]
        public IActionResult Index()
        {
            string text = "helloworld";
            JsonResult json = new JsonResult(text);
            return json;
        }


        [HttpGet]
        [Route("AllUsers")]
        public IEnumerable<User> GetUser()
        {
            //await Task.Run(() => _userRepository.UserExists(id));
            IEnumerable<User> users = _userRepository.GetUsers();
            return users;
        }


        [HttpGet]
        [Route("Email/{email}/Psw/{psw}")]
        public User GetUser(string email, string psw)
        {
            //User user = await Task.Run(() => _userRepository.GetUser(email , psw)); async Task<User>
           User user = _userRepository.GetUser(email, psw);
            //JsonResult json = new JsonResult(user);
            return user;
        }


        [HttpGet]
        [Route("ValidUser/{username}")]
        public bool ValidUserName(string username)
        {
            return _userRepository.ValidUsername(username);
        }


        [HttpGet]
        [Route("ValidEmail/{email}")]
        public bool ValidEmail(string email)
        {
            return _userRepository.ValidEmail(email);
        }


        [HttpGet]
        [Route("CheckPsw/{email}/{psw}")]
        public bool ValidPsw(string email, string psw)
        {
            return _userRepository.CheckPsw(email, psw);
        }


        [HttpPost]
        [Route("CreateUser")]
        public IActionResult CreateUser([Bind("UserName,Email,Password,BirthDate")] User user)
        {
            if (ModelState.IsValid)
            {
                if (_userRepository.ValidEmail(user.Email) && _userRepository.ValidUsername(user.UserName))
                {
                    _userRepository.CreateUser(user);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }

            return Ok();
        }


        [HttpPatch]
        [Route("UpdateUser")]
        public IActionResult UpdateUser(User user)
        {
            //JObject jObject = JObject.Parse(UserJson.ToString());

            if (ModelState.IsValid)
            {
                _userRepository.UpdateUser(user);
            }
            else
            {
                return BadRequest(ModelState);
            }

            return Ok();
        }

        [HttpDelete]
        [Route("DeleteUser")]
        public IActionResult DeleteUser(User user)
        {

            if (ModelState.IsValid)
            {
                _userRepository.DeleteUser(user);
            }
            else
            {
                return BadRequest(ModelState);
            }

            return Ok();
        }
    }
}
