using Microsoft.AspNetCore.Mvc;
using MiAplicacionConApi.Services;
using MiAplicacionConApi.Domain;

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
    }
}
