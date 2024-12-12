using Microsoft.AspNetCore.Mvc;
using MiAplicacionConApi.Services;
using MiAplicacionConApi.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiAplicacionConApi.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        // Constructor que recibe el repositorio de usuarios
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // Obtener todos los usuarios
        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            try
            {
                var users = await _userRepository.GetAllUsersAsync();
                if (users == null || !users.Any())
                {
                    return NotFound("No se encontraron usuarios.");
                }
                return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener los usuarios: {ex.Message}");
            }
        }

        // Obtener un usuario por código
        [HttpGet("{code}")]
        public async Task<ActionResult<User>> GetUserByCode(string code)
        {
            try
            {
                var user = await _userRepository.GetUserByCodeAsync(code);
                if (user == null)
                {
                    return NotFound($"Usuario con código {code} no encontrado.");
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener el usuario: {ex.Message}");
            }
        }

        // Añadir un nuevo usuario
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            try
            {
                await _userRepository.AddUserAsync(user);
                return CreatedAtAction(nameof(GetUserByCode), new { code = user.Code }, user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al añadir el usuario: {ex.Message}");
            }
        }

        // Actualizar un usuario existente
        [HttpPut("{code}")]
        public async Task<IActionResult> PutUser(string code, User user)
        {
            if (code != user.Code)
            {
                return BadRequest("El código de usuario no coincide.");
            }

            try
            {
                await _userRepository.UpdateUserAsync(user);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al actualizar el usuario: {ex.Message}");
            }
        }

        // Eliminar un usuario existente
        [HttpDelete("{code}")]
        public async Task<IActionResult> DeleteUser(string code)
        {
            try
            {
                await _userRepository.DeleteUserAsync(code);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al eliminar el usuario: {ex.Message}");
            }
        }
    }
}
