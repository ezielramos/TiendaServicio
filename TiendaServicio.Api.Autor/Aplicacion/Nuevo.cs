using FluentValidation;
using MediatR;
using TiendaServicio.Api.Autor.Modelo;
using TiendaServicio.Api.Autor.Persistencia;

namespace TiendaServicio.Api.Autor.Aplicacion;

public class Nuevo
{
	public class Ejecuta : IRequest
	{//se comunica con el controller y recive los parametros
		public string Nombre { get; set; }
		public string Apellido { get; set; }
        public DateTime? FechaNacimiento { get; set; }
    }

	public class EjecutaValidacion: AbstractValidator<Ejecuta>
	{
        public EjecutaValidacion()
        {
            RuleFor(x => x.Nombre).NotEmpty();
			RuleFor(x => x.Apellido).NotEmpty();
        }
    }

	public class Manejador : IRequestHandler<Ejecuta>
	{
		public readonly ContextoAutor _contexto;

        public Manejador(ContextoAutor contexto)
        {
            _contexto = contexto;
        }

        public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
		{
			var autorLibro = new AutorLibro
			{
				Nombre = request.Nombre,
				Apellido = request.Apellido,
				FechaNacimiento = request.FechaNacimiento,
				AutorLibroGuid = Guid.NewGuid().ToString(),
			};

			_contexto.AutorLibro.Add(autorLibro);
			var valor = await _contexto.SaveChangesAsync();//realiza la transaccion e indica el numero de transacciones

			if (valor > 0)
			{
				return Unit.Value;
			}

			throw new Exception("No se pudo insertar el autor del libro");
		}
	}
}
