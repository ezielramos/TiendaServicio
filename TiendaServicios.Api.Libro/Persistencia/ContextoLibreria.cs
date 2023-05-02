using Microsoft.EntityFrameworkCore;
using TiendaServicios.Api.Libro.Modelo;

namespace TiendaServicios.Api.Libro.Persistencia;

public class ContextoLibreria : DbContext
{
	public ContextoLibreria()
	{

	}

	//base: para setear la cadena de conexion
	public ContextoLibreria(DbContextOptions<ContextoLibreria> options) : base(options) { }
	public virtual DbSet<LibreriaMaterial> LibreriaMaterial { get; set; }
}
