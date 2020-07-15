using System;
using System.Threading.Tasks;
using ToDoList.Models;

namespace ToDoList.Repositories
{
    public interface IListaRepository
    {
        Task CreateLista();
        Task<Lista> GetLista(int idLista);
    }
}