using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using LoginAPI.Models;
using LoginAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoginAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository usuarioRepository;

        public UsuarioController (IUsuarioRepository usuarioRepository)
        {
            this.usuarioRepository = usuarioRepository;
        }
        
        [HttpGet("logar")]
        public async Task<IActionResult> Login(string loginUsuario, string senhaUsuario)
        {
            var usuario = await usuarioRepository.RealizarLogin(loginUsuario, senhaUsuario);

            if (usuario == null)
            {
                return NotFound(usuario);
            }
            else
            {
                usuario.Senha = null;
                return Ok(usuario);
            }
        }
        
        [HttpPost("cadastro")]
        public async Task Cadastro([FromBody] CadastroUsuarioModel _usuario)
        {
            var usuario = new Usuario(_usuario.loginUsuario, _usuario.senhaUsuario);

            await usuarioRepository.CreateUsuario(usuario);
        }
    }
}
