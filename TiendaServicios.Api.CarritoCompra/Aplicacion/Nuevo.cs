using MediatR;
using TiendaServicios.Api.CarritoCompra.Modelo;
using TiendaServicios.Api.CarritoCompra.Persistencia;

namespace TiendaServicios.Api.CarritoCompra.Aplicacion;

public class Nuevo
{
	public class Ejecuta : IRequest 
	{
        public DateTime FechaCreacionSesion { get; set; }
        public List<string> ProductoLista { get; set; }
    }

	public class Manejador : IRequestHandler<Ejecuta>
	{
		private readonly CarritoContexto _context;
        public Manejador(CarritoContexto contexto)
        {
			_context = contexto;	
        }
        public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
		{
			var carritoSesion = new CarritoSesion
			{
				FechaCreacion = request.FechaCreacionSesion
			};

			_context.CarritoSesion.Add(carritoSesion);

			var value = await _context.SaveChangesAsync();

			if (value == 0)
			{
				throw new Exception("Errores en la insercion del carrito de compras");
			}

			int id = carritoSesion.CarritoSesionId;

            foreach (var obj in request.ProductoLista)
            {
				var detalleSesion = new CarritoSesionDetalle
				{
					FechaCreacion = DateTime.Now,
					CarritoSesionId = id,
					ProductoSeleccionado = obj
				};
				_context.CarritoSesionDetalle.Add(detalleSesion);
            }

			value = await _context.SaveChangesAsync();
			if (value > 0) 
			{
				return Unit.Value;
			}

			throw new Exception("No se pudo insertar el detalle del carrito de compras");

        }
	}


}
