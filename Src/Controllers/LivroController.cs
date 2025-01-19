using backend.Src.Dto;
using backend.Src.Models;
using Domain.Services.Livro;
using Microsoft.AspNetCore.Mvc;

namespace backend.Src.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivroController : ControllerBase
    {
        private readonly ILivroInterface _livroInterface;

        public LivroController(ILivroInterface livroInterface)
        {
            _livroInterface = livroInterface;
        }

        [HttpGet("ListarLIvros")]
        public async Task<ActionResult<ResponseModel<List<LivroModel>>>> ListarAutores()
        {
            var responseListLivros = await _livroInterface.ListarLivros();
            return Ok(responseListLivros);
        }

        [HttpGet("BuscarLivroPorId/{idLivro}")]
        public async Task<ActionResult<ResponseModel<LivroModel>>> BuscarLivroPorId(int idLivro)
        {
            var responseLivro = await _livroInterface.BuscarLivroPorId(idLivro);
            return Ok(responseLivro);
        }

        [HttpGet("BuscarLivroporIdAutor/{idAutor}")]
        public async Task<ActionResult<ResponseModel<LivroModel>>> BuscarLivroporIdAutor(int idAutor)
        {
            var responseLivro = await _livroInterface.BuscarLivrosPorAutor(idAutor);
            return Ok(responseLivro);
        }

        [HttpPost("InserirLivro")]
         public async Task<ActionResult<ResponseModel<List<LivroModel>>>> InserirLivro(LivroInsercaoDto livroInsercaoDto)
        {
            var responseListLivros = await _livroInterface.InserirLivro(livroInsercaoDto);
            return Ok(responseListLivros);
        }

        [HttpPut("Atualizarlivro")]
        public async Task<ActionResult<ResponseModel<List<LivroModel>>>> Atualizarlivro(LivroEdicaoDto livroEdicaoDto)
        {
            var responseListLivros = await _livroInterface.AtualizarLivro(livroEdicaoDto);
            return Ok(responseListLivros);
        }

        [HttpDelete("DeletarLivro/{idLivro}")]
        public async Task<ActionResult<ResponseModel<List<LivroModel>>>> DeletarLivro(int idLivro)
        {
            var responseListLivros = await _livroInterface.DeletarLivro(idLivro);
            return Ok(responseListLivros);
        }

    }
}