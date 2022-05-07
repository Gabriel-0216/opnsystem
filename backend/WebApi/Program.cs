using System.Reflection;
using Application.Commands.Handlers;
using Dominio.DAL.Contexto;
using Dominio.DAL.Repositorios.DepartamentoRepositorio;
using Dominio.DAL.Repositorios.SugestoesRepositorio;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddScoped<ISugestaoRepositorio, SugestaoRepositorio>();
builder.Services.AddScoped<IDepartamentoRepositorio, DepartamentoRepositorio>();
builder.Services.AddControllers();
builder.Services.AddCors();
builder.Services.AddMediatR(typeof(CriarDepartamentoHandler).GetTypeInfo().Assembly);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Add services to the container.
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseCors(cors => { cors.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin(); });


app.Run();




