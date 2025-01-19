using backend.Src.Dto;
using backend.Src.Models;
using Domain.Services.Autor;
using Microsoft.AspNetCore.Mvc;

namespace backend.Src.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly IAutorInterface _autorInterface;
        public AutorController(IAutorInterface autorInterface)
        {
            _autorInterface = autorInterface;
        }

        [HttpGet("ListarAutores")]
        public async Task<ActionResult<ResponseModel<List<AutorModel>>>> ListarAutores()
        {
            var responseListAutores = await _autorInterface.ListarAutores();
            return Ok(responseListAutores);
        }

        [HttpGet("BuscarAutorPorId/{idAutor}")]
        public async Task<ActionResult<ResponseModel<AutorModel>>> BuscarAutorPorId(int idAutor)
        {
            var responseAutor = await _autorInterface.BuscarAutorPorId(idAutor);
            return Ok(responseAutor);
        }

        [HttpGet("BuscarAutorPorIdLivro/{idLivro}")]
        public async Task<ActionResult<ResponseModel<AutorModel>>> BuscarAutorPorIdLivro(int idLivro)
        {
            var responseAutor = await _autorInterface.BuscarAutorPorIdLivro(idLivro);
            return Ok(responseAutor);
        }

        [HttpPost("InserirAutor")]
         public async Task<ActionResult<ResponseModel<List<AutorModel>>>> InserirAutor(AutorInsercaoDto autorInsercaoDto)
        {
            var responseListAutores = await _autorInterface.InserirAutor(autorInsercaoDto);
            return Ok(responseListAutores);
        }

        [HttpPut("AtualizarAutor")]
        public async Task<ActionResult<ResponseModel<List<AutorModel>>>> AtualizarAutor(AutorEdicaoDto autorEdicaoDto)
        {
            var responseListAutores = await _autorInterface.AtualizarAutor(autorEdicaoDto);
            return Ok(responseListAutores);
        }

        [HttpDelete("DeletarAutor/{idAutor}")]
        public async Task<ActionResult<ResponseModel<List<AutorModel>>>> DeletarAutor(int idAutor)
        {
            var responseListAutores = await _autorInterface.DeletarAutor(idAutor);
            return Ok(responseListAutores);
        }

    }
}