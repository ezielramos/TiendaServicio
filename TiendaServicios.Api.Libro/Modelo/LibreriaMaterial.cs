namespace TiendaServicios.Api.Libro.Modelo;

public class LibreriaMaterial
{
    //entity framework lo convierte en primary key
    public Guid? LibreriaMaterialId { get; set; }

    public string Titulo { get; set; }

    public DateTime? FechaPublicacion { get; set; }

    public Guid? AutorLibro { get; set; }

}
