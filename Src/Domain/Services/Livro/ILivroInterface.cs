using backend.Src.Dto;
using backend.Src.Models;

namespace Domain.Services.Livro
{
    public interface ILivroInterface
    {
        Task<ResponseModel<List<LivroModel>>> ListarLivros();
        Task<ResponseModel<LivroModel>> BuscarLivroPorId(int idLivro);

       Task<ResponseModel<List<LivroModel>>> BuscarLivrosPorAutor(int idAutor);

       Task<ResponseModel<List<LivroModel>>> InserirLivro(LivroInsercaoDto livroInsercaoDto);

       Task<ResponseModel<List<LivroModel>>> AtualizarLivro(LivroEdicaoDto livroEdicaoDto);

       Task<ResponseModel<List<LivroModel>>> DeletarLivro(int idLivro);
    }
}