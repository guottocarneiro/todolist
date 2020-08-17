using System;
using System.Collections;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
        private readonly IHttpContextAccessor contextAccessor;

        public ListaController(IListaRepository _listaRepository, ITarefaRepository _tarefaRepository, IHttpContextAccessor _contextAccessor)
        {
            listaRepository = _listaRepository;
            tarefaRepository = _tarefaRepository;
            contextAccessor = _contextAccessor;
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
        [Route("createlista")]
        public async Task CreateLista([FromBody] CadastroListaModel _lista)
        {
            var lista = new Lista(_lista.Nome, _lista.IdUsuario);

            await listaRepository.CreateLista(lista);
        }

        [HttpGet]
        [Route("{idUsuario}")]
        public async Task<ICollection> GetListaPorUsuario(int idUsuario)
        {
            var listas = await listaRepository.GetListaUsuario(idUsuario);

            var result = (from e in listas
                          select new { e.Id, e.Nome}).ToArray();

            return result;
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

        [HttpPost]
        [Route("trocartarefa")]
        public async Task ConcluirTarefa([FromBody] int idTarefa)
        {
            var tarefa = await tarefaRepository.GetTarefa(idTarefa);
            tarefa.TarefaSetCampos(tarefa.Nome, tarefa.Descricao, !tarefa.Status, tarefa.Lista);

            await tarefaRepository.UpdateTarefa(tarefa);
        }

        [HttpGet]
        [Route("{idLista}/tarefas")]
        public async Task<IActionResult> Tarefas(int idLista)
        {
            var lista = await listaRepository.GetLista(idLista);

            if (lista == null)
            {
                return NotFound();
            }
            else
            {
                var result = (from e in lista.Tarefas
                              select new { e.Id, e.Nome, e.Descricao, idLista, e.Status }).ToArray();

                return Ok(result);
            }
        }

        [HttpGet]
        [Route("{idLista}/tarefas/{idTarefa}")]
        public async Task<IActionResult> GetTarefa(int idLista, int idTarefa)
        {
            var tarefa = await tarefaRepository.GetTarefa(idTarefa);

            if (tarefa == null)
            {
                return NotFound();
            }
            else
            {
                var result = new CadastroTarefaModel(tarefa.Id,tarefa.Nome,tarefa.Descricao,idLista, tarefa.Status);

                return Ok(result);
            }
        }

    }
}
