using LoginAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginAPI.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(ApplicationContext contexto) : base(contexto)
        {
        }

        public async Task<Usuario> RealizarLogin(string loginUsuario, string senhaUsuario)
        {
            var usuario = await dbSet.Where(u => u.Login == loginUsuario && u.Senha == senhaUsuario).SingleOrDefaultAsync();
            return usuario;
        }

        public async Task CreateUsuario(string loginUsuario, string senhaUsuario)
        {
            var usuario = new Usuario(loginUsuario, senhaUsuario);

            await dbSet.AddAsync(usuario);

            await contexto.SaveChangesAsync();
        }

        public async Task UpdateUsuario(string loginUsuario, string senhaUsuario)
        {
            var usuario = await dbSet.Where(u => u.Login == loginUsuario && u.Senha == senhaUsuario).SingleOrDefaultAsync();

            dbSet.Update(usuario);

            await contexto.SaveChangesAsync();
        }
    }
}
