using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Models;

namespace ToDoList.Repositories
{
    public class ListaRepository : BaseRepository<Lista>, IListaRepository
    {
        private readonly IHttpContextAccessor contextAccessor;
        public ListaRepository(ApplicationContext contexto, IHttpContextAccessor contextAccessor) : base(contexto)
        {
            this.contextAccessor = contextAccessor;
        }

        public async Task<Lista> GetLista (int idLista)
        {
            var lista = await dbSet.Include(p => p.Tarefas).Where(p => p.Id == idLista).SingleOrDefaultAsync();
            return lista;
        }

        public async Task<ICollection<Lista>> GetListaUsuario(int idUsuario)
        {
            var listas = await dbSet.Include(p => p.Tarefas).Where(p => p.IdUsuario == idUsuario).ToListAsync();
            return listas;
        }

        public async Task CreateLista()
        {
            var lista = new Lista((int)(contextAccessor.HttpContext.Session.GetInt32("usuarioId")));
            await dbSet.AddAsync(lista);
            await contexto.SaveChangesAsync();
        }

        public void SetUsuarioSession(int idUsuario)
        {
            contextAccessor.HttpContext.Session.SetInt32("usuarioId", idUsuario);
        }

    }
}
