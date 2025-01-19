using backend.Src.Data;
using backend.Src.Dto;
using backend.Src.Models;
using Microsoft.EntityFrameworkCore;

namespace Domain.Services.Autor
{
    public class AutorServices : IAutorInterface
    {
        private readonly AppDbContext _context;
        public AutorServices(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<AutorModel>> BuscarAutorPorId(int idAutor)
        {
            ResponseModel<AutorModel> response = new ResponseModel<AutorModel>();

            try
            {
                var autor = await _context.Autores.FirstOrDefaultAsync(linhaBanco => linhaBanco.Id == idAutor);
                if (autor == null)
                {
                    response.Mensagem = "Autor não encontrado";
                    response.Status = false;
                    return response;
                }
                response.Dados = autor;
                response.Mensagem = "Autor encontrado com sucesso";
                response.Status = true;
                return response;
            }
            catch (Exception ex)
            {

                response.Mensagem = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<AutorModel>> BuscarAutorPorIdLivro(int idLivro)
        {
            ResponseModel<AutorModel> response = new ResponseModel<AutorModel>();

            try
            {
                var livro = await _context.Livros
                .Include(autorModel => autorModel.Autor)
                .FirstOrDefaultAsync(linhaBanco => linhaBanco.Id == idLivro);

                if (livro == null)
                {
                    response.Mensagem = "Nenhum registro encontrado";
                    response.Status = false;
                    return response;
                }

                response.Dados = livro.Autor;
                response.Mensagem = "Autor encontrado com sucesso";
                response.Status = true;
                return response;
            }
            catch (Exception ex)
            {

                response.Mensagem = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<AutorModel>>> ListarAutores()
        {
            ResponseModel<List<AutorModel>> response = new ResponseModel<List<AutorModel>>();

            try
            {
                var autores = await _context.Autores.ToListAsync();

                response.Dados = autores;
                response.Mensagem = "Autores listados com sucesso";
                response.Status = true;
                return response;
            }
            catch (Exception ex)
            {

                response.Mensagem = ex.Message;
                response.Status = false;
                return response;
            }
        }


        public async Task<ResponseModel<List<AutorModel>>> InserirAutor(AutorInsercaoDto autorInsercaoDto)
        {
            ResponseModel<List<AutorModel>> response = new ResponseModel<List<AutorModel>>();

            try
            {
               var autor = new AutorModel()
                {
                    Nome = autorInsercaoDto.Nome,
                    Sobrenome = autorInsercaoDto.Sobrenome
                };

                _context.Autores.Add(autor);
                await _context.SaveChangesAsync();

                response.Dados = await _context.Autores.ToListAsync();
                response.Mensagem = "Autor inserido com sucesso";
                response.Status = true;
                return response;
            }
            catch (Exception ex)
            {

                response.Mensagem = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<AutorModel>>> AtualizarAutor(AutorEdicaoDto autorEdicaoDto)
        {
            ResponseModel<List<AutorModel>> response = new ResponseModel<List<AutorModel>>();

            try
            {
                var autor = await _context.Autores.FirstOrDefaultAsync(linhaBanco => linhaBanco.Id == autorEdicaoDto.Id);
                if (autor == null)
                {
                    response.Mensagem = "Autor nao encontrado";
                    response.Status = true;
                    return response;
                }

                autor.Nome = autorEdicaoDto.Nome;
                autor.Sobrenome = autorEdicaoDto.Sobrenome;

                _context.Autores.Update(autor); 
                await _context.SaveChangesAsync();

                response.Dados = await _context.Autores.ToListAsync();
                response.Mensagem = "Autor atualizado com sucesso";
                response.Status = true;
                return response;
            }
            catch (Exception ex)
            {
                
                response.Mensagem = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<AutorModel>>> DeletarAutor(int idAutor)
        {
            ResponseModel<List<AutorModel>> response = new ResponseModel<List<AutorModel>>();

            try
            {
                var autor = await _context.Autores.FirstOrDefaultAsync(linhaBanco => linhaBanco.Id == idAutor);
                if (autor == null)
                {
                    response.Mensagem = "Autor nao encontrado";
                    response.Status = true;
                    return response;
                }

                _context.Autores.Remove(autor);
                await _context.SaveChangesAsync();

                response.Dados = await _context.Autores.ToListAsync();
                response.Mensagem = "Autor deletado com sucesso";
                response.Status = true;
                return response;
            }
            catch (Exception ex)
            {
                
                response.Mensagem = ex.Message;
                response.Status = false;
                return response;
            }
        }
    }
}