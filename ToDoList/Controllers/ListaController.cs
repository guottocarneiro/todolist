using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using ToDoList.Repositories;

namespace ToDoList.Controllers
{
    public class ListaController : Controller
    {
        private readonly IListaRepository listaRepository;
        private readonly ITarefaRepository tarefaRepository;

        public ListaController(IListaRepository _listaRepository, ITarefaRepository _tarefaRepository)
        {
            listaRepository = _listaRepository;
            tarefaRepository = _tarefaRepository;
        }        
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task Create([FromBody] CadastroTarefaModel _tarefa)
        {
            var lista = await listaRepository.GetLista(_tarefa.IdLista);
            var tarefa = new Tarefa(_tarefa.Nome, _tarefa.Descricao, _tarefa.Status, lista);

            await tarefaRepository.CreateTarefa(tarefa);
        }
    }
}
