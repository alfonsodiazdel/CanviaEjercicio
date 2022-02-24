using Domain.Models;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface ILibroService
    {
        
        List<Libro> ListarLibros(PaginacionParametros paginacion);
        Libro BuscarLibro(int id);
        void CrearLibro(Libro libro);
        void ActualizarLibro(Libro libro);
        void EliminarLibro(int id);
        public List<Libro> ListarPorCategoria(int idCategoria);
    }
}
