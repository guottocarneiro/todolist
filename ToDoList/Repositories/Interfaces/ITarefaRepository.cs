using System.Threading.Tasks;
using ToDoList.Models;

namespace ToDoList.Repositories
{
    public interface ITarefaRepository
    {
        Task UpdateTarefa(Tarefa tarefa);
        Task CreateTarefa(Tarefa tarefa);
        Task DeleteTarefa(int idTarefa);
        Task<Tarefa> GetTarefa(int idTarefa);
    }
}