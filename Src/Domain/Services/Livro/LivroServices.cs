using backend.Src.Data;
using backend.Src.Dto;
using backend.Src.Models;
using Microsoft.EntityFrameworkCore;

namespace Domain.Services.Livro
{

    public class LivroServices : ILivroInterface
    {

        private readonly AppDbContext _context;
        public LivroServices(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<List<LivroModel>>> AtualizarLivro(LivroEdicaoDto livroEdicaoDto)
        {
            ResponseModel<List<LivroModel>> response = new ResponseModel<List<LivroModel>>();

            try
            {
                var livro = await _context.Livros
                .Include(autor => autor.Autor)
                .FirstOrDefaultAsync(linhaBanco => linhaBanco.Id == livroEdicaoDto.Id);

                var autor = await _context.Autores
                .FirstOrDefaultAsync(linhaBanco => linhaBanco.Id == livroEdicaoDto.Autor.Id);

                if (livro == null)
                {
                    response.Mensagem = "Livro não encontrado";
                    response.Status = false;
                    return response;
                }
                if (autor == null)
                {
                    response.Mensagem = "Autor não encontrado";
                    response.Status = false;
                    return response;
                }

                livro.Titulo = livroEdicaoDto.Titulo;
                livro.Autor = autor;

                _context.Livros.Update(livro);
                await _context.SaveChangesAsync();

                response.Dados = await _context.Livros.ToListAsync();
                response.Mensagem = "Livro atualizado com sucesso";
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

        public async Task<ResponseModel<LivroModel>> BuscarLivroPorId(int idLivro)
        {
            ResponseModel<LivroModel> response = new ResponseModel<LivroModel>();

            try
            {
                var livro = await _context.Livros
                .Include(autor => autor.Autor)
                .FirstOrDefaultAsync(linhaBanco => linhaBanco.Id == idLivro);
                
                if (livro == null)
                {
                    response.Mensagem = "Livro não encontrado";
                    response.Status = false;
                    return response;
                }
                response.Dados = livro;
                response.Mensagem = "Livro encontrado com sucesso";
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

        public async Task<ResponseModel<List<LivroModel>>> BuscarLivrosPorAutor(int idAutor)
        {
            ResponseModel<List<LivroModel>> response = new ResponseModel<List<LivroModel>>();

            try
            {
                var livros = await _context.Livros
                .Include(autor => autor.Autor)
                .Where(linhaBanco => linhaBanco.Autor.Id == idAutor).ToListAsync();

                if (livros.Count == 0)
                {
                    response.Mensagem = "Nenhum registro encontrado";
                    response.Status = false;
                    return response;
                }

                response.Dados = livros;
                response.Mensagem = "Livros encontrados com sucesso";
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

        public async Task<ResponseModel<List<LivroModel>>> DeletarLivro(int idLivro)
        {
            ResponseModel<List<LivroModel>> response = new ResponseModel<List<LivroModel>>();

            try
            {
                var livro = await _context.Livros
                .Include(autor => autor.Autor)
                .FirstOrDefaultAsync(linhaBanco => linhaBanco.Id == idLivro);

                if (livro == null)
                {
                    response.Mensagem = "Livro nao encontrado";
                    response.Status = true;
                    return response;
                }

                _context.Livros.Remove(livro);
                await _context.SaveChangesAsync();

                response.Dados = await _context.Livros.ToListAsync();
                response.Mensagem = "Livro deletado com sucesso";
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

        public async Task<ResponseModel<List<LivroModel>>> InserirLivro(LivroInsercaoDto livroInsercaoDto)
        {
            ResponseModel<List<LivroModel>> response = new ResponseModel<List<LivroModel>>();

            try
            {
                var autor = await _context.Autores.FirstOrDefaultAsync(linhaBanco => linhaBanco.Id == livroInsercaoDto.Autor.Id);
                if (autor == null)
                {
                    response.Mensagem = "Autor nao encontrado";
                    response.Status = false;
                    return response;
                }

                var livro = new LivroModel()
                {
                    Titulo = livroInsercaoDto.Titulo,
                    Autor = autor
                };

                _context.Livros.Add(livro);
                await _context.SaveChangesAsync();

                response.Dados = await _context.Livros
                .Include(autor => autor.Autor)
                .ToListAsync();
                response.Mensagem = "Livro inserido com sucesso";
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

        public async Task<ResponseModel<List<LivroModel>>> ListarLivros()
        {
            ResponseModel<List<LivroModel>> response = new ResponseModel<List<LivroModel>>();

            try
            {
                var Livros = await _context.Livros
                .Include(autor => autor.Autor)
                .ToListAsync();

                response.Dados = Livros;
                response.Mensagem = "Livros encontrados com sucesso";
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