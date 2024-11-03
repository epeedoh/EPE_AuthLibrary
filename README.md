# EPE Auth 

EPE Auth est une bibliothèque d'authentification réutilisable qui permet de gérer les utilisateurs, les rôles, et l'authentification JWT dans des projets .NET. Cette bibliothèque suit les principes SOLID et est conçue pour être facilement extensible et réutilisable dans divers projets nécessitant une gestion des utilisateurs.

## Installation

Vous pouvez installer ce package via NuGet :

```sh
Install-Package EPE_AuthLibrary
```

## Fonctionnalités

- **Authentification via JWT** : Génération de tokens sécurisés pour authentifier les utilisateurs.
- **Support des Fournisseurs Tiers** : Authentification via Google, Facebook, etc.
- **Gestion des Utilisateurs** : Enregistrement, connexion, gestion des utilisateurs avec flexibilité (e-mail, numéro de téléphone, etc.).
- **Respect de SOLID** : Facile à adapter et étendre.

## Utilisation

### Initialisation

Après avoir ajouté la bibliothèque à votre projet, vous pouvez utiliser les services pour gérer l'authentification.

### Exemple de Code

```csharp

using EPE_AuthLibrary.Interfaces;
using EPE_AuthLibrary.Models;
using EPE_AuthLibrary.Services;

// Exemple d'utilisation de UserService
var userRepository = new UserRepository();
var userService = ServiceFactory.CreateUserService(userRepository);

// Création d'un nouvel utilisateur
var newUser = new User
{
    Username = "johndoe",
    Email = "johndoe@example.com",
    PhoneNumber = "123456789"
};
await userService.CreateUserAsync(newUser, "password123");
```

## Configuration JWT

Pour configurer la génération des tokens JWT, vous devrez fournir une configuration `JwtConfig` au `TokenService` :

```csharp
var jwtConfig = new JwtConfig
{
    Secret = "votre_secret_ici",
    Issuer = "votre_issuer",
    Audience = "votre_audience",
    ExpirationMinutes = 60
};
var tokenService = ServiceFactory.CreateTokenService(jwtConfig);
```

## Intégration avec des Fournisseurs Tiers

Pour ajouter l'authentification via des fournisseurs comme Google, utilisez `IExternalAuthService` :

```csharp
var externalAuthService = new ExternalAuthService(userService, tokenService);
var authResponse = await externalAuthService.AuthenticateWithProviderAsync("google", "token_du_client");
```

## Prérequis

- .NET 6.0 ou plus récent.
- Les dépendances suivantes sont requises pour fonctionner correctement :
  - Microsoft.AspNetCore.Authentication.JwtBearer
  - Google.Apis.Auth (si vous utilisez Google comme fournisseur tiers)

## Contribution

Les contributions sont les bienvenues ! Si vous souhaitez contribuer, veuillez ouvrir une **issue** ou une **pull request** sur le [dépôt GitHub](https://github.com/epeedoh).

## Licence

Ce projet est sous licence MIT. Voir le fichier [LICENSE](LICENSE.txt) pour plus de détails.

## Contact

Pour toute question ou suggestion, n'hésitez pas à me contacter par e-mail à : contact@example.com
