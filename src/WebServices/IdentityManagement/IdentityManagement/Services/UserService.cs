using IdentityManagement.Models;
using IdentityManagement.ViewModels;
using System.Collections.Generic;
using System.Linq;

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

        public User Register(RegisterViewModel registerViewModel)
        {
            User registeredUser = null;

            if (!users.Any(user => user.Email == registerViewModel.Email))
            {
                registeredUser = new User()
                {
                    Name = registerViewModel.Name,
                    Password = registerViewModel.Password,
                    Email = registerViewModel.Email,
                    PhoneNumber = registerViewModel.PhoneNumber,
                    Username = registerViewModel.Username
                };
                users.Add(registeredUser);
            }
            else
            {
                //TODO: if any user if found then throw exception
            }
            return registeredUser;
        }

        public User Login(LoginViewModel loginViewModel)
        {
            return users.FirstOrDefault(user => user.Username == loginViewModel.Username && user.Password == loginViewModel.Password);
        }
    }
}
