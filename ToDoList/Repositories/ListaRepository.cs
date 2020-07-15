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

        public async Task CreateLista()
        {
            var lista = new Lista((int)(contextAccessor.HttpContext.Session.GetInt32("usuarioId")));
            await dbSet.AddAsync(lista);
            await contexto.SaveChangesAsync();
        }

    }
}
