using EPE_AuthLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPE_AuthLibrary.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(User user);   // Générer un token JWT pour un utilisateur
    }
}
