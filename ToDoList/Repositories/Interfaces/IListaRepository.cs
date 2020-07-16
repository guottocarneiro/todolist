using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoList.Models;

namespace ToDoList.Repositories
{
    public interface IListaRepository
    {
        Task CreateLista();
        Task<Lista> GetLista(int idLista);
        Task<ICollection<Lista>> GetListaUsuario(int idUsuario);
        void SetUsuarioSession(int idUsuario);

    }
}