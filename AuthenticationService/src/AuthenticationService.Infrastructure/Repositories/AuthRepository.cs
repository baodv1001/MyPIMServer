using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthService.Infrastructure.Context;
using AuthService.Infrastructure.Entities;
using AuthenticationService.Core.Interfaces.Repositories;

namespace AuthService.Infrastructure.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly AuthDbContext _dbContext;
        private readonly IMapper _mapper;
        public AuthRepository(AuthDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<AuthenticationService.Core.Models.User> Login(string username)
        {
            // Find user by username
            var user = await _dbContext.Users.Include(i => i.Role).FirstOrDefaultAsync(i => i.Username == username);
            if (user != null)
            {
                return _mapper.Map<AuthenticationService.Core.Models.User>(user);
            }
            return null;
        }
    }
}
