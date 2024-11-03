using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPE_AuthLibrary.Models
{
    public class User
    {
        public int UserID { get; set; }               // ID unique de l'utilisateur
        public string Username { get; set; }          // Nom d'utilisateur
        public string Email { get; set; }             // Email de l'utilisateur
        public string PasswordHash { get; set; }      // Mot de passe hashé
        public string PhoneNumber { get; set; }              // Rôle de l'utilisateur (Admin, User, etc.)
        public string Role { get; set; }
        // Champs supplémentaires (optionnels)
        public string FullName { get; set; }          // Nom complet de l'utilisateur (optionnel)
        public DateTime CreatedAt { get; set; }       // Date de création du compte
    }
}
