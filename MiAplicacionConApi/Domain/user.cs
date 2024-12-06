using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MiAplicacionConApi.Domain;
public class User
{
    [Required(ErrorMessage = "El código es obligatorio.")]
    [StringLength(50, ErrorMessage = "El código no puede exceder 50 caracteres.")]
    public string Code { get; set; }

    [Required(ErrorMessage = "La contraseña es obligatoria.")]
    [StringLength(100, MinimumLength = 6, ErrorMessage = "La contraseña debe tener al menos 6 caracteres.")]
    public string Password { get; set; }

    [Required(ErrorMessage = "El nombre es obligatorio.")]
    [StringLength(50, ErrorMessage = "El nombre no puede exceder 50 caracteres.")]
    public string Name { get; set; }

    [StringLength(50, ErrorMessage = "Los apellidos no pueden exceder 50 caracteres.")]
    public string Apellidos { get; set; }

    [Required(ErrorMessage = "El rol es obligatorio.")]
    [StringLength(20, ErrorMessage = "El rol no puede exceder 20 caracteres.")]
    public string Rol { get; set; }

    [Required(ErrorMessage = "El correo electrónico es obligatorio.")]
    [EmailAddress(ErrorMessage = "Debe ingresar un correo electrónico válido.")]
    public string Email { get; set; }

    [Phone(ErrorMessage = "Debe ingresar un número de teléfono válido.")]
    public string Telefono { get; set; }

    [StringLength(20, ErrorMessage = "El estado no puede exceder 20 caracteres.")]
    public string Estado { get; set; }

    [Required(ErrorMessage = "La fecha de registro es obligatoria.")]
    public DateTime FechaRegistro { get; set; }

    // Constructor que asegura la inicialización de las propiedades obligatorias
    public User(string code, string password, string name, string rol, string email, DateTime fechaRegistro)
    {
        Code = code;
        Password = password;
        Name = name;
        Rol = rol;
        Email = email;
        FechaRegistro = fechaRegistro;
        Apellidos = "";  // Default value
        Telefono = "";  // Default value
        Estado = "";  // Default value
    }
}
