using Microsoft.EntityFrameworkCore;
using WebAPICompetitionService.Infra.Data.Context;
using WebAPICompetitionService.Infra.Data.Repository;
using WebAPICompetitionService.Infra.Data.Repository.Interfaces;
using WebAPICompetitionService.Infra.Data.UnitOfWork;
using WebAPICompetitionService.Infra.Tools;
using WebAPICompetitionService.Service.Interfaces;
using WebAPICompetitionService.Service.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Configuration.AddJsonFile("appsettings.json");

builder.Services.AddDbContext<CompetitionContext>(options =>
{
    var configuration = builder.Configuration;
    options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddControllers()
               .AddJsonOptions(options =>
               {
                   options.JsonSerializerOptions.Converters.Add(new DateOnlyJsonConverter());
               });

builder.Services.AddRouting(options => options.LowercaseUrls = true);

builder.Services.AddScoped<ICompeticoesRepository, CompeticoesRepository>();
builder.Services.AddScoped<IEquipesRepository, EquipesRepository>();
builder.Services.AddScoped<IEquipesUsuariosRepository, EquipesUsuariosRepository>();
builder.Services.AddScoped<IInscricoesRepository, InscricoesRepository>();
builder.Services.AddScoped<ICompeticoesService, CompeticoesService>();
builder.Services.AddScoped<IEquipesService, EquipesService>();
builder.Services.AddScoped<IEquipesUsuariosService, EquipesUsuariosService>();
builder.Services.AddScoped<IInscricoesService, InscricoesService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
