using EPE_AuthLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPE_AuthLibrary.Interfaces
{
    public interface ILoginService
    {
        Task<AuthResponse> LoginAsync(string identifier, string password);  
    }
}
