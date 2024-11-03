using EPE_AuthLibrary.Interfaces;
using EPE_AuthLibrary.Models;
using EPE_AuthLibrary.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPE_AuthLibrary.Services
{
    public class UserService : IUserService
    {
        private readonly Dictionary<string, User> _users = new Dictionary<string, User>();

        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task CreateUserAsync(User newUser, string password)
        {
            newUser.PasswordHash = PasswordHasher.HashPassword(password);
            //_users[newUser.Username] = newUser;
            //await Task.CompletedTask;
            await _userRepository.CreateUserAsync(newUser);
        }

        public async Task<User> GetUserByUsernameOrEmailOrPhoneAsync(string identifier)
        {

            ////Rechercher un utilisateur par nom d'utilisateur, email ou numero
            //var user = _users.Values.FirstOrDefault(u =>
            //u.Username == identifier ||
            //u.Email == identifier ||
            //u.PhoneNumber == identifier
            //);
            //return await Task.FromResult(user);
            return await _userRepository.GetUserByUsernameOrEmailOrPhoneAsync(identifier);
        }

        public bool VerifyPassword(User user, string password)
        {
            return PasswordHasher.VerifyHashedPassword(user.PasswordHash,password);
        }
    }
}
