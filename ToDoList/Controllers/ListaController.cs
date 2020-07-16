using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using ToDoList.Repositories;

namespace ToDoList.Controllers
{
    [Route("[controller]")]
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
        [Route("createtarefa")]
        public async Task CreateTarefa([FromBody] CadastroTarefaModel _tarefa)
        {
            var lista = await listaRepository.GetLista(_tarefa.IdLista);
            var tarefa = new Tarefa(_tarefa.Nome, _tarefa.Descricao, _tarefa.Status, lista);

            await tarefaRepository.CreateTarefa(tarefa);
        }
        
        [HttpPost]
        [Route("updatetarefa")]
        public async Task UpdateTarefa([FromBody] CadastroTarefaModel _tarefa)
        {
            var tarefa = await tarefaRepository.GetTarefa(_tarefa.IdTarefa);
            var lista = await listaRepository.GetLista(_tarefa.IdLista);

            tarefa.TarefaSetCampos(_tarefa.Nome, _tarefa.Descricao, _tarefa.Status, lista);
                        
            await tarefaRepository.UpdateTarefa(tarefa);
        }

        [HttpPost]
        [Route("deletetarefa")]
        public async Task DeleteTarefa([FromBody] int idTarefa)
        {
            await tarefaRepository.DeleteTarefa(idTarefa);
        }

        [HttpGet]
        [Route("tarefas")]
        public async Task<IActionResult> Tarefas(int idLista)
        {
            var lista = await listaRepository.GetLista(idLista);

            if (lista == null)
            {
                return NotFound(lista.Tarefas);
            }
            else
            {
                var retornoTarefas = new List<Tarefa>();

                retornoTarefas.Add(new Tarefa("Teste", "Teste", true, lista));
                retornoTarefas.Add(new Tarefa("asda", "Teste", true, lista));
                retornoTarefas.Add(new Tarefa("asd", "s", true, lista));

                return Ok(retornoTarefas);
            }
        }

    }
}
