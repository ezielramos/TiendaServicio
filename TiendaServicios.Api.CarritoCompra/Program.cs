using MediatR;
using Microsoft.EntityFrameworkCore;
using TiendaServicios.Api.CarritoCompra.Aplicacion;
using TiendaServicios.Api.CarritoCompra.Persistencia;
using TiendaServicios.Api.CarritoCompra.RemoteInterface;
using TiendaServicios.Api.CarritoCompra.RemoteService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<ILibrosService, LibrosService>();
builder.Services.AddControllers();
builder.Services.AddDbContext<CarritoContexto>(options =>
{
	options.UseMySQL(builder.Configuration.GetConnectionString("ConexionDatabase"));
});
builder.Services.AddMediatR(typeof(Nuevo.Manejador).Assembly);
builder.Services.AddHttpClient("Libros", config =>
{
	config.BaseAddress = new Uri(builder.Configuration["Services:Libros"]);
});

//builder.Services.AddAutoMapper(typeof(Consulta.Ejecuta));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
