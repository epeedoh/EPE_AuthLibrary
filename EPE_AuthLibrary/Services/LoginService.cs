using EPE_AuthLibrary.Interfaces;
using EPE_AuthLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPE_AuthLibrary.Services
{
    public class LoginService : ILoginService
    {
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;

        public LoginService(IUserService userService, ITokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
        }

        public async Task<AuthResponse> LoginAsync(string identifier, string password)
        {
            //Rechercher un utilisateur par email, nom d'utilisateur, numero
            var user = await _userService.GetUserByUsernameOrEmailOrPhoneAsync(identifier);

            if(user == null ||!_userService.VerifyPassword(user,password))
            {
                  throw new UnauthorizedAccessException("Identifiant ou mot de passe incorrect.");  
            }

            //Generation du token JWT
            var token = _tokenService.GenerateToken(user);

            return new AuthResponse { Token = token, User = user };
        }
    }
}
