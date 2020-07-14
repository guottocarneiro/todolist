using System;
using System.Threading.Tasks;
using ToDoList.Models;

namespace ToDoList.Repositories
{
    public interface IListaRepository
    {
        Task UpdateTarefa(int idLista, string nomeTarefa, Boolean statusTarefa, string descricaoTarefa);
        Task<Lista> GetLista(int idLista);
    }
}