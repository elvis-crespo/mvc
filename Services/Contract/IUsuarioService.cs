using ProjectLogin.Models;

namespace ProjectLogin.Services.Contract
{
    public interface IUsuarioService
    {
        Task<Usuario> GetUsuarios(string correo, string clave);
        Task<Usuario> SaveUsuarios(Usuario modelo);
    }
}
