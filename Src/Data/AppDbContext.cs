using Microsoft.EntityFrameworkCore;
using backend.Src.Models;

namespace backend.Src.Data
{

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        
        }

        public DbSet<LivroModel> Livros { get; set; }
        public DbSet<AutorModel> Autores { get; set; }
        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<CaixaModel> Caixa { get; set; }
        public DbSet<BeneficioModel> Beneficios { get; set; }
        public DbSet<BeneficiosFuncionariosModel> BeneficiosFuncionarios { get; set; }
        public DbSet<FuncionarioModel> Funcionarios { get; set; }
        public DbSet<AvaliacoesFuncionarioModel> AvaliacoesFuncionario { get; set; }

    }

}