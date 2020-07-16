using LoginAPI.Models;
using System.Threading.Tasks;

namespace LoginAPI.Repositories
{
    public interface IUsuarioRepository
    {
        Task CreateUsuario(Usuario usuario);
        Task<Usuario> RealizarLogin(string loginUsuario, string senhaUsuario);
        Task UpdateUsuario(string loginUsuario, string senhaUsuario);
    }
}