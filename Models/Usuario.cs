using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ProjectLogin.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string NombreUsuario { get; set; } = null!;

        [MaxLength(50)]
        public string Correo { get; set; } = null!;

        [Required]
        [MaxLength(100)]
        public string clave { get; set; } = null!;
    }
}
