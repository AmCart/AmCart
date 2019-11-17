using IdentityManagement.DTO;
using IdentityManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityManagement.Services
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

        public User Register(UserDto userDto)
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

        public User Login(string userName, string password)
        {
            return users.FirstOrDefault(user => user.Email == userName && user.Password == password);
        }
    }
}
