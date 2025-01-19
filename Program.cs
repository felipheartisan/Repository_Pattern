using backend.Src.Data;
using Domain.Services.Autor;
using Domain.Services.Livro;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
// Adicione controladores e Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Os métodos da interface estão sendo implementados pelo services
builder.Services.AddScoped<IAutorInterface, AutorServices>();
builder.Services.AddScoped<ILivroInterface, LivroServices>();

// Adicione o DbContext ao contêiner de serviços
string? connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Substitua 'DbContext' pelo nome real do seu contexto, por exemplo, 'AppDbContext'
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(connectionString);
}
);


var app = builder.Build();

// Configure o Swagger (UI e JSON)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // Gera o arquivo JSON
    app.UseSwaggerUI(); // Configura a interface do Swagger UI
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();


