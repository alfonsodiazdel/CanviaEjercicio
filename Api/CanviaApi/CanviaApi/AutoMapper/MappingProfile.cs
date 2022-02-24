using AutoMapper;
using CanviaApi.Models;
using Domain.Models;

namespace CanviaApi.AutoMapper
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            CreateMap<NuevaCategoriaRequest, Categoria>();
            CreateMap<NuevoLibroRequest, Libro>();
            CreateMap<ActualizarLibroRequest, Libro>();
            CreateMap<ActualizarCategoriaRequest, Categoria>();
        }

    }
}
