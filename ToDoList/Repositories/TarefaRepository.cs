using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Models;

namespace ToDoList.Repositories
{
    public class TarefaRepository : BaseRepository<Tarefa>, ITarefaRepository
    {
        public TarefaRepository(ApplicationContext contexto) : base(contexto)
        {

        }

        public async Task CreateTarefa(Tarefa tarefa)
        {
            await dbSet.AddAsync(tarefa);
            await contexto.SaveChangesAsync();
        }

        public async Task UpdateTarefa(Tarefa tarefa)
        {
            dbSet.Update(tarefa);
            await contexto.SaveChangesAsync();
        }

        public async Task DeleteTarefa(Tarefa tarefa)
        {
            dbSet.Remove(tarefa);
            await contexto.SaveChangesAsync();
        }
    }
}
