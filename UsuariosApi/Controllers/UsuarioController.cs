using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UsuariosApi.Data.Dtos;
using UsuariosApi.Models;
using UsuariosApi.Services;

namespace UsuariosApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        
        private CadastroService _cadastroService;

        public UsuarioController(CadastroService cadastroService)
        {
            _cadastroService = cadastroService;
        }

        

        [HttpPost]
        public async Task<IActionResult> CadastraUsuario(CreateUsuarioDto dto)
        {
            
           await _cadastroService.CadastraUsuario(dto);
            return Ok("Usuário cadastrado!");
        }
    }
}
