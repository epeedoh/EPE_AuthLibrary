using EPE_AuthLibrary.Interfaces;
using EPE_AuthLibrary.Models;
using EPE_AuthLibrary.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPE_AuthLibrary.Tests
{
    public class UserServiceTests
    {
        [Fact]
        public async void CreateUser_ShouldAddUserSuccessfully()
        {
            //Arrange
            var mockUserRepository = new Mock<IUserRepository>();

         //   var userService = new UserService();

            var newUser = new User
            {
                Username = "johndoe",
                Email = "epe@gmail.com",
                Role = "User",
                PhoneNumber = "1234567890"
            };

            var password = "TestPassword";

            //Configurer le mock pour retourner un utilisateur pour un identifiant spéciphique
            mockUserRepository.Setup(repo => repo.GetUserByUsernameOrEmailOrPhoneAsync(It.IsAny<string>()))
                .ReturnsAsync(newUser);

            // Créer une instance de UserService en utilisant le mock de IUserRepository via ServiceFactory
            var userService = ServiceFactory.CreateUserService(mockUserRepository.Object);


            //Act
            await userService.CreateUserAsync(newUser, password);
            var createdUser = await userService.GetUserByUsernameOrEmailOrPhoneAsync("testuser");

            //Assert
            Assert.NotNull(createdUser);
            Assert.Equal("johndoe", createdUser.Username);
            Assert.Equal("epe@gmail.com", createdUser.Email);

        }
    }
}
