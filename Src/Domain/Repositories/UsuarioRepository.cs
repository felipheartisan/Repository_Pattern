using backend.Src.Data;
using backend.Src.Models;
using backend.Src.Domain.Repositories.Intefaces;
using Microsoft.EntityFrameworkCore;

namespace backend.Src.Domain.Repositories
{

    public class UsuarioRepository : IRepository<UsuarioModel>
    {
        private AppDbContext _context;
        public UsuarioRepository(AppDbContext context)
        {
            _context = context;

        }

        public async Task<UsuarioModel> BuscarPorId(int id)
        {
            return await _context.Usuarios.FindAsync(id);
        }

        public async Task<List<UsuarioModel>> BuscarTodos()
        {
            return await _context.Usuarios.ToListAsync();
        }


        public async Task<UsuarioModel> Atualizar(UsuarioModel usuarioATualizado, int id)
        {
            try
            {
                UsuarioModel usuarioEncontrado = await BuscarPorId(id);
                if (usuarioEncontrado == null)
                {
                    throw new Exception($"Usuário não foi encontrado para o ID: {id}");
                }
                usuarioEncontrado.Usuario = usuarioATualizado.Usuario;
                usuarioEncontrado.Token = usuarioATualizado.Token;

                _context.Usuarios.Update(usuarioEncontrado);
                await _context.SaveChangesAsync();

                return usuarioEncontrado;
            }
            catch (Exception ex)
            {

                if (ex.InnerException != null)
                {
                    throw new Exception(ex.InnerException.Message);
                }
                else
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public async Task<bool> Criar(UsuarioModel novoUsuario)
        {

            await _context.Usuarios.AddAsync(novoUsuario);
            await _context.SaveChangesAsync();
            return true;

        }

        public async Task<bool> Deletar(int id)
        {
            try
            {
                UsuarioModel usuarioEncontrado = await BuscarPorId(id);
                if (usuarioEncontrado == null)
                {
                    throw new Exception($"Usuário não foi encontrado para o ID: {id}");
                }

                _context.Usuarios.Remove(usuarioEncontrado);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {

                if (ex.InnerException != null)
                {
                    throw new Exception(ex.InnerException.Message);
                }
                else
                {
                    throw new Exception(ex.Message);
                }
            }
        }


    }
}