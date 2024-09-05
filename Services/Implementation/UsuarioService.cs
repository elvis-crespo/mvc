using Microsoft.EntityFrameworkCore;
using ProjectLogin.Contexto;
using ProjectLogin.Models;
using ProjectLogin.Services.Contract;

namespace ProjectLogin.Services.Implementation
{
    public class UsuarioService : IUsuarioService
    {
        private readonly ApplicationDbContext _context;
                                                       
        public UsuarioService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario> GetUsuarios(string correo, string clave)
        {
            Usuario usuarioEncontrado = await _context.Usuarios.Where(u =>
                u.Correo == correo && u.clave == clave).FirstOrDefaultAsync();

            return usuarioEncontrado;
        }

        public async Task<Usuario> SaveUsuarios(Usuario modelo)
        {
            _context.Usuarios.Add(modelo);
            await _context.SaveChangesAsync();
            return modelo;
        }
    }
}
