using System.Threading.Tasks;
using ToDoList.Models;

namespace ToDoList.Repositories
{
    public interface ITarefaRepository
    {
        Task UpdateTarefa(Tarefa tarefa);
        Task CreateTarefa(Tarefa tarefa);
    }
}