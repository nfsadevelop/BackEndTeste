using ApiTeste.Data;
using ApiTeste.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<Context>(opt => opt.UseSqlServer($@"Server=(localdb)\MSSQLLocalDB;Integrated Security=true; AttachDbFileName={Environment.CurrentDirectory}\Database.mdf;"));

builder.Services.AddScoped<Context, Context>();
builder.Services.AddScoped<UsuarioService, UsuarioService>();
builder.Services.AddScoped<SexoService, SexoService>();
builder.Services.AddScoped<TipoPessoaService, TipoPessoaService>();

builder.Services.AddCors();

builder.Services.AddControllers();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true)
                .AllowCredentials());

app.MapControllers();

app.MapGet("/", () => "Api OK");


app.Run();
