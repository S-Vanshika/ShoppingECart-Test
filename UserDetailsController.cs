using ECommerceAPI.Models;
using ECommerceAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ECommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserDetailsController : ControllerBase
    {
        private UserDetailsServices _userDetailsServices;

        //UserDetialsController constructor
        public UserDetailsController(UserDetailsServices userDetailsServices)
        {
            _userDetailsServices = userDetailsServices;
        }

        //Display AllUserDetails
        [HttpGet("GetAllUserDetails")]
        public List<UserDetails> GetAllUserDetails()
        {
            return _userDetailsServices.GetAllUserDetails();
        }

        //Display UserDetails using ID
        [HttpGet("GetUserDetailsbyId")]
        public IActionResult GetUserDetailsbyId(int UserId)
        {
            return Ok(_userDetailsServices.GetUserDetailsbyId(UserId));
        }

        //Display UserDetails using Email
        [HttpGet("GetUserDetailsbyEmail")]
        public IActionResult GetUserDetailsbyEmail(string Email)
        {
            return Ok(_userDetailsServices.GetUserDetailsbyEmail(Email));
        }


        //SaveDetails Function
        [HttpPost("AddUserDetails")]
        public IActionResult AddUserDetails(UserDetails userDetails)
        {
            return Ok(_userDetailsServices.AddUserDetails(userDetails));
        }

        //UpdateDetails function
        [HttpPut("EditUserDetails")]
        public IActionResult EditUserDetails(UserDetails userDetails)
        {
            return Ok(_userDetailsServices.EditUserDetails(userDetails));
        }

        //DeleteDetails Function
        [HttpDelete("DeleteUserDetails")]
        public IActionResult DeleteUserDetails(int UserId)
        {
            return Ok(_userDetailsServices.DeleteUserDetails(UserId));
        }

        //Login Function
        [HttpPost]
        [Route("login")]
        public IActionResult LogIn(Login model)
        {
            var User = _userDetailsServices.GetUserDetailsbyEmail(model.Email);
            if(User != null && model.Password == User.Password)
            {
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim("UserId", User.UserID.ToString())
                    }),
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("PNM4t3NEYbOd1SGe")),
                    SecurityAlgorithms.HmacSha256Signature)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                var Token = tokenHandler.WriteToken(securityToken);
                return Ok(new { Token });
            }
            else
            {
                return BadRequest(new { msg = "Incorrect Login Credentials"});
            }
        }
    }
}
