using AuthenticationService.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationService.Core.Interfaces.Repositories
{
    public interface IAuthRepository
    {
        Task<User> Login(string username);
    }
}
