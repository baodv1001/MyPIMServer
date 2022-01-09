using AuthenticationService.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationService.Core.Interfaces.Services
{
    public interface IAuthService
    {
        Task<User> Login(string username);
    }
}
