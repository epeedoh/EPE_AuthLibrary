using EPE_AuthLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPE_AuthLibrary.Interfaces
{
    public interface IUserService
    {
        Task<User> GetUserByUsernameOrEmailOrPhoneAsync(string identifier);
        Task CreateUserAsync(User newUser, string password);
        bool VerifyPassword(User user, string password);
    }
}
