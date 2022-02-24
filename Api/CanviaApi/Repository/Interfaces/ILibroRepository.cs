using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface ILibroRepository
    {
        List<Libro> Listar();
        Libro Buscar(int id);
        void Crear(Libro libro);
        void Actualizar(Libro libro);
        void Eliminar(int id);
        public List<Libro> ListarPorCategoria(int idCategoria);
    }
}
