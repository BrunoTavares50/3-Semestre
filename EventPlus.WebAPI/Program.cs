using EventPlus.WebAPI.BdContextEvent;
using EventPlus.WebAPI.Controllers;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Configuração do EFCore - Banco de dados
builder.Services.AddDbContext<EventContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//Injeção de de dependência
//AddScoped significa que uma instância nova é criada por requisição http
//Isso garante que cada requisição tenha seu próprio contexto isolado
builder.Services.AddScoped<ITipoUsuario, TipoUsuarioRepository>();

builder.Services.AddScoped<ITipoEvento, TipoEventoRepository>();

builder.Services.AddScoped<IUsuario, UsuarioRepository>();

//Registra o serviço de controllers(mapeia automaticamente os controllers da pasta /Controllers)
builder.Services.AddControllers();

var app = builder.Build();

//Mapeia as rotas definidas nos Controllers com os atributos [Route]: api/[controller]
app.MapControllers();

app.Run();
