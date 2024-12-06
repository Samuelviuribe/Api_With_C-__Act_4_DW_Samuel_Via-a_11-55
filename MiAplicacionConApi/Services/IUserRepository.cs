using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MiAplicacionConApi.Domain;

namespace MiAplicacionConApi.Services
{
    public interface IUserRepository
    {
    Task<List<User>> GetAllUsersAsync();
    Task<User> GetUserByCodeAsync(string code);
    Task AddUserAsync(User user);
    Task UpdateUserAsync(User user);
    Task DeleteUserAsync(string code);
    }
}