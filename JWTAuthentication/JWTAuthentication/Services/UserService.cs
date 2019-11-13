using JWTAuthentication.DTO;
using JWTAuthentication.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JWTAuthentication.Services
{
    public class UserService
    {
        private static UserService instance;
        private static object syncObject = new object();

        private List<User> users;

        /// <summary>
        /// Singleton instance
        /// </summary>
        public static UserService Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncObject)
                    {
                        if (instance == null)
                        {
                            instance = new UserService();
                        }
                    }
                }
                return instance;
            }
        }

        private UserService()
        {
            users = new List<User>();
        }

        public User RegisterUser(UserDto userDto)
        {
            User registeredUser = null;
            
            if (!users.Any(user => user.Email == userDto.Email))
            {
                registeredUser = new User()
                {
                    Name = userDto.Name,
                    Password = userDto.Password,
                    Email = userDto.Email,
                    PhoneNumber = userDto.PhoneNumber
                };
                users.Add(registeredUser);
            }
            else
            {
                //TODO: if any user if found then throw exception
            }
            return registeredUser;
        }

        public User AuthenticateUser(UserDto login)
        {
            return users.FirstOrDefault(user => user.Email == login.Email && user.Password == login.Password);
        }

        public string GenerateJSONWebToken(User user)
        {
            //TODO: Make this configurable
            //user can be used to provide user specific access
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SecretKey"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(null, null, null, expires: DateTime.Now.AddMinutes(120), signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
