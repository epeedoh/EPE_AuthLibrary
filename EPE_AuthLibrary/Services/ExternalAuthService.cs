using EPE_AuthLibrary.Interfaces;
using EPE_AuthLibrary.Models;
using Google.Apis.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPE_AuthLibrary.Services
{
    public class ExternalAuthService : IExternalAuthService
    {
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;

        public ExternalAuthService(IUserService userService, ITokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
        }   

        public async Task<AuthResponse> AuthenticateWithProviderAsync(string provider, string token)
        {
            if(provider.ToLower()=="google")
            {
                //Validation du token Google
                var payload = await GoogleJsonWebSignature.ValidateAsync(token);

                //Verifier si l'utilisateur existe
                var user = await _userService.GetUserByUsernameOrEmailOrPhoneAsync(payload.Email);  

                //si l'utilisateur n'existe pas le créer
                if(user == null) {
                    user = new User
                    {
                        Username = payload.Email,
                        Email = payload.Email,
                        FullName = payload.Name,
                        Role = "User",
                        CreatedAt = DateTime.Now
                    };
                    await _userService.CreateUserAsync(user, null);
                }

                // Generer token jwt pour notre systeme
                var jwtToken = _tokenService.GenerateToken(user);
                return new AuthResponse { Token = jwtToken, User = user };
            }else
            {
                throw new NotSupportedException("Fournisseur d'authentification non pris en charge.");
            }

        }


    }
}
