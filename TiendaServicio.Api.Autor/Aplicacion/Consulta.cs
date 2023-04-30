using MediatR;
using Microsoft.EntityFrameworkCore;
using TiendaServicio.Api.Autor.Modelo;
using TiendaServicio.Api.Autor.Persistencia;

namespace TiendaServicio.Api.Autor.Aplicacion;

public class Consulta
{
	public class ListaAutor : IRequest<List<AutorLibro>> { }

	public class Manejador : IRequestHandler<ListaAutor, List<AutorLibro>>
	{
		private readonly ContextoAutor _contexto;
		public Manejador(ContextoAutor contexto)
		{
			_contexto = contexto;
		}
		public async Task<List<AutorLibro>> Handle(ListaAutor request, CancellationToken cancellationToken)
		{
			var autores = await _contexto.AutorLibro.ToListAsync();

			return autores;
		}
	}
}
