using System.Threading.Tasks;
using ToDoList.Models;

namespace ToDoList.Repositories
{
    public interface ITarefaRepository
    {
        Task UpdateTarefa(string nomeTarefa, bool statusTarefa, string descricaoTarefa, Lista lista);
    }
}