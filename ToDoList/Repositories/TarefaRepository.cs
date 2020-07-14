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

        public async Task UpdateTarefa(string nomeTarefa, Boolean statusTarefa, string descricaoTarefa, Lista lista)
        {
            var tarefa = await contexto.Set<Tarefa>().Where(t => t.Nome == nomeTarefa).SingleOrDefaultAsync();

            if (tarefa == null)
            {
                tarefa = new Tarefa(nomeTarefa, descricaoTarefa, true, lista);
                await contexto.Set<Tarefa>().AddAsync(tarefa);
            }
            else
            {
                tarefa.TarefaSetCampos(nomeTarefa, descricaoTarefa, statusTarefa, lista);
                contexto.Set<Tarefa>().Update(tarefa);
            }

            await contexto.SaveChangesAsync();
        }
    }
}
