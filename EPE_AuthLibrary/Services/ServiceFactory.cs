using EPE_AuthLibrary.Config;
using EPE_AuthLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPE_AuthLibrary.Services
{
    public static class ServiceFactory
    {
        //Factory pour créer un UserService avec IUserReposotory
        public static IUserService CreateUserService(IUserRepository userReposotory)
        {
            return new UserService(userReposotory);
        }

        public static ITokenService CreateTokenService(JwtConfig jwtConfig) 
        { 
          return new TokenService(jwtConfig);  
        }

    }
}
