using AutoMapper;
using TiendaServicio.Api.Autor.Modelo;

namespace TiendaServicio.Api.Autor.Aplicacion;

public class MappingProfile:Profile
{
    public MappingProfile()
    {
        CreateMap<AutorLibro, AutorDto>();
    }
}
