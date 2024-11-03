using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPE_AuthLibrary.Models
{
    public class AuthResponse
    {
        public string Token { get; set; }              // Token JWT
        public User User { get; set; }                 // Informations sur l'utilisateur
    }
}
