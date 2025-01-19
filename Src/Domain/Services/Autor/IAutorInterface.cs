using backend.Src.Dto;
using backend.Src.Models;

namespace Domain.Services.Autor{
    public interface IAutorInterface
    {
       Task<ResponseModel<List<AutorModel>>> ListarAutores();

       Task<ResponseModel<AutorModel>> BuscarAutorPorId(int id);

       Task<ResponseModel<AutorModel>> BuscarAutorPorIdLivro(int idLivro);

       Task<ResponseModel<List<AutorModel>>> InserirAutor(AutorInsercaoDto autorInsercaoDto);

       Task<ResponseModel<List<AutorModel>>> AtualizarAutor(AutorEdicaoDto autorEdicaoDto);

       Task<ResponseModel<List<AutorModel>>> DeletarAutor(int idAutor);
    }
}