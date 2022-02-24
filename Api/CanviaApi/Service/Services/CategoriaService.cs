using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Service.Interfaces;
using Repository.Interfaces;
using Service.Models;

namespace Service.Services
{
    public class CategoriaService : ICategoriaService
    {

        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaService(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }
        
        public void ActualizarCategoria(Categoria categoria)
        {
            _categoriaRepository.Actualizar(categoria);
        }

        public Categoria BuscarCategoria(int id)
        {
            return _categoriaRepository.Buscar(id);
        }

        public void CrearCategoria(Categoria categoria)
        {
            _categoriaRepository.Crear(categoria);
        }

        public void EliminarCategoria(int id)
        {
            _categoriaRepository.Eliminar(id);
        }

        public List<Categoria> ListarCategorias(PaginacionParametros paginacion)
        {
            if (paginacion.PageNumber == 0 || paginacion.PageSize == 0)
                return _categoriaRepository.Listar();
            return _categoriaRepository.Listar().Skip((paginacion.PageNumber - 1) * paginacion.PageSize).Take(paginacion.PageSize).ToList();
        }
    }
}
