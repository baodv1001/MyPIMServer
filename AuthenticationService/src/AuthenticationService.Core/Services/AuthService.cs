using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthenticationService.Core.Interfaces.Repositories;
using AuthenticationService.Core.Models;
using AuthenticationService.Core.Interfaces.Services;

namespace AuthService.Core.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;
        private readonly ILogger<AuthService> _logger;
        public AuthService(IAuthRepository authRepository, ILogger<AuthService> logger)
        {
            _authRepository = authRepository ?? throw new ArgumentNullException(nameof(authRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public Task<User> Login(string username)
        {
            var user = _authRepository.Login(username);
            if (user != null)
            {
                return user;
            }
            return null;
        }
    }
}
