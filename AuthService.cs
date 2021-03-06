using DAL;
using Microsoft.AspNetCore.Identity;
using Services.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.implementations
{
    public class AuthService : IAuthService
    {
        //public User AuthenticateUser(string Username, string Password)
        //{
        //    throw new NotImplementedException();
        //}

        //public bool CreateUser(User user, string Password)
        //{
        //    throw new NotImplementedException();
        //}

        //public User GetUser(string Username)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<bool> SignOut()
        //{
        //    throw new NotImplementedException();
        //}
        protected SignInManager<User> _signManager;
        protected UserManager<User> _userManager;
        protected RoleManager<Role> _roleManager;
        public AuthService(SignInManager<User> signManager, UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signManager = signManager;
        }
        public User AuthenticateUser(string Username, string Password)
        {
            //lockoutOnFailure default value:5 
            var result = _signManager.PasswordSignInAsync(Username, Password, false, lockoutOnFailure: false).Result;
            if (result.Succeeded)
            {
                var user = _userManager.FindByNameAsync(Username).Result;
                var roles = _userManager.GetRolesAsync(user).Result;
                user.Roles = roles.ToArray();

                return user;
            }
            return null;
        }

        public User GetUser(string Username)
        {
            return _userManager.FindByNameAsync(Username).Result;
        }
        public bool CreateUser(User user, string Password)
        {
            var result = _userManager.CreateAsync(user, Password).Result;
            if (result.Succeeded)
            {
                //Admin, User
                string role = "Admin";
                var res = _userManager.AddToRoleAsync(user, role).Result;
                if (res.Succeeded)
                {
                    return true;
                }
            }
            return false;
        }

        public async Task<bool> SignOut()
        {
            try
            {
                await _signManager.SignOutAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
