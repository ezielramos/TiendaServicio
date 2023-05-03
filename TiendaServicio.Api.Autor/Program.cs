using MediatR;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TiendaServicio.Api.Autor.Aplicacion;
using TiendaServicio.Api.Autor.Persistencia;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers().AddFluentValidation(cfg => cfg.RegisterValidatorsFromAssemblyContaining<Nuevo>());

builder.Services.AddDbContext<ContextoAutor>(options =>
{
	options.UseNpgsql(builder.Configuration.GetConnectionString("ConexionDatabase"));
});

builder.Services.AddMediatR(typeof(Nuevo.Manejador).Assembly);
builder.Services.AddAutoMapper(typeof(Consulta.Manejador));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();





////Apply migrations at runtime
//using (var scope = app.Services.CreateScope())
//{
//	var db = scope.ServiceProvider.GetRequiredService<ContextoAutor>();
//	db.Database.Migrate();
//}

////CHECK DATABASE CONECTION:
//app.MapGet("/dbconexion", async ([FromServices] ContextoAutor dbContext)  => 
//{
//	dbContext.Database.EnsureCreated();//si la base de datos no esta creada la crea
//	var sql = dbContext.Database.GenerateCreateScript();
//	return Results.Ok(sql);
//});





// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
