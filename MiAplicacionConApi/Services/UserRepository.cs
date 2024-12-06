using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MiAplicacionConApi.Domain;
using MiAplicacionConApi.Data;

namespace MiAplicacionConApi.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        // Constructor que recibe el DbContext
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Obtener todos los usuarios
        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        // Buscar un usuario por su código
        public async Task<User> GetUserByCodeAsync(string code)
        {
            // Usar FirstOrDefaultAsync para buscar por "Code" en lugar de "FindAsync"
            return await _context.Users
                                 .FirstOrDefaultAsync(u => u.Code == code);
        }

        // Crear un nuevo usuario
        public async Task AddUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        // Actualizar un usuario
        public async Task UpdateUserAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        // Eliminar un usuario
        public async Task DeleteUserAsync(string code)
        {
            var user = await _context.Users
                                      .FirstOrDefaultAsync(u => u.Code == code);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }
    }
}
