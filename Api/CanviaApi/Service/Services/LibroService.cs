using Domain.Models;
using Repository.Interfaces;
using Service.Interfaces;
using Service.Models;
using System.Collections.Generic;
using System.Linq;

namespace Service.Services
{
    public class LibroService: ILibroService
    {

        private readonly ILibroRepository _libroRepository;

        public LibroService(ILibroRepository libroRepository)
        {
            _libroRepository = libroRepository;
        }

        public void ActualizarLibro(Libro libro)
        {
            _libroRepository.Actualizar(libro);
        }

        public Libro BuscarLibro(int id)
        {
            return _libroRepository.Buscar(id);
        }

        public void CrearLibro(Libro libro)
        {
            _libroRepository.Crear(libro);
        }

        public void EliminarLibro(int id)
        {
            _libroRepository.Eliminar(id);
        }

        public List<Libro> ListarLibros(PaginacionParametros paginacion)
        {
            if (paginacion.PageNumber == 0 || paginacion.PageSize == 0)
                return _libroRepository.Listar();
            return _libroRepository.Listar().Skip((paginacion.PageNumber-1) * paginacion.PageSize).Take(paginacion.PageSize).ToList();
        }

        public List<Libro> ListarPorCategoria(int idCategoria)
        {
            return _libroRepository.ListarPorCategoria(idCategoria);
        }
    }
}
