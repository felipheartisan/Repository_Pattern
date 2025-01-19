
using backend.Src.Domain.Repositories;
using backend.Src.Models;
using Microsoft.AspNetCore.Mvc;
using backend.Src.Data;
namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private AppDbContext _context;
        private UsuarioRepository _repository;
        public UsuarioController(AppDbContext context)
        {
            _context = context;
            _repository = new UsuarioRepository(_context);
        }
        [HttpPost("Registrar")]
        public async Task<IActionResult> RegistrarLogin([FromBody] UsuarioModel novoUsuario)
        {
            await _repository.Criar(novoUsuario);
            return Ok(novoUsuario);

        }

    }
}